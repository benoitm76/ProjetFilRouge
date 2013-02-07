using System;
using Microsoft.Xna.Framework;

namespace FileRouge.Scenes.Core
{
    public enum SceneState
    {
        TransitionOn,
        Active,
        TransitionOff,
        Hidden,
    }

    public abstract class AbstractGameScene : DrawableGameComponent
    {
        #region Fields

        private bool _isPopup;
        private TimeSpan _transitionOnTime = TimeSpan.Zero;
        private TimeSpan _transitionOffTime = TimeSpan.Zero;
        private float _transitionPosition = 1;
        private SceneState _sceneState = SceneState.TransitionOn;
        private bool _othersceneHasFocus;
        private readonly SceneManager _sceneManager;
        private bool _isExiting;

        #endregion

        #region Properties

        public bool IsPopup
        {
            get { return _isPopup; }
            protected set { _isPopup = value; }
        }

        protected TimeSpan TransitionOnTime
        {
            set { _transitionOnTime = value; }
        }

        protected TimeSpan TransitionOffTime
        {
            set { _transitionOffTime = value; }
        }
        
        protected float TransitionPosition
        {
            get { return _transitionPosition; }
        }
        
        public float TransitionAlpha
        {
            get { return 1f - TransitionPosition; }
        }

        public SceneState SceneState
        {
            get { return _sceneState; }
        }
        
        public bool IsExiting
        {
            set { _isExiting = value; }
            protected get { return _isExiting; }
        }
       
        protected bool IsActive
        {
            get
            {
                return !_othersceneHasFocus &&
                       (_sceneState == SceneState.TransitionOn ||
                        _sceneState == SceneState.Active);
            }
        }
        
        public SceneManager SceneManager
        {
            get { return _sceneManager; }
        }
        
        #endregion

        #region Initialization

        protected AbstractGameScene(SceneManager sceneMgr)
            : base(sceneMgr.Game)
        {
            _sceneManager = sceneMgr;
        }

        #endregion

        #region Update and Draw

        public virtual void Update(GameTime gameTime, bool othersceneHasFocus, bool coveredByOtherscene)
        {
            _othersceneHasFocus = othersceneHasFocus;

            if (_isExiting)
            {
                // Si la sc�ne est sur le point d'�tre quitt�e, d�sactivation de la sc�ne
                _sceneState = SceneState.TransitionOff;

                // Quand la transition est finie, on retire la sc�ne
                if (!UpdateTransition(gameTime, _transitionOffTime, 1))
                    _sceneManager.RemoveScene(this);
            }
            else if (coveredByOtherscene)
            {
                // Si la sc�ne est recouverte, d�sactivation de la sc�ne
                _sceneState = UpdateTransition(gameTime, _transitionOffTime, 1)
                    // Transition en cours
                    ? SceneState.TransitionOff
                    // Transition termin�e
                    : SceneState.Hidden;
            }
            else
            {
                // Sinon activation de la sc�ne
                _sceneState = UpdateTransition(gameTime, _transitionOnTime, -1)
                    // Transition en cours
                    ? SceneState.TransitionOn
                    // Transition termin�e
                    : SceneState.Active;
            }
        }

        private bool UpdateTransition(GameTime gameTime, TimeSpan time, int direction)
        {
            float transitionDelta = time == TimeSpan.Zero
                                        ? 1
                                        : (float) (gameTime.ElapsedGameTime.TotalMilliseconds/
                                                   time.TotalMilliseconds);

            _transitionPosition += transitionDelta * direction;

            // Est-on arriv� � la fin de la transition?
            bool endTransition = ((direction < 0) && (_transitionPosition <= 0)) ||
                                 ((direction > 0) && (_transitionPosition >= 1));
            if (endTransition)
                _transitionPosition = MathHelper.Clamp(_transitionPosition, 0, 1);
            return !endTransition;
        }

        public virtual void HandleInput() { }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Indique � la sc�ne qu'elle doit dispara�tre, � l'instar de SceneManager.RemoveScene,
        /// qui quitte instantan�ment la sc�ne, cette m�thode respecte la dur�e de transition.
        /// </summary>
        public void Remove()
        {
            // Si la sc�ne a un temps de d�sactivation nul, retrait imm�diat
            // de la sc�ne, sinon, d�sactivation de la sc�ne
            if (_transitionOffTime == TimeSpan.Zero)
                _sceneManager.RemoveScene(this);
            else
                _isExiting = true;
        }

        public void Add()
        {
            _sceneManager.AddScene(this);
        }

        #endregion
    }
}
