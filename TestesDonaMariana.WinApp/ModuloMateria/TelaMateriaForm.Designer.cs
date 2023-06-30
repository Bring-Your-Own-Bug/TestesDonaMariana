namespace TestesDonaMariana.WinApp.ModuloMateria
{
    partial class TelaMateriaForm
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
            lbErroTelefone = new Label();
            lbErroNome = new Label();
            btnCancelar = new Button();
            btnAdd = new Button();
            lbNome = new Label();
            lbDisciplina = new Label();
            lbId = new Label();
            txtNome = new TextBox();
            txtId = new TextBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            rdPrimeiraSerie = new RadioButton();
            rdSegundaSerie = new RadioButton();
            SuspendLayout();
            // 
            // lbErroTelefone
            // 
            lbErroTelefone.AutoSize = true;
            lbErroTelefone.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroTelefone.ForeColor = Color.Red;
            lbErroTelefone.Location = new Point(100, 105);
            lbErroTelefone.Name = "lbErroTelefone";
            lbErroTelefone.Size = new Size(112, 13);
            lbErroTelefone.TabIndex = 55;
            lbErroTelefone.Text = "*Campo Obrigatório";
            lbErroTelefone.Visible = false;
            // 
            // lbErroNome
            // 
            lbErroNome.AutoSize = true;
            lbErroNome.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroNome.ForeColor = Color.Red;
            lbErroNome.Location = new Point(100, 63);
            lbErroNome.Name = "lbErroNome";
            lbErroNome.Size = new Size(112, 13);
            lbErroNome.TabIndex = 54;
            lbErroNome.Text = "*Campo Obrigatório";
            lbErroNome.Visible = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(301, 206);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(70, 36);
            btnCancelar.TabIndex = 53;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.DialogResult = DialogResult.OK;
            btnAdd.Location = new Point(225, 206);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(70, 36);
            btnAdd.TabIndex = 52;
            btnAdd.Text = "Adicionar";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(51, 82);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 51;
            lbNome.Text = "Nome:";
            // 
            // lbDisciplina
            // 
            lbDisciplina.AutoSize = true;
            lbDisciplina.Location = new Point(33, 124);
            lbDisciplina.Name = "lbDisciplina";
            lbDisciplina.Size = new Size(61, 15);
            lbDisciplina.TabIndex = 50;
            lbDisciplina.Text = "Disciplina:";
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(40, 40);
            lbId.Name = "lbId";
            lbId.Size = new Size(54, 15);
            lbId.TabIndex = 49;
            lbId.Text = "Número:";
            // 
            // txtNome
            // 
            txtNome.BackColor = SystemColors.Window;
            txtNome.Location = new Point(100, 79);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(249, 23);
            txtNome.TabIndex = 47;
            // 
            // txtId
            // 
            txtId.Location = new Point(100, 37);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(71, 23);
            txtId.TabIndex = 46;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(100, 121);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 56;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 166);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 57;
            label1.Text = "Série:";
            // 
            // rdPrimeiraSerie
            // 
            rdPrimeiraSerie.AutoSize = true;
            rdPrimeiraSerie.Checked = true;
            rdPrimeiraSerie.Location = new Point(100, 166);
            rdPrimeiraSerie.Name = "rdPrimeiraSerie";
            rdPrimeiraSerie.Size = new Size(36, 19);
            rdPrimeiraSerie.TabIndex = 58;
            rdPrimeiraSerie.TabStop = true;
            rdPrimeiraSerie.Text = "1ª";
            rdPrimeiraSerie.UseVisualStyleBackColor = true;
            // 
            // rdSegundaSerie
            // 
            rdSegundaSerie.AutoSize = true;
            rdSegundaSerie.Location = new Point(142, 166);
            rdSegundaSerie.Name = "rdSegundaSerie";
            rdSegundaSerie.Size = new Size(36, 19);
            rdSegundaSerie.TabIndex = 59;
            rdSegundaSerie.TabStop = true;
            rdSegundaSerie.Text = "2ª";
            rdSegundaSerie.UseVisualStyleBackColor = true;
            // 
            // TelaMateriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 254);
            Controls.Add(rdSegundaSerie);
            Controls.Add(rdPrimeiraSerie);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(lbErroTelefone);
            Controls.Add(lbErroNome);
            Controls.Add(btnCancelar);
            Controls.Add(btnAdd);
            Controls.Add(lbNome);
            Controls.Add(lbDisciplina);
            Controls.Add(lbId);
            Controls.Add(txtNome);
            Controls.Add(txtId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaMateriaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Materias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbErroTelefone;
        private Label lbErroNome;
        private Button btnCancelar;
        private Button btnAdd;
        private Label lbNome;
        private Label lbDisciplina;
        private Label lbId;
        private TextBox txtNome;
        public TextBox txtId;
        private ComboBox comboBox1;
        private Label label1;
        private RadioButton rdPrimeiraSerie;
        private RadioButton rdSegundaSerie;
    }
}