using System;
using FileRouge.Scenes.Core;

namespace FileRouge.Scenes
{
    /// <summary>
    /// Le menu principal est la premi�re chose affich�e lors du lancement du binaire
    /// </summary>
    public class MainMenuScene : AbstractMenuScene
    {
        #region Initialization

        /// <summary>
        /// Le constructeur remplit le menu
        /// </summary>
        public MainMenuScene(SceneManager sceneMgr)
            : base(sceneMgr, "Menu principal")
        {
            // Cr�ation des options
            var playGameMenuItem = new MenuItem("Lancer le jeu");
            var optionsMenuItem = new MenuItem("Options");
            var scoresMenuItem = new MenuItem("Scores");
            var exitMenuItem = new MenuItem("Quitter");

            // Gestion des �v�nements
            playGameMenuItem.Selected += PlayGameMenuItemSelected;
            optionsMenuItem.Selected += OptionsMenuItemSelected;
            scoresMenuItem.Selected += ScoresMenuItemSelected;
            exitMenuItem.Selected += OnCancel;

            // Ajout des options du menu
            MenuItems.Add(playGameMenuItem);
            MenuItems.Add(optionsMenuItem);
            MenuItems.Add(scoresMenuItem);
            MenuItems.Add(exitMenuItem);
        }

        #endregion

        #region Handle Input

        private void PlayGameMenuItemSelected(object sender, EventArgs e)
        {
            LoadingScene.Load(SceneManager, true, new GameplayScene(SceneManager));
        }

        private void OptionsMenuItemSelected(object sender, EventArgs e)
        {
            new OptionsMenuScene(SceneManager).Add();
        }

        private void ScoresMenuItemSelected(object sender, EventArgs e)
        {
             LoadingScene.Load(SceneManager, false, new ScoresMenuScene(SceneManager));
        }

        protected override void OnCancel()
        {
            const string message = "Etes vous sur de vouloir quitter?\n";
            var confirmExitMessageBox = new MessageBoxScene(SceneManager, message);

            confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;
            confirmExitMessageBox.Add();
        }

        private void ConfirmExitMessageBoxAccepted(object sender, EventArgs e)
        {
            SceneManager.Game.Exit();
        }

        #endregion
    }
}
