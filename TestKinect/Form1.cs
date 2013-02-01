using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;

namespace TestKinect
{
    public partial class Form1 : Form
    {
        public KinectInput ki;
        public Form1()
        {
            InitializeComponent();
            ki = new KinectInput();
            label4.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ki.playerFire += fireEnnemy;
            ki.playerMove += move;
            ki.startFire += startFire;
            ki.stopFire += stopFire;
            ki.onContinueFire = true;
        }

        public void fireEnnemy()
        {
            label3.Text += "Feu!";
        }

        public void startFire()
        {
            label4.Show();
        }

        public void stopFire()
        {
            label4.Hide();
        }

        public void move()
        {            
            label1.Text = "X : " + ki.oldPointLeftHand.X + " -- Y : " + ki.oldPointLeftHand.Y + " -- Z : " + ki.oldPointLeftHand.Z;
            label2.Left = (int)(400 * ki.oldPointLeftHand.X + 400);
            label2.Top = (int)(600 - (300 * ki.oldPointLeftHand.Y + 300)); 
        }
    }
}
