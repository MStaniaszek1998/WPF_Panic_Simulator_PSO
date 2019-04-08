using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ZORD_3_PSO
{
    //done
    
    public enum SourceScen
    {
        samolot,
        field,
        pathWay,
    }

    class Scenarios:ICreator
    {

       
        MenuPSO MakeMenu;

        public Scenarios( MenuPSO menu)
        {
           
            MakeMenu = menu;

        }
        public void Create()
        {
            MenuItem Scena;
            Scena = MakeMenu.MakeMainButton("Scenarios", Photos.Scenario, 40);
            MakeMenu.MakeButtonToMenuParent("Scenario 1", 30, Photos.Scenario, samolot, Scena);
            MakeMenu.MakeButtonToMenuParent("Scenario 2", 30, Photos.Scenario, field, Scena);
            MakeMenu.MakeButtonToMenuParent("Scenario 3", 30, Photos.Scenario, pathWay, Scena);
        }
        
        private void Maker(SourceScen Scena)
        {
           
            StreamReader reader = new StreamReader(File.OpenRead(@"..\..\CSV\"+ Scena.ToString()+ ".csv"));
            List<List<string>> Scene = new List<List<string>>();

            while (!reader.EndOfStream)
            {
                List<string> OneRow = new List<string>();
                string line = reader.ReadLine();
                if (!String.IsNullOrWhiteSpace(line))
                {
                    
                    string[] arr = line.Split(',');
                    OneRow = arr.OfType<string>().ToList();
                    


                }
                Scene.Add(OneRow);
            }
            for(int i = 0; i < MakeMenu.Swarm.MyWindow.mapa.Grid.Count; i++)
            {
                for(int j = 0; j < MakeMenu.Swarm.MyWindow.mapa.Grid[i].Count; j++)
                {
                    string oneDir = Scene[i][j];
                    int Chooser = Convert.ToInt32(oneDir);
                    if(Chooser == 1)
                    {
                        MakeMenu.Swarm.MyWindow.mapa.Grid[i][j].WybranaBomba = true;
                        MakeMenu.Swarm.MyWindow.mapa.Grid[i][j].Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Obrazki/" + Photos.Bomb.ToString() + ".png")));
                    }
                }
            }
        }
        private void samolot(object sender, RoutedEventArgs e)
        {
            Maker(SourceScen.samolot);
        }
        private void field(object sender, RoutedEventArgs e)
        {
            Maker(SourceScen.field);
        }
        private void pathWay(object sender, RoutedEventArgs e)
        {
            Maker(SourceScen.pathWay);
        }

        
    }
}
