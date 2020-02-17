using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFinal.Core.Contrato
{
    public interface IRepositorioGravacao<T>
        where T : EntidadeBase
    {
        T Adicionar(T entidade);

        IEnumerable<T> AdicionarLista(IEnumerable<T> listaEntidades);

        void Deletar(Guid id);

        void Deletar(T entidade);

        void DeletarLista(IEnumerable<T> entidades);

        T Editar(T entidade);

        T Editar(T entidadeNoBanco, object entidadeNova);

        Task GravarDadosAssincronamente();

        void GravarDadosSincronamente();
    }
}