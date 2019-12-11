namespace Heranca
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }

        public string ImprimirPessoa() => $"Nome: {Nome}, Endereco: {Endereco}, Tipo: {this.GetType().ToString()}";

        public abstract string ImprimirResumido();
    }

    public class PessoaFisica : Pessoa, ICalcularImposto
    {
        public string Cpf { get; set; }

        public decimal Salario { get; set; }

        public decimal CalcularImposto(decimal percentual) =>
            this.Salario * percentual;

        public virtual decimal CalcularImposto() =>
            CalcularImposto(.25m);

        public override string ImprimirResumido()
        {
            throw new System.NotImplementedException();
        }
    }

    public class PessoaJuridica : Pessoa
    {
        public string Cnpj { get; set; }
        public decimal Faturamento { get; set; }

        public override string ImprimirResumido()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Empresa : PessoaJuridica, ICalcularImposto
    {
        public decimal CalcularImposto()
        {
            return Faturamento * .4m;
        }
    }

    public sealed class Funcionario : PessoaFisica
    {
        public string CTPS { get; set; }

        public sealed override decimal CalcularImposto()
        {
            var calculoOriginal = base.CalcularImposto();

            return calculoOriginal * .16m;
        }
    }

    class FuncionarioCopia : Funcionario
    {
        public override decimal CalcularImposto()
        {
            return 0;
        }
    }

    public interface ICalcularImposto
    {
        decimal CalcularImposto();
    }
}