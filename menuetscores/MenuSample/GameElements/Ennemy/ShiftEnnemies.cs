using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace FileRouge.GameElements.Ennemy
{
    class ShiftEnnemies : Ennemies
    {
        public int startShift;
        public int endShift;
        public int heightShift;
        public int directionMove;

        public ShiftEnnemies(Vector2 size_window, RTGame rtgame)
            : base(size_window, rtgame)
        {
            startShift = (int)(size_window.X - size_window.X * 0.3f);
            endShift = (int)(size_window.X - size_window.X * 0.7f);
            heightShift = (int)(size_window.Y * 0.4f);
            size = new Vector2(100, 101);
            nbrSprite = 1;
        }

        public override void fire()
        {
            throw new NotImplementedException();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, int displacementX)
        {
            if (directionMove == 0)
            {
                if (heightShift + position.Y > size_window.Y)
                {
                    directionMove = -1;
                }
                else
                {
                    directionMove = 1;
                }
            }

            float newVerticalPos = 0;
            float newHorizontalPos = 0;
            newVerticalPos = position.Y;
            newHorizontalPos = position.X - displacementX;
            if (position.X < startShift && position.X > endShift)
            {
                float pourcShift = (float)displacementX / (startShift - endShift);
                newVerticalPos += pourcShift * heightShift * directionMove;
                newHorizontalPos = newHorizontalPos - 2;
            }

            Vector2 newPos = new Vector2(newHorizontalPos, newVerticalPos);
            position = newPos;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content, "cocote");
        }
    }
}
