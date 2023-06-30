namespace TestesDonaMariana.WinApp.ModuloMateria
{
    partial class TabelaMateriaControl
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
            gridMateria = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridMateria).BeginInit();
            SuspendLayout();
            // 
            // gridMateria
            // 
            gridMateria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridMateria.Location = new Point(77, 74);
            gridMateria.Name = "gridMateria";
            gridMateria.RowTemplate.Height = 25;
            gridMateria.Size = new Size(240, 150);
            gridMateria.TabIndex = 0;
            // 
            // TabelaMateriaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridMateria);
            Name = "TabelaMateriaControl";
            Size = new Size(405, 333);
            ((System.ComponentModel.ISupportInitialize)gridMateria).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridMateria;
    }
}
