using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FileRouge.GameElements.Bonu
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
            base.LoadContent(content, "heal");
        }

        public override void applyBonus()
        {
            rtgame.mp.coefDep = rtgame.mp.coefDep * 1.3f;
        }

        public override void disbaleBonus()
        {
            rtgame.mp.coefDep = rtgame.mp.coefDep / 1.3f;
        }
    }
}
