using ProjetoFinal.Core.Contrato;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Dominio
{
    public class PrioridadesUsuario : EntidadeBase
    {
        [Column(name: "Proprietario_Id")]
        [ForeignKey("Proprietario")]
        public Guid IdProprietario { get; set; }

        public virtual Usuario Proprietario { get; set; }

        [ForeignKey("Tarefa")]
        public Guid IdTarefa { get; set; }

        public virtual Tarefa Tarefa { get; set; }
    }
}