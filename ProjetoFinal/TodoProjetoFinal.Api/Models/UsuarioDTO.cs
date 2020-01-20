using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoProjetoFinal.Api.Models
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Conectado { get; set; }
    }
}