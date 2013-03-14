using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using FileRouge.GameElements.Core;

namespace FileRouge.GameElements.Items
{
    abstract class Bonus : Sprite
    {
        protected RTGame rtgame;
        public int duration;

        public Bonus(Vector2 size_window, RTGame rtgame)
            : base(size_window)
        {
            this.rtgame = rtgame;
        }

        public abstract void applyBonus(GameTime gameTime);

        public abstract void disableBonus();

        public abstract void LoadContent(ContentManager content);

        public virtual void Update(GameTime gameTime, int displacementX)
        {
            Vector2 newPos = new Vector2(position.X - displacementX, position.Y);
            position = newPos;
        }
    }
}
