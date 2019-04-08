using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZORD_3_PSO
{
	public class Map
	{
        //REFAKTOR WITH WJ

       
        MainWindow mw;
		int wymiarGrid;
		int wysokoscGrid;
		int szerokoscGrid;

		public int WymiarGrid
		{
			get { return wymiarGrid; }
			set { wymiarGrid = value; }
		}

		int WysokoscGrid
		{
			get { return wysokoscGrid; }
			set { wysokoscGrid = value; }
		}

		int SzerokoscGrid
		{
			get { return szerokoscGrid; }
			set { szerokoscGrid = value; }
		}

		List<List<PoointGrid>> grid;

		public List<List<PoointGrid>> Grid
		{
			get { return grid; }
			set { grid = value; }
		}

		public MainWindow Mw
		{
			get { return mw; }
			set { mw = value; }
		}

		public Map(MainWindow mw, int wymiarGrid, int wysokosc, int szerokosc)
		{
			Mw = mw;

            SetScreenInfo(wymiarGrid, wysokosc, szerokosc);
            SettingGrid();


        }
        private void SettingGrid()
        {
            Grid = new List<List<PoointGrid>>();

            for (int i = 0; i < wymiarGrid; i++)
            {
                List<PoointGrid> podlista = new List<PoointGrid>();
                for (int j = 0; j < wymiarGrid; j++)
                {
                    PoointGrid makeNew = new PoointGrid();
                    makeNew = MakePunktGrid(i, j);
                    Mw.root.Children.Add(makeNew);
                    podlista.Add(makeNew);

                }
                Grid.Add(podlista);
            }

        }
        private PoointGrid MakePunktGrid(int i, int j)
        {
            PoointGrid guzik = new PoointGrid();
            guzik.X = SzerokoscGrid * j + SzerokoscGrid / 2;
            guzik.Y = WysokoscGrid * i + WysokoscGrid / 2;
            guzik.Height = WysokoscGrid;
            guzik.Width = SzerokoscGrid;
            guzik.Background = Brushes.Transparent;
            guzik.BorderThickness = new Thickness(0, 0, 0, 0);
            guzik.Click += SettingMouseSpawn;
            
            guzik.MouseRightButtonDown += SettingMouseBomb;
            
            Canvas.SetTop(guzik, i * WysokoscGrid);
            Canvas.SetLeft(guzik, j * SzerokoscGrid);
            return guzik;
        }

        private void SettingMouseSpawn(object sender, RoutedEventArgs e)
        {
            PoointGrid ctrl = (PoointGrid)sender;
            if (ctrl.Background == Brushes.Transparent)
            {
                ctrl.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Obrazki/" + Photos.spawn.ToString() + ".png")));
                ctrl.WybranySpawn = true;
            }

            else
            {
                ctrl.Background = Brushes.Transparent;
                ctrl.WybranySpawn = false;
            }
        }

        private void SettingMouseBomb(object sender, MouseButtonEventArgs e)
        {
            PoointGrid ctrl = (PoointGrid)sender;
            if (ctrl.Background == Brushes.Transparent)
            {
                ctrl.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Obrazki/" + Photos.Bomb.ToString() + ".png")));
                ctrl.WybranaBomba = true;
            }

            else
            {
                ctrl.Background = Brushes.Transparent;
                ctrl.WybranaBomba = false;
            }
        }

        private void SetScreenInfo(int wymiarGrida, int height, int width)
        {
            Mw.Title = "AI - Panic Simulator";
            Mw.Height = 880;
            Mw.Width = 820;
            
            
            Mw.Icon = BitmapFrame.Create(new Uri(@"pack://application:,,,/Obrazki/pso.png"));
            Mw.ResizeMode = ResizeMode.NoResize;
            WymiarGrid = wymiarGrida;
            WysokoscGrid = height / wymiarGrid;
            SzerokoscGrid = width / wymiarGrid;
        }
	
	}
}
