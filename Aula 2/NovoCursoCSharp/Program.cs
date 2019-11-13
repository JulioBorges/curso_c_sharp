using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoCursoCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Pré-Incremento:\n");

            //int x = 0;
            //Console.WriteLine("x = " + x);

            //Console.WriteLine("\n++x +20 = \n");
            //Console.WriteLine(++x + 20 + "\n");

            //Console.WriteLine("\nPós-Incremento:\n");
            //x = 0;

            //Console.WriteLine("\nx++ +20 = \n");
            //Console.WriteLine(x++ + 20 + "\n");

            //Console.WriteLine("\nPré-Decremento:\n");
            //x = 0;

            //Console.WriteLine("x = " + x);

            //Console.WriteLine("\n--x +20 = \n");
            //Console.WriteLine(--x + 20 + "\n");

            //Console.WriteLine("\nPós-Decremento:\n");
            //x = 0;

            //Console.WriteLine("\nx-- +20 = \n");
            //Console.WriteLine(x-- + 20 + "\n");

            //Console.ReadKey();

            //int a = 2, b = 1;

            //if (a > b)
            //    Console.WriteLine("Maior");
            //else
            //    Console.WriteLine("Menor");

            ////var retorno = (a > b)
            ////    ? a + " é Maior que " + b
            ////    : a + " é Menor que " + b;

            //var retorno = (a > b)
            //    ? $"{a} é Maior que {b}"
            //    : $"{a} é Menor que {b}";

            //Console.WriteLine(retorno);

            //decimal dinheiro = 10_000_000_00.52m;
            //string testeDinheiro = $"Eu queria ter {dinheiro:c3} na minha conta bancária";
            //Console.WriteLine(testeDinheiro);


            //Console.ReadKey();

            //DateTime hoje = DateTime.Now;
            //Console.WriteLine(hoje);

            //DateTime lancamentoBackToTheFuture = new DateTime(1985, 12, 25);
            //Console.WriteLine(lancamentoBackToTheFuture);

            //Console.WriteLine($"Now: {hoje:f}");
            //Console.WriteLine($"Back to the Future: {lancamentoBackToTheFuture:F}");


            //TimeSpan tsInstance = new TimeSpan();
            //Console.WriteLine(tsInstance);
            //// Ticks == Cem Nanosegundos;
            //TimeSpan tsInstance1 = new TimeSpan(1);
            //Console.WriteLine(tsInstance1);
            //// HH:mm:ss
            //TimeSpan tsInstance2 = new TimeSpan(7, 36, 10);
            //Console.WriteLine(tsInstance2);
            //// dd-HH:mm:ss
            //TimeSpan tsInstance3 = new TimeSpan(8, 2, 50, 10);
            //Console.WriteLine(tsInstance3);
            //// dd-HH:mm:ss.mmm (Milissegundos)
            //TimeSpan tsInstance4 = new TimeSpan(4, 7, 36, 10, 100);
            //Console.WriteLine(tsInstance4);

            //Console.ReadKey();

            string a = null;

            int? b = a?.Length;

            int? c = b ?? 4;


            var d = default(decimal);

            Console.WriteLine(b);
            Console.ReadKey();
        }
    }
}
