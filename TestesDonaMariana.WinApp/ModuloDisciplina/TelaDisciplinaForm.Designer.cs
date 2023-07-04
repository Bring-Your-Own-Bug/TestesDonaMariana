namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    partial class TelaDisciplinaForm
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
            lbErroNome = new Label();
            btnCancelar = new Button();
            btnAdd = new Button();
            lbNome = new Label();
            lbId = new Label();
            txtNome = new TextBox();
            txtId = new TextBox();
            SuspendLayout();
            // 
            // lbErroNome
            // 
            lbErroNome.AutoSize = true;
            lbErroNome.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroNome.ForeColor = Color.Red;
            lbErroNome.Location = new Point(94, 58);
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
            btnCancelar.Location = new Point(284, 160);
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
            btnAdd.Location = new Point(208, 160);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(70, 36);
            btnAdd.TabIndex = 52;
            btnAdd.Text = "Adicionar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(45, 77);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 51;
            lbNome.Text = "Nome:";
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(34, 35);
            lbId.Name = "lbId";
            lbId.Size = new Size(54, 15);
            lbId.TabIndex = 49;
            lbId.Text = "Número:";
            // 
            // txtNome
            // 
            txtNome.BackColor = SystemColors.Window;
            txtNome.Location = new Point(94, 74);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(227, 23);
            txtNome.TabIndex = 47;
            // 
            // txtId
            // 
            txtId.Location = new Point(94, 32);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(71, 23);
            txtId.TabIndex = 46;
            // 
            // TelaDisciplinaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 208);
            Controls.Add(lbErroNome);
            Controls.Add(btnCancelar);
            Controls.Add(btnAdd);
            Controls.Add(lbNome);
            Controls.Add(lbId);
            Controls.Add(txtNome);
            Controls.Add(txtId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaDisciplinaForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Disciplinas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbErroNome;
        private Button btnCancelar;
        private Button btnAdd;
        private Label lbNome;
        private Label lbId;
        private TextBox txtNome;
        public TextBox txtId;
    }
}