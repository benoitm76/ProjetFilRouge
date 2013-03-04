using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections;

namespace FileRouge.Armement
{
    abstract class Arme
    {
        protected string NomArme;
        protected int CadTir;
        public const int LevelArme = 1;
        protected ArrayList Missile;
        protected int DegArme;
        public abstract void ArmeCarct;
    }
}
