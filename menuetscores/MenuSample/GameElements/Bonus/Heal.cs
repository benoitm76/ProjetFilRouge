﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FileRouge.GameElements.Bonu
{
    class Heal : Bonus
    {
        public Heal(Vector2 size_window, RTGame rtGame)
            : base(size_window, rtGame)
        {
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.LoadContent(content, "heal");
        }

        public override void applyBonus()
        {
            if(rtgame.mp.health < rtgame.mp.maxHealth)
                rtgame.mp.health++;
        }
    }
}
