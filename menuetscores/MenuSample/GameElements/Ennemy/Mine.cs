using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace FileRouge.GameElements.Ennemy
{
    class Mine : Ennemies
    {

        public Mine(Vector2 size_window, RTGame rtgame) : base(size_window, rtgame)
        {
        }

        public override void fire()
        {
            throw new NotImplementedException();
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content, "mine");
        }
    }
}
