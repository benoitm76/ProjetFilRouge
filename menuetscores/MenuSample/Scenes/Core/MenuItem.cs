using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FileRouge.Scenes.Core
{
    /// <summary>
    /// Un �l�ment de menu
    /// </summary>
    public class MenuItem
    {
        #region Fields

        private const float Scale = 0.8f;
        private string _text;
        private float _selectionFade;
        private Vector2 _position;

        #endregion

        #region Properties

        public string Text
        {
            set { _text = value; }
        }

        public Vector2 Position
        {
            set { _position = value; }
        }

        #endregion

        #region Events

        public event EventHandler Selected;

        internal void OnSelectitem()
        {
            if (Selected != null)
                Selected(this, new EventArgs());
        }

        #endregion

        #region Initialization

        public MenuItem(string text)
        {
            _text = text;
        }

        #endregion

        #region Update and Draw

        public void Update(bool isSelected, GameTime gameTime)
        {
            float fadeSpeed = (float)gameTime.ElapsedGameTime.TotalSeconds * 4;

            _selectionFade = isSelected 
                ? Math.Min(_selectionFade + fadeSpeed, 1) 
                : Math.Max(_selectionFade - fadeSpeed, 0);
        }

        public void Draw(AbstractMenuScene scene, bool isSelected, GameTime gameTime)
        {
            Color color = isSelected ? Color.Black : Color.White;
            double time = gameTime.TotalGameTime.TotalSeconds;
            float pulsate = (float)Math.Sin(time * 6) + Scale;
            float scale = Scale + pulsate * 0.05f * _selectionFade;
            color *= scene.TransitionAlpha;
            SceneManager sceneManager = scene.SceneManager;
            SpriteBatch spriteBatch = sceneManager.SpriteBatch;
            SpriteFont font = sceneManager.Font;
            var origin = new Vector2(0, font.LineSpacing / 2f);
            spriteBatch.DrawString(font, _text, _position, color, 0,
                                   origin, scale, SpriteEffects.None, 0);
        }

        public static int GetHeight(AbstractMenuScene scene)
        {
            return (int)(scene.SceneManager.Font.LineSpacing * Scale);
        }

        public int GetWidth(AbstractMenuScene scene)
        {
            return (int)(scene.SceneManager.Font.MeasureString(_text).X * Scale);
        }

        #endregion
    }
}
