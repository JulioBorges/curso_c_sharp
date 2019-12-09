using System;
using System.IO;

namespace Exception_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var resultado = DividirPorZero(3);
                Console.WriteLine(resultado);
            }
            catch (Exception dii)
            {
                LogException(dii);
            }
            finally
            {
                Console.WriteLine("Fechou a aplicação");
                Console.Read();
            }
        }

        private static bool LogException(Exception ex)
        {
            File.WriteAllText("C:\\Erro.log", ex.Message);
            return true;
        }

        private static double DividirPorZero(int valor)
        {
            try
            {
                return valor / 0;
            }
            catch (DivideByZeroException dii)
            {
                Console.WriteLine("Não foi possível dividir por zero");
                throw dii;
            }
        }
    }
}