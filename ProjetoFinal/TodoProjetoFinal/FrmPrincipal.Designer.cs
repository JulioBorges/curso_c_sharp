namespace TodoProjetoFinal
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tarefaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.concluidoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataCriacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criticidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.observacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proprietarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCarregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarefaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.concluidoDataGridViewCheckBoxColumn,
            this.descricaoDataGridViewTextBoxColumn,
            this.dataCriacaoDataGridViewTextBoxColumn,
            this.criticidadeDataGridViewTextBoxColumn,
            this.observacaoDataGridViewTextBoxColumn,
            this.proprietarioDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tarefaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(687, 371);
            this.dataGridView1.TabIndex = 0;
            // 
            // tarefaBindingSource
            // 
            this.tarefaBindingSource.DataSource = typeof(ProjetoFinal.Dominio.Tarefa);
            // 
            // concluidoDataGridViewCheckBoxColumn
            // 
            this.concluidoDataGridViewCheckBoxColumn.DataPropertyName = "Concluido";
            this.concluidoDataGridViewCheckBoxColumn.HeaderText = "Concluído";
            this.concluidoDataGridViewCheckBoxColumn.Name = "concluidoDataGridViewCheckBoxColumn";
            this.concluidoDataGridViewCheckBoxColumn.Width = 70;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            this.descricaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            // 
            // dataCriacaoDataGridViewTextBoxColumn
            // 
            this.dataCriacaoDataGridViewTextBoxColumn.DataPropertyName = "DataCriacao";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = "-";
            this.dataCriacaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataCriacaoDataGridViewTextBoxColumn.HeaderText = "Data criação";
            this.dataCriacaoDataGridViewTextBoxColumn.Name = "dataCriacaoDataGridViewTextBoxColumn";
            // 
            // criticidadeDataGridViewTextBoxColumn
            // 
            this.criticidadeDataGridViewTextBoxColumn.DataPropertyName = "Criticidade";
            this.criticidadeDataGridViewTextBoxColumn.HeaderText = "Criticidade";
            this.criticidadeDataGridViewTextBoxColumn.Name = "criticidadeDataGridViewTextBoxColumn";
            this.criticidadeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.criticidadeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // observacaoDataGridViewTextBoxColumn
            // 
            this.observacaoDataGridViewTextBoxColumn.DataPropertyName = "Observacao";
            this.observacaoDataGridViewTextBoxColumn.HeaderText = "Observacao";
            this.observacaoDataGridViewTextBoxColumn.Name = "observacaoDataGridViewTextBoxColumn";
            this.observacaoDataGridViewTextBoxColumn.Visible = false;
            // 
            // proprietarioDataGridViewTextBoxColumn
            // 
            this.proprietarioDataGridViewTextBoxColumn.DataPropertyName = "Proprietario";
            this.proprietarioDataGridViewTextBoxColumn.HeaderText = "Proprietario";
            this.proprietarioDataGridViewTextBoxColumn.Name = "proprietarioDataGridViewTextBoxColumn";
            this.proprietarioDataGridViewTextBoxColumn.Visible = false;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // btnCarregar
            // 
            this.btnCarregar.Location = new System.Drawing.Point(12, 389);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(133, 23);
            this.btnCarregar.TabIndex = 1;
            this.btnCarregar.Text = "Carregar Dados";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 501);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TODO List";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarefaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource tarefaBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn concluidoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataCriacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn criticidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proprietarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnCarregar;
    }
}

