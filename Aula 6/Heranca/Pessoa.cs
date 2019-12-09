namespace Heranca
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }

        public string ImprimirPessoa() => $"Nome: {Nome}, Endereco: {Endereco}, Tipo: {this.GetType().ToString()}";
    }

    public class PessoaFisica : Pessoa
    {
        public string Cpf { get; set; }
    }

    public class PessoaJuridica : Pessoa
    {
        public string Cnpj { get; set; }
    }
}