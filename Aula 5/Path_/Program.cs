using System;
using System.IO;

namespace Path_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string path1 = @"c:\temp\MyTest.txt";
            string path2 = @"c:\temp\MyTest";
            string path3 = @"temp";

            if (Path.HasExtension(path1))
            {
                Console.WriteLine("{0} Possui extensão.", path1);
            }

            if (!Path.HasExtension(path2))
            {
                Console.WriteLine("{0} Não possui extensão.", path2);
            }

            if (!Path.IsPathRooted(path3))
            {
                Console.WriteLine("A string {0} não é um diretório raiz.", path3);
            }

            Console.WriteLine("O Path completo do arquivo {0} é {1}.", path3, Path.GetFullPath(path3));
            Console.WriteLine("{0} é o diretório temporário do sistema.", Path.GetTempPath());
            Console.WriteLine("{0} é um arquivo temporário pronto para uso.", Path.GetTempFileName());

            Console.Read();
        }
    }
}