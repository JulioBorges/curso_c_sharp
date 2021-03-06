﻿using ProjetoFinal.Core.Contrato;
using ProjetoFinal.Core.Contrato;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ProjetoFinal.Data.Repositorio
{
    public class RepositorioGravacaoEF<T> : IRepositorioGravacao<T>
        where T : EntidadeBase
    {
        private readonly DbContext _contexto;

        public RepositorioGravacaoEF(DbContext contexto)
        {
            _contexto = contexto;
        }

        public T Adicionar(T entidade)
        {
            return _contexto.Set<T>().Add(entidade);
        }

        public IEnumerable<T> AdicionarLista(IEnumerable<T> listaEntidades)
        {
            return _contexto.Set<T>().AddRange(listaEntidades);
        }

        public void Deletar(Guid id)
        {
            var entidade = _contexto.Set<T>().Find(id);
            _contexto.Set<T>().Remove(entidade);
        }

        public void Deletar(T entidade)
        {
            _contexto.Set<T>().Remove(entidade);
        }

        public void DeletarLista(IEnumerable<T> entidades)
        {
            _contexto.Set<T>().RemoveRange(entidades);
        }

        public T Editar(T entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Modified;

            return _contexto.Entry(entidade).Entity;
        }

        public T Editar(T entidadeNoBanco, object entidadeNova)
        {
            _contexto.Entry(entidadeNoBanco)
                .CurrentValues
                .SetValues(entidadeNova);

            return _contexto.Entry(entidadeNoBanco).Entity;
        }

        public async Task GravarDadosAssincronamente()
        {
            await _contexto.SaveChangesAsync();
        }

        public void GravarDadosSincronamente()
        {
            _contexto.SaveChanges();
        }
    }
}