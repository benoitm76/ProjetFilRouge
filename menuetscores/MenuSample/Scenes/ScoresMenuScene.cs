using System;
using System.Linq;
using System.Collections.Generic;
using FileRouge.Scenes.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FileRouge.Scenes
{
    /// <summary>
    /// Un exemple de menu d'options
    /// </summary>
    public class ScoresMenuScene : AbstractScoresScene
    {
        private SpriteFont font;
        private SpriteBatch spriteBatch;
        private ContentManager Content;

        EnrLireScores enrLireScores = new EnrLireScores();
        
        public ScoresMenuScene(SceneManager sceneMgr)
            : base(sceneMgr,"Scores")
        {
            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }

        public override void Initialize()
        {
            if (Content == null)
                Content = new ContentManager(SceneManager.Game.Services, "Content");

            base.Initialize();
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
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, bool othersceneHasFocus, bool coveredByOtherscene)
        {
            base.Update(gameTime, othersceneHasFocus, coveredByOtherscene);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            int zero = 0;
            spriteBatch.Begin();

            List<Scores> listDesScores = new List<Scores>();
            listDesScores = enrLireScores.RecupScores();

            listDesScores.Sort(delegate(Scores s1, Scores s2) { return s2.Score.CompareTo(s1.Score); });

            for (int i=0;i<listDesScores.Count();i++)
            {
                spriteBatch.DrawString(font, listDesScores[i].Nom, new Vector2(75, 125 + (i * 40)), Color.White);
                spriteBatch.DrawString(font, listDesScores[i].Score.ToString(), new Vector2(350, 125 + (i * 40)), Color.White);
                spriteBatch.DrawString(font, listDesScores[i].Date, new Vector2(550, 125 + (i * 40)), Color.White);
                if (i == 9) i = 999999999;
            }
            spriteBatch.End();
            base.Draw(gameTime);

            //Permet le fondu au chargement
            if (TransitionPosition > 0 && SceneState == SceneState.TransitionOn)
            {
                SceneManager.FadeBackBufferToBlack(TransitionPosition);
            }
        }

        protected override void OnCancel()
        {
            Remove();
            LoadingScene.Load(SceneManager, false, new MainMenuScene(SceneManager));
        }
    }
}
