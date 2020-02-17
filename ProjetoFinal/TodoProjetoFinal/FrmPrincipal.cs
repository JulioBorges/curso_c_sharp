using ProjetoFinal.Dominio;
using ProjetoFinal.Dominio.Enums;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TodoProjetoFinal.Repositorio;

namespace TodoProjetoFinal
{
    public partial class FrmPrincipal : Form
    {
        BindingList<Tarefa> _tarefas;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, System.EventArgs e)
        {
            criticidadeDataGridViewTextBoxColumn.DataSource =
                Enum.GetValues(typeof(NivelCriticidade));

            tarefaBindingSource.DataSource = _tarefas;
        }

        private async void btnCarregar_Click(object sender, EventArgs e)
        {
            var repo = new RepositorioTarefa();

            var tarefas = await repo.ListarTarefas();

            _tarefas = new BindingList<Tarefa>(tarefas.ToList());
        }
    }
}