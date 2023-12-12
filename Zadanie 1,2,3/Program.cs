using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadanie_1_2_3
{
    internal class Program
    {

        static void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        static int CalculateSquare(int number)
        {
            return number * number; 
        }
        static async Task<int> CalculateFactorialAsync(int number) 
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(8000);
                int factorial = 1;
                for (int i = 1; i <= number; i++)
                {
                    factorial *= i;
                }
                return factorial;
            });
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1.Необходимо создать программу, где будет реализовано 3 потока. Каждый из потоков будет выводить на экран числа от 1 до 10. Продемонстрировать.");
            Thread thread1 = new Thread(PrintNumbers);
            Thread thread2 = new Thread(PrintNumbers);
            Thread thread3 = new Thread(PrintNumbers);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            Thread.Sleep(100);
            Console.WriteLine("Потоки завершены.");
            Console.WriteLine("Задача 2.Необходимо создать программу, которая будет вычислять факториал от введенного числа и квадрат от введенного числа. Вычисление факториала должно проходить асинхронно, вычисление возведения в квадрат синхронно. В методе для вычислении факториала необходимо задержать поток на 8 с.");
            Console.WriteLine("Введите число:");
            int number = int.Parse(Console.ReadLine());
            int square = CalculateSquare(number);
            Console.WriteLine($"Квадрат числа: {square}");
            int factorial = CalculateFactorialAsync(number).Result;
            Console.WriteLine($"Факториал числа: {factorial}");
            Console.WriteLine("Вычисления завершены.");
            Console.WriteLine("Задача 3. Вы получаете объект и должны вернуть имена всех(!) методов, которые вы нашли для этого объекта.");
            Refi refiObject = new Refi();
            Type myType = refiObject.GetType();
            MethodInfo[] methods = myType.GetMethods();
            Console.WriteLine("Методы:");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
            Console.ReadKey();
        }
    }
}
