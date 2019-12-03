using System;
using System.Linq;

namespace Repeticao
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine("For");
            //For();
            SwitchCase(TipoInformacao.Outros);
            //Console.WriteLine("Foreach");
            //ForEach();
            //Console.WriteLine("While");
            //While();
            //Console.WriteLine("Do while");
            //DoWhile();
            Console.ReadKey();
        }

        private static void SwitchCase(TipoInformacao valor)
        {
            switch (valor)
            {
                case TipoInformacao.Numero:
                    {
                        Console.WriteLine("Numero");
                        break;
                    }
                case TipoInformacao.Texto:
                    {
                        Console.WriteLine("Texto");
                        break;
                    }
                case TipoInformacao.Outros:
                    Console.WriteLine("Outros");
                    break;
            }
        }

        private static void DoWhile()
        {
            int i = 5;

            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < 5);
        }

        private static void While()
        {
            int i = 5;

            while (i < 5)
            {
                Console.WriteLine(i);
                i++;
            }
        }

        private static void ForEach()
        {
            foreach (int item in Enumerable.Range(0, 5))
            {
                Console.WriteLine(item);
            }
        }

        private static void For()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }

            for (int i = 4; i >= 0; i--)
            {
                Console.WriteLine(i);
            }

            string[,] matriz = new string[2, 2];

            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                    break;

                for (int j = 0; j < 2; j++)
                {
                    matriz[i, j] = $"i: {i}, j:{j}";
                }
            }

            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                    return;

                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine(matriz[i, j]);
                }
            }

            Console.WriteLine("Fechou dentro do método");
        }
    }
}