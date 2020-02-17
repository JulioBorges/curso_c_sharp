using ProjetoFinal.Core.Contrato;
using ProjetoFinal.Dominio.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Dominio
{
	public class Tarefa : EntidadeBase
	{
		public Tarefa() : base()
		{
			DataCriacao = DateTime.Now;
		}
		
		[MaxLength(200)]
		public string Descricao { get; set; }
		
		public bool Concluido { get; set; }
		public DateTime DataCriacao { get; set; }
		public NivelCriticidade Criticidade { get; set; }
		
		[MaxLength(1000)]
		public string Observacao { get; set; }
		public virtual Usuario Proprietario { get; set; }
	}
}
