using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Classes
{
    static class NewtonCalculations
    {
        public static double F(double x, double a)
        {
            return (Math.Cos(x-a));
        }
        public static double dFdx(double x, double a)
        {
            return (Math.Sin(a - x));
        }
   }
}
