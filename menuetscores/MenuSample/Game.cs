using FileRouge.Inputs;
using FileRouge.Scenes;
using FileRouge.Scenes.Core;
using Microsoft.Xna.Framework;

namespace FileRouge
{
    /// <summary>
    /// Ceci est un sample montrant comment g�rer diff�rents �tats de jeu avec transitions.
    /// D�mo de menus, sc�ne de chargement, sc�ne de jeu et sc�ne de pause. Cette classe est
    /// extr�mement simple, tout se passe dans le gestionnaire de sc�nes: le SceneManager.
    /// </summary>
    public class MenuSampleGame : Game
    {
        public MenuSampleGame()
        {
            Content.RootDirectory = "Content";

            // Initialisation du GraphicsDeviceManager
            // pour obtenir une fen�tre de dimensions 800*480
            new GraphicsDeviceManager(this) { PreferredBackBufferWidth = 1280, PreferredBackBufferHeight = 720 };

            // Cr�ation du gestionnaire de sc�nes
            var sceneMgr = new SceneManager(this);

            // Mise � jour automatique de Win... des entr�es utilisateur
            // et du gestionnaire de sc�nes
            Components.Add(new InputState(this));
            Components.Add(sceneMgr);

            // Activation des premi�res sc�nes
            new BackgroundScene(sceneMgr).Add();
            new MainMenuScene(sceneMgr).Add();
        }

        public static void Main()
        {
            // Point d'entr�e
            using (var game = new MenuSampleGame())
                game.Run();
        }
    }
}
