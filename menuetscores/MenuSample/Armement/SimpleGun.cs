using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using FileRouge.Scenes.Core;
using Microsoft.Xna.Framework.Content;
using FileRouge.GameElements;
using FileRouge.GameElements.Core;
using FileRouge.GameElements.Ennemy;
using Microsoft.Xna.Framework.Audio;

namespace FileRouge.Armement
{
    class SimpleGun : Arme
    {
        public TimeSpan lastShotRaf { get; set; }
        public int shotRestRaf { get; set; }

        protected SoundEffect fireSound;      

        public SimpleGun(Vector2 size_window, RTGame rtgame, Boolean ennemyermainplayer) : base(size_window, rtgame, ennemyermainplayer)
        {
            NomArme = "Simple Gun";
            color = Color.Red;
            fireSound = rtgame.content.Load<SoundEffect>("Sounds/laser");
            
        }

        public override void ArmeCarct()
        {
            if (LevelArme == 1)
            {
                CadTir = 500;
                DegArme = 1;

            }
            else if (LevelArme == 2)
            {
                CadTir = 400;
                DegArme = 2;

            }
            else if (LevelArme == 3)
            {
                CadTir = 300;
                DegArme = 4;

            }
            else if (LevelArme != 1 && LevelArme != 2 && LevelArme != 3)
            {
                CadTir = 200;
                DegArme = 4;
            }   
        }

        public override void fire(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (((TimeSpan)(gameTime.TotalGameTime - lastShot)).TotalMilliseconds > CadTir)
            {
                if (EnnemyOrMainPlayer)
                {
                    shotRestRaf = 3;
                    lastShot = gameTime.TotalGameTime;
                }
                else
                {
                    SimpleMissile missile = new SimpleMissile(size_window);
                    missile.position = position;
                    missile.VitMissile = 3;
                    missile.LoadContent(rtgame.content);
                    missiles.Add(missile);
                    lastShot = gameTime.TotalGameTime;
                }
            }
        }

        public override void Update(GameTime gameTime, int displacementX)
        {
            if (EnnemyOrMainPlayer)
            {
                if (shotRestRaf > 0 && ((TimeSpan)(gameTime.TotalGameTime - lastShotRaf)).TotalMilliseconds > 200)
                {
                    SimpleMissile missile = new SimpleMissile(size_window);
                    missile.position = position;
                    missile.VitMissile = 3;
                    missile.LoadContent(rtgame.content);
                    missiles.Add(missile);
                    lastShotRaf = gameTime.TotalGameTime;
                    shotRestRaf--;
                    fireSound.Play();
                }
            }

            List<Missile> destroy_missile = new List<Missile>();
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
            }

        }
            

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (SimpleMissile m in missiles)
            {
                if (EnnemyOrMainPlayer)
                    m.Draw(spriteBatch, gameTime, color, 0f);
                else
                    m.Draw(spriteBatch, gameTime, color, (float)(Math.PI));
            }           
        }
    }
    
}
