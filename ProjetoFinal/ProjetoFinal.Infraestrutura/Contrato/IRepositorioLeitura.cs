using ProjetoFinal.Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjetoFinal.Infraestrutura.Contrato
{
	public interface IRepositorioLeitura<T> 
		where T : EntidadeBase
	{
		Task<IEnumerable<T>> Listar();

		Task<IEnumerable<T>> Listar(Expression<Func<T, bool>> filtro);

		Task<T> Primeiro(Guid id);

		IQueryable<T> Query();
	}
}
