﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileRouge.GameElements.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace FileRouge.GameElements
{
    abstract class Ennemies : ChangingSprite
    {
        protected RTGame rtgame;

        public Ennemies(Vector2 size_window, RTGame rtgame)
            : base(size_window)
        {
            this.rtgame = rtgame;
        }

        public abstract void fire();

        public abstract void LoadContent(ContentManager content);

        public virtual void Update(GameTime gameTime, int displacementX)
        {
            Vector2 newPos = new Vector2(position.X - displacementX, position.Y);
            position = newPos;
        }
    }
}
