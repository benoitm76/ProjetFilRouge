using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FileRouge.GameElements.Items
{
    class SpeedUp : Bonus
    {
        public SpeedUp(Vector2 size_window, RTGame rtGame)
            : base(size_window, rtGame)
        {
            duration = 5000;
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.LoadContent(content, "bonus-speedup");
        }

        public override void applyBonus(GameTime gameTime)
        {
            rtgame.mp.coefDep = rtgame.mp.coefDep * 1.3f;
            rtgame.mp.listBonus.Add(new FileRouge.GameElements.MainPlayer.ApplyBonus(this, gameTime));
        }

        public override void disableBonus()
        {
            rtgame.mp.coefDep = rtgame.mp.coefDep / 1.3f;
        }
    }
}
