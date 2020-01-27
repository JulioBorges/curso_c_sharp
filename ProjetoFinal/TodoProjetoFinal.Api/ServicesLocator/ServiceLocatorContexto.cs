using ProjetoFinal.Infraestrutura;
using System.Data.Entity;

namespace TodoProjetoFinal.Api.ServicesLocator
{
    public static class ServiceLocatorContexto
    {
        private static DbContext _contextoInterno;

        // Pattern Singleton
        public static DbContext InstanciarContexto()
        {
            if (_contextoInterno == null)
                _contextoInterno = new ProjetoFinalContexto();

            return _contextoInterno;
        }
    }
}