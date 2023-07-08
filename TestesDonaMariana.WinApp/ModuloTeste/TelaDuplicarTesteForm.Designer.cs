namespace TestesDonaMariana.WinApp.ModuloTeste
{
    partial class TelaDuplicarTesteForm
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
            groupBox1 = new GroupBox();
            btnSortearQuestoes = new Button();
            listQuestoesSorteadas = new ListBox();
            btnCancelar = new Button();
            txtMateriaEscolhida = new Label();
            txtDisciplinaEscolhida = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnGravar = new Button();
            txtTitulo = new TextBox();
            cmbDisciplina = new ComboBox();
            ckbRecuperacao = new CheckBox();
            cmbMateria = new ComboBox();
            label4 = new Label();
            numericQtdQuestoes = new NumericUpDown();
            txtId = new TextBox();
            lbErroTitulo = new Label();
            lbErroDisciplina = new Label();
            lbErroMateria = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericQtdQuestoes).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSortearQuestoes);
            groupBox1.Controls.Add(listQuestoesSorteadas);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(32, 232);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(502, 287);
            groupBox1.TabIndex = 107;
            groupBox1.TabStop = false;
            groupBox1.Text = "Questões Selecionadas:";
            // 
            // btnSortearQuestoes
            // 
            btnSortearQuestoes.Location = new Point(10, 22);
            btnSortearQuestoes.Name = "btnSortearQuestoes";
            btnSortearQuestoes.Size = new Size(117, 23);
            btnSortearQuestoes.TabIndex = 96;
            btnSortearQuestoes.Text = "Sortear Questões";
            btnSortearQuestoes.UseVisualStyleBackColor = true;
            // 
            // listQuestoesSorteadas
            // 
            listQuestoesSorteadas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listQuestoesSorteadas.FormattingEnabled = true;
            listQuestoesSorteadas.ItemHeight = 15;
            listQuestoesSorteadas.Location = new Point(0, 51);
            listQuestoesSorteadas.Name = "listQuestoesSorteadas";
            listQuestoesSorteadas.Size = new Size(502, 229);
            listQuestoesSorteadas.TabIndex = 95;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(540, 552);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(70, 36);
            btnCancelar.TabIndex = 106;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtMateriaEscolhida
            // 
            txtMateriaEscolhida.AutoSize = true;
            txtMateriaEscolhida.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtMateriaEscolhida.Location = new Point(99, 183);
            txtMateriaEscolhida.Name = "txtMateriaEscolhida";
            txtMateriaEscolhida.Size = new Size(0, 15);
            txtMateriaEscolhida.TabIndex = 105;
            // 
            // txtDisciplinaEscolhida
            // 
            txtDisciplinaEscolhida.AutoSize = true;
            txtDisciplinaEscolhida.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtDisciplinaEscolhida.Location = new Point(99, 129);
            txtDisciplinaEscolhida.Name = "txtDisciplinaEscolhida";
            txtDisciplinaEscolhida.Size = new Size(0, 15);
            txtDisciplinaEscolhida.TabIndex = 104;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 183);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 102;
            label3.Text = "Matéria:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 132);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 101;
            label2.Text = "Disciplina:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 77);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 100;
            label1.Text = "Titulo:";
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(449, 552);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(70, 36);
            btnGravar.TabIndex = 108;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtTitulo.Location = new Point(100, 77);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(371, 23);
            txtTitulo.TabIndex = 109;
            // 
            // cmbDisciplina
            // 
            cmbDisciplina.FormattingEnabled = true;
            cmbDisciplina.Location = new Point(99, 129);
            cmbDisciplina.Name = "cmbDisciplina";
            cmbDisciplina.Size = new Size(198, 23);
            cmbDisciplina.TabIndex = 110;
            // 
            // ckbRecuperacao
            // 
            ckbRecuperacao.AutoSize = true;
            ckbRecuperacao.Location = new Point(327, 187);
            ckbRecuperacao.Name = "ckbRecuperacao";
            ckbRecuperacao.Size = new Size(143, 19);
            ckbRecuperacao.TabIndex = 111;
            ckbRecuperacao.Text = "Prova de Recuperação";
            ckbRecuperacao.UseVisualStyleBackColor = true;
            // 
            // cmbMateria
            // 
            cmbMateria.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cmbMateria.FormattingEnabled = true;
            cmbMateria.Location = new Point(99, 183);
            cmbMateria.Name = "cmbMateria";
            cmbMateria.Size = new Size(198, 23);
            cmbMateria.TabIndex = 112;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(327, 132);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 113;
            label4.Text = "Qtd. Questões:";
            // 
            // numericQtdQuestoes
            // 
            numericQtdQuestoes.Location = new Point(432, 130);
            numericQtdQuestoes.Name = "numericQtdQuestoes";
            numericQtdQuestoes.Size = new Size(38, 23);
            numericQtdQuestoes.TabIndex = 114;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(100, 24);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 115;
            txtId.Text = "0";
            txtId.Visible = false;
            // 
            // lbErroTitulo
            // 
            lbErroTitulo.AutoSize = true;
            lbErroTitulo.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroTitulo.ForeColor = Color.Red;
            lbErroTitulo.Location = new Point(100, 61);
            lbErroTitulo.Name = "lbErroTitulo";
            lbErroTitulo.Size = new Size(112, 13);
            lbErroTitulo.TabIndex = 116;
            lbErroTitulo.Text = "*Campo Obrigatório";
            lbErroTitulo.Visible = false;
            // 
            // lbErroDisciplina
            // 
            lbErroDisciplina.AutoSize = true;
            lbErroDisciplina.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroDisciplina.ForeColor = Color.Red;
            lbErroDisciplina.Location = new Point(99, 113);
            lbErroDisciplina.Name = "lbErroDisciplina";
            lbErroDisciplina.Size = new Size(112, 13);
            lbErroDisciplina.TabIndex = 117;
            lbErroDisciplina.Text = "*Campo Obrigatório";
            lbErroDisciplina.Visible = false;
            // 
            // lbErroMateria
            // 
            lbErroMateria.AutoSize = true;
            lbErroMateria.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroMateria.ForeColor = Color.Red;
            lbErroMateria.Location = new Point(99, 167);
            lbErroMateria.Name = "lbErroMateria";
            lbErroMateria.Size = new Size(112, 13);
            lbErroMateria.TabIndex = 118;
            lbErroMateria.Text = "*Campo Obrigatório";
            lbErroMateria.Visible = false;
            // 
            // TelaDuplicarTeste
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 600);
            Controls.Add(lbErroMateria);
            Controls.Add(lbErroDisciplina);
            Controls.Add(lbErroTitulo);
            Controls.Add(txtId);
            Controls.Add(numericQtdQuestoes);
            Controls.Add(label4);
            Controls.Add(cmbMateria);
            Controls.Add(ckbRecuperacao);
            Controls.Add(cmbDisciplina);
            Controls.Add(txtTitulo);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Controls.Add(btnCancelar);
            Controls.Add(txtMateriaEscolhida);
            Controls.Add(txtDisciplinaEscolhida);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaDuplicarTeste";
            ShowIcon = false;
            Text = "Duplicação de Testes";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericQtdQuestoes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ListBox listQuestoesSorteadas;
        private Button btnCancelar;
        private Label txtMateriaEscolhida;
        private Label txtDisciplinaEscolhida;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSortearQuestoes;
        private Button btnGravar;
        private TextBox txtTitulo;
        private ComboBox cmbDisciplina;
        private CheckBox ckbRecuperacao;
        private ComboBox cmbMateria;
        private Label label4;
        private NumericUpDown numericQtdQuestoes;
        private TextBox txtId;
        private Label lbErroTitulo;
        private Label lbErroDisciplina;
        private Label lbErroMateria;
    }
}