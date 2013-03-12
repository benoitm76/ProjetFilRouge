using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using FileRouge.GameElements.Core;
using Microsoft.Xna.Framework.Graphics;
using FileRouge.GameElements;

namespace FileRouge.Armement
{
    abstract class Arme : Sprite
    {
        protected string NomArme;
        protected int CadTir;
        public int LevelArme = 1;
        protected List<Missile> missiles;
        protected int DegArme;
        protected TimeSpan lastShot;
        protected Boolean IsContinuedShot = false;
        protected RTGame rtgame;

        public Arme(Vector2 size_window, RTGame rtgame)
            : base(size_window)
        {
            this.rtgame = rtgame;
            missiles = new List<Missile>();
            ArmeCarct();
        }

        public abstract void ArmeCarct();
        public abstract void fire(Microsoft.Xna.Framework.GameTime gameTime);
        public abstract void Update(GameTime gameTime, int displacementX);        
    }
}
