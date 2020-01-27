using ProjetoFinal.Dominio;
using ProjetoFinal.Infraestrutura;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace TodoProjetoFinal.Api.Controllers
{
    [RoutePrefix("api/tarefa/auditoria")]
    public class AuditoriaController : ApiController
    {
        private readonly ProjetoFinalContexto _contexto;

        public AuditoriaController()
        {
            _contexto = new ProjetoFinalContexto();
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                var retorno = _contexto.Tarefas
                    .Include("TarefaAuditada")
                    .Include("Proprietario")
                    .AsNoTracking()
                    .FirstOrDefault(o => o.Id == id);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Auditoria auditoria)
        {
            try
            {
                var auditoriaNoBanco = _contexto.Auditoria
                    .Include("Proprietario")
                    .Include("TarefaAuditada")
                    .FirstOrDefault(audit => audit.Proprietario.Id == auditoria.Proprietario.Id &&
                                    audit.TarefaAuditada.Id == auditoria.TarefaAuditada.Id &&
                                    audit.Concluido);

                if (auditoriaNoBanco != null)
                {
                    auditoriaNoBanco.Concluido = auditoria.Concluido;
                    _contexto.Entry(auditoria).State = EntityState.Modified;
                }
                else
                {
                    _contexto.Auditoria.Add(auditoria);
                }

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