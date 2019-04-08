using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ZORD_3_PSO
{ //done
    //MAYBE REFAKTOR
    class ControllerPSO
    {

        List<List<Particle>> FullSimulation;
        List<PoointGrid> bombs = new List<PoointGrid>();
        List<PoointGrid> spawnPoints = new List<PoointGrid>();
        MainWindow myWindow;

        bool CzyAnimacjaPoszla;
        public bool AnimacjaWTrakcie
        {
            get { return CzyAnimacjaPoszla; }
            set { CzyAnimacjaPoszla = value; }
        }

        //RF

        public List<PoointGrid> SpawnPoints
        {
            get { return spawnPoints; }
            set
            {
                spawnPoints = value;
            }
        }
        public List<PoointGrid> Bombs
        {
            get { return bombs; }
            set { bombs = value; }
        }
        public MainWindow MyWindow
        {
            get { return myWindow; }
            set { myWindow = value; }
        }

        MenuPSO menuPso;
        public MenuPSO MenuPso
        {
            get { return menuPso; }
            set { menuPso = value; }
            }

        public ControllerPSO(MainWindow mw)
        {
            
            MyWindow = mw;
            mw.mapa = new Map(mw, 20, 800, 800);
            MakeMenu();
            this.FullSimulation =  new List<List<Particle>>();
            this.bombs = new List<PoointGrid>();
        }
        private void MakeMenu()
        {
            PSOInput Parametry = new PSOInput();
            menuPso = new MenuPSO( Parametry, this);
            Scenarios NoweScenario = new Scenarios( menuPso);
            Backgrounds ZmienneTapety = new Backgrounds(menuPso);
            menuPso.ConstructMenu();
            NoweScenario.Create();
            ZmienneTapety.Create();
        }
        public int SetBombs()
        {
            int checker = 0;
            
            for (int i = 0; i < MyWindow.mapa.Grid.Count; i++)
            {
                for (int j = 0; j < MyWindow.mapa.Grid[i].Count; j++)
                {
                    if (MyWindow.mapa.Grid[i][j].WybranaBomba == true)
                    {
                        Bombs.Add(MyWindow.mapa.Grid[i][j]);//agregacja
                        MyWindow.mapa.Grid[i][j].WybranaBomba = false;
                        checker += 1;
                    }
                }
            }
            return checker;
        }

        public int SetSpawnPoints()
        {
            int checker = 0;
            for (int i = 0; i < MyWindow.mapa.Grid.Count; i++)
            {
                for (int j = 0; j < MyWindow.mapa.Grid[i].Count; j++)
                {
                    if (MyWindow.mapa.Grid[i][j].WybranySpawn == true)
                    {
                        SpawnPoints.Add(MyWindow.mapa.Grid[i][j]);//agregacja

                        MyWindow.mapa.Grid[i][j].WybranySpawn = false;
                        checker += 1;
                    }
                }
            }
            return checker;
        }

       private bool CheckingifReady(int spawnAmm, int bombsAmm)
        {
            if((spawnAmm == 0) &&( bombsAmm ==0))
            {
                throw new Exception("You did not give respawns and bombs");
                
            }
            if(spawnAmm == 0)
            {
                throw new Exception("You did not give respawns");
        
            }
            if (bombsAmm == 0)
            {
                throw new Exception("You did not give bomb locations");
            }
            return true;
        }
        
        public void StartSimulations(PSOInput Params)
        {
            AllowSymulation();
            
            List<Pooint> MiejscaBomb = LISTChangeFromPunktGrid(Bombs);
            PSOBuilder.SetParams(Params);

            PSO.SetBombs(MiejscaBomb);
            PSO.setIterations(Params.Iteracje);

            Pooint Spawn = new Pooint();
            List<Particle> newSwarm = new List<Particle>();
            foreach (var oneSpawn in spawnPoints)
            {
                
                Spawn = ChangeGridToPunkt(oneSpawn);
                newSwarm = PSOBuilder.CreateSwarm(Spawn);
                PSO newPso = new PSO( newSwarm);
                newPso.Start();
                FullSimulation.Add(newPso.Swarm);
            }
            //animation
            AnimateSwarm();
        }
        void AllowSymulation()
        {
            int checkSpawn = SetSpawnPoints();
            int checkBombs = SetBombs();
            if (!(CheckingifReady(checkSpawn, checkBombs))){return;}
        }
        private List<Pooint> LISTChangeFromPunktGrid(List<PoointGrid> toBeChanged)
        {
            List<Pooint> Skonwertowane = new List<Pooint>();
            for (int i = 0; i < toBeChanged.Count; i++)
            {
                Skonwertowane.Add(ChangeGridToPunkt(toBeChanged[i]));
            }
            return Skonwertowane;
        }
        private Pooint ChangeGridToPunkt(PoointGrid toBeChanged)
        {
            return new Pooint(toBeChanged.X, toBeChanged.Y);
        }

        public void AnimateSwarm()
        {
            CzyAnimacjaPoszla = true;
            AnimationPSO Animacja = new AnimationPSO(myWindow.mapa);
            for (int k = 0; k < FullSimulation.Count; k++)
            {
                for (int j = 0; j < FullSimulation[k].Count; j++)
                {
                    List<List<int>> Coords = new List<List<int>>();
                    Coords = MakeHistoryPositions(k,j);
                    myWindow.root.Children.Add(FullSimulation[k][j].ReturnImage());
                    Animacja.Lataj(FullSimulation[k][j], Coords);
                }
            }
            
        }

        private List<List<int>> MakeHistoryPositions( int k,int j)
        {
            List<List<int>> Coords = new List<List<int>>();
            for (int i = 0; i < FullSimulation[k][j].HistoryPositons.Count; i++)
            {
                List<int> xy = new List<int>();
                int x = FullSimulation[k][j].HistoryPositons[i].X;
                int y = FullSimulation[k][j].HistoryPositons[i].Y;
                xy.Add(x);
                xy.Add(y);
                Coords.Add(xy);
            }
            return Coords;
        }


        public void ResetujCzastki()
        {
            if (CzyAnimacjaPoszla == true)
            {
                for (int i = 0; i < FullSimulation.Count; i++)
                {
                    for (int j = 0; j < FullSimulation[i].Count; j++)
                    {
                        myWindow.root.Children.Remove(FullSimulation[i][j].ReturnImage());
                    }
                }
            }
            FullSimulation.Clear();
            
            GC.Collect();
        }



        
    }
}

