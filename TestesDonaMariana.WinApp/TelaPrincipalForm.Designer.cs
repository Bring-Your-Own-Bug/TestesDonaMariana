namespace TestesDonaMariana.WinApp
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip1 = new ToolStrip();
            btnDisciplina = new ToolStripButton();
            btnMateria = new ToolStripButton();
            btnQuestao = new ToolStripButton();
            btnTeste = new ToolStripButton();
            barraFuncoes = new ToolStrip();
            btnAdicionar = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDetalhes = new ToolStripButton();
            btnDuplicacao = new ToolStripButton();
            lbTipoCadastro = new ToolStripLabel();
            statusStrip1 = new StatusStrip();
            lbStatus = new ToolStripStatusLabel();
            plPrincipal = new Panel();
            toolStrip1.SuspendLayout();
            barraFuncoes.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(0, 165, 100);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnDisciplina, btnMateria, btnQuestao, btnTeste });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1013, 58);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnDisciplina
            // 
            btnDisciplina.BackColor = Color.FromArgb(0, 165, 100);
            btnDisciplina.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDisciplina.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnDisciplina.ForeColor = Color.White;
            btnDisciplina.ImageTransparentColor = Color.Magenta;
            btnDisciplina.Margin = new Padding(0);
            btnDisciplina.Name = "btnDisciplina";
            btnDisciplina.Padding = new Padding(15);
            btnDisciplina.RightToLeft = RightToLeft.No;
            btnDisciplina.Size = new Size(129, 58);
            btnDisciplina.Text = "Disciplina";
            btnDisciplina.TextDirection = ToolStripTextDirection.Horizontal;
            btnDisciplina.Click += btnDisciplina_Click;
            btnDisciplina.MouseEnter += btnColor_MouseEnter;
            btnDisciplina.MouseLeave += btnColor_MouseLeave;
            // 
            // btnMateria
            // 
            btnMateria.BackColor = Color.FromArgb(0, 165, 100);
            btnMateria.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnMateria.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnMateria.ForeColor = Color.White;
            btnMateria.ImageTransparentColor = Color.Magenta;
            btnMateria.Margin = new Padding(0);
            btnMateria.Name = "btnMateria";
            btnMateria.Padding = new Padding(15);
            btnMateria.RightToLeft = RightToLeft.No;
            btnMateria.Size = new Size(111, 58);
            btnMateria.Text = "Matéria";
            btnMateria.TextDirection = ToolStripTextDirection.Horizontal;
            btnMateria.Click += btnMateria_Click;
            btnMateria.MouseEnter += btnColor_MouseEnter;
            btnMateria.MouseLeave += btnColor_MouseLeave;
            // 
            // btnQuestao
            // 
            btnQuestao.BackColor = Color.FromArgb(0, 165, 100);
            btnQuestao.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnQuestao.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnQuestao.ForeColor = Color.White;
            btnQuestao.ImageTransparentColor = Color.Magenta;
            btnQuestao.Margin = new Padding(0);
            btnQuestao.Name = "btnQuestao";
            btnQuestao.Padding = new Padding(15);
            btnQuestao.RightToLeft = RightToLeft.No;
            btnQuestao.Size = new Size(118, 58);
            btnQuestao.Text = "Questão";
            btnQuestao.TextDirection = ToolStripTextDirection.Horizontal;
            btnQuestao.Click += btnQuestao_Click;
            btnQuestao.MouseEnter += btnColor_MouseEnter;
            btnQuestao.MouseLeave += btnColor_MouseLeave;
            // 
            // btnTeste
            // 
            btnTeste.BackColor = Color.FromArgb(0, 165, 100);
            btnTeste.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTeste.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnTeste.ForeColor = Color.White;
            btnTeste.ImageTransparentColor = Color.Magenta;
            btnTeste.Margin = new Padding(0);
            btnTeste.Name = "btnTeste";
            btnTeste.Padding = new Padding(15);
            btnTeste.RightToLeft = RightToLeft.No;
            btnTeste.Size = new Size(94, 58);
            btnTeste.Text = "Teste";
            btnTeste.TextDirection = ToolStripTextDirection.Horizontal;
            btnTeste.Click += btnTeste_Click;
            btnTeste.MouseEnter += btnColor_MouseEnter;
            btnTeste.MouseLeave += btnColor_MouseLeave;
            // 
            // barraFuncoes
            // 
            barraFuncoes.BackColor = Color.White;
            barraFuncoes.GripStyle = ToolStripGripStyle.Hidden;
            barraFuncoes.Items.AddRange(new ToolStripItem[] { btnAdicionar, btnEditar, btnExcluir, toolStripSeparator1, btnDetalhes, btnDuplicacao, lbTipoCadastro });
            barraFuncoes.Location = new Point(0, 58);
            barraFuncoes.Name = "barraFuncoes";
            barraFuncoes.Size = new Size(1013, 54);
            barraFuncoes.TabIndex = 1;
            barraFuncoes.Visible = false;
            // 
            // btnAdicionar
            // 
            btnAdicionar.BackColor = Color.FromArgb(80, 230, 80);
            btnAdicionar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdicionar.Image = Properties.Resources.add;
            btnAdicionar.ImageScaling = ToolStripItemImageScaling.None;
            btnAdicionar.ImageTransparentColor = Color.Magenta;
            btnAdicionar.Margin = new Padding(10);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Padding = new Padding(5);
            btnAdicionar.Size = new Size(103, 34);
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.Click += btnAdd_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(80, 130, 230);
            btnEditar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.Image = Properties.Resources.edit;
            btnEditar.ImageScaling = ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Margin = new Padding(10);
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(5);
            btnEditar.Size = new Size(79, 34);
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.FromArgb(230, 80, 80);
            btnExcluir.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnExcluir.Image = Properties.Resources.remove;
            btnExcluir.ImageScaling = ToolStripItemImageScaling.None;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Margin = new Padding(10);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(5);
            btnExcluir.Size = new Size(85, 34);
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 54);
            // 
            // btnDetalhes
            // 
            btnDetalhes.BackColor = Color.Yellow;
            btnDetalhes.Enabled = false;
            btnDetalhes.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDetalhes.Image = Properties.Resources.addItem;
            btnDetalhes.ImageScaling = ToolStripItemImageScaling.None;
            btnDetalhes.ImageTransparentColor = Color.Magenta;
            btnDetalhes.Margin = new Padding(10);
            btnDetalhes.Name = "btnDetalhes";
            btnDetalhes.Padding = new Padding(5);
            btnDetalhes.Size = new Size(97, 34);
            btnDetalhes.Text = "Detalhes";
            btnDetalhes.Click += btnDetalhes_Click;
            // 
            // btnDuplicacao
            // 
            btnDuplicacao.BackColor = Color.Orange;
            btnDuplicacao.Enabled = false;
            btnDuplicacao.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDuplicacao.Image = Properties.Resources.statusCheck;
            btnDuplicacao.ImageScaling = ToolStripItemImageScaling.None;
            btnDuplicacao.ImageTransparentColor = Color.Magenta;
            btnDuplicacao.Margin = new Padding(10);
            btnDuplicacao.Name = "btnDuplicacao";
            btnDuplicacao.Padding = new Padding(5);
            btnDuplicacao.Size = new Size(113, 34);
            btnDuplicacao.Text = "Duplicação";
            btnDuplicacao.Click += btnDuplicacao_Click;
            // 
            // lbTipoCadastro
            // 
            lbTipoCadastro.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbTipoCadastro.Name = "lbTipoCadastro";
            lbTipoCadastro.Size = new Size(0, 51);
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lbStatus });
            statusStrip1.Location = new Point(0, 604);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1013, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(0, 17);
            // 
            // plPrincipal
            // 
            plPrincipal.Dock = DockStyle.Fill;
            plPrincipal.Location = new Point(0, 58);
            plPrincipal.Name = "plPrincipal";
            plPrincipal.Size = new Size(1013, 546);
            plPrincipal.TabIndex = 3;
            plPrincipal.ControlAdded += plPrincipal_ControlAdded;
            plPrincipal.ControlRemoved += plPrincipal_ControlRemoved;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 626);
            Controls.Add(plPrincipal);
            Controls.Add(barraFuncoes);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Testes Dona Mariana";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            barraFuncoes.ResumeLayout(false);
            barraFuncoes.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btnDisciplina;
        private ToolStripButton btnMateria;
        private ToolStripButton btnQuestao;
        private ToolStripButton btnTeste;
        private ToolStrip barraFuncoes;
        private ToolStripButton btnAdicionar;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbStatus;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel lbTipoCadastro;
        private Panel plPrincipal;
        private ToolStripButton btnDetalhes;
        private ToolStripButton btnDuplicacao;
    }
}