namespace TestesDonaMariana.WinApp.ModuloQuestao
{
    partial class TabelaQuestaoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridQuestao = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridQuestao).BeginInit();
            SuspendLayout();
            // 
            // gridQuestao
            // 
            gridQuestao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridQuestao.Location = new Point(59, 71);
            gridQuestao.Name = "gridQuestao";
            gridQuestao.RowTemplate.Height = 25;
            gridQuestao.Size = new Size(240, 150);
            gridQuestao.TabIndex = 0;
            // 
            // TabelaQuestaoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridQuestao);
            Name = "TabelaQuestaoControl";
            Size = new Size(373, 314);
            ((System.ComponentModel.ISupportInitialize)gridQuestao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridQuestao;
    }
}
