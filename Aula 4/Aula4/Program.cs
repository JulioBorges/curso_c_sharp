using System;

namespace Aula4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string operacao = "";

            while (operacao != "S")
            {
                Console.WriteLine("Digite a operação desejada ([+], [-], [*], [/]");
                operacao = Console.ReadLine();

                decimal InfoDoUsuario(string msg)
                {
                    Console.WriteLine(msg);
                    return Convert.ToDecimal(Console.ReadLine());
                };

                decimal valorA = InfoDoUsuario("Digite o primeiro valor");
                decimal valorB = InfoDoUsuario("Digite o segundo valor");

                var acao = RetornaAcao(operacao);
                decimal resultado = acao(valorA, valorB);

                Console.WriteLine($"O resultado é: {resultado}");

                Console.WriteLine("Deseja sair da calculadora? (S ou N)");
                operacao = Console.ReadLine();
                Console.Clear();
            }
        }

        public static Func<decimal, decimal, decimal> RetornaAcao(string operacao)
        {
            switch (operacao)
            {
                case "+":
                    return CalculadoraHelper.CalcularSoma;

                case "-":
                    return CalculadoraHelper.CalcularSubtracao;

                case "*":
                    return CalculadoraHelper.CalcularMultiplicacao;

                case "/":
                    return CalculadoraHelper.CalcularDivisao;

                default:
                    throw new Exception("Operação inválida");
            }
        }
    }
}