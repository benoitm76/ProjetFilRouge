using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileRouge.GameElements.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
namespace FileRouge.Armement
{
    abstract class Missile : Sprite
    {
        public Missile(Vector2 size_window)
            : base(size_window)
        {
        }

        public abstract void Update(GameTime gameTime, int displacementX);
    }
}
