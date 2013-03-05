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
        public FollowingEnnemies(Vector2 size_window, RTGame rtgame)
            : base(size_window, rtgame)
        {
        }

        public override void fire()
        {
            throw new NotImplementedException();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, int displacementX)
        {
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
            base.LoadContent(content, "mine");
        }
    }
}
