using ProjetoFinal.Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFinal.Infraestrutura.Contrato
{
	public interface IRepositorioGravacao<T> 
		where T : EntidadeBase
	{
		T Adicionar(T entidade);

		IEnumerable<T> AdicionarLista(IEnumerable<T> listaEntidades);

		void Deletar(Guid id);

		void Deletar(T entidade);

		T Editar(T entidade);

		Task GravarDadosAssincronamente();

		void GravarDadosSincronamente();
	}
}
