using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace FileRouge.Armement
{
    class EpicMissile : Missile
    {
        public int VitMissile {get; set;}

        public EpicMissile(Vector2 size_window)
            : base(size_window)
        {

        }

        public void LoadContent(ContentManager content)
        {
            base.LoadContent(content, "mine");
        }

        public override void Update(GameTime gameTime, int displacementX)
        {
            Vector2 newPos = new Vector2(position.X + displacementX * VitMissile, position.Y);
            position = newPos;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, Color.White);       
        }
    }
}
