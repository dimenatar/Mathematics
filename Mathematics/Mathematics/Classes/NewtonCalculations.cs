using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Mathematics.Classes
{
    static class NewtonCalculations
    {
        public static double f(double x, double a) => Math.Cos(x -a);
        public static double ff(double x, double a) => Math.Pow(a, x);
        public static double fff(double x, double a, double b, double c, double d) => a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d;
        public static double fdX(double x, double a) => Math.Sin(a-x);
        public static double ffdX(double x, double a) => Math.Pow(a, x) * Math.Log10(a);

        public static double fffdX(double x, double a, double b, double c) => a*3 * Math.Pow(x, 2) + b*2 * x + c;


        private const double E = 0.00001;
        private const int maxIterations = 100000;
        public static double CosF(double x, double a)
        {
            return (Math.Cos(x-a));
        }
        public static double dFCosF(double x, double a)
        {
            return -(Math.Sin(x-a));
        }
        public static double GetRoot(Func <double, double, double >f, Func<double, double, double> fxd, int FirstB, int SecondB, int koef)
        {
            int counter = 0;
            double x = SecondB;
            if (f(FirstB,koef)*f(SecondB, koef) >0)
            {
                MessageBox.Show("Знаки на концах отрезка одинаковы");
                return 0;
            }
            if (f(FirstB,koef)*fxd(FirstB,koef) >0)
            {
                x = FirstB;
            }
            else
            {
                x = SecondB;
            }
            
            double x1 = f(x, koef) / fxd(x, koef);
            while (Math.Abs(x - x1) >= E && counter < maxIterations)
            {
                x = x1;
                x1 = x - f(x, koef) / fxd(x, koef);
                counter++;
            }
            
            return Math.Round(x,4);
        }
        public static double GetRoot(Func<double, double, double,double,double,double> f, Func<double, double, double, double, double> fdX, int FirstB, int SecondB, int koef1, int koef2,int koef3,int koef4)
        {
            int counter = 0;
            double x = SecondB;
            if (f(FirstB, koef1, koef2, koef3, koef4) * f(SecondB, koef1, koef2, koef3, koef4) > 0)
            {
                MessageBox.Show("Знаки на концах отрезка одинаковы");
                return 0;
            }
            if (f(FirstB, koef1, koef2, koef3, koef4) * fdX(FirstB, koef1, koef2, koef3) > 0)
            {
                x = FirstB;
            }
            else
            {
                x = SecondB;
            }

            double x1 = f(x, koef1, koef2, koef3, koef4) / fdX(x, koef1, koef2, koef3);
            while (Math.Abs(x - x1) >= E && counter < maxIterations)
            {
                x = x1;
                x1 = x - f(x, koef1, koef2, koef3, koef4) / fdX(x, koef1, koef2, koef3);
                counter++;
            }

            return Math.Round(x, 4);
        }
    }
}
