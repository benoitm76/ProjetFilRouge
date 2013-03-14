using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FileRouge.Armement;

namespace FileRouge.GameElements.Items
{
    class DoubleGunBonus : Bonus
    {
        public DoubleGunBonus(Vector2 size_window, RTGame rtGame)
            : base(size_window, rtGame)
        {
            duration = 5000;
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.LoadContent(content, "weapon-double");
        }

        public override void applyBonus(GameTime gameTime)
        {
            rtgame.mp.newArme(new DoubleGun(size_window, rtgame, true), 256, 85);
        }

        public override void disableBonus()
        {
        }
    }
}
