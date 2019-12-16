using ProjetoFinal.Dominio.Contrato;

namespace ProjetoFinal.Dominio
{
	public class Usuario : EntidadeBase
	{
		public string Nome { get; set; }
		public string Senha { get; set; }
	}
}
