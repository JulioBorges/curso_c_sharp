using System;

namespace ExpressoesLambdaDelegates
{
    internal class Program
    {
        public delegate void Teste();

        public delegate int Teste2();

        public delegate int Teste3(int param);

        public static void Main(string[] args)
        {
            //Teste teste = MetodoTeste;
            //teste();

            //teste = () => Console.WriteLine("lambda");

            //teste();

            // método local
            //int CountLetters(string str)
            //{
            //    return str.Length;
            //}

            //string teste = "testes de contagem de letras";
            //Console.WriteLine(CountLetters(teste));

            //// Lambda e delegate
            //Func<string, int> countLetters = (str) => str.Length;

            //Console.WriteLine(countLetters(teste));

            //Console.ReadKey();
            int tipoValidacao = int.Parse(Console.ReadLine());
            Processamento processamento;
            if (tipoValidacao == 1)
                processamento = new Processamento(ExibirComQUebra);
            else
                processamento = new Processamento(ExibirSemQUebra);

            processamento.Processar(10);
            Console.ReadKey();
        }

        public static void ExibirComQUebra(string info) => Console.WriteLine(info);

        public static void ExibirSemQUebra(string info) => Console.Write(info);

        public static void MetodoTeste()
        {
            Console.WriteLine("teste");
        }
    }
}