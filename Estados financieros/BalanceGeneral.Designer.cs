namespace RazonesFinancieras
{
    partial class BalanceGeneral
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
            ActualizarButton = new Button();
            button1 = new Button();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            SuspendLayout();
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
            ActualizarButton.TabIndex = 65;
            ActualizarButton.Text = "Actualizar";
            ActualizarButton.UseVisualStyleBackColor = false;
            ActualizarButton.Click += ActualizarButton_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(150, 150, 150);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(550, 70);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(150, 30);
            button1.TabIndex = 66;
            button1.Text = "Enviar cambios";
            button1.UseVisualStyleBackColor = false;
            // 
            // bigLabel1
            // 
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Arial Black", 20F, FontStyle.Bold);
            bigLabel1.ForeColor = Color.Black;
            bigLabel1.Location = new Point(0, 0);
            bigLabel1.Margin = new Padding(0);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(300, 45);
            bigLabel1.TabIndex = 67;
            bigLabel1.Text = "Balance General";
            // 
            // BalanceGeneral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(187, 232, 242);
            ClientSize = new Size(700, 450);
            Controls.Add(bigLabel1);
            Controls.Add(button1);
            Controls.Add(ActualizarButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BalanceGeneral";
            Text = "BalanceGeneral";
            Load += BalanceGeneral_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button ActualizarButton;
        private Button button1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
    }
}