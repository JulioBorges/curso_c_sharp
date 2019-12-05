using System;

namespace Exception
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var resultado = DividirPorZero(3);
                Console.WriteLine(resultado);
            }
            catch
            {
                Console.WriteLine("Não foi possível dividir por zero");
            }

            Console.Read();
        }

        private static double DividirPorZero(int valor)
        {
            return valor / 0;
        }
    }
}