namespace TestesDonaMariana.WinApp.ModuloQuestao
{
    partial class TelaQuestaoForm
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
            label1 = new Label();
            txtMateria = new ComboBox();
            lbErroMateria = new Label();
            lbErroDisciplina = new Label();
            btnCancelar = new Button();
            btnAdd = new Button();
            lbNome = new Label();
            lbDisciplina = new Label();
            txtDisciplina = new ComboBox();
            label2 = new Label();
            txtEnunciado = new TextBox();
            lbErroEnunciado = new Label();
            txtResposta = new TextBox();
            listAlternativas = new CheckedListBox();
            groupBox1 = new GroupBox();
            txtId = new TextBox();
            lbErroAlternativas = new Label();
            btnAddAlternativa = new Button();
            btnExcluirAlternativa = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 194);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 70;
            label1.Text = "Enunciado:";
            // 
            // txtMateria
            // 
            txtMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            txtMateria.FormattingEnabled = true;
            txtMateria.Location = new Point(90, 98);
            txtMateria.Name = "txtMateria";
            txtMateria.Size = new Size(157, 23);
            txtMateria.TabIndex = 2;
            // 
            // lbErroMateria
            // 
            lbErroMateria.AutoSize = true;
            lbErroMateria.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroMateria.ForeColor = Color.Red;
            lbErroMateria.Location = new Point(90, 82);
            lbErroMateria.Name = "lbErroMateria";
            lbErroMateria.Size = new Size(112, 13);
            lbErroMateria.TabIndex = 68;
            lbErroMateria.Text = "*Campo Obrigatório";
            lbErroMateria.Visible = false;
            // 
            // lbErroDisciplina
            // 
            lbErroDisciplina.AutoSize = true;
            lbErroDisciplina.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroDisciplina.ForeColor = Color.Red;
            lbErroDisciplina.Location = new Point(90, 40);
            lbErroDisciplina.Name = "lbErroDisciplina";
            lbErroDisciplina.Size = new Size(112, 13);
            lbErroDisciplina.TabIndex = 67;
            lbErroDisciplina.Text = "*Campo Obrigatório";
            lbErroDisciplina.Visible = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(360, 590);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(70, 36);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.DialogResult = DialogResult.OK;
            btnAdd.Location = new Point(284, 590);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(70, 36);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Adicionar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(34, 101);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(50, 15);
            lbNome.TabIndex = 64;
            lbNome.Text = "Matéria:";
            // 
            // lbDisciplina
            // 
            lbDisciplina.AutoSize = true;
            lbDisciplina.Location = new Point(23, 59);
            lbDisciplina.Name = "lbDisciplina";
            lbDisciplina.Size = new Size(61, 15);
            lbDisciplina.TabIndex = 63;
            lbDisciplina.Text = "Disciplina:";
            // 
            // txtDisciplina
            // 
            txtDisciplina.DropDownStyle = ComboBoxStyle.DropDownList;
            txtDisciplina.FormattingEnabled = true;
            txtDisciplina.Location = new Point(90, 56);
            txtDisciplina.Name = "txtDisciplina";
            txtDisciplina.Size = new Size(157, 23);
            txtDisciplina.TabIndex = 1;
            txtDisciplina.SelectedValueChanged += AtualizarComboBoxMateria;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 306);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 74;
            label2.Text = "Resposta:";
            // 
            // txtEnunciado
            // 
            txtEnunciado.Location = new Point(90, 154);
            txtEnunciado.Multiline = true;
            txtEnunciado.Name = "txtEnunciado";
            txtEnunciado.Size = new Size(321, 99);
            txtEnunciado.TabIndex = 3;
            // 
            // lbErroEnunciado
            // 
            lbErroEnunciado.AutoSize = true;
            lbErroEnunciado.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroEnunciado.ForeColor = Color.Red;
            lbErroEnunciado.Location = new Point(90, 138);
            lbErroEnunciado.Name = "lbErroEnunciado";
            lbErroEnunciado.Size = new Size(112, 13);
            lbErroEnunciado.TabIndex = 76;
            lbErroEnunciado.Text = "*Campo Obrigatório";
            lbErroEnunciado.Visible = false;
            // 
            // txtResposta
            // 
            txtResposta.Location = new Point(90, 284);
            txtResposta.Multiline = true;
            txtResposta.Name = "txtResposta";
            txtResposta.Size = new Size(321, 64);
            txtResposta.TabIndex = 4;
            // 
            // listAlternativas
            // 
            listAlternativas.BackColor = SystemColors.Control;
            listAlternativas.BorderStyle = BorderStyle.None;
            listAlternativas.Dock = DockStyle.Fill;
            listAlternativas.FormattingEnabled = true;
            listAlternativas.Location = new Point(3, 19);
            listAlternativas.Name = "listAlternativas";
            listAlternativas.Size = new Size(372, 153);
            listAlternativas.TabIndex = 5;
            listAlternativas.TabStop = false;
            listAlternativas.UseTabStops = false;
            listAlternativas.ItemCheck += ApenasUmaAlternativaCheck;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listAlternativas);
            groupBox1.Location = new Point(33, 385);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(378, 175);
            groupBox1.TabIndex = 79;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alternativas";
            // 
            // txtId
            // 
            txtId.Location = new Point(303, 30);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(71, 23);
            txtId.TabIndex = 81;
            txtId.Text = "0";
            txtId.Visible = false;
            // 
            // lbErroAlternativas
            // 
            lbErroAlternativas.AutoSize = true;
            lbErroAlternativas.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroAlternativas.ForeColor = Color.Red;
            lbErroAlternativas.Location = new Point(272, 375);
            lbErroAlternativas.Name = "lbErroAlternativas";
            lbErroAlternativas.Size = new Size(138, 13);
            lbErroAlternativas.TabIndex = 82;
            lbErroAlternativas.Text = "*Mínimo de 3 alternativas";
            lbErroAlternativas.Visible = false;
            // 
            // btnAddAlternativa
            // 
            btnAddAlternativa.Location = new Point(33, 563);
            btnAddAlternativa.Name = "btnAddAlternativa";
            btnAddAlternativa.Size = new Size(75, 23);
            btnAddAlternativa.TabIndex = 6;
            btnAddAlternativa.Text = "Adicionar";
            btnAddAlternativa.UseVisualStyleBackColor = true;
            btnAddAlternativa.Click += AdicionarAlternativa;
            // 
            // btnExcluirAlternativa
            // 
            btnExcluirAlternativa.Location = new Point(114, 563);
            btnExcluirAlternativa.Name = "btnExcluirAlternativa";
            btnExcluirAlternativa.Size = new Size(75, 23);
            btnExcluirAlternativa.TabIndex = 7;
            btnExcluirAlternativa.Text = "Excluir";
            btnExcluirAlternativa.UseVisualStyleBackColor = true;
            btnExcluirAlternativa.Click += ExcluirAlternativa;
            // 
            // TelaQuestaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 638);
            Controls.Add(btnExcluirAlternativa);
            Controls.Add(btnAddAlternativa);
            Controls.Add(lbErroAlternativas);
            Controls.Add(txtId);
            Controls.Add(groupBox1);
            Controls.Add(txtResposta);
            Controls.Add(lbErroEnunciado);
            Controls.Add(txtEnunciado);
            Controls.Add(label2);
            Controls.Add(txtDisciplina);
            Controls.Add(label1);
            Controls.Add(txtMateria);
            Controls.Add(lbErroMateria);
            Controls.Add(lbErroDisciplina);
            Controls.Add(btnCancelar);
            Controls.Add(btnAdd);
            Controls.Add(lbNome);
            Controls.Add(lbDisciplina);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaQuestaoForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Questões";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lbErroMateria;
        private Label lbErroDisciplina;
        private Button btnCancelar;
        private Button btnAdd;
        private Label lbNome;
        private Label lbDisciplina;
        private Label label2;
        private TextBox txtEnunciado;
        private Label lbErroEnunciado;
        private TextBox txtResposta;
        private GroupBox groupBox1;
        internal ComboBox txtMateria;
        internal ComboBox txtDisciplina;
        public TextBox txtId;
        private Label lbErroAlternativas;
        private Button btnAddAlternativa;
        private Button btnExcluirAlternativa;
        internal CheckedListBox listAlternativas;
    }
}