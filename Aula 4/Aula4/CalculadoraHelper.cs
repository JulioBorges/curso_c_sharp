namespace Aula4
{
    public static class CalculadoraHelper
    {
        public static decimal CalcularSoma(decimal valorA, decimal valorB) =>
            valorA + valorB;

        public static decimal CalcularSubtracao(decimal valorA, decimal valorB) =>
            valorA - valorB;

        public static decimal CalcularMultiplicacao(decimal valorA, decimal valorB) =>
            valorA - valorB;

        public static decimal CalcularDivisao(decimal valorA, decimal valorB)
        {
            if (valorB == 0)
                return 0;

            return valorA / valorB;
        }
    }
}