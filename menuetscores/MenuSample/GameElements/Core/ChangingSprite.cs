using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FileRouge.GameElements.Core
{
    //Classe pour les sprites qui changent de texture
    class ChangingSprite : Sprite
    {
        //Le sprite courant
        protected int spriteShow;
        //La représentation des couleurs de chaque sprite
        protected Color[][] colors;
        //Le nombre total de sprite
        protected int nbrSprite;

        public ChangingSprite(Vector2 size_window)
            : base(size_window)
        {
            nbrSprite = 1;
            size = new Vector2(123, 150);
        }

        public override void LoadContent(ContentManager content, string assetName)
        {
            base.LoadContent(content, assetName);

            //On charge le tableau de couleur de chaque sprite
            colors = new Color[nbrSprite][];
            for (int k = 0; k < nbrSprite; k++)
            {
                colors[k] = new Color[(int)size.X * (int)size.Y];
                int i = 0;
                for (int y = 0; y < size.Y; y++)
                {
                    for (int x = 0; x < size.X; x++)
                    {
                        colors[k][i] = color[(k * (int)size.X + x) + (y * (int)texture.Width)];
                        i++;
                    }
                }
            }
        }

        public override Rectangle getRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }

        public override Color[] getColor()
        {
            return colors[spriteShow];
        }
    }
}
