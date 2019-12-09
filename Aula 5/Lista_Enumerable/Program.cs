using System;
using System.Collections.Generic;
using System.Linq;

namespace Lista_Enumerable
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lista = new List<string>()
            {
                "Julio",
                "Bruno",
                "Matheus",
                "Juan"
            };

            var filtradoEnum = lista.Where(a => ComecaComJota(a, "enumerable"));

            filtradoEnum = filtradoEnum.Where(a => TerminaComO(a));
            
            var filtradoLista = lista.Where(a => ComecaComJota(a, "lista")).ToList();

            foreach (var itemb in filtradoEnum)
                Console.WriteLine(itemb);

            foreach (var item in filtradoLista)
                Console.WriteLine(item);

            Console.ReadKey();
        }

        private static bool ComecaComJota(string a, string origem)
        {
            Console.WriteLine($"Filtrando {a} na origem {origem}");
            return a.StartsWith("J");
        }

        private static bool TerminaComO(string a)
        {
            return a.EndsWith("o");
        }
    }
}