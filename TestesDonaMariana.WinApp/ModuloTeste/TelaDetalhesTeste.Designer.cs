namespace TestesDonaMariana.WinApp.ModuloTeste
{
    partial class TelaDetalhesTeste
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
            label2 = new Label();
            label3 = new Label();
            txtTitulo = new Label();
            txtDisciplina = new Label();
            txtMateria = new Label();
            btnCancelar = new Button();
            groupBox1 = new GroupBox();
            listQuestoesSeleciondas = new ListBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 28);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Titulo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 69);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Disciplina:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 109);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 2;
            label3.Text = "Matéria:";
            // 
            // txtTitulo
            // 
            txtTitulo.AutoSize = true;
            txtTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtTitulo.Location = new Point(90, 28);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(91, 15);
            txtTitulo.TabIndex = 3;
            txtTitulo.Text = "Teste Escolhido";
            // 
            // txtDisciplina
            // 
            txtDisciplina.AutoSize = true;
            txtDisciplina.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtDisciplina.Location = new Point(90, 66);
            txtDisciplina.Name = "txtDisciplina";
            txtDisciplina.Size = new Size(112, 15);
            txtDisciplina.TabIndex = 4;
            txtDisciplina.Text = "Disciplina Escolhida";
            // 
            // txtMateria
            // 
            txtMateria.AutoSize = true;
            txtMateria.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtMateria.Location = new Point(90, 109);
            txtMateria.Name = "txtMateria";
            txtMateria.Size = new Size(103, 15);
            txtMateria.TabIndex = 5;
            txtMateria.Text = "Matéria Escolhida";
            txtMateria.Click += txtMateria_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(424, 474);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(70, 36);
            btnCancelar.TabIndex = 84;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listQuestoesSeleciondas);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(23, 166);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(427, 269);
            groupBox1.TabIndex = 99;
            groupBox1.TabStop = false;
            groupBox1.Text = "Questões Selecionadas:";
            // 
            // listQuestoesSeleciondas
            // 
            listQuestoesSeleciondas.Dock = DockStyle.Fill;
            listQuestoesSeleciondas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listQuestoesSeleciondas.FormattingEnabled = true;
            listQuestoesSeleciondas.ItemHeight = 15;
            listQuestoesSeleciondas.Location = new Point(3, 19);
            listQuestoesSeleciondas.Name = "listQuestoesSeleciondas";
            listQuestoesSeleciondas.Size = new Size(421, 247);
            listQuestoesSeleciondas.TabIndex = 95;
            listQuestoesSeleciondas.SelectedIndexChanged += listQuestoesSeleciondas_SelectedIndexChanged;
            // 
            // TelaDetalhesTeste
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 522);
            Controls.Add(groupBox1);
            Controls.Add(btnCancelar);
            Controls.Add(txtMateria);
            Controls.Add(txtDisciplina);
            Controls.Add(txtTitulo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaDetalhesTeste";
            ShowIcon = false;
            Text = "Vizualização de Testes";
            Load += TelaDetalhesTeste_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label txtTitulo;
        private Label txtDisciplina;
        private Label txtMateria;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private ListBox listQuestoesSeleciondas;
    }
}