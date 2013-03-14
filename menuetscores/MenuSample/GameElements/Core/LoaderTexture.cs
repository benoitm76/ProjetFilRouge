using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace FileRouge.GameElements.Core
{
    //Permet de changer qu'une seule fois chaque texture
    class LoaderTexture
    {
        //Dictionnaire contenant les différentes textures précédement changé
        private static Dictionary<String, Texture2D> listTextures;

        private static Dictionary<String, Color[]> listColors;


        public static Texture2D loadTexture(ContentManager content, String assetName)
        {
            //Lors du première appel on initialise la liste
            if (listTextures == null)
            {
                listTextures = new Dictionary<string,Texture2D>();
                listColors = new Dictionary<string, Color[]>();
            }
            try
            {
                //Si la texture existe on la retourne
                return listTextures[assetName];
            }
            catch (KeyNotFoundException)
            {
                //Sinon on la charge en mémoire
                listTextures.Add(assetName, content.Load<Texture2D>(assetName));
                Color[] color = new Color[listTextures[assetName].Width * listTextures[assetName].Height];
                listTextures[assetName].GetData(color);
                listColors.Add(assetName, color);
                return listTextures[assetName];
            }
        }

        public static Color[] loadColor(String assetName)
        {
            return listColors[assetName];
        }
    }
}
