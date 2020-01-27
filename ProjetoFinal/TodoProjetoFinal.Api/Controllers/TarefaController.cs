using ProjetoFinal.Dominio;
using ProjetoFinal.Infraestrutura;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace TodoProjetoFinal.Api.Controllers
{
    [RoutePrefix("api/tarefa")]
    public class TarefaController : ApiController
    {
        private readonly ProjetoFinalContexto _contexto;

        public TarefaController()
        {
            _contexto = new ProjetoFinalContexto();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                var retorno = _contexto.Tarefas
                    .Include("Proprietario")
                    .AsNoTracking();

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                var retorno = _contexto.Tarefas
                    .AsNoTracking()
                    .FirstOrDefault(tarefa => tarefa.Id == id);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/Auditoria")]
        public IHttpActionResult GetAuditoria(Guid id)
        {
            try
            {
                var retorno = _contexto.Auditoria
                    .Include("TarefaAuditada")
                    .AsNoTracking()
                    .Where(tarefa => tarefa.TarefaAuditada.Id == id);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Tarefa tarefa)
        {
            try
            {
                var tarefaExiste = _contexto.Tarefas.AsNoTracking()
                        .Any(o => o.Id == tarefa.Id);

                if (tarefaExiste)
                    return Conflict();

                _contexto.Tarefas.Add(tarefa);
                _contexto.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(Guid id, [FromBody]Tarefa tarefa)
        {
            try
            {
                var tarefaNoBanco = _contexto.Tarefas
                        .FirstOrDefault(t => t.Id == id);

                if (tarefaNoBanco == null)
                    return NotFound();

                _contexto.Entry(tarefaNoBanco).CurrentValues
                    .SetValues(tarefa);

                _contexto.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}/alterarConclusao/{concluido}")]
        public IHttpActionResult Patch(Guid id, bool concluido)
        {
            try
            {
                var tarefaNoBanco = _contexto.Tarefas
                        .FirstOrDefault(t => t.Id == id);

                if (tarefaNoBanco == null)
                    return NotFound();

                tarefaNoBanco.Concluido = concluido;
                _contexto.Entry(tarefaNoBanco).State = EntityState.Modified;

                _contexto.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                var tarefaNoBanco = _contexto.Tarefas
                        .FirstOrDefault(u => u.Id == id);

                if (tarefaNoBanco == null)
                    return NotFound();

                _contexto.Tarefas.Remove(tarefaNoBanco);

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