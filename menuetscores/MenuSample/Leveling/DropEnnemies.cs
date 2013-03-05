using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileRouge.GameElements;

namespace FileRouge.Leveling
{
    class DropEnnemies
    {
        public Ennemies ennemie { get; set; }
        public float distanceDrop { get; set; }
        public float verticalPosition { get; set; }

        public DropEnnemies(Ennemies ennemie, float distanceDrop, float verticalPosition)
        {
            this.ennemie = ennemie;
            this.distanceDrop = distanceDrop;
            this.verticalPosition = verticalPosition;
        }
    }
}
