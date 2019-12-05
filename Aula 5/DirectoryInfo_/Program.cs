using System;
using System.IO;

namespace DirectoryInfo_
{
    internal class Program
    {
        public static void Main()
        {
            DirectoryInfo di = new DirectoryInfo(@"c:\DiretorioTeste");

            try
            {
                if (di.Exists)
                {
                    Console.WriteLine("Diretório já existe.");
                    return;
                }

                di.Create();
                Console.WriteLine("O diretório foi criado com sucesso.");

                di.Delete();
                Console.WriteLine("O diretório foi removido com sucesso.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: {0}", e.ToString());
            }
            finally { }
        }
    }
}