using ProjetoFinal.Dominio.Contrato;
using System;

namespace ProjetoFinal.Dominio
{
	public class Auditoria : EntidadeBase
	{
		public Tarefa TarefaAuditada { get; set; }
		public bool Concluido { get; set; }
		public Usuario Proprietario { get; set; }
		public DateTime Data { get; set; }
	}
}
