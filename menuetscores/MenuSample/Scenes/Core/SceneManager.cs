using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FileRouge.Scenes.Core
{
    /// <summary>
    /// Le gestionnaire de sc�nes est un composant que g�re des instances de sc�nes. Il
    /// maintient une pile de sc�ne, appelle leur Update (le Draw est appel� automatiquement)
    /// et limite les entr�es utilisateurs � la premi�re sc�ne active de la pile.
    /// </summary>
    public class SceneManager : DrawableGameComponent
    {
        #region Fields

        private readonly List<AbstractGameScene> _scenes = new List<AbstractGameScene>();
        private readonly List<AbstractGameScene> _scenesToUpdate = new List<AbstractGameScene>();
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private Texture2D _blankTexture;

        #endregion

        #region Properties

        /// <summary>
        /// Un SpriteBatch partag� pour toutes les sc�nes.
        /// </summary>
        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; }
        }

        /// <summary>
        /// Une police partag�e pour toutes les sc�nes.
        /// </summary>
        public SpriteFont Font
        {
            get { return _font; }
        }

        #endregion

        #region Initialization

        public SceneManager(Game game)
            : base(game)
        {
        }

        protected override void LoadContent()
        {
            ContentManager content = Game.Content;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = content.Load<SpriteFont>("menufont");
            _blankTexture = content.Load<Texture2D>("blank");
        }

        #endregion

        #region Update and Draw

        public override void Update(GameTime gameTime)
        {
            // Fait un copie de la liste principale pour �viter la confusion des
            // processus mettant � jour une sc�ne ou en retirant une.
            _scenesToUpdate.Clear();

            foreach (AbstractGameScene scene in _scenes)
                _scenesToUpdate.Add(scene);

            bool othersceneHasFocus = !Game.IsActive;
            bool coveredByOtherscene = false;

            while (_scenesToUpdate.Count > 0)
            {
                AbstractGameScene scene = _scenesToUpdate[_scenesToUpdate.Count - 1];
                _scenesToUpdate.RemoveAt(_scenesToUpdate.Count - 1);
                scene.Update(gameTime, othersceneHasFocus, coveredByOtherscene);

                if (scene.SceneState == SceneState.TransitionOn ||
                    scene.SceneState == SceneState.Active)
                {
                    // Si c'est la premi�re sc�ne, lui donner l'acc�s aux entr�es utilisateur.
                    if (!othersceneHasFocus)
                    {
                        scene.HandleInput();
                        othersceneHasFocus = true;
                    }

                    // Si la sc�ne courant n'est pas un popup et est active,
                    // informez les sc�nes suivantes qu'elles sont recouverte.
                    if (!scene.IsPopup)
                        coveredByOtherscene = true;
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Ajoute une nouvelle sc�ne au gestionnaire. Normalement il faut appeler
        /// la m�thode Add de la sc�ne.
        /// </summary>
        public void AddScene(AbstractGameScene scene)
        {
            scene.IsExiting = false;
            Game.Components.Add(scene);
            _scenes.Add(scene);
        }

        /// <summary>
        /// Retire une sc�ne du gestionnaire de sc�nes. Normalement, il faut appeler
        /// la m�thode Remove de la sc�ne qui permet de cr�er la transition de la sc�ne
        /// avant son retrait du gestionnaire.
        /// </summary>
        public void RemoveScene(AbstractGameScene scene)
        {
            Game.Components.Remove(scene);
            _scenes.Remove(scene);
            _scenesToUpdate.Remove(scene);
        }

        /// <summary>
        /// M�thode aidant � cr�er le fade to black lors d'une popup
        /// </summary>
        public void FadeBackBufferToBlack(float alpha)
        {
            Viewport viewport = GraphicsDevice.Viewport;

            _spriteBatch.Begin();
            _spriteBatch.Draw(_blankTexture,
                             new Rectangle(0, 0, viewport.Width, viewport.Height),
                             Color.Black * alpha);
            _spriteBatch.End();
        }

        #endregion
    }
}
