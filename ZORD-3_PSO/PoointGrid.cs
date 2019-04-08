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
    //done
//To be refaktored
    public class PoointGrid:Button
	{
		bool wybranaBomba;
        bool wybranySpawn;
		int x;
		int y;
        public PoointGrid(int x, int y)
        {
            X = x;
            Y = y;
        }
        public PoointGrid()
        {
            
        }
        public int X
		{
			get { return x; }
			set { x = value; }
		}
		public int Y
		{
			get { return y; }
			set { y = value; }
		}
		public bool WybranaBomba
		{
			get { return wybranaBomba; }
			set { wybranaBomba = value; }
		}
        public bool WybranySpawn
        {
            get { return wybranySpawn; }
            set { wybranySpawn = value; }
        }
    }
}
