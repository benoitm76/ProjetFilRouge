using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using FileRouge.GameElements.Bonu;
using FileRouge.GameElements.Ennemy;
using FileRouge.Leveling;
using FileRouge.Armement;

namespace FileRouge.GameElements
{
    class RTGame
    {
        #region Constantes
        public const int Keyboard = 0;
        public const int XboxController = 1;
        public const int Mouse = 2;
        public const int KiniectController = 4;
        #endregion

        public float distance { get; set; }
        public int kill { get; set; }
        public float vitesse { get; set; }
        public List<Ennemies> ennemies { get; set; }
        public List<Bonus> bonus { get; set; }
        public float maxSpeed { get; set; }
        public int maxEnnemies { get; set; }
        public int inGameMaxEnnemies { get; set; }
        public int maxBonus { get; set; }
        public Vector2 size_window { get; set; }
        public static int controller { get; set; }
        public ContentManager content { get; set; }
        public float distancy_meters { get; set; }
        public Vector2 player_position { get; set; }
        public MainPlayer mp { get; set; }
        public List<DropEnnemies> level;

        public List<Arme> missileRestant { get; set; }

        public int timeSpeedDown { get; set; }

        public Random random;

        public RTGame(Vector2 size_window, ContentManager content)
        {
            vitesse = 1f;
            maxEnnemies = 6;
            maxBonus = 1;
            maxSpeed = 3f;
            inGameMaxEnnemies = 18;
            ennemies = new List<Ennemies>();
            bonus = new List<Bonus>();
            random = new Random();
            missileRestant = new List<Arme>();

            this.size_window = size_window;
            this.content = content;

            level = new List<DropEnnemies>();

            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 550, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 600, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 650, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 700, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 750, size_window.Y * 0.3f));

            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1000, size_window.X / 2));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1100, size_window.X / 2));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1200, size_window.X / 2));

            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 1500, 200));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 1600, 400));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 1700, 600));
        }

        public void generateEnnemies()
        {
            if (level.Count != 0)
            {
                if (distance > level[0].distanceDrop)
                {
                    Ennemies newEnnemi = level[0].ennemie;
                    newEnnemi.LoadContent(content);
                    Vector2 pos = new Vector2((int)size_window.X, level[0].verticalPosition);
                    newEnnemi.position = pos;
                    ennemies.Add(newEnnemi);
                    level.RemoveAt(0);
                }
            }
            //Génération aléatoire des ennemies
            /*if (ennemies.Count < maxEnnemies)
            {
                int rm = random.Next(0, 20);
                Ennemies newEnnemi = null;
                switch (rm)
                {
                    case 0:
                        //Mine
                        newEnnemi = new ShiftEnnemies(size_window, this);
                        break;
                    case 10:
                        newEnnemi = new MovingEnnemies(size_window, this);
                        break;
                    case 20:
                        newEnnemi = new FollowingEnnemies(size_window, this);
                        break;
                    default:
                        break;
                }
                if (newEnnemi != null)
                {
                    newEnnemi.LoadContent(content);
                    Vector2 pos = new Vector2((int)size_window.X, random.Next(0, (int)(size_window.Y - newEnnemi.texture.Height)));
                    newEnnemi.position = pos;
                    ennemies.Add(newEnnemi);
                }
            }*/
        }

        public void generateBonus()
        {
            if (bonus.Count < maxBonus)
            {
                if (random.Next(0, 80 + (int)(distance / 1000 * 0.05f * 80)) == 10)
                {
                    Bonus newBonus;
                    int rm = random.Next(0, 2);
                    switch (rm)
                    {
                        case 0:
                            //Heal
                            newBonus = new Heal(size_window, this);
                            break;
                        case 1:
                            newBonus = new Heal(size_window, this);
                            //Weapon
                            break;
                        case 2:
                            newBonus = new Heal(size_window, this);
                            //Speedown
                            break;
                        default:
                            newBonus = new Heal(size_window, this);
                            break;
                    }
                    newBonus.LoadContent(content);
                    Vector2 pos = new Vector2((int)size_window.X, random.Next(70, (int)(size_window.Y - newBonus.texture.Height - 70)));
                    newBonus.position = pos;
                    bonus.Add(newBonus);
                }
            }
        }

        public void updateDistancy()
        {
            if (timeSpeedDown != 0)
                timeSpeedDown--;

            if (timeSpeedDown == 1)
                vitesse += 0.5f;

            if (distancy_meters >= 1000)
            {
                if ((int)(distance / 1000) % 3 == 1)
                    vitesse += 0.2f;

                if ((int)(distance / 1000) % 3 == 2)
                {
                    if (maxEnnemies <= inGameMaxEnnemies)
                        maxEnnemies += 1;
                }
                distancy_meters -= 1000;
            }
            distancy_meters += 1 * vitesse;
            distance += 1 * vitesse;
        }
    }
}
