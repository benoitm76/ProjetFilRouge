using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FileRouge.Armement;

namespace FileRouge.GameElements.Items
{
    class BoomGunBonus : Bonus
    {
        public BoomGunBonus(Vector2 size_window, RTGame rtGame)
            : base(size_window, rtGame)
        {
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.LoadContent(content, "weapon-boom");
        }

        public override void applyBonus(GameTime gameTime)
        {
            rtgame.mp.newArme(new EpicGun(size_window, rtgame, true), 256, 80);
        }

        public override void disableBonus()
        {
        }
    }
}
