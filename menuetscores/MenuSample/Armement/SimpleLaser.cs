using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FileRouge.GameElements;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;
using FileRouge.GameElements.Core;

namespace FileRouge.Armement
{
    class SimpleLaser : Arme
    {
        public int beamDuration { get; set; }

        public SimpleLaser(Vector2 size_window, RTGame rtgame, Boolean ennemyormainplayer)
            : base(size_window, rtgame, ennemyormainplayer)
        {
            NomArme = "Simple Laser";
        }

        public override void ArmeCarct()
        {
            if (LevelArme == 1)
            {
                CadTir = 1000;
                beamDuration = 200;
                DegArme = 1;

            }
            else if (LevelArme == 2)
            {
                CadTir = 800;
                beamDuration = 200;
                DegArme = 2;

            }
            else if (LevelArme == 3)
            {
                CadTir = 600;
                beamDuration = 200;
                DegArme = 4;

            }
            else 
            {
                CadTir = 500;
                beamDuration = 300;
                DegArme = 1;
            }   

        }

        public override void fire(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (missiles.Count == 0 && ((TimeSpan)(gameTime.TotalGameTime - lastShot)).TotalMilliseconds > CadTir)
            {
                SimpleBeam missile = new SimpleBeam(size_window);
                missile.position = position;
                missile.LoadContent(rtgame.content);
                missiles.Add(missile);
                lastShot = gameTime.TotalGameTime;
            }
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, int displacementX)
        {
            if (missiles.Count == 1)
            {
                if (((TimeSpan)(gameTime.TotalGameTime - lastShot)).TotalMilliseconds > beamDuration)
                {
                    missiles.RemoveAt(0);
                }
                else
                {
                    List<Ennemies> destroy_ennemies = new List<Ennemies>();
                    ((SimpleBeam)missiles[0]).Update(gameTime, rtgame.mp.arme.position);
                    Parallel.ForEach(rtgame.ennemies, ennemie =>
                    {
                        if (ennemie.getRectangle().Intersects(new Rectangle((int)position.X, (int)(position.Y - missiles[0].texture.Height / 2), (int)(size_window.X - position.X), missiles[0].texture.Height)))
                        {
                            destroy_ennemies.Add(ennemie);
                        }
                    });

                    foreach (Ennemies e in destroy_ennemies)
                        rtgame.ennemies.Remove(e);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (missiles.Count == 1)
            {
                missiles[0].Draw(spriteBatch, gameTime);
            }
        }
    }
}
