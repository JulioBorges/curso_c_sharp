using System;
using System.Collections.Generic;

namespace Generics
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ImprimirNovoNumero<Dados>(new Dados());
            ImprimirNovoNumero<DadosBinarios>(new DadosBinarios());

            ListaString listaPropria = new ListaString();
            listaPropria.Add("Um");
            listaPropria.Add("Dois");
            listaPropria.Add("Fim");

            ImprimirListaDeString<ListaString>(listaPropria);

            List<string> listaGenerica = new List<string>();
            listaGenerica.Add("Um");
            listaGenerica.Add("Dois");
            listaGenerica.Add("Fim");
            ImprimirListaDeString<List<string>>(listaGenerica);

            Console.ReadKey();
        }

        private class Dados
        {
            public override string ToString()
            {
                return "Dado: " + new Random().Next(1, 1500);
            }
        }

        private class DadosBinarios
        {
            public override string ToString()
            {
                return "Dados Binários: " + Convert.ToString(new Random().Next(1, 1500), 2);
            }
        }

        private static void ImprimirNovoNumero<T>(T dado)
        {
            Console.WriteLine(dado);
        }

        private static void ImprimirNovoNumeroComConstrutor<T>()
            where T : new()
        {
            T dado = new T();
            Console.WriteLine(dado);
        }

        private static void ImprimirListaDeString<T>(T lista)
            where T : IEnumerable<string>
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }

        private class ListaString : List<string>
        {
        }
    }
}