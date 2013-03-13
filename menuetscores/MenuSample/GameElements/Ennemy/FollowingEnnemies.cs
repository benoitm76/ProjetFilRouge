using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace FileRouge.GameElements.Ennemy
{
    class FollowingEnnemies : Ennemies
    {
        private int lastUpdate;

        public FollowingEnnemies(Vector2 size_window, RTGame rtgame)
            : base(size_window, rtgame)
        {
            size = new Vector2(128, 130);
            nbrSprite = 8;
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
                if (spriteShow == 8)
                {
                    spriteShow = 0;
                }
            }

            float newVerticalPos = 0;
            newVerticalPos = position.Y;

            if ((int)rtgame.mp.position.Y > (int)position.Y)
            {
                newVerticalPos = position.Y + 2f;
            }
            else if ((int)rtgame.mp.position.Y < (int)position.Y)
            {
                newVerticalPos = position.Y - 2f;
            }

            Vector2 newPos = new Vector2(position.X - displacementX, newVerticalPos);
            position = newPos;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content, "shuriken");
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            //base.Draw(spriteBatch, gameTime);
            spriteBatch.Draw(texture, position, new Rectangle((int)size.X * spriteShow, 0, (int)size.X, (int)size.Y), Color.White);
        }
    }
}
