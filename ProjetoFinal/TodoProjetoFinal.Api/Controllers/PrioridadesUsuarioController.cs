using ProjetoFinal.Dominio;
using ProjetoFinal.Infraestrutura;
using System;
using System.Linq;
using System.Web.Http;
using TodoProjetoFinal.Api.Models;

namespace TodoProjetoFinal.Api.Controllers
{
    [RoutePrefix("api/usuario/prioridade")]
    public class PrioridadesUsuarioController : ApiController
    {
        private readonly ProjetoFinalContexto _contexto;

        public PrioridadesUsuarioController()
        {
            _contexto = new ProjetoFinalContexto();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]PrioridadeTarefaDTO prioridadeTarefa)
        {
            try
            {
                var existePrioridade = _contexto.Prioridades
                    .Include("Proprietario")
                    .Include("Tarefa")
                    .AsNoTracking()
                    .Any(o => o.Proprietario.Id == prioridadeTarefa.IdProprietario &&
                                o.Tarefa.Id == prioridadeTarefa.IdTarefa);

                if (existePrioridade)
                    return Ok();

                _contexto.Prioridades.Add(new PrioridadesUsuario
                {
                    IdProprietario = prioridadeTarefa.IdProprietario,
                    IdTarefa = prioridadeTarefa.IdTarefa
                });

                _contexto.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody]PrioridadeTarefaDTO prioridadeTarefa)
        {
            try
            {
                var prioridade = _contexto.Prioridades
                    .Include("Proprietario")
                    .Include("Tarefa")
                    .Where(o => o.Proprietario.Id == prioridadeTarefa.IdProprietario &&
                                o.Tarefa.Id == prioridadeTarefa.IdTarefa);

                if (prioridade == null)
                    return Ok();

                _contexto.Prioridades.RemoveRange(prioridade);

                _contexto.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}