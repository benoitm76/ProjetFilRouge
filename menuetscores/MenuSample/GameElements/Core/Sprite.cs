using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace FileRouge.GameElements.Core
{
    class Sprite
    {
        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }
        public Vector2 size_window { get; set; }
        public Vector2 size { get; set; }

        public Color[] color { get; set; }

        public Sprite(Vector2 size_window)
        {
            this.size_window = size_window;
        }

        public virtual void Initialize()
        {
        }

        public virtual void LoadContent(ContentManager content, string assetName)
        {
            texture = LoaderTexture.loadTexture(content, assetName);
            color = LoaderTexture.loadColor(assetName);
        }

        public virtual void Update(GameTime gameTime)
        {
        }
        
        public virtual void HandleInput(KeyboardState keyboardState, MouseState mouseState)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public virtual Rectangle getRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public virtual Color[] getColor()
        {
            return color;
        }
    }
}
