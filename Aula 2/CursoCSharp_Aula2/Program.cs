using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp_Aula2
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a = 10;
            //short b = 9;

            //Console.WriteLine("Max Values");
            //Console.WriteLine(short.MaxValue);
            //Console.WriteLine(int.MaxValue);
            //Console.WriteLine(long.MaxValue);

            //Console.WriteLine("Min Values");
            //Console.WriteLine(short.MinValue);
            //Console.WriteLine(int.MinValue);
            //Console.WriteLine(long.MinValue);

            float c = 10;
            //float c2 = c / 3;
            //// Console.WriteLine(c2);

            //double d = 10;

            //Console.WriteLine("Max Values");
            //Console.WriteLine(float.MaxValue);
            //Console.WriteLine(double.MaxValue);

            //Console.WriteLine("Min Values");
            //Console.WriteLine(float.MinValue);
            //Console.WriteLine(double.MinValue);

            //decimal d;
            //d = 1_000_000_000_000.59m;

            //Console.WriteLine("Max Values");
            //Console.WriteLine(decimal.MaxValue);

            //Console.WriteLine("Min Values");
            //Console.WriteLine(decimal.MinValue);

            //decimal e = d / 3.76m;
            //Console.WriteLine(e.ToString("#.0000000000000000000000"));

            //char ch = '0';
            //string str = "Este é um texto";

            //char letra = str[5];
            //Console.WriteLine(letra);

            //var espaco = str.IndexOf(' ');

            //Console.WriteLine(espaco);

            //string[] palavras = str.Split(' ');

            //for (int i = 0; i < palavras.Length; i++)
            //{
            //    Console.WriteLine(palavras[i]);
            //}

            const decimal pi = 3.1445578692m;

            var teste = 2m;
            teste %= .5m;

            Console.WriteLine(teste);

            Console.Read();
        }

    }
}
