using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FileRouge.GameElements.Core
{
    //Permet de changer qu'une seule fois chaque texture
    class LoaderTexture
    {
        //Dictionnaire contenant les différentes textures précédement changé
        private static Dictionary<String, Texture2D> listTextures;

        public static Texture2D loadTexture(ContentManager content, String assetName)
        {
            //Lors du première appel on initialise la liste
            if (listTextures == null)
            {
                listTextures = new Dictionary<string,Texture2D>();
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
                return listTextures[assetName];
            }
        }
    }
}
