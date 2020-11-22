using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Classes
{
    public static class IntegralCalculations
    {
        public static double f(double x) => Math.Sin(x);
        public static double ff(double x, double a) => Math.Pow(x, a);
        public static double fff(double x) => Math.Cos(x);
        public static double ffff(double x, double a) => Math.Pow(a,x);
        public static double fffff(double x, double a, double b, double c, double d) => a*Math.Pow(x, 3)+b*Math.Pow(x,2)+c*x+d;
        public static double LeftTriangle(Func<double, double> f, double a, double b, int n)
        {
            var h = (b - a) / n;
            var sum = 0d;
            for (var i = 0; i <= n - 1; i++)
            {
                var x = a + i * h;
                sum += f(x);
            }

            var result = h * sum;
            return result;
        }
        public static double LeftTriangle(Func<double, double,double> f, double a, double b, int n, int koef)
        {
            var h = (b - a) / n;
            var sum = 0d;
            for (var i = 0; i <= n - 1; i++)
            {
                var x = a + i * h;
                sum += f(x, koef);
            }

            var result = h * sum;
            return result;
        }
        public static double LeftTriangle(Func<double, double, double, double, double, double> f, double a, double b, int n, int koef1, int koef2, int koef3, int koef4)
        {
            var h = (b - a) / n;
            var sum = 0d;
            for (var i = 0; i <= n - 1; i++)
            {
                var x = a + i * h;
                sum += f(x, koef1, koef2, koef3, koef4);
            }

            var result = h * sum;
            return result;
        }
    }
}
