using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileRouge.Armement
{
    class Arme1 : Arme
    {
        public Arme1()
        {
            NomArme = "laser";
            ArmeCarct();

        }

     public override void ArmeCarct()
        {

            if (LevelArme == 1)
            {
                CadTir = 100;
                DegArme = 1;

            }
            else if (LevelArme == 2)
            {
                CadTir = 150;
                DegArme = 2;

            }
            else if (LevelArme == 3)
            {
                CadTir = 150;
                DegArme = 4;

            }
            else if (LevelArme != 1 && LevelArme != 2 && LevelArme != 3)
            {
                CadTir = 100;
                DegArme = 1;
            }
           

        }
    }
    
}
