using ProjetoFinal.Dominio;
using ProjetoFinal.Infraestrutura.Contrato;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TodoProjetoFinal.Api.Models;
using TodoProjetoFinal.Api.ServicesLocator;

namespace TodoProjetoFinal.Api.Controllers
{
    [RoutePrefix("api/usuario/prioridade")]
    public class PrioridadesUsuarioController : ApiController
    {
        private readonly IRepositorioLeitura<PrioridadesUsuario> _repositorioLeitura;
        private readonly IRepositorioGravacao<PrioridadesUsuario> _repositorioGravacao;

        // Aqui usaria injeção de dependencia
        public PrioridadesUsuarioController()
        {
            // Pattern ServiceLocator
            _repositorioLeitura = ServiceLocatorRepositorio
                .InstanciarRepositorioLeitura<PrioridadesUsuario>();

            _repositorioGravacao = ServiceLocatorRepositorio
                .InstanciarRepositorioGravacao<PrioridadesUsuario>();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]PrioridadeTarefaDTO prioridadeTarefa)
        {
            try
            {
                var existePrioridade = await _repositorioLeitura.Existe(o => o.Proprietario.Id == prioridadeTarefa.IdProprietario &&
                                o.Tarefa.Id == prioridadeTarefa.IdTarefa, "Proprietario", "Tarefa");

                if (existePrioridade)
                    return Ok();

                _repositorioGravacao.Adicionar(new PrioridadesUsuario
                {
                    IdProprietario = prioridadeTarefa.IdProprietario,
                    IdTarefa = prioridadeTarefa.IdTarefa
                });

                await _repositorioGravacao.GravarDadosAssincronamente();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody]PrioridadeTarefaDTO prioridadeTarefa)
        {
            try
            {
                var prioridades = await _repositorioLeitura
                    .Listar(filtro: o => o.Proprietario.Id == prioridadeTarefa.IdProprietario &&
                                o.Tarefa.Id == prioridadeTarefa.IdTarefa, includes: new[] { "Proprietario", "Tarefa" });

                if (!prioridades.Any())
                    return Ok();

                _repositorioGravacao.DeletarLista(prioridades);

                await _repositorioGravacao.GravarDadosAssincronamente();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}