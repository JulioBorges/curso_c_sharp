using Heranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEncapsulamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Encapsulamento enc = new Encapsulamento(45);

            Console.WriteLine(enc.PropriedadePublica);
            Console.ReadKey();
        }
    }
}
