using ProjetoFinal.Dominio;
using ProjetoFinal.Core.Contrato;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using TodoProjetoFinal.Api.ServicesLocator;

namespace TodoProjetoFinal.Api.Controllers
{
    [RoutePrefix("api/tarefa")]
    public class TarefaController : ApiController
    {
        private readonly IRepositorioLeitura<Tarefa> _repositorioLeitura;
        private readonly IRepositorioLeitura<Auditoria> _repositorioLeituraAuditoria;
        private readonly IRepositorioGravacao<Tarefa> _repositorioGravacao;

        public TarefaController()
        {
            _repositorioLeitura = ServiceLocatorRepositorio
                .InstanciarRepositorioLeitura<Tarefa>();

            _repositorioGravacao = ServiceLocatorRepositorio
                .InstanciarRepositorioGravacao<Tarefa>();

            _repositorioLeituraAuditoria = ServiceLocatorRepositorio
                .InstanciarRepositorioLeitura<Auditoria>();
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var retorno = await _repositorioLeitura.Listar(true, "Proprietario");

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            try
            {
                var retorno = await _repositorioLeitura.Primeiro(id, true);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/Auditoria")]
        public async Task<IHttpActionResult> GetAuditoria(Guid id)
        {
            try
            {
                var retorno = await _repositorioLeituraAuditoria
                    .Listar(tarefa => tarefa.TarefaAuditada.Id == id, true, "TarefaAuditada");

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]Tarefa tarefa)
        {
            try
            {
                var tarefaExiste = await _repositorioLeitura.Existe(o => o.Id == tarefa.Id);

                if (tarefaExiste)
                    return Conflict();

                _repositorioGravacao.Adicionar(tarefa);
                await _repositorioGravacao.GravarDadosAssincronamente();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> Put(Guid id, [FromBody]Tarefa tarefa)
        {
            try
            {
                var tarefaNoBanco = await _repositorioLeitura.Primeiro(id);

                if (tarefaNoBanco == null)
                    return StatusCode(HttpStatusCode.NoContent);

                _repositorioGravacao.Editar(tarefaNoBanco, tarefa);
                await _repositorioGravacao.GravarDadosAssincronamente();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}/alterarConclusao/{concluido}")]
        public async Task<IHttpActionResult> Patch(Guid id, bool concluido)
        {
            try
            {
                var tarefaNoBanco = await _repositorioLeitura.Primeiro(id);

                if (tarefaNoBanco == null)
                    return StatusCode(HttpStatusCode.NoContent);

                tarefaNoBanco.Concluido = concluido;
                _repositorioGravacao.Editar(tarefaNoBanco);
                await _repositorioGravacao.GravarDadosAssincronamente();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            try
            {
                var tarefaNoBanco = await _repositorioLeitura.Primeiro(id);

                if (tarefaNoBanco == null)
                    return StatusCode(HttpStatusCode.NoContent);

                _repositorioGravacao.Deletar(tarefaNoBanco);
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