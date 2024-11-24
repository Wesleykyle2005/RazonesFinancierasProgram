namespace RazonesFinancieras.Razones_de_actividad
{
    partial class RotacionDeActivosTotalesForm
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
            label9 = new Label();
            label3 = new Label();
            RotacionDeActivosTotalestxt = new TextBox();
            label2 = new Label();
            Ventastxt = new TextBox();
            ACtivosTotalestxt = new TextBox();
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
            EvaluarButton.TabIndex = 64;
            EvaluarButton.Text = "Evaluar";
            EvaluarButton.UseVisualStyleBackColor = false;
            EvaluarButton.Click += EvaluarButton_Click;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(150, 150, 150);
            label4.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(0, 280);
            label4.Name = "label4";
            label4.Size = new Size(150, 20);
            label4.TabIndex = 63;
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
            textBox1.TabIndex = 62;
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(150, 150, 150);
            label9.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(50, 100);
            label9.Name = "label9";
            label9.Size = new Size(150, 20);
            label9.TabIndex = 59;
            label9.Text = "Ventas";
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(150, 150, 150);
            label3.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(140, 200);
            label3.Name = "label3";
            label3.Size = new Size(160, 40);
            label3.TabIndex = 61;
            label3.Text = "Rotacion de los activos totales";
            // 
            // RotacionDeActivosTotalestxt
            // 
            RotacionDeActivosTotalestxt.BorderStyle = BorderStyle.None;
            RotacionDeActivosTotalestxt.Location = new Point(300, 200);
            RotacionDeActivosTotalestxt.Multiline = true;
            RotacionDeActivosTotalestxt.Name = "RotacionDeActivosTotalestxt";
            RotacionDeActivosTotalestxt.Size = new Size(100, 20);
            RotacionDeActivosTotalestxt.TabIndex = 58;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(150, 150, 150);
            label2.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(400, 100);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 60;
            label2.Text = "Activos totales";
            // 
            // Ventastxt
            // 
            Ventastxt.BorderStyle = BorderStyle.None;
            Ventastxt.Location = new Point(200, 100);
            Ventastxt.Margin = new Padding(0);
            Ventastxt.Multiline = true;
            Ventastxt.Name = "Ventastxt";
            Ventastxt.Size = new Size(100, 20);
            Ventastxt.TabIndex = 56;
            // 
            // ACtivosTotalestxt
            // 
            ACtivosTotalestxt.BorderStyle = BorderStyle.None;
            ACtivosTotalestxt.Location = new Point(550, 100);
            ACtivosTotalestxt.Margin = new Padding(0);
            ACtivosTotalestxt.Multiline = true;
            ACtivosTotalestxt.Name = "ACtivosTotalestxt";
            ACtivosTotalestxt.Size = new Size(100, 20);
            ACtivosTotalestxt.TabIndex = 57;
            // 
            // RotacionDeActivosTotalesForm
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
            Controls.Add(RotacionDeActivosTotalestxt);
            Controls.Add(label2);
            Controls.Add(Ventastxt);
            Controls.Add(ACtivosTotalestxt);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RotacionDeActivosTotalesForm";
            Text = "RotacionDeActivosTotalesForm";
            Load += RotacionDeActivosTotalesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EvaluarButton;
        private Label label4;
        private TextBox textBox1;
        private Label label9;
        private Label label3;
        private TextBox RotacionDeActivosTotalestxt;
        private Label label2;
        private TextBox Ventastxt;
        private TextBox ACtivosTotalestxt;
    }
}