using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileRouge.GameElements.Core;
using Microsoft.Xna.Framework;
namespace FileRouge.Armement
{
    abstract class Missile :  Sprite
    {
        protected Vector2 PosMissile;
        protected int VitMissile;

        public Missile(Vector2 size_window)
            : base(size_window)
        {
        }
    
    }
}
