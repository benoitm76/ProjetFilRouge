using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FileRouge.GameElements.Items
{
    class Bouclier : Bonus
    {
        public Bouclier(Vector2 size_window, RTGame rtGame)
            : base(size_window, rtGame)
        {
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.LoadContent(content, "bonus-boubou");
        }

        public override void applyBonus(GameTime gameTime)
        {
            if (rtgame.mp.shield < rtgame.mp.maxShield)
                rtgame.mp.shield++;
        }

        public override void disableBonus()
        {
        }
    }
}
