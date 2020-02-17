using ProjetoFinal.Dominio;
using ProjetoFinal.Core.Contrato;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using TodoProjetoFinal.Api.Models;
using TodoProjetoFinal.Api.ServicesLocator;

namespace TodoProjetoFinal.Api.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly IRepositorioLeitura<Usuario> _repositorioLeitura;
        private readonly IRepositorioGravacao<Usuario> _repositorioGravacao;
        private readonly IRepositorioLeitura<Tarefa> _repositorioLeituraTarefas;
        private readonly IRepositorioGravacao<Tarefa> _repositorioGravacaoTarefas;
        private readonly IRepositorioLeitura<PrioridadesUsuario> _repositorioLeituraPrioridades;

        public UsuarioController()
        {
            _repositorioLeitura = ServiceLocatorRepositorio
                .InstanciarRepositorioLeitura<Usuario>();

            _repositorioGravacao = ServiceLocatorRepositorio
                .InstanciarRepositorioGravacao<Usuario>();

            _repositorioLeituraTarefas = ServiceLocatorRepositorio
               .InstanciarRepositorioLeitura<Tarefa>();

            _repositorioGravacaoTarefas = ServiceLocatorRepositorio
                .InstanciarRepositorioGravacao<Tarefa>();

            _repositorioLeituraPrioridades = ServiceLocatorRepositorio
               .InstanciarRepositorioLeitura<PrioridadesUsuario>();
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var retorno = (await _repositorioLeitura.Listar(true))
                        .Select(o => new UsuarioDTO
                        {
                            Id = o.Id,
                            Nome = o.Nome,
                            Conectado = o.Conectado
                        });

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
                var usuario = await _repositorioLeitura.Query(true)
                    .Select(o => new UsuarioDTO
                    {
                        Id = o.Id,
                        Nome = o.Nome,
                        Conectado = o.Conectado
                    })
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (usuario == null)
                    return StatusCode(HttpStatusCode.NoContent);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody]Usuario usuario)
        {
            try
            {
                var usuarioExiste = await _repositorioLeitura.Existe(filtro: o => o.Nome == usuario.Nome);

                if (usuarioExiste)
                    return Conflict();

                _repositorioGravacao.Adicionar(usuario);
                await _repositorioGravacao.GravarDadosAssincronamente();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost] Resposta personalizada
        //public HttpResponseMessage Post([FromBody]Usuario usuario)
        //{
        //    var usuarioExiste = _contexto.Usuarios.AsNoTracking()
        //        .Any(o => o.Nome == usuario.Nome);

        //    if (usuarioExiste)
        //        return new HttpResponseMessage(HttpStatusCode.Conflict)
        //        {
        //            Content = new StringContent($"Erro ao inserir o usuario {usuario.Nome}")
        //        };

        //    _contexto.Usuarios.Add(usuario);
        //    _contexto.SaveChanges();

        //    return new HttpResponseMessage(HttpStatusCode.OK);
        //}

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> Put(Guid id, [FromBody]UsuarioDTO usuario)
        {
            try
            {
                var usuarioNoBanco = await _repositorioLeitura.Primeiro(id, false);

                if (usuarioNoBanco == null)
                    return StatusCode(HttpStatusCode.NoContent);

                _repositorioGravacao.Editar(usuarioNoBanco, usuario);
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
                var usuarioNoBanco = await _repositorioLeitura.Primeiro(id);

                if (usuarioNoBanco == null)
                    return StatusCode(HttpStatusCode.NoContent);

                var tarefas = await _repositorioLeituraTarefas
                    .Listar(filtro: t => t.Proprietario.Id == id);

                _repositorioGravacaoTarefas.DeletarLista(tarefas);
                _repositorioGravacao.Deletar(usuarioNoBanco);

                await _repositorioGravacaoTarefas.GravarDadosAssincronamente();
                await _repositorioGravacao.GravarDadosAssincronamente();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/prioridades")]
        public async Task<IHttpActionResult> GetPrioridades(Guid idUsuario)
        {
            try
            {
                var retorno = (await _repositorioLeituraPrioridades
                    .Listar(filtro: pr => pr.Proprietario.Id == idUsuario, true, new[] { "Proprietario", "Tarefa" }))
                    .Select(pr => pr.Tarefa).ToList();

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}