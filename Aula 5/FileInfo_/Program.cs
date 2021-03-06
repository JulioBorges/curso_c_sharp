﻿using System;
using System.IO;

namespace FileInfo_
{
    internal class Program
    {
        public static void Main()
        {
            string path = Path.GetTempFileName();
            var fi1 = new FileInfo(path);

            using (StreamWriter sw = fi1.CreateText())
            {
                sw.WriteLine("Criando um arquivo");
            }

            using (StreamReader sr = fi1.OpenText())
            {
                var s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

            fi1.MoveTo("teste.txt");

            try
            {
                string path2 = Path.GetTempFileName();
                var fi2 = new FileInfo(path2);

                fi2.Delete();

                fi1.CopyTo(path2);
                Console.WriteLine($"{path} foi copiado para {path2}.");

                fi2.Delete();
                Console.WriteLine($"{path2} foi excluído com sucesso.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao processar o arquivo: {e.ToString()}");
            }
        }
    }
}