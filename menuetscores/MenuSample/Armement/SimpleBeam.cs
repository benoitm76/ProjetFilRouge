using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FileRouge.Armement
{
    class SimpleBeam : Missile
    {

        public SimpleBeam(Vector2 size_window)
            : base(size_window)
        {

        }

        public void LoadContent(ContentManager content)
        {
            base.LoadContent(content, "laser");
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, int displacementX)
        {
            
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime, Vector2 position)
        {
            this.position = position;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, null, new Color(15, 153, 254, 255),
                           0, Vector2.Zero, new Vector2(1000, 1),
                           SpriteEffects.None, 0);
        }
    }
}
