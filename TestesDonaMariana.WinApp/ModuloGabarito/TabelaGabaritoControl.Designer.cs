namespace TestesDonaMariana.WinApp.ModuloGabarito
{
    partial class TabelaGabaritoControl
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
            gridGabarito = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridGabarito).BeginInit();
            SuspendLayout();
            // 
            // gridGabarito
            // 
            gridGabarito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridGabarito.Location = new Point(76, 87);
            gridGabarito.Name = "gridGabarito";
            gridGabarito.RowTemplate.Height = 25;
            gridGabarito.Size = new Size(240, 150);
            gridGabarito.TabIndex = 0;
            // 
            // TabelaGabaritoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridGabarito);
            Name = "TabelaGabaritoControl";
            Size = new Size(392, 344);
            ((System.ComponentModel.ISupportInitialize)gridGabarito).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridGabarito;
    }
}
