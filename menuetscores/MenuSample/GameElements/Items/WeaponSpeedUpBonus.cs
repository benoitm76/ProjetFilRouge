using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FileRouge.Armement;

namespace FileRouge.GameElements.Items
{
    class WeaponSpeedUpBonus : Bonus
    {
        public WeaponSpeedUpBonus(Vector2 size_window, RTGame rtGame)
            : base(size_window, rtGame)
        {
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.LoadContent(content, "bonus-weapon-speedup");
        }

        public override void applyBonus(GameTime gameTime)
        {
            rtgame.mp.arme.LevelArme += 1;
            rtgame.mp.arme.ArmeCarct();
        }

        public override void disableBonus()
        {
        }
    }
}
