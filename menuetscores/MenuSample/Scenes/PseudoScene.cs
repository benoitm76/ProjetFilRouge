﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileRouge.Scenes.Core;
using FileRouge.GameElements;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using FileRouge.Inputs;
using Microsoft.Xna.Framework;

namespace FileRouge.Scenes
{
    class PseudoScene : AbstractScoresScene
    {
        private RTGame rtgame;
        private SpriteFont font;
        private SpriteBatch spriteBatch;
        private ContentManager Content;
        private Textbox textbox;
        private int entre;

        public PseudoScene(SceneManager sceneMgr, RTGame rtgame)
            : base(sceneMgr, "Entrez votre pseudo :")
        {
            this.rtgame = rtgame;
            entre = 1;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            if (Content == null)
            {
                Content = new ContentManager(SceneManager.Game.Services, "Content");
            }
            font = Content.Load<SpriteFont>("scorefont");
            base.LoadContent();
            textbox = new Textbox(
            GraphicsDevice,
            400,
            font)
            {
                ForegroundColor = Color.Blue,
                BackgroundColor = Color.White,
                Position = new Vector2((int)((rtgame.size_window.X - 400) / 2), 160),
                HasFocus = true
            };
        }

        public override void Update(GameTime gameTime)
        {
            textbox.Update(gameTime);
            base.Update(gameTime);

            if (Textbox.Pseudo != "Default" && Textbox.Pseudo != "" && entre!=0)
            {
                entre--;
                EnrLireScores enrScores = new EnrLireScores();
                enrScores.AjouterScore(Textbox.Pseudo, Math.Round(rtgame.distance).ToString());

                Remove();
                LoadingScene.Load(SceneManager, false, new ScoresMenuScene(SceneManager));
            }
        }

        public override void Draw(GameTime gameTime)
        {
            _sceneManager.Game.IsMouseVisible = true;
            //textbox.PreDraw();
            textbox.Draw();

            if (Textbox.Pseudo != "")
            {
                spriteBatch.Begin();
                Vector2 tailletext = font.MeasureString("Appuyer sur entrer");
                spriteBatch.DrawString(font, "Appuyer sur entrer", new Vector2((rtgame.size_window.X / 2) - (tailletext.X / 2), 300), Color.White);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        public new void handSelect()
        {
        }

        protected override void OnCancel()
        {
            //Remove();
            //LoadingScene.Load(SceneManager, false, new ScoresMenuScene(SceneManager));
        }
    }
}
