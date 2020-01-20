using ProjetoFinal.Dominio;
using ProjetoFinal.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoProjetoFinal.Api.Models;

namespace TodoProjetoFinal.Api.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly ProjetoFinalContexto _contexto;

        public UsuarioController()
        {
            _contexto = new ProjetoFinalContexto();
        }

        /// <summary>
        /// Retornar todos os usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var retorno = _contexto.Usuarios.AsNoTracking()
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

        /// <summary>
        /// Retorna um usuário específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                return Ok(_contexto.Usuarios
                    .AsNoTracking()
                    .Select(o => new UsuarioDTO
                    {
                        Id = o.Id,
                        Nome = o.Nome,
                        Conectado = o.Conectado
                    })
                    .FirstOrDefault(o => o.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Usuario usuario)
        {
            try
            {
                var usuarioExiste = _contexto.Usuarios.AsNoTracking()
                        .Any(o => o.Nome == usuario.Nome);

                if (usuarioExiste)
                    return Conflict();

                _contexto.Usuarios.Add(usuario);
                _contexto.SaveChanges();
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
        public IHttpActionResult Put(Guid id, [FromBody]UsuarioDTO usuario)
        {
            try
            {
                var usuarioNoBanco = _contexto.Usuarios
                        .FirstOrDefault(u => u.Id == id);

                if (usuarioNoBanco == null)
                    return NotFound();

                _contexto.Entry(usuarioNoBanco).CurrentValues
                    .SetValues(usuario);

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
                var usuarioNoBanco = _contexto.Usuarios
                        .FirstOrDefault(u => u.Id == id);

                if (usuarioNoBanco == null)
                    return NotFound();

                var tarefas = _contexto.Tarefas.Where(t => t.Proprietario.Id == id);

                _contexto.Tarefas.RemoveRange(tarefas);
                _contexto.Usuarios.Remove(usuarioNoBanco);

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