using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
/*
 * Wstepna refaktoryzacja 21.11
 * 
 * 
 * Zrobione nie zmieniac DONE
 */
namespace ZORD_3_PSO
{
   
    
    class PSO
    {
        private static int iterations;
     
        List<Particle> swarm;
        Particle theBest;
        static List<Pooint> BombaPSO;
        public static List<Pooint> Bomby
        {
            get { return BombaPSO; }
            set { BombaPSO = value; }
        }
        public List<Particle> Swarm
        {
            get
            {
                return swarm;
            }
            set
            {
                swarm = value;
            }
        }
        public static int Iterations
        {
            get { return iterations; }
            set { if (value < 0) { throw new Exception("Iteracje nie moga byc mniejsze lub równe  0"); } else { iterations = value; } }
        }
      
        
        public static void SetBombs(List<Pooint> Ladunki)
        {
            Bomby = Ladunki;
        }
        public static void setIterations(int iter)
        {
            Iterations = iter;
        }
      



        public PSO( List<Particle> GeneratedSwarm)
        {
           
                swarm = new List<Particle>();

                Swarm = GeneratedSwarm;
                
           
            
            
                
            
        }








        public void Start()
        {

            for (int i = 0; i < Iterations; i++)
            {
                Fitness();
                SetGlobal();
                SetPersonal();
                Velocity();
                NewPosition();
            }
        }

        double CalcFunction(Pooint single)
        {
            double fitness = 0;
            int minusForBomb = -10;
            double stat = 0.00000000001;
            for (int j = 0; j < BombaPSO.Count; j++)
            {

                //funkcja fitness
                double dulX = ((1000) / ((Math.Abs(single.X - BombaPSO[j].X))+ stat))+minusForBomb;
                double dulY = ((1000) / ((Math.Abs(single.Y - BombaPSO[j].Y))+ stat))+minusForBomb;
                

                fitness += (dulX+dulY);
            }
            fitness = fitness / BombaPSO.Count;
            return fitness;
        }

      
        private void Fitness()
        {
            for (int i = 0; i < Swarm.Count; i++) {

                Swarm[i].Fitness = CalcFunction(Swarm[i].Current);
            }
        }

        private void SetGlobal()
        {
            Swarm.Sort((x, y) => x.Fitness.CompareTo(y.Fitness));
            theBest = Swarm.First();
        }

        private void SetPersonal()
        {
            bool isPrevPositionBetter = true;
            for(int i =0; i<Swarm.Count;i++)
            {
                isPrevPositionBetter = (CalcFunction(Swarm[i].HistoryBest) > Swarm[i].Fitness);
                if (isPrevPositionBetter)
                {
                    Swarm[i].HistoryBest = Swarm[i].Current;
                }
                
            }
        }

        private void NewPosition()
        {
            for(int i=0;i<Swarm.Count;i++)
            {

                CzyXPozaEkranem(i);
                CzyYPozaEkranem(i);
                AddtoHistoryPos(i, Swarm[i].Current.X, Swarm[i].Current.Y);

            }

        }

        private void CzyXPozaEkranem(int ktoryParticle)
        {
            int xPositionNew = Swarm[ktoryParticle].Current.X + Swarm[ktoryParticle].Velocity.X;
            bool isYXioletedScreen = (xPositionNew >= 790) || (xPositionNew <= 10);
            bool isXTooLarge = (xPositionNew) >= 790;
            bool isXTooSmall = (xPositionNew) <= 10;
            if (isYXioletedScreen)
            {
                if (isXTooLarge) { Swarm[ktoryParticle].Current.X = 780; }
                if (isXTooSmall) { Swarm[ktoryParticle].Current.X = 20; }
            }
            else{Swarm[ktoryParticle].Current.X = xPositionNew;}
        }

        private void CzyYPozaEkranem(int ktoryParticle)
        {
            int yPositionNew = Swarm[ktoryParticle].Current.Y + Swarm[ktoryParticle].Velocity.Y;
            bool isYVioletedScreen = ((yPositionNew >= 790) || (yPositionNew <= 10));
            bool isYTooLarge = (yPositionNew >= 790);
            bool isYTooSmall = (yPositionNew <= 10);
            if (isYVioletedScreen)
            {
                if (isYTooLarge){Swarm[ktoryParticle].Current.Y = 780; }
                if (isYTooSmall){Swarm[ktoryParticle].Current.Y = 20;}
            }
            else{Swarm[ktoryParticle].Current.Y = yPositionNew;}

        }

        private void AddtoHistoryPos(int whichParticle,int xPos, int yPos)
        {
            int xTemp = xPos;
            int yTemp = yPos;
            Swarm[whichParticle].HistoryPositons.Add(new Pooint(xTemp, yTemp));
        }

        private void Velocity()
        {

            double inertia = 0.98;
            double social = 0.77;
            double coginitiv = 0.56;

            foreach(var single in Swarm)
            {
                CalcOsobnikSpeed(single, inertia, social, coginitiv);
            }
        }

        private void CalcOsobnikSpeed(Particle single, double inertia, double social, double coginitiv)
        {
           
            double R1 = GetRandomNum.GetDoubleNum(); 
            double R2 = GetRandomNum.GetDoubleNum(); 
            int xVelocity = 0;
            int yVelocity = 0;
            xVelocity =(int) (inertia * single.Velocity.X + (coginitiv * R1 * (single.HistoryBest.X - single.Current.X)) + (social * R2 * (theBest.Current.X - single.Current.X)));
            yVelocity = (int)(inertia * single.Velocity.Y +( coginitiv * R1 * (single.HistoryBest.Y - single.Current.Y)) + (social * R2 * (theBest.Current.Y - single.Current.Y)));
            single.Velocity.X = xVelocity;
            single.Velocity.Y = yVelocity;

        }
        












        

    }
}
