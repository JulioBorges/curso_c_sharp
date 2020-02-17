using System;

namespace ProjetoFinal.Core.Contrato
{
	public abstract class EntidadeBase
	{
		public EntidadeBase() => Id = Guid.NewGuid();

		public Guid Id { get; set; }
	}
}
