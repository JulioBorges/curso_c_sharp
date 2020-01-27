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
		Task<IEnumerable<T>> Listar(bool readOnly = false, params string[] includes);

		Task<IEnumerable<T>> Listar(Expression<Func<T, bool>> filtro, bool readOnly = false, params string[] includes);

		Task<T> Primeiro(Guid id, bool readOnly = false, params string[] includes);

		Task<T> Primeiro(Expression<Func<T, bool>> filtro, bool readOnly = false, params string[] includes);

		IQueryable<T> Query(bool readOnly = false, params string[] includes);
	}
}
