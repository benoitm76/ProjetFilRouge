using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileRouge.GameElements.Core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace FileRouge.GameElements
{
    class MainPlayer : Sprite
    {
        public float coefDep { get; set; }
        public int health;
        public int nb_frame_invulnerability { get; set; }

        private RTGame rtgame;

        public MainPlayer(Vector2 size_window, RTGame rtgame)
            : base(size_window)
        {
            this.rtgame = rtgame;
            health = 5;
            coefDep = 5f;
        }

        public void HandleInput()
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
            newPos.X = newPos.X + displacement.X * coefDep;
            newPos.Y = newPos.Y + displacement.Y * coefDep;

            position = newPos;
        }

        public override void Update(GameTime gameTime)
        {
            //On vérifie que la particule ne sorte pas de l'écran
            Vector2 newPos = new Vector2(position.X, position.Y);
            if (newPos.X + texture.Width > size_window.X)
            {
                newPos.X = size_window.X - texture.Width;
            }
            if (newPos.X < 0)
            {
                newPos.X = 0;
            }
            if (newPos.Y + texture.Height > size_window.Y - 0)
            {
                newPos.Y = size_window.Y - texture.Height - 0;
            }
            if (newPos.Y < 0)
            {
                newPos.Y = 0;
            }

            position = newPos;

            if (nb_frame_invulnerability != 0)
            {
                nb_frame_invulnerability--;
            }
        }

        public void LoadContent(ContentManager content)
        {
            base.LoadContent(content, "vaisseau");

            position = new Vector2(50, (size_window.Y - texture.Height) / 2);
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
            spriteBatch.Draw(texture, position, color);
        }

        public void touched()
        {
            health--;
            nb_frame_invulnerability = 80;
        }
    }
}
