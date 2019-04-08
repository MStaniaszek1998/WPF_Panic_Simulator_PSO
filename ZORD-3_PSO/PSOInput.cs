using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZORD_3_PSO
{
    //done

    class PSOInput
    {
        int iteracje;
        int swarmWielkosc;
        int iloscAut;
        int iloscLudzikow;
        public int IloscAut
        {
            get { return iloscAut; }
            set { iloscAut = value; }
        }
        public int IloscLudzikow
        {
            get { return iloscLudzikow; }
            set { iloscLudzikow = value; }
        }
        public int Iteracje
        {
            get { return iteracje; }
            set { iteracje = value; }
        }
        public int SwarmWielkosc
        {
            get
            {
                return swarmWielkosc;
            }
            set
            {
                swarmWielkosc = value;
            }
        }
        public PSOInput()
        {
            iteracje = 20;
            //swarmWielkosc = 10;
            iloscAut = 5;
            IloscLudzikow = 5;

        }
    }
}
