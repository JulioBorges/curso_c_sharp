using System;
using System.IO;

namespace Directory_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var diretorio = Directory.GetCurrentDirectory();
            Console.WriteLine($"Diretório atual: {diretorio}");

            var arquivos = Directory.GetFiles(diretorio);
            Console.WriteLine($"Quantidade de arquivos: {arquivos.Length}");

            foreach (var arquivo in arquivos)
                Console.WriteLine(arquivo);

            foreach (var arquivo in Directory.EnumerateFileSystemEntries(@"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE", "*.*", SearchOption.AllDirectories))
                Console.WriteLine(arquivo);

            Console.Read();
        }
    }
}