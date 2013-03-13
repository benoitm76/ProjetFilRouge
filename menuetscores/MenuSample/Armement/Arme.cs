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
        protected Boolean EnnemyOrMainPlayer;
        public Color color { get; set; }

        public Arme(Vector2 size_window, RTGame rtgame, Boolean ennemyermainplayer)
            : base(size_window)
        {
            this.rtgame = rtgame;
            this.EnnemyOrMainPlayer = ennemyermainplayer;
            missiles = new List<Missile>();
            ArmeCarct();
        }

        public abstract void ArmeCarct();
        public abstract void fire(Microsoft.Xna.Framework.GameTime gameTime);
        public abstract void Update(GameTime gameTime, int displacementX);        
    }
}
