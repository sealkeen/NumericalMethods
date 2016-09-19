using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethodsOfZeroOrder
{
    partial class Program
    {
        static Side LastSide;
        static double A = -2, B = 3;

        static void Main(string[] args)
        {
            Accuracy = 0; //Точность
            while (Accuracy <= 0)
            {
                Console.WriteLine("Set another accuracy.");
                try { Accuracy = Convert.ToDouble(Console.ReadLine()); } catch { }
            }

            double result = PerformDichotomy(A, B);
            Console.WriteLine("Result is {0} after {1} trys", result, Turns);
            Console.ReadKey();
        }

        static double PerformDichotomy(double start, double end)
        {
            Turns++;                        
            double lineLength = 0,          //Длина Отрезка
            centre = (start + end) / 2,     //Центральная точка
            x1 = (start + centre) / 2,      //Центр левой половины
            x2 = (centre + end) / 2,        //Центр правой половины
            fx1 = TargetFunction(x1),       //Результат вычислений f(x1)
            fx2 = TargetFunction(x2),       //Результат вычислений f(x2) 
             fc = TargetFunction(centre);   //Результат вычислений f(c)
            if (fc > fx1)
            {
                lineLength = Math.Abs(centre - start);
                end = centre; LastSide = Side.Left; //Экстремум функции находится слева от центра, указываем на это
            }
            else
            {
                if (fc > fx2)
                {
                    lineLength = Math.Abs(centre - end);
                    start = centre; LastSide = Side.Right; //Экстремум функции находится справа от центра, указываем на это
                }
                else
                {
                    lineLength = Math.Abs(x2 - x1);
                    start = x1; end = x2;
                }
            }
            if (lineLength >= Accuracy)
                return PerformDichotomy(start, end);
            else
                switch (LastSide)
                {
                    case Side.Left: return start;
                    case Side.Right: return end;
                    default: return centre;
                }
        }
        static double TargetFunction(double x)
        {
            return (A * Sqr(x)) + (B * x);
        }
    }
}
