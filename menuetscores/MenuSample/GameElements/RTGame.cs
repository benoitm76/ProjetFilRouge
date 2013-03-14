﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using FileRouge.GameElements.Ennemy;
using FileRouge.Leveling;
using FileRouge.Armement;
using FileRouge.GameElements.Items;

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


            // Level 1

            //vague 1
        
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 550, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 600, size_window.Y * 0.4f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 650, size_window.Y * 0.1f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 700, size_window.Y * 0.5f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 750, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 850, size_window.Y * 0.2f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 900, size_window.Y * 0.1f));

            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1000, size_window.Y / 7));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1100, size_window.Y / 2));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1200, size_window.Y / 1));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1200, size_window.Y / 4));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1300, size_window.Y / 8));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1350, size_window.Y / 5));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1400, size_window.Y / 3));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1400, size_window.Y / 1));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1400, size_window.Y / 4));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1400, size_window.Y / 7));

            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 1600, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1600, size_window.Y / 2));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1650, size_window.Y / 2));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 1680, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 1750, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1750, size_window.Y / 2));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 1750, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1800, size_window.X / 2));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 1850, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1900, size_window.Y / 2));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1900, size_window.Y / 7));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 1900, size_window.Y / 3));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 2000, size_window.Y / 4));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 2000, size_window.Y / 2));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 2000, size_window.Y / 9));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 2000, size_window.Y / 1));

            //vague 2

            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 2500, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 2650, size_window.Y * 0.1f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 2650, size_window.Y * 0.2f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 2750, 200));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 2750, 700));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 2790, 300));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 2800, 600));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 2820, 200));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 2850, size_window.Y * 0.2f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 2890, 610));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 2890, 200));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 2890, 150));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 2990, 400));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 2990, 680));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 3000, size_window.Y * 0.8f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 3200, 450));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 3250, 150));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 3260, 420));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 3280, 600));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 3290, 200));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 3300, 720));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 3450, size_window.Y * 0.2f));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 3450, size_window.Y * 0.4f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 3590, 100));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 3690, 720));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 3690, 300));


            level.Add(new DropEnnemies(new Mine(size_window, this), 3800, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 3850, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 3900, 100));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4000, 0));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4000, 100));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4000, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4000, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4000, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4000, 500));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4000, 600));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4000, 720));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4200, 0));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4200, 100));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4200, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4200, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4200, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4200, 500));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4200, 600));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4200, 720));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4350, 0));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4350, 100));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4350, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4350, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4350, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4350, 500));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4350, 600));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4350, 720));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4400, 0));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4400, 100));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4400, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4400, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4400, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4400, 500));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4400, 600));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4400, 720));

            level.Add(new DropEnnemies(new Mine(size_window, this), 4500, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4550, 720));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4600, 100));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4650, 0));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4700, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4750, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4800, 720));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4850, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4900, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 4950, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5000, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5050, 720));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5100, 100));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5150, 0));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5200, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5250, 600));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5300, 720));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5350, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5400, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5450, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5500, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5550, 720));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5600, 100));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5650, 0));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5700, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5750, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5800, 720));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5850, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5900, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 5950, 600));
            level.Add(new DropEnnemies(new Mine(size_window, this), 6000, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 6050, 720));
            level.Add(new DropEnnemies(new Mine(size_window, this), 6100, 100));
            level.Add(new DropEnnemies(new Mine(size_window, this), 6150, 0));
            level.Add(new DropEnnemies(new Mine(size_window, this), 6200, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 6250, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 6300, 720));
            level.Add(new DropEnnemies(new Mine(size_window, this), 6500, 100));
            level.Add(new DropEnnemies(new Mine(size_window, this), 6500, 700));
            level.Add(new DropEnnemies(new Mine(size_window, this), 6500, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 6500, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 6600, 720));
            


            //vague4
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 6900, size_window.Y / 2));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 6980, size_window.Y / 4));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7100, 0));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7100, 100));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7100, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7100, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7100, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7100, 500));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7100, 600));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7100, 720));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 7200, 200));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 7210, size_window.Y / 5));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 7220, 600));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 7240, size_window.Y / 1));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 7300, 200));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 7320, 500));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 7390, 700));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7500, 0));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7500, 100));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7500, 200));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7500, 300));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7500, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7500, 500));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7500, 600));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7500, 720));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 7550, size_window.Y / 2));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 7560, size_window.Y / 8));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 7580, size_window.Y / 4));
            level.Add(new DropEnnemies(new Mine(size_window, this), 7600, 720));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 7650, 200));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 7680, 400));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 7700, 100));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 7710, 700));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 7730, 0));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 7740, size_window.Y / 2));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 7780, size_window.Y / 4));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 7800, size_window.Y / 8));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 7880, size_window.Y / 1));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 7900, size_window.Y / 7));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 7990, size_window.Y / 5));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 8000, 0));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 8040, size_window.Y / 2));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 8080, size_window.Y * 0.4f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 8110, 500));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 8150, size_window.Y / 5));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 8200, size_window.Y * 0.6f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 8280, 200));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 8310, size_window.Y / 1));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 8360, size_window.Y * 0.7f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 8400, 600));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 8460, size_window.Y / 5));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 8480, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 8480, 100));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 8480, size_window.Y / 4));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 8480, size_window.Y * 0.2f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 8600, 0));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 8600, 0));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 8600, size_window.Y / 2));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 8680, size_window.Y * 0.4f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 8750, 500));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 8800, size_window.Y / 5));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 8800, size_window.Y * 0.6f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 8800, 200));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 8800, size_window.Y / 1));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 8870, size_window.Y * 0.7f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 8920, 600));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 8970, size_window.Y / 5));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 9000, size_window.Y * 0.3f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 9000, 100));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 9000, size_window.Y / 4));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 9000, size_window.Y * 0.2f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 9000, 0)); 
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 7730, 0));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 9000, size_window.Y / 2));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 9100, size_window.Y * 0.4f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 9150, 500));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 9220, size_window.Y / 5));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 9300, size_window.Y * 0.6f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 9340, 200));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 9390, size_window.Y / 1));
            level.Add(new DropEnnemies(new ShiftEnnemies(size_window, this), 9390, size_window.Y * 0.7f));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 10000, 600));
            level.Add(new DropEnnemies(new FollowingEnnemies(size_window, this), 10000, size_window.Y / 5));
            
            /*
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 1500, 200));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 1600, 400));
            level.Add(new DropEnnemies(new MovingEnnemies(size_window, this), 1700, 600));

            level.Add(new DropEnnemies(new Mine(size_window, this), 2000, 200));

            level.Add(new DropEnnemies(new Mine(size_window, this), 2100, 600));
            level.Add(new DropEnnemies(new Mine(size_window, this), 2200, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 2300, 600));
            level.Add(new DropEnnemies(new Mine(size_window, this), 2400, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 2500, 200));

            level.Add(new DropEnnemies(new Mine(size_window, this), 2100, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 2200, 600));
            level.Add(new DropEnnemies(new Mine(size_window, this), 2000, 600));
            level.Add(new DropEnnemies(new Mine(size_window, this), 2100, 400));
            level.Add(new DropEnnemies(new Mine(size_window, this), 2200, 200));

            */

            
            //vague 3
            //vague 4
            //vague 5
            //vague 6
            //vague 7
            //vague 8
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
                    int rm = random.Next(0, 3);
                    switch (rm)
                    {
                        case 0:
                            //Heal
                            newBonus = new DoubleGunBonus(size_window, this);
                            break;
                        case 1:
                            newBonus = new DoubleGunBonus(size_window, this);
                            //Weapon
                            break;
                        case 2:
                            newBonus = new SimpleGunBonus(size_window, this);
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
