using ProjetoFinal.Dominio;
using ProjetoFinal.Infraestrutura;
using ProjetoFinal.Infraestrutura.Contrato;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TodoProjetoFinal.Api.ServicesLocator;

namespace TodoProjetoFinal.Api.Controllers
{
    [RoutePrefix("api/tarefa/auditoria")]
    public class AuditoriaController : ApiController
    {
        private readonly IRepositorioLeitura<Auditoria> _repositorioLeitura;
        private readonly IRepositorioGravacao<Auditoria> _repositorioGravacao;

        // Aqui usaria injeção de dependencia
        public AuditoriaController()
        {
            // Pattern ServiceLocator
            _repositorioLeitura = ServiceLocatorRepositorio
                .InstanciarRepositorioLeitura<Auditoria>();
            
            _repositorioGravacao = ServiceLocatorRepositorio
                .InstanciarRepositorioGravacao<Auditoria>();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            try
            {
                var retorno = await _repositorioLeitura
                    .Primeiro(id, true, "TarefaAuditada", "Proprietario");

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]Auditoria auditoria)
        {
            try
            {
                var auditoriaNoBanco = await _repositorioLeitura
                    .Primeiro(audit => audit.Proprietario.Id == auditoria.Proprietario.Id &&
                                    audit.TarefaAuditada.Id == auditoria.TarefaAuditada.Id &&
                                    audit.Concluido, false, "Proprietario", "TarefaAuditada");

                if (auditoriaNoBanco != null)
                {
                    auditoriaNoBanco.Concluido = auditoria.Concluido;
                    auditoria = _repositorioGravacao.Editar(auditoriaNoBanco);
                }
                else
                {
                    auditoria = _repositorioGravacao.Adicionar(auditoria);
                }

                await _repositorioGravacao.GravarDadosAssincronamente();
                
                return Ok(auditoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}