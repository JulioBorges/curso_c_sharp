using ProjetoFinal.Dominio.Contrato;
using System.Collections.Generic;

namespace ProjetoFinal.Dominio
{
	public class PrioridadesUsuario : EntidadeBase
	{
		public Usuario Proprietario { get; set; }
		public IEnumerable<Tarefa> Tarefas { get; set; }
	}
}
