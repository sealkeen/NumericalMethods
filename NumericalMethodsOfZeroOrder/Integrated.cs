using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethodsOfZeroOrder
{
    enum Side { Left, Centre, Right}
    partial class Program
    {
        static double Accuracy { get; set; }  //Точность
        static double Turns { get; set; }     //Количество шагов
        static double Sqr(double x)
        {
            return x * x;
        }
    }
}
