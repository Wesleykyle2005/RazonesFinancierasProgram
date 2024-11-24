namespace RazonesFinancieras.Estados_financieros
{
    partial class Estado_de_resultados
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
            EnviarCambiosButton = new Button();
            ActualizarButton = new Button();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            dgvER = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvER).BeginInit();
            SuspendLayout();
            // 
            // EnviarCambiosButton
            // 
            EnviarCambiosButton.BackColor = Color.FromArgb(150, 150, 150);
            EnviarCambiosButton.FlatAppearance.BorderSize = 0;
            EnviarCambiosButton.FlatStyle = FlatStyle.Flat;
            EnviarCambiosButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            EnviarCambiosButton.ForeColor = Color.Black;
            EnviarCambiosButton.Location = new Point(550, 70);
            EnviarCambiosButton.Margin = new Padding(0);
            EnviarCambiosButton.Name = "EnviarCambiosButton";
            EnviarCambiosButton.Size = new Size(150, 30);
            EnviarCambiosButton.TabIndex = 69;
            EnviarCambiosButton.Text = "Enviar cambios";
            EnviarCambiosButton.UseVisualStyleBackColor = false;
            // 
            // ActualizarButton
            // 
            ActualizarButton.BackColor = Color.FromArgb(150, 150, 150);
            ActualizarButton.FlatAppearance.BorderSize = 0;
            ActualizarButton.FlatStyle = FlatStyle.Flat;
            ActualizarButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            ActualizarButton.ForeColor = Color.Black;
            ActualizarButton.Location = new Point(0, 70);
            ActualizarButton.Margin = new Padding(0);
            ActualizarButton.Name = "ActualizarButton";
            ActualizarButton.Size = new Size(100, 30);
            ActualizarButton.TabIndex = 68;
            ActualizarButton.Text = "Actualizar";
            ActualizarButton.UseVisualStyleBackColor = false;
            ActualizarButton.Click += ActualizarButton_Click;
            // 
            // bigLabel1
            // 
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Arial Black", 20F, FontStyle.Bold);
            bigLabel1.ForeColor = Color.Black;
            bigLabel1.Location = new Point(0, 0);
            bigLabel1.Margin = new Padding(0);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(350, 45);
            bigLabel1.TabIndex = 70;
            bigLabel1.Text = "Estado de resultados\r\n";
            // 
            // dgvER
            // 
            dgvER.BackgroundColor = Color.White;
            dgvER.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvER.Dock = DockStyle.Bottom;
            dgvER.GridColor = Color.Black;
            dgvER.Location = new Point(0, 100);
            dgvER.Name = "dgvER";
            dgvER.Size = new Size(700, 350);
            dgvER.TabIndex = 71;
            // 
            // Estado_de_resultados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(187, 232, 242);
            ClientSize = new Size(700, 450);
            Controls.Add(dgvER);
            Controls.Add(bigLabel1);
            Controls.Add(EnviarCambiosButton);
            Controls.Add(ActualizarButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Estado_de_resultados";
            Text = "Estado_de_resultados";
            Load += Estado_de_resultados_Load;
            ((System.ComponentModel.ISupportInitialize)dgvER).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button EnviarCambiosButton;
        private Button ActualizarButton;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private DataGridView dgvER;
    }
}