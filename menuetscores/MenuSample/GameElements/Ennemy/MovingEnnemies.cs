using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace FileRouge.GameElements.Ennemy
{
    class MovingEnnemies : Ennemies
    {
        private int direction_move = 1;

        public MovingEnnemies(Vector2 size_window, RTGame rtgame)
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
            base.LoadContent(content, "mine");
        }
    }
}
