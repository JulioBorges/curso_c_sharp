using ProjetoFinal.Core.Contrato;
using ProjetoFinal.Core.Contrato;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjetoFinal.Data.Repositorio
{
    public class RepositorioLeituraEF<T> : IRepositorioLeitura<T>
        where T : EntidadeBase
    {
        private readonly DbContext _contexto;

        public RepositorioLeituraEF(DbContext contexto) =>
            _contexto = contexto;

        public async Task<IEnumerable<T>> Listar(bool readOnly = false, params string[] includes) =>
            await Query(readOnly, includes).ToListAsync();

        public async Task<IEnumerable<T>> Listar(Expression<Func<T, bool>> filtro, bool readOnly = false, params string[] includes) =>
            await Query(readOnly, includes)
                .Where(filtro)
                .ToListAsync();

        public async Task<bool> Existe(Expression<Func<T, bool>> filtro, params string[] includes) =>
            await Query(true, includes).AnyAsync(filtro);

        public async Task<T> Primeiro(Guid id, bool readOnly = false, params string[] includes) =>
            await Query(readOnly, includes)
                .FirstOrDefaultAsync(o => o.Id == id);

        public async Task<T> Primeiro(Expression<Func<T, bool>> filtro, bool readOnly = false, params string[] includes) =>
            await Query(readOnly, includes)
                .FirstOrDefaultAsync(filtro);

        public IQueryable<T> Query(bool readOnly = false, params string[] includes)
        {
            DbQuery<T> query = _contexto.Set<T>();

            if (includes.Length > 0)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }

            if (readOnly)
                return query.AsNoTracking();

            return query;
        }
    }
}