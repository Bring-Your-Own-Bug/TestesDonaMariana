namespace TestesDonaMariana.WinApp.ModuloTeste
{
    partial class TelaTesteForm
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
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            label1 = new Label();
            SuspendLayout();
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Cursor = Cursors.Hand;
            radioButton1.ForeColor = SystemColors.ControlText;
            radioButton1.Location = new Point(52, 192);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(91, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Alternativa 1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Cursor = Cursors.Hand;
            radioButton2.ForeColor = SystemColors.ControlText;
            radioButton2.Location = new Point(52, 217);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(91, 19);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Alternativa 1";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Cursor = Cursors.Hand;
            radioButton3.ForeColor = SystemColors.ControlText;
            radioButton3.Location = new Point(52, 242);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(91, 19);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "Alternativa 1";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Cursor = Cursors.Hand;
            radioButton4.ForeColor = SystemColors.ControlText;
            radioButton4.Location = new Point(52, 267);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(91, 19);
            radioButton4.TabIndex = 3;
            radioButton4.TabStop = true;
            radioButton4.Text = "Alternativa 1";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(384, 139);
            label1.TabIndex = 4;
            label1.Text = "ENUNCIADO";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TelaTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(408, 361);
            Controls.Add(label1);
            Controls.Add(radioButton4);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaTesteForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Teste";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private Label label1;
    }
}