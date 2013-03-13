using System;
using System.Collections.Generic;
using Microsoft.Kinect;
using TestKinect;
using FileRouge.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FileRouge.Scenes.Core
{
    /// <summary>
    /// Classe de base pour les sc�nes contenant un menu d'options.
    /// </summary>
    abstract public class AbstractMenuScene : AbstractGameScene
    {
        #region Fields

        public KinectInput ki;
        private double position;
        private Boolean scores;

        private readonly List<MenuItem> _menuItems = new List<MenuItem>();
        private int _selecteditem;
        private readonly string _menuTitle;

        #endregion

        #region Properties

        /// <summary>
        /// R�cup�re la liste des objets de menu, ainsi les classes d�riv�es
        /// peuvent en ajouter ou les modifier.
        /// </summary>
        protected IList<MenuItem> MenuItems
        {
            get { return _menuItems; }
        }

        #endregion

        #region Initialization

        protected AbstractMenuScene(SceneManager sceneMgr, string menuTitle)
            : base(sceneMgr)
        {
            _menuTitle = menuTitle;

            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            // Prise en charge de Kinect
            ki = new KinectInput();
            ki.playerMove += move;
            ki.playerFire += handSelect;
            scores = false;
        }

        public void handSelect()
        {
            if (this.IsActive)
            {
                OnSelectitem(_selecteditem);
                if (_selecteditem == 1)
                    scores = true;
            }
        }

        public void move()
        {
            if (this.IsActive && !scores)
            {
                position = ki.oldPointLeftHand.Y;

                if (position > 0.2)
                    _selecteditem = 0;

                else if (position < -0.2)
                    _selecteditem = 2;

                else
                {
                    _selecteditem = 1;
                }
            }
        }

        #endregion

        #region Handle Input

        public override void HandleInput()
        {
            if (InputState.IsMenuUp())
            {
                _selecteditem--;
                if (_selecteditem < 0)
                    _selecteditem = _menuItems.Count - 1;
            }

            if (InputState.IsMenuDown())
            {
                _selecteditem++;
                if (_selecteditem >= _menuItems.Count)
                    _selecteditem = 0;
            }

            if (InputState.IsMenuSelect())
                OnSelectitem(_selecteditem);
            else if (InputState.IsMenuCancel())
                OnCancel();
        }

        /// <summary>
        /// Selection d'un objet du menu.
        /// </summary>
        private void OnSelectitem(int itemIndex)
        {
            _menuItems[itemIndex].OnSelectitem();
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

        private void UpdateMenuItemLocations()
        {
            var transitionOffset = (float)Math.Pow(TransitionPosition, 2);
            var position = new Vector2(0f, 175f);

            foreach (MenuItem menuItem in _menuItems)
            {
                position.X = SceneManager.GraphicsDevice.Viewport.Width / 2 - menuItem.GetWidth(this) / 2;

                if (SceneState == SceneState.TransitionOn)
                    position.X -= transitionOffset * 256;
                else
                    position.X += transitionOffset * 512;

                menuItem.Position = position;
                position.Y += MenuItem.GetHeight(this);
            }
        }

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
            UpdateMenuItemLocations();

            GraphicsDevice graphics = SceneManager.GraphicsDevice;
            SpriteBatch spriteBatch = SceneManager.SpriteBatch;
            SpriteFont font = SceneManager.Font;

            spriteBatch.Begin();
            for (int i = 0; i < _menuItems.Count; i++)
            {
                MenuItem menuItem = _menuItems[i];
                bool isSelected = IsActive && (i == _selecteditem);
                menuItem.Draw(this, isSelected, gameTime);
            }
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
