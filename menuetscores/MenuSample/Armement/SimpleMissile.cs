using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FileRouge.Armement
{
    class SimpleMissile : Missile
    {
        public int VitMissile {get; set;}

        public SimpleMissile(Vector2 size_window)
            : base(size_window)
        {

        }

        public void LoadContent(ContentManager content)
        {
            base.LoadContent(content, "baboule");
        }

        public override void Update(GameTime gameTime, int displacementX)
        {
            Vector2 newPos = new Vector2(position.X + displacementX * VitMissile, position.Y);
            position = newPos;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, Color.Red);       
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime, Color color, float angle)
        {
            //spriteBatch.Draw(texture, position, Color.Red);
            spriteBatch.Draw(texture, position, null, color, angle,
                new Vector2(texture.Width / 2, texture.Height / 2) , 1.0f, SpriteEffects.None, 0f);

        }
    }
}
