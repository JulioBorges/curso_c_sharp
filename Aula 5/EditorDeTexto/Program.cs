using System;
using System.IO;

namespace EditorDeTexto
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Bem vindo ao nosso simplório editor de texto");
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1: Criar um novo arquivo");
            Console.WriteLine("; Sair do editor");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case ";":
                    Environment.Exit(0);
                    break;

                case "1":
                    AbrirArquivo();
                    break;

                default:
                    Console.Clear();
                    Main();
                    break;
            }
        }

        private static void AbrirArquivo()
        {
            var arquivo = SelecionarArquivo();

            if (ArquivoExistente(arquivo))
                ManipularArquivo(arquivo);
        }

        private static void ManipularArquivo(string arquivo)
        {
            using (StreamWriter sw = File.CreateText(arquivo))
            {
                char c;
                do
                {
                    c = Convert.ToChar(Console.Read());

                    if (c == ';')
                        continue;

                    sw.Write(c);
                } while (c != ';');
            }
        }

        private static bool ArquivoExistente(string arquivo)
        {
            if (!File.Exists(arquivo))
            {
                Console.WriteLine("Arquivo Inexistente, o editor será fechado");
                Console.ReadKey();
                return false;
            }

            return true;
        }

        private static string SelecionarArquivo()
        {
            Console.Clear();
            Console.WriteLine("Digite o caminho completo do arquivo");
            return Console.ReadLine();
        }
    }
}