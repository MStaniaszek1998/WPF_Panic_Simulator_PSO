using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZORD_3_PSO
{
    class PSOBuilder
    {
        //DONE
        
        static int iloscAut;
        static int iloscLudzikow;
        public static  int IloscAut
        {
            get { return iloscAut; }
            set
            {
                if (value <= 0) { throw new Exception("Ammount of cars cannot be below 0"); } else { iloscAut = value; }
            }
        }
        private static int IloscLudzikow
        {
            get { return iloscLudzikow; }
            set
            {
                if (value <= 0) { throw new Exception("Ammount of scouts cannot be below 0"); } else { iloscLudzikow = value; }
            }
        }
        public static void SetParams(PSOInput Params)
        {

            IloscAut = Params.IloscAut;
            IloscLudzikow = Params.IloscLudzikow;

        }
        public static List<Particle> CreateSwarm( Pooint SpawnOne)
        {
            List<Particle> Combained = new List<Particle>();

            Combained.AddRange(MakeLudziki(SpawnOne, true));
            Combained.AddRange(MakeLudziki(SpawnOne, false));

            return Combained;
        }
        
        private static List<Particle> MakeLudziki(Pooint SpawnOne, bool Choice)
        {
            List<Particle> Czastki = new List<Particle>();
            int jakiRodzaj = Choice ? iloscAut : iloscLudzikow;
            for (int i = 0; i < jakiRodzaj; i++)
            {
                int x = GetRandomNum.GetIntNumber(SpawnOne.X - 10, SpawnOne.X + 10);
                int y = GetRandomNum.GetIntNumber(SpawnOne.Y - 10, SpawnOne.Y + 10);
                if (Choice)
                {
                    Czastki.Add(new Car(new Pooint(x, y)));
                }
                else
                {
                    Czastki.Add(new Scout(new Pooint(x, y)));
                }
                

            }
            return Czastki;
        }
        




    }
}
