using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ZORD_3_PSO
{
    //done

    class MenuPSO
    {
        PSOInput Parametry;
       
        ControllerPSO AktywujSwarma;
        public ControllerPSO Swarm
        {
            get { return AktywujSwarma; }
        }

        public MenuPSO(PSOInput hp, ControllerPSO AktywujPSO)
        {
            AktywujSwarma = AktywujPSO;
            
            
            this.Parametry = hp;

        }

        public void ConstructMenu()
        {

            MenuItem menuPSO = new MenuItem();
            menuPSO = MakeMainButton("PSO", Photos.pso, 40);
            MakeButtonToMenuParent("Help", 25, Photos.pytaj, Helper, menuPSO);
            MakeButtonToMenuParent("Reset", 25, Photos.reset, Resetuj_Click, menuPSO);
            MakeButtonToMenuParent("Exit", 25, Photos.exit, Wyjdz_click, menuPSO);



            MenuItem SwarmSizes = new MenuItem();
            MakeMainButton("Start", Photos.play, 40, guzik_Click2uruchom);
            SwarmSizes = MakeMainButton("Settings", Photos.sol_green, 40);
            DodajOpcjeSlider("Scouts", ZORD_3_PSO.Parameters.IloscLudzikow, 5, 50, 1, Parametry.IloscLudzikow, SwarmSizes);
            DodajOpcjeSlider("Cars", ZORD_3_PSO.Parameters.IloscAut, 5, 50, 1, Parametry.IloscAut, SwarmSizes);
            DodajOpcjeSlider("Iterations",ZORD_3_PSO.Parameters.Iteracje, 5, 100, 1, Parametry.Iteracje, SwarmSizes);
            
        }

        private void MakeMainButton(string name, Photos foto, int height, RoutedEventHandler Event)
        {
            MenuItem MainButton = new MenuItem
            {
                Header = name,
                Height = height,
                Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri(@"pack://application:,,,/Obrazki/" + foto.ToString() + ".png")) }
            };
            MainButton.Click += Event;
            AktywujSwarma.MyWindow.menu.Items.Add(MainButton);
            
        }

        public MenuItem MakeMainButton(string name, Photos foto, int height)
        {
            MenuItem MainButton = new MenuItem();
            MainButton.Header = name;
            MainButton.Height = height;
            MainButton.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri(@"pack://application:,,,/Obrazki/" + foto.ToString() + ".png")) };
            AktywujSwarma.MyWindow.menu.Items.Add(MainButton);
            return MainButton;
        }

        public void MakeButtonToMenuParent(string name, int height, Photos foto, RoutedEventHandler myMethodName, MenuItem parent)
        {
            MenuItem CustomButton = new MenuItem();
            CustomButton.Header = name;
            CustomButton.Height = height;
            CustomButton.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri(@"pack://application:,,,/Obrazki/"+foto.ToString()+".png"))};
            CustomButton.Click += myMethodName;
            parent.Items.Add(CustomButton);


        }
        
        public void DodajOpcjeSlider(string ButtonName,Parameters name, double min,double max, double podzialka, double domyslnie, MenuItem Parent)
        {
            MenuItem miOpcja = new MenuItem();
            miOpcja.Header = ButtonName;
            miOpcja.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri(@"pack://application:,,,/Obrazki/"+Photos.options.ToString()+".png")) };
            DockPanel newPanel = new DockPanel();
            newPanel = CreateDocPanel(min,max,podzialka, name, domyslnie);
            
            miOpcja.Items.Add(newPanel);
            Parent.Items.Add(miOpcja);
        }

        private DockPanel CreateDocPanel(double min,double max, double podzialka, Parameters nazwa, double wartoscDomysla)
        {
            DockPanel panel = new DockPanel();
            Slider sliderOpcja = new Slider();
            sliderOpcja = CreateSlider(min, max, podzialka);
            BindToDestinationSlider(nazwa, sliderOpcja);
            TextBox tbOpcja = new TextBox();
            tbOpcja = MakeTextBox(wartoscDomysla);
            BindToDestinationTXT(nazwa, tbOpcja);
            panel.Children.Add(sliderOpcja);
            panel.Children.Add(tbOpcja);
            return panel;
            
        }
        private TextBox MakeTextBox(double Domyslnie)
        {
            TextBox newText = new TextBox
            {
                Width = 40,
                Text = Domyslnie.ToString()
            };
            return newText;
        }

        private Slider CreateSlider(double min, double max, double podzialka )
        {
            Slider newSlide = new Slider();
            newSlide.Minimum = min;
            newSlide.Maximum = max;
            newSlide.Width = 100;
            newSlide.TickPlacement = System.Windows.Controls.Primitives.TickPlacement.BottomRight;
            newSlide.TickFrequency = podzialka;
            newSlide.IsSnapToTickEnabled = true;
            return newSlide;

        }

        private void BindToDestinationSlider(Parameters name, Slider destination)
        {
            Binding binderNew = new Binding(name.ToString());
            binderNew.Source = Parametry;
            binderNew.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            destination.SetBinding(Slider.ValueProperty, binderNew);


        }

        private void BindToDestinationTXT(Parameters name, TextBox destination)
        {
            Binding binderNew = new Binding(name.ToString())
            {
                Source = Parametry,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            destination.SetBinding(TextBox.TextProperty, binderNew);
        }

        void guzik_Click2uruchom(object sender, RoutedEventArgs e)
        {
           
                AktywujSwarma.StartSimulations(Parametry);

        }

        private void Wyjdz_click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


        private void WyczyscSpawnPoints()
        {
            for (int i = 0; i < AktywujSwarma.SpawnPoints.Count; i++)
            {
                AktywujSwarma.SpawnPoints[i].WybranySpawn = false;
                AktywujSwarma.SpawnPoints[i].Background = Brushes.Transparent;
            }
            AktywujSwarma.SpawnPoints.Clear();
        }


        private void WyczyscBomby()
        {
            for (int i = 0; i < AktywujSwarma.Bombs.Count; i++)
            {
                AktywujSwarma.Bombs[i].WybranaBomba = false;
                AktywujSwarma.Bombs[i].Background = Brushes.Transparent;
            }
            AktywujSwarma.Bombs.Clear();
        }

        private void ClearAllCanvas()
        {
            foreach (var rzad in AktywujSwarma.MyWindow.mapa.Grid)
            {
                foreach(var button in rzad)
                {
                    button.WybranaBomba = false;
                    button.WybranySpawn = false;
                    button.Background = Brushes.Transparent;
                }
            }
        }
        public void ResetIfError()
        {
            ClearAllCanvas();
            WyczyscBomby();
            WyczyscSpawnPoints();
            AktywujSwarma.ResetujCzastki();
            

        }

        private void Resetuj_Click(object sender, RoutedEventArgs e)
        {//make it general
            if (!AktywujSwarma.AnimacjaWTrakcie)
            {
                ClearAllCanvas();
                GC.Collect(); 
                return;
            }
            WyczyscSpawnPoints();
            WyczyscBomby();
            AktywujSwarma.ResetujCzastki();
            GC.Collect();
            AktywujSwarma.AnimacjaWTrakcie = false;
        }
        private void Helper(object sender, RoutedEventArgs e)
        {//make it general
            second main = new second();
            main.ShowDialog();
            
        }
    }
  
    
}
