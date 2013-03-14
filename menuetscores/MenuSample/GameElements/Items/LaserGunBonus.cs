using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FileRouge.Armement;

namespace FileRouge.GameElements.Items
{
    class LaserGunBonus : Bonus
    {
        public LaserGunBonus(Vector2 size_window, RTGame rtGame)
            : base(size_window, rtGame)
        {
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.LoadContent(content, "weapon-beam");
        }

        public override void applyBonus(GameTime gameTime)
        {
            rtgame.mp.newArme(new SimpleLaser(size_window, rtgame, true), 256, 75);
        }

        public override void disableBonus()
        {
        }
    }
}
