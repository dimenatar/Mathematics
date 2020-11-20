using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Classes
{
    static class NewtonCalculations
    {
        public static double Cos()
        {
            double Xn = 0.0, X = 0.0;
            double f(double x)
            {
                return Math.Cos(2 / x) - 2 * Math.Sin(1 / x) + 1 / x;
            }
            double find(double a, double b, double e)
            {
                double E = 0.0;
                Xn = b; //Здесь сами подумаете
                do
                {
                    X = Xn - f(Xn) * e / (f(Xn + e) - f(Xn));
                    E = Math.Abs(X - Xn);
                    Xn = X;
                } while (E > e);
                return X;
            }
        }
    }
}
