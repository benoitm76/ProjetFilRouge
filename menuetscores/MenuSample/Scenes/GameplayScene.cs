using System;
using System.Threading;
using FileRouge.Inputs;
using FileRouge.Scenes.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FileRouge.GameElements;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileRouge.GameElements.Core;

namespace FileRouge.Scenes
{
    /// <summary>
    /// Le jeu!
    /// </summary>
    public class GameplayScene : AbstractGameScene
    {
        #region Fields

        SpriteBatch spriteBatch;

        private Vector2 size_window;
        private Texture2D _background;
        private int scrollX = 1;
        private RTGame r;
        private ContentManager _content;
        private SpriteFont _gameFont;
        private float _pauseAlpha;

        //bar de vie
        private Texture2D mVie;
        private Texture2D mBou;
        private SpriteFont tVie;

        //private Vector2 _playerPosition;
        #endregion

        #region Initialization

        /// <summary>
        /// Constructor.
        /// </summary>
        public GameplayScene(SceneManager sceneMgr)
            : base(sceneMgr)
        {

            _pauseAlpha = 0;

            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            if (_content == null)
                _content = new ContentManager(SceneManager.Game.Services, "Content");

            size_window = new Vector2(1280, 720);

            r = new RTGame(size_window, _content);
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            _background = _content.Load<Texture2D>(@"game_background");

            _gameFont = _content.Load<SpriteFont>("gamefont");

            mVie = _content.Load<Texture2D>("vie");

            tVie = _content.Load<SpriteFont>("VieSP");

            mBou = _content.Load<Texture2D>("Bouclier");

            r.mp = new MainPlayer(new Vector2(size_window.X, size_window.Y), r);
            r.mp.Initialize();
            r.mp.LoadContent(_content);

            // Un vrai jeu possède évidemment plus de contenu que ça, et donc cela prend
            // plus de temps à charger. On simule ici un chargement long pour que vous
            // puissiez admirer la magnifique scène de chargement. :p
            //Thread.Sleep(1000);

            // En cas de longs période de traitement, appelez cette méthode *tintintin*.
            // Elle indique au mécanisme de synchronisation du jeu que vous avez fini un
            // long traitement, et qu'il ne devrait pas essayer de rattraper le retard.
            // Cela évite un lag au début du jeu.
            SceneManager.Game.ResetElapsedTime();
        }

        protected override void UnloadContent()
        {
            _content.Unload();
        }

        #endregion

        #region Update and Draw

        public override void Update(GameTime gameTime, bool othersceneHasFocus, bool coveredByOtherscene)
        {
            base.Update(gameTime, othersceneHasFocus, false);
            r.mp.HandleInput();
            r.mp.Update(gameTime);

            _pauseAlpha = coveredByOtherscene 
                ? Math.Min(_pauseAlpha + 1f / 32, 1) 
                : Math.Max(_pauseAlpha - 1f / 32, 0);

            if (IsActive)
            {

                scrollX = (int)(scrollX + 5);
                if (scrollX >= _background.Width - size_window.X)
                {
                    scrollX = 0;
                }

                int displacementX = (int)(5 * r.vitesse);

                List<Ennemies> destroy_ennemies = new List<Ennemies>();
                Parallel.ForEach(r.ennemies, ennemie =>
                    {
                        ennemie.Update(gameTime, displacementX);
                        if (r.mp.nb_frame_invulnerability == 0)
                        {
                            if (Collision.CheckCollision(r.mp.getRectangle(), r.mp.color, ennemie.getRectangle(), ennemie.color))
                            {
                                destroy_ennemies.Add(ennemie);
                                r.mp.touched();
                            }
                        }
                        if (ennemie.position.X < 0 - ennemie.texture.Width)
                        {
                            destroy_ennemies.Add(ennemie);
                        }
                    });

                List<Bonus> destroy_bonus = new List<Bonus>();
                Parallel.ForEach(r.bonus, bonu =>
                {
                    bonu.Update(gameTime, displacementX);
                    if (Collision.CheckCollision(r.mp.getRectangle(), r.mp.color, bonu.getRectangle(), bonu.color))
                    {
                        bonu.applyBonus();
                        destroy_bonus.Add(bonu);
                    }

                    if (bonu.position.X < 0 - bonu.texture.Width)
                    {
                        
                        destroy_bonus.Add(bonu);
                    }
                });

                r.updateDistancy();

                foreach (Ennemies ennemie in destroy_ennemies)
                    r.ennemies.Remove(ennemie);

                foreach (Bonus bonu in destroy_bonus)
                    r.bonus.Remove(bonu);

                if (scrollX % 20 == 0)
                {
                    Parallel.Invoke(r.generateEnnemies, r.generateBonus);
                }
            }
        }

        public override void HandleInput()
        {
            KeyboardState keyboardState = InputState.CurrentKeyboardState;
            GamePadState gamePadState = InputState.CurrentGamePadState;

            // Le menu de pause s'enclenche si un joueur appuie sur la touche assignée
            // au menu de pause, ou lorsque qu'une manette branchée est déconnectée
            bool gamePadDisconnected = !gamePadState.IsConnected &&
                                       InputState.GamePadWasConnected;

            if (InputState.IsPauseGame() || gamePadDisconnected)
                new PauseMenuScene(SceneManager, this).Add();
            else
            {
                
                /*Vector2 movement = Vector2.Zero;

                if (keyboardState.IsKeyDown(Keys.Left))
                    movement.X--;

                if (keyboardState.IsKeyDown(Keys.Right))
                    movement.X++;

                if (keyboardState.IsKeyDown(Keys.Up))
                    movement.Y--;

                if (keyboardState.IsKeyDown(Keys.Down))
                    movement.Y++;

                Vector2 thumbstick = gamePadState.ThumbSticks.Left;

                movement.X += thumbstick.X;
                movement.Y -= thumbstick.Y;

                if (movement.Length() > 1)
                    movement.Normalize();

                Vector2 _playerPosition = r.player_position + movement * 4;
                r.player_position = _playerPosition;*/
            }
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ClearOptions.Target, Color.Orange, 0, 0);
            spriteBatch.Begin();            
            spriteBatch.Draw(_background, Vector2.Zero, new Rectangle(scrollX, 0, _background.Width, _background.Height), Color.White);
            r.mp.Draw(spriteBatch, gameTime);
            //spriteBatch.DrawString(_gameFont, "8==p", r.player_position, Color.Green);


            //AFFICHAGE DE LA VIE
           int coeur = 120;
            for (int nb = 1; nb< r.mp.health  ; nb++)
            {
                spriteBatch.Draw(mVie, new Rectangle(coeur, 10, mVie.Width, mVie.Height), Color.White);

                coeur = coeur + 35;
            }

            //Bouclier
            int bouclier = 130;
            for (int nb = 1; nb < 3; nb++)
            {
                spriteBatch.Draw(mBou, new Rectangle(bouclier, 42, mBou.Width, mBou.Height), Color.White);

                bouclier = bouclier + 30;
            }
            //text DE LA VIE
            spriteBatch.DrawString(tVie,"Vie(s) :", new Vector2(20, 10), Color.Red);



            foreach (Ennemies ennemie in r.ennemies)
            {
                ennemie.Draw(spriteBatch, gameTime);
            }

            foreach (Bonus lbonus in r.bonus)
            {
                lbonus.Draw(spriteBatch, gameTime);
            }

            spriteBatch.Draw(_content.Load<Texture2D>("laser"), new Vector2(100, 100), null, new Color(15, 153, 254, 255),
                       0, Vector2.Zero, new Vector2(1000, 1),
                       SpriteEffects.None, 0);

            spriteBatch.End();

            if (TransitionPosition > 0 || _pauseAlpha > 0)
            {
                float alpha = MathHelper.Lerp(1f - TransitionAlpha, 1f, _pauseAlpha / 2);
                SceneManager.FadeBackBufferToBlack(alpha);
            }
        }

        #endregion
    }
}
