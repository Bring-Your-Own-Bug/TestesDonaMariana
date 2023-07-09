namespace TestesDonaMariana.WinApp.ModuloTeste
{
    partial class TelaPdfTesteForm
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
            ckbGabarito = new CheckBox();
            btnLocalizar = new Button();
            txtDiretorio = new TextBox();
            txtTitulo = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnCancelar = new Button();
            btnGerarPdf = new Button();
            lbErroTitulo = new Label();
            lbErroDiretorio = new Label();
            SuspendLayout();
            // 
            // ckbGabarito
            // 
            ckbGabarito.AutoSize = true;
            ckbGabarito.Location = new Point(125, 123);
            ckbGabarito.Name = "ckbGabarito";
            ckbGabarito.Size = new Size(143, 19);
            ckbGabarito.TabIndex = 77;
            ckbGabarito.Text = "Gerar PDF do Gabarito";
            ckbGabarito.UseVisualStyleBackColor = true;
            // 
            // btnLocalizar
            // 
            btnLocalizar.Image = Properties.Resources.folderOpen;
            btnLocalizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnLocalizar.Location = new Point(364, 82);
            btnLocalizar.Name = "btnLocalizar";
            btnLocalizar.Size = new Size(115, 25);
            btnLocalizar.TabIndex = 76;
            btnLocalizar.Text = "Localizar...";
            btnLocalizar.UseVisualStyleBackColor = true;
            btnLocalizar.Click += btnLocalizar_Click;
            // 
            // txtDiretorio
            // 
            txtDiretorio.Location = new Point(125, 84);
            txtDiretorio.Name = "txtDiretorio";
            txtDiretorio.Size = new Size(233, 23);
            txtDiretorio.TabIndex = 75;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(125, 43);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(233, 23);
            txtTitulo.TabIndex = 74;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 87);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 81;
            label2.Text = "Diretório do Arquivo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 46);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 80;
            label1.Text = "Título do Teste";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(403, 189);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(81, 36);
            btnCancelar.TabIndex = 79;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGerarPdf
            // 
            btnGerarPdf.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGerarPdf.DialogResult = DialogResult.OK;
            btnGerarPdf.Location = new Point(317, 189);
            btnGerarPdf.Name = "btnGerarPdf";
            btnGerarPdf.Size = new Size(80, 36);
            btnGerarPdf.TabIndex = 78;
            btnGerarPdf.Text = "Gerar PDF";
            btnGerarPdf.UseVisualStyleBackColor = true;
            btnGerarPdf.Click += btnGerarPdf_Click;
            // 
            // lbErroTitulo
            // 
            lbErroTitulo.AutoSize = true;
            lbErroTitulo.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroTitulo.ForeColor = Color.Red;
            lbErroTitulo.Location = new Point(125, 27);
            lbErroTitulo.Name = "lbErroTitulo";
            lbErroTitulo.Size = new Size(112, 13);
            lbErroTitulo.TabIndex = 92;
            lbErroTitulo.Text = "*Campo Obrigatório";
            lbErroTitulo.Visible = false;
            // 
            // lbErroDiretorio
            // 
            lbErroDiretorio.AutoSize = true;
            lbErroDiretorio.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbErroDiretorio.ForeColor = Color.Red;
            lbErroDiretorio.Location = new Point(125, 68);
            lbErroDiretorio.Name = "lbErroDiretorio";
            lbErroDiretorio.Size = new Size(112, 13);
            lbErroDiretorio.TabIndex = 93;
            lbErroDiretorio.Text = "*Campo Obrigatório";
            lbErroDiretorio.Visible = false;
            // 
            // TelaPdfTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 237);
            Controls.Add(lbErroDiretorio);
            Controls.Add(lbErroTitulo);
            Controls.Add(ckbGabarito);
            Controls.Add(btnLocalizar);
            Controls.Add(txtDiretorio);
            Controls.Add(txtTitulo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGerarPdf);
            Name = "TelaPdfTesteForm";
            Text = "Gerar PDF";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox ckbGabarito;
        private Button btnLocalizar;
        private TextBox txtDiretorio;
        private TextBox txtTitulo;
        private Label label2;
        private Label label1;
        private Button btnCancelar;
        private Button btnGerarPdf;
        private Label lbErroTitulo;
        private Label lbErroDiretorio;
    }
}