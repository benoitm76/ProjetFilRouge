using System;
using FileRouge.Scenes.Core;

namespace FileRouge.Scenes
{
    /// <summary>
    /// Un exemple de menu d'options
    /// </summary>
    public class OptionsMenuScene : AbstractMenuScene
    {
        #region Fields

        private readonly MenuItem _languageMenuItem;
        private readonly MenuItem _resolutionMenuItem;
        private readonly MenuItem _fullscreenMenuItem;
        private readonly MenuItem _volumeMenuItem;

        private enum Language
        {
            English,
            Francais,
            Espanol,
            Italiano,
            Nihongo,
        }

        private static Language _currentLanguage = Language.Francais;
        private static readonly string[] Resolutions = { "640x360", "854x480", "960x540", "1024x576", "1280x720", "1366x768" , "1600x900", "1920x1080"};
        private static int _currentResolution;
        private static bool _fullscreen;
        private static int _volume = 42;

        #endregion

        #region Initialization

        /// <summary>
        /// Constructor.
        /// </summary>
        public OptionsMenuScene(SceneManager sceneMgr)
            : base(sceneMgr, "Options")
        {
            // Cr�ation des options du menu
            _languageMenuItem = new MenuItem(string.Empty);
            _resolutionMenuItem = new MenuItem(string.Empty);
            _fullscreenMenuItem = new MenuItem(string.Empty);
            _volumeMenuItem = new MenuItem(string.Empty);
            SetMenuItemText();
            var back = new MenuItem("Retour");

            // Gestion des �v�nements
            _languageMenuItem.Selected += LanguageMenuItemSelected;
            _resolutionMenuItem.Selected += ResolutionMenuItemSelected;
            _fullscreenMenuItem.Selected += FullscreenMenuItemSelected;
            _volumeMenuItem.Selected += VolumeMenuItemSelected;
            back.Selected += OnCancel;
            
            // Ajout des options au menu
            MenuItems.Add(_languageMenuItem);
            MenuItems.Add(_resolutionMenuItem);
            MenuItems.Add(_fullscreenMenuItem);
            MenuItems.Add(_volumeMenuItem);
            MenuItems.Add(back);
        }

        /// <summary>
        /// Mise � jour des valeurs du menu
        /// </summary>
        private void SetMenuItemText()
        {
            _languageMenuItem.Text = "Langue: " + _currentLanguage;
            _resolutionMenuItem.Text = "Resolution: " + Resolutions[_currentResolution];
            _fullscreenMenuItem.Text = "Plein ecran: " + (_fullscreen ? "oui" : "non");
            _volumeMenuItem.Text = "Volume: " + _volume;
        }

        #endregion

        #region Handle Input

        private void LanguageMenuItemSelected(object sender, EventArgs e)
        {
            _currentLanguage++;

            if (_currentLanguage > Language.Nihongo)
                _currentLanguage = 0;

            SetMenuItemText();
        }

        private void ResolutionMenuItemSelected(object sender, EventArgs e)
        {
            _currentResolution = (_currentResolution + 1) % Resolutions.Length;
            SetMenuItemText();
        }

        private void FullscreenMenuItemSelected(object sender, EventArgs e)
        {
            _fullscreen = !_fullscreen;
            SetMenuItemText();
        }

        private void VolumeMenuItemSelected(object sender, EventArgs e)
        {
            _volume++;
            SetMenuItemText();
        }

        #endregion
    }
}
