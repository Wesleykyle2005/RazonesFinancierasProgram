namespace RazonesFinancieras.Razones_de_actividad
{
    partial class PeriodoDeCobroPromedioForm
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
            PeriodoPromedioDeCobrotxt = new TextBox();
            label2 = new Label();
            CuentasPorCobrarTxt = new TextBox();
            VentasTxt = new TextBox();
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
            EvaluarButton.TabIndex = 55;
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
            label4.TabIndex = 54;
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
            textBox1.TabIndex = 53;
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(150, 150, 150);
            label9.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(50, 100);
            label9.Name = "label9";
            label9.Size = new Size(150, 40);
            label9.TabIndex = 50;
            label9.Text = "Cuentas por cobrar";
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(150, 150, 150);
            label3.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(140, 200);
            label3.Name = "label3";
            label3.Size = new Size(160, 40);
            label3.TabIndex = 52;
            label3.Text = "Promedio de cobro promedio";
            // 
            // PeriodoPromedioDeCobrotxt
            // 
            PeriodoPromedioDeCobrotxt.BorderStyle = BorderStyle.None;
            PeriodoPromedioDeCobrotxt.Location = new Point(300, 200);
            PeriodoPromedioDeCobrotxt.Multiline = true;
            PeriodoPromedioDeCobrotxt.Name = "PeriodoPromedioDeCobrotxt";
            PeriodoPromedioDeCobrotxt.Size = new Size(100, 20);
            PeriodoPromedioDeCobrotxt.TabIndex = 49;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(150, 150, 150);
            label2.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(400, 100);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 51;
            label2.Text = "Ventas anuales";
            // 
            // CuentasPorCobrarTxt
            // 
            CuentasPorCobrarTxt.BorderStyle = BorderStyle.None;
            CuentasPorCobrarTxt.Location = new Point(200, 100);
            CuentasPorCobrarTxt.Margin = new Padding(0);
            CuentasPorCobrarTxt.Multiline = true;
            CuentasPorCobrarTxt.Name = "CuentasPorCobrarTxt";
            CuentasPorCobrarTxt.Size = new Size(100, 20);
            CuentasPorCobrarTxt.TabIndex = 47;
            // 
            // VentasTxt
            // 
            VentasTxt.BorderStyle = BorderStyle.None;
            VentasTxt.Location = new Point(550, 100);
            VentasTxt.Margin = new Padding(0);
            VentasTxt.Multiline = true;
            VentasTxt.Name = "VentasTxt";
            VentasTxt.Size = new Size(100, 20);
            VentasTxt.TabIndex = 48;
            // 
            // PeriodoDeCobroPromedioForm
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
            Controls.Add(PeriodoPromedioDeCobrotxt);
            Controls.Add(label2);
            Controls.Add(CuentasPorCobrarTxt);
            Controls.Add(VentasTxt);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PeriodoDeCobroPromedioForm";
            Text = "PeriodoDePagoPromedioForm";
            Load += PeriodoDePagoPromedioForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EvaluarButton;
        private Label label4;
        private TextBox textBox1;
        private Label label9;
        private Label label3;
        private TextBox PeriodoPromedioDeCobrotxt;
        private Label label2;
        private TextBox CuentasPorCobrarTxt;
        private TextBox VentasTxt;
    }
}