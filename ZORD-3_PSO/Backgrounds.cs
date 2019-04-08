using System;
using System.Collections.Generic;
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
    class Backgrounds : ICreator
    {
        MenuPSO tapety;

        public Backgrounds(MenuPSO Tapets)
        {
            tapety = Tapets;

        }
        public void Create()
        {
            MenuItem Rysunek;
            Rysunek = tapety.MakeMainButton("Backgrounds", Photos.LiterkaBackGround, 40);
            tapety.MakeButtonToMenuParent("Forest", 30, Photos.Las, MakeLas, Rysunek);
            tapety.MakeButtonToMenuParent("City 1", 30, Photos.Miasto, MakeMiasto, Rysunek);
            tapety.MakeButtonToMenuParent("City 2", 30, Photos.Miasto2, MakeMiasto2, Rysunek);
            tapety.MakeButtonToMenuParent("None", 30, Photos.Brak, Brak, Rysunek);
        }

        private void MakeLas(object sender, RoutedEventArgs e)
        {
            tapety.Swarm.MyWindow.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Obrazki/" + Photos.Las.ToString() + ".png")));
        }
        private void MakeMiasto(object sender, RoutedEventArgs e)
        {
            tapety.Swarm.MyWindow.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Obrazki/" + Photos.Miasto.ToString() + ".png")));
        }
        private void MakeMiasto2(object sender, RoutedEventArgs e)
        {
            tapety.Swarm.MyWindow.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Obrazki/" + Photos.Miasto2.ToString() + ".png")));
        }
        private void Brak(object sender, RoutedEventArgs e)
        {
            tapety.Swarm.MyWindow.Background = Brushes.White;
        }
    }
}
