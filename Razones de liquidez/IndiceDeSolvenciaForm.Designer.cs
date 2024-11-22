namespace RazonesFinancieras.Razones_de_liquidez
{
    partial class IndiceDeSolvenciaForm
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
            EvaluarButton = new Button();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            PasivoCirculantetextBoxPasivoCirculantetextBox = new TextBox();
            textBox7 = new TextBox();
            textBox9 = new TextBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // EvaluarButton
            // 
            EvaluarButton.BackColor = Color.FromArgb(150, 150, 150);
            EvaluarButton.FlatAppearance.BorderSize = 0;
            EvaluarButton.FlatStyle = FlatStyle.Flat;
            EvaluarButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            EvaluarButton.ForeColor = Color.Black;
            EvaluarButton.Location = new Point(300, 270);
            EvaluarButton.Margin = new Padding(0);
            EvaluarButton.Name = "EvaluarButton";
            EvaluarButton.Size = new Size(100, 30);
            EvaluarButton.TabIndex = 17;
            EvaluarButton.Text = "Evaluar";
            EvaluarButton.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(150, 150, 150);
            label4.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(0, 280);
            label4.Name = "label4";
            label4.Size = new Size(150, 20);
            label4.TabIndex = 16;
            label4.Text = "Conclusion";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(0, 300);
            textBox1.Margin = new Padding(0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(700, 100);
            textBox1.TabIndex = 15;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(150, 150, 150);
            label3.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(140, 200);
            label3.Name = "label3";
            label3.Size = new Size(160, 20);
            label3.TabIndex = 14;
            label3.Text = "Indice de solvencia";
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(150, 150, 150);
            label2.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(400, 100);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 13;
            label2.Text = "Pasivo circulante";
            // 
            // PasivoCirculantetextBoxPasivoCirculantetextBox
            // 
            PasivoCirculantetextBoxPasivoCirculantetextBox.BorderStyle = BorderStyle.None;
            PasivoCirculantetextBoxPasivoCirculantetextBox.Location = new Point(550, 100);
            PasivoCirculantetextBoxPasivoCirculantetextBox.Margin = new Padding(0);
            PasivoCirculantetextBoxPasivoCirculantetextBox.Multiline = true;
            PasivoCirculantetextBoxPasivoCirculantetextBox.Name = "PasivoCirculantetextBoxPasivoCirculantetextBox";
            PasivoCirculantetextBoxPasivoCirculantetextBox.Size = new Size(100, 20);
            PasivoCirculantetextBoxPasivoCirculantetextBox.TabIndex = 10;
            // 
            // textBox7
            // 
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.Location = new Point(200, 100);
            textBox7.Margin = new Padding(0);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 20);
            textBox7.TabIndex = 9;
            // 
            // textBox9
            // 
            textBox9.BorderStyle = BorderStyle.None;
            textBox9.Location = new Point(300, 200);
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(100, 20);
            textBox9.TabIndex = 11;
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(150, 150, 150);
            label9.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(50, 100);
            label9.Name = "label9";
            label9.Size = new Size(150, 20);
            label9.TabIndex = 12;
            label9.Text = "Activo circulante";
            // 
            // IndiceDeSolvenciaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(187, 232, 242);
            ClientSize = new Size(700, 450);
            Controls.Add(EvaluarButton);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label9);
            Controls.Add(label3);
            Controls.Add(textBox9);
            Controls.Add(label2);
            Controls.Add(textBox7);
            Controls.Add(PasivoCirculantetextBoxPasivoCirculantetextBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "IndiceDeSolvenciaForm";
            Text = "IndiceDeSolvenciaForm";
            Load += IndiceDeSolvenciaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EvaluarButton;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private TextBox PasivoCirculantetextBoxPasivoCirculantetextBox;
        private TextBox textBox7;
        private TextBox textBox9;
        private Label label9;
    }
}