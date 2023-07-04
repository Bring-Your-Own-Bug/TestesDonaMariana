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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipalForm));
            menuStrip1 = new MenuStrip();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            disciplinaToolStripMenuItem = new ToolStripMenuItem();
            barraFuncoes = new ToolStrip();
            btnEditar = new ToolStripButton();
            plPrincipal = new Panel();
            statusStrip1 = new StatusStrip();
            lbTipoCadastro = new ToolStripLabel();
            btnAdicionar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            menuStrip1.SuspendLayout();
            barraFuncoes.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { disciplinaToolStripMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(71, 20);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // disciplinaToolStripMenuItem
            // 
            disciplinaToolStripMenuItem.Name = "disciplinaToolStripMenuItem";
            disciplinaToolStripMenuItem.Size = new Size(125, 22);
            disciplinaToolStripMenuItem.Text = "Disciplina";
            disciplinaToolStripMenuItem.Click += disciplinaToolStripMenuItem_Click;
            // 
            // barraFuncoes
            // 
            barraFuncoes.Items.AddRange(new ToolStripItem[] { btnAdicionar, btnEditar, btnExcluir, toolStripSeparator1, lbTipoCadastro });
            barraFuncoes.Location = new Point(0, 24);
            barraFuncoes.Name = "barraFuncoes";
            barraFuncoes.Size = new Size(800, 25);
            barraFuncoes.TabIndex = 1;
            barraFuncoes.Text = "toolStrip1";
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Image = (Image)resources.GetObject("btnEditar.Image");
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(23, 22);
            btnEditar.Text = "toolStripButton1";
            // 
            // plPrincipal
            // 
            plPrincipal.Dock = DockStyle.Fill;
            plPrincipal.Location = new Point(0, 49);
            plPrincipal.Name = "plPrincipal";
            plPrincipal.Size = new Size(800, 401);
            plPrincipal.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // lbTipoCadastro
            // 
            lbTipoCadastro.Name = "lbTipoCadastro";
            lbTipoCadastro.Size = new Size(86, 22);
            lbTipoCadastro.Text = "toolStripLabel1";
            // 
            // btnAdicionar
            // 
            btnAdicionar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAdicionar.Image = (Image)resources.GetObject("btnAdicionar.Image");
            btnAdicionar.ImageTransparentColor = Color.Magenta;
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(23, 22);
            btnAdicionar.Text = "toolStripButton2";
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluir.Image = (Image)resources.GetObject("btnExcluir.Image");
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(23, 22);
            btnExcluir.Text = "toolStripButton3";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(plPrincipal);
            Controls.Add(barraFuncoes);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TelaPrincipalForm";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            barraFuncoes.ResumeLayout(false);
            barraFuncoes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem disciplinaToolStripMenuItem;
        private ToolStrip barraFuncoes;
        private ToolStripButton btnEditar;
        private ToolStripLabel lbTipoCadastro;
        private Panel plPrincipal;
        private StatusStrip statusStrip1;
        private ToolStripButton btnAdicionar;
        private ToolStripButton btnExcluir;
        private ToolStripSeparator toolStripSeparator1;
    }
}