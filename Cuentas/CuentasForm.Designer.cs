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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            EnviarCambiosButton = new Button();
            ActualizarButton = new Button();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            dgvCuentas = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            txtEmpId = new TextBox();
            panel3 = new Panel();
            AddCuenta = new Button();
            cbTipoCuenta = new ComboBox();
            label5 = new Label();
            txtValor = new TextBox();
            label4 = new Label();
            txtClasificacion = new TextBox();
            label3 = new Label();
            txtNombreCuenta = new TextBox();
            label1 = new Label();
            DeleteRowButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCuentas).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // EnviarCambiosButton
            // 
            EnviarCambiosButton.BackColor = Color.FromArgb(150, 150, 150);
            EnviarCambiosButton.FlatAppearance.BorderSize = 0;
            EnviarCambiosButton.FlatStyle = FlatStyle.Flat;
            EnviarCambiosButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            EnviarCambiosButton.ForeColor = Color.Black;
            EnviarCambiosButton.Location = new Point(550, 0);
            EnviarCambiosButton.Margin = new Padding(0);
            EnviarCambiosButton.Name = "EnviarCambiosButton";
            EnviarCambiosButton.Size = new Size(150, 30);
            EnviarCambiosButton.TabIndex = 69;
            EnviarCambiosButton.Text = "Enviar cambios";
            EnviarCambiosButton.UseVisualStyleBackColor = false;
            EnviarCambiosButton.Click += EnviarCambiosButton_Click;
            // 
            // ActualizarButton
            // 
            ActualizarButton.BackColor = Color.FromArgb(150, 150, 150);
            ActualizarButton.FlatAppearance.BorderSize = 0;
            ActualizarButton.FlatStyle = FlatStyle.Flat;
            ActualizarButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            ActualizarButton.ForeColor = Color.Black;
            ActualizarButton.Location = new Point(0, 0);
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
            bigLabel1.Text = "Administrar cuentas";
            // 
            // dgvCuentas
            // 
            dgvCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCuentas.BackgroundColor = Color.White;
            dgvCuentas.BorderStyle = BorderStyle.None;
            dgvCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvCuentas.DefaultCellStyle = dataGridViewCellStyle1;
            dgvCuentas.Dock = DockStyle.Fill;
            dgvCuentas.GridColor = Color.Black;
            dgvCuentas.Location = new Point(0, 0);
            dgvCuentas.MultiSelect = false;
            dgvCuentas.Name = "dgvCuentas";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCuentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCuentas.Size = new Size(700, 241);
            dgvCuentas.TabIndex = 71;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvCuentas);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 241);
            panel1.TabIndex = 72;
            // 
            // panel2
            // 
            panel2.Controls.Add(DeleteRowButton);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(ActualizarButton);
            panel2.Controls.Add(EnviarCambiosButton);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtEmpId);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 184);
            panel2.Name = "panel2";
            panel2.Size = new Size(700, 266);
            panel2.TabIndex = 73;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(150, 150, 150);
            label2.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(115, 0);
            label2.Margin = new Padding(0, 3, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(83, 30);
            label2.TabIndex = 62;
            label2.Text = "Empresa";
            // 
            // txtEmpId
            // 
            txtEmpId.BackColor = Color.FromArgb(242, 193, 133);
            txtEmpId.BorderStyle = BorderStyle.None;
            txtEmpId.Location = new Point(198, 0);
            txtEmpId.Margin = new Padding(0, 3, 0, 0);
            txtEmpId.Multiline = true;
            txtEmpId.Name = "txtEmpId";
            txtEmpId.Size = new Size(105, 30);
            txtEmpId.TabIndex = 63;
            txtEmpId.Text = "1";
            // 
            // panel3
            // 
            panel3.Controls.Add(AddCuenta);
            panel3.Controls.Add(cbTipoCuenta);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(txtValor);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(txtClasificacion);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtNombreCuenta);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(174, 33);
            panel3.Name = "panel3";
            panel3.Size = new Size(526, 148);
            panel3.TabIndex = 74;
            // 
            // AddCuenta
            // 
            AddCuenta.BackColor = Color.FromArgb(150, 150, 150);
            AddCuenta.FlatAppearance.BorderSize = 0;
            AddCuenta.FlatStyle = FlatStyle.Flat;
            AddCuenta.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            AddCuenta.ForeColor = Color.Black;
            AddCuenta.Location = new Point(64, 118);
            AddCuenta.Margin = new Padding(0);
            AddCuenta.Name = "AddCuenta";
            AddCuenta.Size = new Size(150, 30);
            AddCuenta.TabIndex = 72;
            AddCuenta.Text = "Añadir cuenta";
            AddCuenta.UseVisualStyleBackColor = false;
            AddCuenta.Click += AddCuenta_Click;
            // 
            // cbTipoCuenta
            // 
            cbTipoCuenta.BackColor = Color.FromArgb(242, 193, 133);
            cbTipoCuenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoCuenta.FlatStyle = FlatStyle.Flat;
            cbTipoCuenta.ForeColor = Color.Black;
            cbTipoCuenta.FormattingEnabled = true;
            cbTipoCuenta.Items.AddRange(new object[] { "Activos", "Pasivos", "Capital", "Costos", "Ventas", "Gastos", "OtrosIngresos" });
            cbTipoCuenta.Location = new Point(150, 26);
            cbTipoCuenta.Name = "cbTipoCuenta";
            cbTipoCuenta.Size = new Size(105, 23);
            cbTipoCuenta.TabIndex = 71;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(150, 150, 150);
            label5.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(0, 98);
            label5.Margin = new Padding(0, 3, 0, 0);
            label5.Name = "label5";
            label5.Size = new Size(150, 20);
            label5.TabIndex = 70;
            label5.Text = "Valor";
            // 
            // txtValor
            // 
            txtValor.BackColor = Color.FromArgb(242, 193, 133);
            txtValor.BorderStyle = BorderStyle.None;
            txtValor.Location = new Point(150, 98);
            txtValor.Margin = new Padding(0, 3, 0, 0);
            txtValor.Multiline = true;
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(105, 20);
            txtValor.TabIndex = 69;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(150, 150, 150);
            label4.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(0, 75);
            label4.Margin = new Padding(0, 3, 0, 0);
            label4.Name = "label4";
            label4.Size = new Size(150, 20);
            label4.TabIndex = 68;
            label4.Text = "Clasificación";
            // 
            // txtClasificacion
            // 
            txtClasificacion.BackColor = Color.FromArgb(242, 193, 133);
            txtClasificacion.BorderStyle = BorderStyle.None;
            txtClasificacion.Location = new Point(150, 75);
            txtClasificacion.Margin = new Padding(0, 3, 0, 0);
            txtClasificacion.Multiline = true;
            txtClasificacion.Name = "txtClasificacion";
            txtClasificacion.Size = new Size(105, 20);
            txtClasificacion.TabIndex = 67;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(150, 150, 150);
            label3.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(0, 52);
            label3.Margin = new Padding(0, 3, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(150, 20);
            label3.TabIndex = 66;
            label3.Text = "Nombre de cuenta";
            // 
            // txtNombreCuenta
            // 
            txtNombreCuenta.BackColor = Color.FromArgb(242, 193, 133);
            txtNombreCuenta.BorderStyle = BorderStyle.None;
            txtNombreCuenta.Location = new Point(150, 52);
            txtNombreCuenta.Margin = new Padding(0, 3, 0, 0);
            txtNombreCuenta.Multiline = true;
            txtNombreCuenta.Name = "txtNombreCuenta";
            txtNombreCuenta.Size = new Size(105, 20);
            txtNombreCuenta.TabIndex = 65;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(150, 150, 150);
            label1.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 29);
            label1.Margin = new Padding(0, 3, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(150, 20);
            label1.TabIndex = 64;
            label1.Text = "Tipo de cuenta";
            // 
            // DeleteRowButton
            // 
            DeleteRowButton.BackColor = Color.FromArgb(150, 150, 150);
            DeleteRowButton.FlatAppearance.BorderSize = 0;
            DeleteRowButton.FlatStyle = FlatStyle.Flat;
            DeleteRowButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            DeleteRowButton.ForeColor = Color.Black;
            DeleteRowButton.Location = new Point(391, 0);
            DeleteRowButton.Margin = new Padding(0);
            DeleteRowButton.Name = "DeleteRowButton";
            DeleteRowButton.Size = new Size(150, 30);
            DeleteRowButton.TabIndex = 75;
            DeleteRowButton.Text = "Eliminar cuenta";
            DeleteRowButton.UseVisualStyleBackColor = false;
            DeleteRowButton.Click += DeleteRowButton_Click;
            // 
            // Estado_de_resultados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(187, 232, 242);
            ClientSize = new Size(700, 450);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(bigLabel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Estado_de_resultados";
            Text = "Estado_de_resultados";
            ((System.ComponentModel.ISupportInitialize)dgvCuentas).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button EnviarCambiosButton;
        private Button ActualizarButton;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private DataGridView dgvCuentas;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label2;
        private ComboBox cbTipoCuenta;
        private Label label5;
        private TextBox txtValor;
        private Label label4;
        private TextBox txtClasificacion;
        private Label label3;
        private TextBox txtNombreCuenta;
        private Label label1;
        private TextBox txtEmpId;
        private Button AddCuenta;
        private Button DeleteRowButton;
    }
}