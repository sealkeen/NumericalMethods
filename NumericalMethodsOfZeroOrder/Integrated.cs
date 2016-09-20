using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethodsOfZeroOrder
{
    enum Side { Left, Centre, Right, None }
    partial class Program
    {
        static double Accuracy { get; set; }  //Точность
        static double Turns { get; set; }     //Количество шагов
        static double FcBuff { get; set; }    //Буфер f(c)
        static double Fx1Buff { get; set; }    //Буфер f(x1)
        static double Fx2Buff { get; set; }    //Буфер f(x2)
        static double Sqr(double x)
        {
            return x * x;
        }

    }
}
