using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileRouge.GameElements.Core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using FileRouge.Armement;

namespace FileRouge.GameElements
{
    class MainPlayer : ChangingSprite
    {
        public float coefDep { get; set; }
        public int health;
        public int nb_frame_invulnerability { get; set; }
        public Arme arme { get; set; }
        public Vector2 oldPosition { get; set; }

        private RTGame rtgame;

        public MainPlayer(Vector2 size_window, RTGame rtgame)
            : base(size_window)
        {
            this.rtgame = rtgame;
            health = 5;
            coefDep = 5f;
            size = new Vector2(256, 105);
            nbrSprite = 3;
        }

        public void HandleInput(GameTime gameTime)
        {
            Vector2 displacement = new Vector2();
            Vector2 newPos = new Vector2(position.X, position.Y);
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                displacement.Y = -1;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                displacement.Y = 1;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                displacement.X = 1;
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                displacement.X = -1;
            }
            if(keyboardState.IsKeyDown(Keys.Space))
            {
                arme.fire(gameTime);
            }
            newPos.X = newPos.X + displacement.X * coefDep;
            newPos.Y = newPos.Y + displacement.Y * coefDep;

            position = newPos;
        }

        public void Update(GameTime gameTime, int displacementX)
        {
            //On vérifie que la particule ne sorte pas de l'écran
            Vector2 newPos = new Vector2(position.X, position.Y);
            if (newPos.X + size.X > size_window.X)
            {
                newPos.X = size_window.X - size.X;
            }
            if (newPos.X < 0)
            {
                newPos.X = 0;
            }
            if (newPos.Y + size.Y > size_window.Y - 0)
            {
                newPos.Y = size_window.Y - size.Y - 0;
            }
            if (newPos.Y < 0)
            {
                newPos.Y = 0;
            }

            position = newPos;

            if (position.Y == oldPosition.Y)            
                spriteShow = 1;
            
            else if (position.Y > oldPosition.Y)
                spriteShow = 0;
            else
                spriteShow = 2;

            oldPosition = position;
            

            if (nb_frame_invulnerability != 0)
            {
                nb_frame_invulnerability--;
            }

            arme.position = new Vector2(position.X + 256, position.Y + 80);
            arme.Update(gameTime, displacementX);            
        }

        public void LoadContent(ContentManager content)
        {
            base.LoadContent(content, "avion");

            position = new Vector2(50, (size_window.Y - size.Y) / 2);
            oldPosition = position;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Color color = Color.White;
            if (nb_frame_invulnerability != 0)
            {
                //On fait clignoter l'ennemie si il est en phase d'invulnérabilité
                if ((int)(nb_frame_invulnerability / 20) % 2 == 0)
                {
                    color = Color.Transparent;
                }                
            }
            arme.Draw(spriteBatch,gameTime);
            spriteBatch.Draw(texture, position, new Rectangle((int)size.X * spriteShow, 0, (int)size.X, (int)size.Y), color);
        }

        public void touched()
        {
            health--;
            nb_frame_invulnerability = 100;
        }
    }
}
