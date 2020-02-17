using Flurl;
using Flurl.Http;
using ProjetoFinal.Dominio;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace TodoProjetoFinal.Repositorio
{
    public class RepositorioTarefa
    {
        private string URL_API;

        public RepositorioTarefa()
        {
            URL_API = ConfigurationManager.AppSettings["URL_API"];
        }

        public async Task<IEnumerable<Tarefa>> ListarTarefas()
        {
            return await URL_API
                .AppendPathSegment("api/Tarefa")
                .GetJsonAsync<IEnumerable<Tarefa>>();
        }
    }
}
