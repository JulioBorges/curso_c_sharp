using ProjetoFinal.Core.Contrato;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Dominio
{
	public class Usuario : EntidadeBase
	{
		[MaxLength(200)]
		public string Nome { get; set; }
		public string Senha { get; set; }
		public bool Conectado { get; set; }
	}
}
