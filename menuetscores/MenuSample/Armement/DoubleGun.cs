﻿using System;
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

namespace FileRouge.Armement
{
    class DoubleGun : SimpleGun
    {
        public DoubleGun(Vector2 size_window, RTGame rtgame, Boolean ennemyermainplayer)
            : base(size_window, rtgame, ennemyermainplayer)
        {
            NomArme = "Double Gun";
            color = Color.Yellow;
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
                CadTir = 500;
                DegArme = 1;
            }   
        }

        public override void fire(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (((TimeSpan)(gameTime.TotalGameTime - lastShot)).TotalMilliseconds > CadTir)
            {
                SimpleMissile missile = new SimpleMissile(size_window);
                SimpleMissile missile2 = new SimpleMissile(size_window);
                Vector2 p = new Vector2(position.X, position.Y - 20);
                missile.position = p;
                missile.VitMissile = 3;
                missile.LoadContent(rtgame.content);
                missiles.Add(missile);
                Vector2 p2 = new Vector2(position.X, position.Y + 20);
                missile2.position = p2;
                missile2.VitMissile = 3;
                missile2.LoadContent(rtgame.content);
                missiles.Add(missile2);
                lastShot = gameTime.TotalGameTime;
            }            
        }

        /*public override void Update(GameTime gameTime, int displacementX)
        {
            List<Missile> destroy_missile = new List<Missile>();
            List<Ennemies> destroy_ennemies = new List<Ennemies>();

            //Pour chaque missile
            Parallel.ForEach(missiles, missile =>
            {
                //On met a jour sa position
                missile.Update(gameTime, displacementX);
                //On vérifie qu'il sort pas de l'écran
                if (missile.position.X >= size_window.X - missile.texture.Width)
                {
                    destroy_missile.Add(missile);
                }
                //On vérifie si il percute un énnemie
                Parallel.ForEach(rtgame.ennemies, ennemie =>
                {
                    if (Collision.CheckCollision(missile.getRectangle(), missile.getColor(), ennemie.getRectangle(), ennemie.getColor()))
                    {
                        destroy_missile.Add(missile);
                        destroy_ennemies.Add(ennemie);
                    }
               });
            });

            foreach (Missile m in destroy_missile)
                missiles.Remove(m);
            foreach (Ennemies e in destroy_ennemies)
                rtgame.ennemies.Remove(e);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Missile m in missiles)
            {
                m.Draw(spriteBatch, gameTime);
            }            
        }*/
    }
    
}
