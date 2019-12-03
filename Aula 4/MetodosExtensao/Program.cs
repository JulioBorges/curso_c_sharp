using System;

namespace MetodosExtensao
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string teste = "Isso é um teste";

            Console.WriteLine(teste.WordCount());
            Console.ReadKey();
        }
    }
}