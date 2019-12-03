using System;
using System.IO;

namespace File_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var arquivo = "C:\\teste.txt";

            if (!File.Exists(arquivo))
            {
                Console.WriteLine("Arquivo inexistente, deseja criá-lo e escrever um texto nele (S/N)?");
                var escreverArquivo = Console.ReadLine() == "S";

                if (!escreverArquivo)
                    return;

                EscreverArquivo(arquivo);
            }

            LerArquivo(arquivo);
        }

        private static void EscreverArquivo(string arquivo)
        {
            using (StreamWriter sw = File.CreateText(arquivo))
            {
                sw.WriteLine("Opa");
                sw.WriteLine("To escrevendo");
                sw.Write("Alguma coisa\r\n");
                sw.WriteLine("Neste arquivo");
            }
        }

        private static void LerArquivo(string arquivo)
        {
            using (StreamReader sr = File.OpenText(arquivo))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}