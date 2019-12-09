using System;

namespace Heranca
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ConceitoBasicoHeranca();
            HerancaComMetodos();

            Console.Read();
        }

        private static void ConceitoBasicoHeranca()
        {
            Pessoa pessoa;

            pessoa = new PessoaFisica
            {
                Nome = "Julio",
                Endereco = "Rua 2, 350, Centro"
            };

            Console.WriteLine(pessoa.ImprimirPessoa());

            pessoa = new PessoaJuridica
            {
                Nome = "Grupo SYM",
                Endereco = "Rua Fortaleza, 170, Industrial"
            };

            Console.WriteLine(pessoa.ImprimirPessoa());
        }

        private static void HerancaComMetodos()
        {
            PessoaFisica pFisica = new PessoaFisica()
            {
                Nome = "Julio",
                Endereco = "Rua 2, 350, Centro",
                Cpf = "012.456.785-82"
            };

            Imprimir(pFisica);

            PessoaJuridica pJuridica = new PessoaJuridica
            {
                Nome = "Grupo SYM",
                Endereco = "Rua Fortaleza, 170, Industrial",
                Cnpj = "6658.47875.1212-00001/54"
            };

            Imprimir(pJuridica);
        }

        private static void Imprimir(Pessoa pessoa)
        {
            Console.WriteLine(pessoa.ImprimirPessoa());
        }
    }
}