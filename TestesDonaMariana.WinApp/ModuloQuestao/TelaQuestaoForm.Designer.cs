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
            comboBox1 = new ComboBox();
            lbErroTelefone = new Label();
            lbErroNome = new Label();
            btnCancelar = new Button();
            btnAdd = new Button();
            lbNome = new Label();
            lbDisciplina = new Label();
            comboBox2 = new ComboBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            checkedListBox1 = new CheckedListBox();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 193);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 70;
            label1.Text = "Enunciado:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(90, 100);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(157, 23);
            comboBox1.TabIndex = 69;
            // 
            // lbErroTelefone
            // 
            lbErroTelefone.AutoSize = true;
            lbErroTelefone.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroTelefone.ForeColor = Color.Red;
            lbErroTelefone.Location = new Point(90, 84);
            lbErroTelefone.Name = "lbErroTelefone";
            lbErroTelefone.Size = new Size(112, 13);
            lbErroTelefone.TabIndex = 68;
            lbErroTelefone.Text = "*Campo Obrigatório";
            lbErroTelefone.Visible = false;
            // 
            // lbErroNome
            // 
            lbErroNome.AutoSize = true;
            lbErroNome.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroNome.ForeColor = Color.Red;
            lbErroNome.Location = new Point(90, 42);
            lbErroNome.Name = "lbErroNome";
            lbErroNome.Size = new Size(112, 13);
            lbErroNome.TabIndex = 67;
            lbErroNome.Text = "*Campo Obrigatório";
            lbErroNome.Visible = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(360, 590);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(70, 36);
            btnCancelar.TabIndex = 66;
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
            btnAdd.TabIndex = 65;
            btnAdd.Text = "Adicionar";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(34, 103);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(50, 15);
            lbNome.TabIndex = 64;
            lbNome.Text = "Matéria:";
            // 
            // lbDisciplina
            // 
            lbDisciplina.AutoSize = true;
            lbDisciplina.Location = new Point(23, 61);
            lbDisciplina.Name = "lbDisciplina";
            lbDisciplina.Size = new Size(61, 15);
            lbDisciplina.TabIndex = 63;
            lbDisciplina.Text = "Disciplina:";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(90, 58);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 73;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 308);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 74;
            label2.Text = "Resposta:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(90, 154);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(321, 99);
            textBox1.TabIndex = 75;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(90, 138);
            label3.Name = "label3";
            label3.Size = new Size(112, 13);
            label3.TabIndex = 76;
            label3.Text = "*Campo Obrigatório";
            label3.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(90, 283);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(321, 64);
            textBox2.TabIndex = 77;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = SystemColors.Control;
            checkedListBox1.BorderStyle = BorderStyle.None;
            checkedListBox1.Dock = DockStyle.Fill;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(3, 19);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(372, 153);
            checkedListBox1.TabIndex = 78;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkedListBox1);
            groupBox1.Location = new Point(33, 385);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(378, 175);
            groupBox1.TabIndex = 79;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alternativas";
            // 
            // TelaQuestaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 638);
            Controls.Add(groupBox1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(comboBox2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(lbErroTelefone);
            Controls.Add(lbErroNome);
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
        private ComboBox comboBox1;
        private Label lbErroTelefone;
        private Label lbErroNome;
        private Button btnCancelar;
        private Button btnAdd;
        private Label lbNome;
        private Label lbDisciplina;
        private ComboBox comboBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private CheckedListBox checkedListBox1;
        private GroupBox groupBox1;
    }
}