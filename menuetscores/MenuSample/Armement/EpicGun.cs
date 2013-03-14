using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FileRouge.GameElements;
using System.Threading.Tasks;
using FileRouge.GameElements.Core;
using Microsoft.Xna.Framework.Graphics;

namespace FileRouge.Armement
{
    class EpicGun : Arme
    {
        public EpicGun(Vector2 size_window, RTGame rtgame, Boolean ennemyermainplayer) : base(size_window, rtgame, ennemyermainplayer)
        {
            NomArme = "Simple Gun";
            color = Color.White;
        }

        public override void ArmeCarct()
        {
            if (LevelArme == 1)
            {
                CadTir = 10000;
                DegArme = 1;
            }
            else if (LevelArme == 2)
            {
                CadTir = 5000;
                DegArme = 1;
            }
            else if (LevelArme == 3)
            {
                CadTir = 3000;
                DegArme = 1;
            }
            else
            {
                CadTir = 2000;
                DegArme = 1;
            }
        }

        public override void fire(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (((TimeSpan)(gameTime.TotalGameTime - lastShot)).TotalMilliseconds > CadTir && missiles.Count == 0)
            {
                EpicMissile missile = new EpicMissile(size_window);
                missile.position = position;
                missile.VitMissile = 2;
                missile.LoadContent(rtgame.content);
                missiles.Add(missile);
                lastShot = gameTime.TotalGameTime;
            }            
        }

        public override void Update(GameTime gameTime, int displacementX)
        {
            List<Ennemies> destroy_ennemies = new List<Ennemies>();
            if (missiles.Count > 0)
            {
                missiles[0].Update(gameTime, displacementX);
                if (missiles[0].position.X > size_window.X - 200)
                {
                    rtgame.ennemies = new List<Ennemies>();
                    missiles.RemoveAt(0);
                }
            }
            /*List<Missile> destroy_missile = new List<Missile>();
            List<Ennemies> destroy_ennemies = new List<Ennemies>();

            //Pour chaque missile
            Parallel.ForEach(missiles, missile =>
            {
                //On met a jour sa position
                if (EnnemyOrMainPlayer)
                    missile.Update(gameTime, displacementX);
                else
                    missile.Update(gameTime, -displacementX);             

                //On vérifie qu'il sort pas de l'écran
                if (missile.position.X >= size_window.X - missile.texture.Width && missile.position.X <= 0 - missile.texture.Width)
                {
                    destroy_missile.Add(missile);
                }

                if (EnnemyOrMainPlayer)
                {
                    //On vérifie si il percute un énnemie
                    Parallel.ForEach(rtgame.ennemies, ennemie =>
                    {
                        if (Collision.CheckCollision(missile.getRectangle(), missile.getColor(), ennemie.getRectangle(), ennemie.getColor()))
                        {
                            destroy_missile.Add(missile);
                            destroy_ennemies.Add(ennemie);
                        }
                    });
                }
                else
                {
                    if (Collision.CheckCollision(missile.getRectangle(), missile.getColor(), rtgame.mp.getRectangle(), rtgame.mp.getColor()))
                    {
                        destroy_missile.Add(missile);
                        rtgame.mp.touched();
                    }
                }
            });            
            foreach (Missile m in destroy_missile)
                missiles.Remove(m);
            foreach (Ennemies e in destroy_ennemies)
            {
                rtgame.ennemies.Remove(e);
                if(e.arme != null)
                    rtgame.missileRestant.Add(e.arme);
            }*/

        }
            

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (EpicMissile m in missiles)       
               m.Draw(spriteBatch, gameTime);        
        }
    }
}
