using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZORD_3_PSO
{
    //done

    class Pooint
    {
        int x;
        int y;
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
        public Pooint(int x, int y)
        {
            X = x;
            Y = y;

        }
        public Pooint()
        {

        }
    }
}
