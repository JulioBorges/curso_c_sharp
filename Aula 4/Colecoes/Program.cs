using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Colecoes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Vetor();
            Lista();
            Enumerable();
        }

        private static void Enumerable()
        {
            IEnumerable<int> enumeracao = new int[] { 0, 1, 2, 3, 4 };

            enumeracao = new List<int>
            {
                0,
                1,
                2,
                3,
                4
            };

            enumeracao = new Collection<int>()
            {
                0,
                1,
                2,
                3,
                4
            };
        }

        private static void Lista()
        {
            List<int> lista = new List<int>();

            lista.Add(0);
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            lista.Add(4);

            lista = new List<int>
            {
                0,
                1,
                2,
                3,
                4
            };
        }

        private static void Vetor()
        {
            int[] vetorInt = new int[5];
            vetorInt[0] = 0;
            vetorInt[1] = 1;
            vetorInt[2] = 2;
            vetorInt[3] = 3;
            vetorInt[4] = 4;

            vetorInt = new int[] { 0, 1, 2, 3, 4 };
        }
    }
}