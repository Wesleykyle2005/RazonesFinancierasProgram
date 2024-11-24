namespace RazonesFinancieras.Razones_de_endeudamiento
{
    partial class RazonDeDeudaTotalForm
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
            ConclusionTextBox = new TextBox();
            label9 = new Label();
            label3 = new Label();
            RazonDeLaDeudaTextBox = new TextBox();
            label2 = new Label();
            PaivosTotalesTextBox = new TextBox();
            ActivosTotalesTextBox = new TextBox();
            button2 = new Button();
            copyButton = new Button();
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
            // ConclusionTextBox
            // 
            ConclusionTextBox.BorderStyle = BorderStyle.None;
            ConclusionTextBox.Location = new Point(0, 300);
            ConclusionTextBox.Margin = new Padding(0);
            ConclusionTextBox.Multiline = true;
            ConclusionTextBox.Name = "ConclusionTextBox";
            ConclusionTextBox.Size = new Size(700, 100);
            ConclusionTextBox.TabIndex = 62;
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
            label9.Text = "Pasivos totales";
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(150, 150, 150);
            label3.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(141, 200);
            label3.Name = "label3";
            label3.Size = new Size(160, 20);
            label3.TabIndex = 61;
            label3.Text = "Razón de la deuda";
            // 
            // RazonDeLaDeudaTextBox
            // 
            RazonDeLaDeudaTextBox.BackColor = Color.FromArgb(242, 193, 133);
            RazonDeLaDeudaTextBox.BorderStyle = BorderStyle.None;
            RazonDeLaDeudaTextBox.Location = new Point(300, 200);
            RazonDeLaDeudaTextBox.Multiline = true;
            RazonDeLaDeudaTextBox.Name = "RazonDeLaDeudaTextBox";
            RazonDeLaDeudaTextBox.Size = new Size(100, 20);
            RazonDeLaDeudaTextBox.TabIndex = 58;
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
            // PaivosTotalesTextBox
            // 
            PaivosTotalesTextBox.BackColor = Color.FromArgb(242, 193, 133);
            PaivosTotalesTextBox.BorderStyle = BorderStyle.None;
            PaivosTotalesTextBox.Location = new Point(200, 100);
            PaivosTotalesTextBox.Margin = new Padding(0);
            PaivosTotalesTextBox.Multiline = true;
            PaivosTotalesTextBox.Name = "PaivosTotalesTextBox";
            PaivosTotalesTextBox.Size = new Size(100, 20);
            PaivosTotalesTextBox.TabIndex = 56;
            // 
            // ActivosTotalesTextBox
            // 
            ActivosTotalesTextBox.BackColor = Color.FromArgb(242, 193, 133);
            ActivosTotalesTextBox.BorderStyle = BorderStyle.None;
            ActivosTotalesTextBox.Location = new Point(550, 100);
            ActivosTotalesTextBox.Margin = new Padding(0);
            ActivosTotalesTextBox.Multiline = true;
            ActivosTotalesTextBox.Name = "ActivosTotalesTextBox";
            ActivosTotalesTextBox.Size = new Size(100, 20);
            ActivosTotalesTextBox.TabIndex = 57;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(150, 150, 150);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(500, 400);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(200, 30);
            button2.TabIndex = 79;
            button2.Text = "Guardar al informe final";
            button2.UseVisualStyleBackColor = false;
            // 
            // copyButton
            // 
            copyButton.BackColor = Color.FromArgb(150, 150, 150);
            copyButton.FlatAppearance.BorderSize = 0;
            copyButton.FlatStyle = FlatStyle.Flat;
            copyButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            copyButton.ForeColor = Color.Black;
            copyButton.Location = new Point(0, 400);
            copyButton.Margin = new Padding(0);
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(200, 30);
            copyButton.TabIndex = 78;
            copyButton.Text = "Copiar al portapapeles";
            copyButton.UseVisualStyleBackColor = false;
            copyButton.Click += copyButton_Click;
            // 
            // RazonDeDeudaTotalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(187, 232, 242);
            ClientSize = new Size(700, 450);
            Controls.Add(button2);
            Controls.Add(copyButton);
            Controls.Add(EvaluarButton);
            Controls.Add(label4);
            Controls.Add(ConclusionTextBox);
            Controls.Add(label9);
            Controls.Add(label3);
            Controls.Add(RazonDeLaDeudaTextBox);
            Controls.Add(label2);
            Controls.Add(PaivosTotalesTextBox);
            Controls.Add(ActivosTotalesTextBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RazonDeDeudaTotalForm";
            Text = "RazonDeDeudaTotalForm";
            Load += RazonDeDeudaTotalForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EvaluarButton;
        private Label label4;
        private TextBox ConclusionTextBox;
        private Label label9;
        private Label label3;
        private TextBox RazonDeLaDeudaTextBox;
        private Label label2;
        private TextBox PaivosTotalesTextBox;
        private TextBox ActivosTotalesTextBox;
        private Button button2;
        private Button copyButton;
    }
}