using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using FileRouge.Armement;

namespace FileRouge.GameElements.Ennemy
{
    class MovingEnnemies : Ennemies
    {
        private int direction_move = 1;

        private int lastUpdate;

        public MovingEnnemies(Vector2 size_window, RTGame rtgame)
            : base(size_window, rtgame)
        {
            nbrSprite = 2;
            size = new Vector2(285, 256);
        }

        public override void fire(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, int displacementX)
        {
            lastUpdate++;
            if (lastUpdate % 15 == 0)
            {
                lastUpdate = 0;
                spriteShow++;
                if (spriteShow == nbrSprite)
                {
                    spriteShow = 0;
                }
            }

            float newVerticalPos = 0;
            newVerticalPos = position.Y;
            newVerticalPos += (float)Math.Sin(Math.Cos(position.X / 100)) * 5;

            if (newVerticalPos + texture.Height > size_window.Y)
            {
                newVerticalPos = (size_window.Y - texture.Height - newVerticalPos) + size_window.Y - texture.Height;
                direction_move = direction_move * -1;
            }
            if (newVerticalPos < 0)
            {
                newVerticalPos = newVerticalPos * -1;
                direction_move = direction_move * -1;
            }

            Vector2 newPos = new Vector2(position.X - displacementX, newVerticalPos);
            position = newPos;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content, "passon");
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            //base.Draw(spriteBatch, gameTime);
            spriteBatch.Draw(texture, position, new Rectangle((int)size.X * spriteShow, 0, (int)size.X, (int)size.Y), Color.White);
        }
    }
}
