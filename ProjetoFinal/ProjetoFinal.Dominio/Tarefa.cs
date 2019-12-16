using ProjetoFinal.Dominio.Contrato;
using ProjetoFinal.Dominio.Enums;
using System;

namespace ProjetoFinal.Dominio
{
	public class Tarefa : EntidadeBase
	{
		public Tarefa() : base()
		{
			DataCriacao = DateTime.Now;
		}

		public string Descricao { get; set; }
		public bool Concluido { get; set; }
		public DateTime DataCriacao { get; set; }
		public NivelCriticidade Criticidade { get; set; }
		public string Observacao { get; set; }
		public Usuario Proprietario { get; set; }
	}
}
