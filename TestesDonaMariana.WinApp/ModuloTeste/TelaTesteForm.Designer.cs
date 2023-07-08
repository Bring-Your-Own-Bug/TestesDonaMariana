namespace TestesDonaMariana.WinApp.ModuloTeste
{
    partial class TelaTesteForm
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
            cmbDisciplina = new ComboBox();
            cmbMateria = new ComboBox();
            lbErroMateria = new Label();
            lbErroDisciplina = new Label();
            btnCancelar = new Button();
            btnAdd = new Button();
            lbNome = new Label();
            lbDisciplina = new Label();
            lbErroTitulo = new Label();
            label2 = new Label();
            txtTitulo = new TextBox();
            label3 = new Label();
            numQuestao = new NumericUpDown();
            ckbRecuperacao = new CheckBox();
            listQuestoes = new ListBox();
            btnGerarQuestao = new Button();
            groupBox1 = new GroupBox();
            txtId = new TextBox();
            lbErroQtdQuestoes = new Label();
            ((System.ComponentModel.ISupportInitialize)numQuestao).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbDisciplina
            // 
            cmbDisciplina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisciplina.FormattingEnabled = true;
            cmbDisciplina.Location = new Point(92, 102);
            cmbDisciplina.Name = "cmbDisciplina";
            cmbDisciplina.Size = new Size(157, 23);
            cmbDisciplina.TabIndex = 88;
            cmbDisciplina.SelectedValueChanged += cmbDisciplina_SelectedValueChanged;
            // 
            // cmbMateria
            // 
            cmbMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMateria.FormattingEnabled = true;
            cmbMateria.Location = new Point(92, 144);
            cmbMateria.Name = "cmbMateria";
            cmbMateria.Size = new Size(157, 23);
            cmbMateria.TabIndex = 86;
            cmbMateria.SelectedIndexChanged += cmbMateria_SelectedIndexChanged;
            cmbMateria.SelectedValueChanged += cmbMateria_SelectedValueChanged;
            // 
            // lbErroMateria
            // 
            lbErroMateria.AutoSize = true;
            lbErroMateria.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroMateria.ForeColor = Color.Red;
            lbErroMateria.Location = new Point(92, 128);
            lbErroMateria.Name = "lbErroMateria";
            lbErroMateria.Size = new Size(112, 13);
            lbErroMateria.TabIndex = 85;
            lbErroMateria.Text = "*Campo Obrigatório";
            lbErroMateria.Visible = false;
            // 
            // lbErroDisciplina
            // 
            lbErroDisciplina.AutoSize = true;
            lbErroDisciplina.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroDisciplina.ForeColor = Color.Red;
            lbErroDisciplina.Location = new Point(92, 86);
            lbErroDisciplina.Name = "lbErroDisciplina";
            lbErroDisciplina.Size = new Size(112, 13);
            lbErroDisciplina.TabIndex = 84;
            lbErroDisciplina.Text = "*Campo Obrigatório";
            lbErroDisciplina.Visible = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(369, 477);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(70, 36);
            btnCancelar.TabIndex = 83;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.DialogResult = DialogResult.OK;
            btnAdd.Location = new Point(293, 477);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(70, 36);
            btnAdd.TabIndex = 82;
            btnAdd.Text = "Adicionar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(36, 147);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(50, 15);
            lbNome.TabIndex = 81;
            lbNome.Text = "Matéria:";
            // 
            // lbDisciplina
            // 
            lbDisciplina.AutoSize = true;
            lbDisciplina.Location = new Point(25, 105);
            lbDisciplina.Name = "lbDisciplina";
            lbDisciplina.Size = new Size(61, 15);
            lbDisciplina.TabIndex = 80;
            lbDisciplina.Text = "Disciplina:";
            // 
            // lbErroTitulo
            // 
            lbErroTitulo.AutoSize = true;
            lbErroTitulo.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroTitulo.ForeColor = Color.Red;
            lbErroTitulo.Location = new Point(92, 44);
            lbErroTitulo.Name = "lbErroTitulo";
            lbErroTitulo.Size = new Size(112, 13);
            lbErroTitulo.TabIndex = 91;
            lbErroTitulo.Text = "*Campo Obrigatório";
            lbErroTitulo.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 63);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 90;
            label2.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.BackColor = SystemColors.Window;
            txtTitulo.Location = new Point(92, 60);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(323, 23);
            txtTitulo.TabIndex = 89;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(278, 105);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 92;
            label3.Text = "Qtd. Questões:";
            // 
            // numQuestao
            // 
            numQuestao.Location = new Point(369, 102);
            numQuestao.Name = "numQuestao";
            numQuestao.Size = new Size(46, 23);
            numQuestao.TabIndex = 93;
            // 
            // ckbRecuperacao
            // 
            ckbRecuperacao.AutoSize = true;
            ckbRecuperacao.Location = new Point(278, 146);
            ckbRecuperacao.Name = "ckbRecuperacao";
            ckbRecuperacao.Size = new Size(143, 19);
            ckbRecuperacao.TabIndex = 94;
            ckbRecuperacao.Text = "Prova de Recuperação";
            ckbRecuperacao.UseVisualStyleBackColor = true;
            ckbRecuperacao.CheckedChanged += ckbRecuperacao_CheckedChanged;
            // 
            // listQuestoes
            // 
            listQuestoes.Dock = DockStyle.Fill;
            listQuestoes.FormattingEnabled = true;
            listQuestoes.ItemHeight = 15;
            listQuestoes.Location = new Point(3, 19);
            listQuestoes.Name = "listQuestoes";
            listQuestoes.Size = new Size(397, 185);
            listQuestoes.TabIndex = 95;
            // 
            // btnGerarQuestao
            // 
            btnGerarQuestao.Location = new Point(301, 201);
            btnGerarQuestao.Name = "btnGerarQuestao";
            btnGerarQuestao.Size = new Size(123, 30);
            btnGerarQuestao.TabIndex = 96;
            btnGerarQuestao.Text = "Gerar Questões";
            btnGerarQuestao.UseVisualStyleBackColor = true;
            btnGerarQuestao.Click += btnGerarQuestao_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listQuestoes);
            groupBox1.Location = new Point(24, 228);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(403, 207);
            groupBox1.TabIndex = 98;
            groupBox1.TabStop = false;
            groupBox1.Text = "Questões";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(92, 12);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 99;
            txtId.Text = "0";
            txtId.Visible = false;
            // 
            // lbErroQtdQuestoes
            // 
            lbErroQtdQuestoes.AutoSize = true;
            lbErroQtdQuestoes.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroQtdQuestoes.ForeColor = Color.Red;
            lbErroQtdQuestoes.Location = new Point(278, 86);
            lbErroQtdQuestoes.Name = "lbErroQtdQuestoes";
            lbErroQtdQuestoes.Size = new Size(155, 13);
            lbErroQtdQuestoes.TabIndex = 100;
            lbErroQtdQuestoes.Text = "*Limite de questões atingido";
            lbErroQtdQuestoes.Visible = false;
            // 
            // TelaTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(451, 525);
            Controls.Add(lbErroQtdQuestoes);
            Controls.Add(txtId);
            Controls.Add(btnGerarQuestao);
            Controls.Add(groupBox1);
            Controls.Add(ckbRecuperacao);
            Controls.Add(numQuestao);
            Controls.Add(label3);
            Controls.Add(lbErroTitulo);
            Controls.Add(label2);
            Controls.Add(txtTitulo);
            Controls.Add(cmbDisciplina);
            Controls.Add(cmbMateria);
            Controls.Add(lbErroMateria);
            Controls.Add(lbErroDisciplina);
            Controls.Add(btnCancelar);
            Controls.Add(btnAdd);
            Controls.Add(lbNome);
            Controls.Add(lbDisciplina);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaTesteForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gerador de Testes";
            ((System.ComponentModel.ISupportInitialize)numQuestao).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbErroMateria;
        private Label lbErroDisciplina;
        private Button btnCancelar;
        private Button btnAdd;
        private Label lbNome;
        private Label lbDisciplina;
        private Label lbErroTitulo;
        private Label label2;
        private TextBox txtTitulo;
        private Label label3;
        private NumericUpDown numQuestao;
        private ListBox listQuestoes;
        private Button btnGerarQuestao;
        private GroupBox groupBox1;
        private TextBox txtId;
        public ComboBox cmbDisciplina;
        public ComboBox cmbMateria;
        public CheckBox ckbRecuperacao;
        private Label lbErroQtdQuestoes;
    }
}