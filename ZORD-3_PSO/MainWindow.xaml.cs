using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ZORD_3_PSO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ControllerPSO PSO;

        public Map mapa;
        public MainWindow()
        {


            

            InitializeComponent();
            
            PSO = new ControllerPSO(this);

            Dispatcher.UnhandledException += eventHandler;
        }

        private void eventHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("ERROR occurred: " + e.Exception.Message, "ERROR!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            PSO.MenuPso.ResetIfError();
            e.Handled = true;

        }
        

        
    }
}
