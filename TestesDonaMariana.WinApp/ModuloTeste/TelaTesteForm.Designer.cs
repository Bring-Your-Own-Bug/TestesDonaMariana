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
            lbErroTelefone = new Label();
            lbErroNome = new Label();
            btnCancelar = new Button();
            btnAdd = new Button();
            lbNome = new Label();
            lbDisciplina = new Label();
            label1 = new Label();
            label2 = new Label();
            txtTitulo = new TextBox();
            label3 = new Label();
            numQuestao = new NumericUpDown();
            ckbRecuperacao = new CheckBox();
            listQuestoes = new ListBox();
            btnGerarQuestao = new Button();
            groupBox1 = new GroupBox();
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
            // 
            // cmbMateria
            // 
            cmbMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMateria.FormattingEnabled = true;
            cmbMateria.Location = new Point(92, 144);
            cmbMateria.Name = "cmbMateria";
            cmbMateria.Size = new Size(157, 23);
            cmbMateria.TabIndex = 86;
            // 
            // lbErroTelefone
            // 
            lbErroTelefone.AutoSize = true;
            lbErroTelefone.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroTelefone.ForeColor = Color.Red;
            lbErroTelefone.Location = new Point(92, 128);
            lbErroTelefone.Name = "lbErroTelefone";
            lbErroTelefone.Size = new Size(112, 13);
            lbErroTelefone.TabIndex = 85;
            lbErroTelefone.Text = "*Campo Obrigatório";
            lbErroTelefone.Visible = false;
            // 
            // lbErroNome
            // 
            lbErroNome.AutoSize = true;
            lbErroNome.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroNome.ForeColor = Color.Red;
            lbErroNome.Location = new Point(92, 86);
            lbErroNome.Name = "lbErroNome";
            lbErroNome.Size = new Size(112, 13);
            lbErroNome.TabIndex = 84;
            lbErroNome.Text = "*Campo Obrigatório";
            lbErroNome.Visible = false;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(92, 44);
            label1.Name = "label1";
            label1.Size = new Size(112, 13);
            label1.TabIndex = 91;
            label1.Text = "*Campo Obrigatório";
            label1.Visible = false;
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
            // TelaTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(451, 525);
            Controls.Add(btnGerarQuestao);
            Controls.Add(groupBox1);
            Controls.Add(ckbRecuperacao);
            Controls.Add(numQuestao);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtTitulo);
            Controls.Add(cmbDisciplina);
            Controls.Add(cmbMateria);
            Controls.Add(lbErroTelefone);
            Controls.Add(lbErroNome);
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

        private ComboBox cmbDisciplina;
        private ComboBox cmbMateria;
        private Label lbErroTelefone;
        private Label lbErroNome;
        private Button btnCancelar;
        private Button btnAdd;
        private Label lbNome;
        private Label lbDisciplina;
        private Label label1;
        private Label label2;
        private TextBox txtTitulo;
        private Label label3;
        private NumericUpDown numQuestao;
        private CheckBox ckbRecuperacao;
        private ListBox listQuestoes;
        private Button btnGerarQuestao;
        private GroupBox groupBox1;
    }
}