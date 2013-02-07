using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileRouge
{
    class Scores
    {
        private String nom;
        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        private String date;
        public String Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
