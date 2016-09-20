using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethodsOfZeroOrder
{
    partial class Program
    {
        static Side LastSide = Side.None;
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
            fc = 0;                         //Результат вычислений f(centre)

            switch (LastSide) {
                case Side.Centre:
                    fc = FcBuff; break;     //Значение центра берём из буфера
                case Side.Left:
                    fc = Fx1Buff; break;
                case Side.Right:
                    fc = Fx2Buff; break;
                case Side.None:
                    fc = TargetFunction(centre);
                    break;
            }

            if (fc > fx1)
            {
                lineLength = Math.Abs(centre - start); Fx1Buff = fx1;
                end = centre; LastSide = Side.Left;                 //Экстремум функции находится слева от центра, указываем на это
            }
            else
            {
                if (fc > fx2)
                {
                    lineLength = Math.Abs(centre - end); Fx2Buff = fx2;
                    start = centre; LastSide = Side.Right;          //Экстремум функции находится справа от центра, указываем на это
                }
                else
                {
                    lineLength = Math.Abs(x2 - x1); FcBuff = fc;
                    start = x1; end = x2; LastSide = Side.Centre;   //Экстремум функции находится в центре, указываем на это
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
            return (A * x * x) + (B * x);
        }
    }
}
