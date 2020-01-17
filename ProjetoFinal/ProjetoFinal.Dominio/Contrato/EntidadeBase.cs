using System;

namespace ProjetoFinal.Dominio.Contrato
{
	public abstract class EntidadeBase
	{
		public EntidadeBase() => Id = Guid.NewGuid();

		public Guid Id { get; set; }
	}
}
