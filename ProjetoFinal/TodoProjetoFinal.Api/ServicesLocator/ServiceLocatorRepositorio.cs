using ProjetoFinal.Data.Repositorio;
using ProjetoFinal.Core.Contrato;
using ProjetoFinal.Core.Contrato;

namespace TodoProjetoFinal.Api.ServicesLocator
{
    public static class ServiceLocatorRepositorio
    {
        public static IRepositorioLeitura<T> InstanciarRepositorioLeitura<T>()
            where T : EntidadeBase
        {
            return new RepositorioLeituraEF<T>(ServiceLocatorContexto.InstanciarContexto());
        }

        public static IRepositorioGravacao<T> InstanciarRepositorioGravacao<T>()
            where T : EntidadeBase
        {
            return new RepositorioGravacaoEF<T>(ServiceLocatorContexto.InstanciarContexto());
        }
    }
}