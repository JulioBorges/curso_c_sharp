using ProjetoFinal.Dominio.Contrato;
using System;

namespace ProjetoFinal.Dominio
{
	public class AuditoriaLogin : EntidadeBase
	{
		public Usuario UsuarioLogado { get; set; }
		public DateTime Data { get; set; }
		public bool Logou { get; set; }
	}
}
