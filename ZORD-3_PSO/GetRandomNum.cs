using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZORD_3_PSO
{
    //done

    class GetRandomNum
    {
        public static double GetDoubleNum()
        {
            int seed = Guid.NewGuid().GetHashCode();
            RandomMersenne mDouble = new RandomMersenne((uint)seed);
            return mDouble.Random();
        }
        public static int GetIntNumber(int min, int max)
        {
            int seed = Guid.NewGuid().GetHashCode();
            RandomMersenne mInt = new RandomMersenne((uint)seed);
            return mInt.IRandom(min, max);
        }
    }
}
