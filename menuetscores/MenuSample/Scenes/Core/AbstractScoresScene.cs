using System;
using System.Collections.Generic;
using Microsoft.Kinect;
using FileRouge.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FileRouge.Scenes.Core
{
    /// <summary>
    /// Classe de base pour les scènes contenant un menu d'options.
    /// </summary>
    abstract public class AbstractScoresScene : AbstractGameScene
    {
        public KinectInput ki;

        #region Fields

        private readonly List<MenuItem> _menuItems = new List<MenuItem>();
        private int _selecteditem;
        private readonly string _menuTitle;

        #endregion

        #region Properties

        /// <summary>
        /// Récupère la liste des objets de menu, ainsi les classes dérivées
        /// peuvent en ajouter ou les modifier.
        /// </summary>
        protected IList<MenuItem> MenuItems
        {
            get { return _menuItems; }
        }

        #endregion

        #region Initialization

        protected AbstractScoresScene(SceneManager sceneMgr, string menuTitle)
            : base(sceneMgr)
        {
            _menuTitle = menuTitle;

            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            // Prise en charge de Kinect
            ki = new KinectInput();
            ki.playerMove += move;
            ki.playerFire += handSelect;
        }

        public void handSelect()
        {
            if (this.IsActive)
            {
                OnCancel();
            }
        }

        public void move()
        {

        }

        #endregion

        #region Handle Input

        public override void HandleInput()
        {
            if (InputState.IsMenuCancel())
                OnCancel();
        }

        /// <summary>
        /// Annulation dans le menu.
        /// </summary>
        protected virtual void OnCancel()
        {
            Remove();
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            OnCancel();
        }

        #endregion

        #region Update and Draw

        public override void Update(GameTime gameTime, bool othersceneHasFocus, bool coveredByOtherscene)
        {
            base.Update(gameTime, othersceneHasFocus, coveredByOtherscene);

            for (int i = 0; i < _menuItems.Count; i++)
            {
                bool isSelected = IsActive && (i == _selecteditem);
                _menuItems[i].Update(isSelected, gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice graphics = SceneManager.GraphicsDevice;
            SpriteBatch spriteBatch = SceneManager.SpriteBatch;
            SpriteFont font = SceneManager.Font;

            spriteBatch.Begin();
            var transitionOffset = (float)Math.Pow(TransitionPosition, 2);
            var titlePosition = new Vector2(graphics.Viewport.Width / 2f, 80);
            Vector2 titleOrigin = font.MeasureString(_menuTitle) / 2;
            Color titleColor = new Color(192, 192, 192) * TransitionAlpha;
            titlePosition.Y -= transitionOffset * 100;
            spriteBatch.DrawString(font, _menuTitle, titlePosition, titleColor, 0,
                                   titleOrigin, 1, SpriteEffects.None, 0);
            spriteBatch.End();
        }

        #endregion
    }
}
