using System;

namespace Heranca
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //ConceitoBasicoHeranca();
            //HerancaComMetodos();
            //QuadradoRetangulo();
            CalcularImpostoInterface();

            Console.Read();
        }

        private static void CalcularImpostoInterface()
        {
            Funcionario func = new Funcionario
            {
                Salario = 3000,
                Nome = "Jose",
                Endereco = "rua 3"
            };
            CalcularImposto(func);

            PessoaFisica pFIsica = new PessoaFisica
            {
                Salario = 15000,
                Nome = "Maria",
                Endereco = "rua 1"
            };
            CalcularImposto(pFIsica);

            Empresa empresa = new Empresa
            {
                Faturamento = 1500000,
                Nome = "Grupo SYM",
                Endereco = "rua 3988"
            };
            CalcularImposto(empresa);
        }

        private static void CalcularImposto(ICalcularImposto calcular)
        {
            Console.WriteLine(calcular.CalcularImposto());
        }

        private static void QuadradoRetangulo()
        {
            Retangulo retangulo = NovoRetangulo();

            Console.WriteLine(retangulo.getArea());
        }

        private static Retangulo NovoRetangulo()
        {
            Retangulo quadrado = new Quadrado();

            quadrado.setAltura(2);
            quadrado.setLargura(3);

            return quadrado;
        }

        private static void ConceitoBasicoHeranca()
        {
            Pessoa pessoa;

            pessoa = new PessoaFisica
            {
                Nome = "Julio",
                Endereco = "Rua 2, 350, Centro",
                Cpf = "0909090909"
            };

            Console.WriteLine(pessoa.ImprimirPessoa());

            pessoa = new PessoaJuridica
            {
                Nome = "Grupo SYM",
                Endereco = "Rua Fortaleza, 170, Industrial",
                Cnpj = "0988434874875-099"
            };

            Console.WriteLine(pessoa.ImprimirPessoa());
        }

        private static void HerancaComMetodos()
        {
            PessoaFisica pFisica = new PessoaFisica()
            {
                Nome = "Julio",
                Endereco = "Rua 2, 350, Centro",
                Cpf = "012.456.785-82",
                Salario = 20000m
            };

            Console.WriteLine(pFisica.CalcularImposto());
            Console.WriteLine(pFisica.CalcularImposto(.10m));

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