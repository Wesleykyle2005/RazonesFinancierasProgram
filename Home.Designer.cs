namespace RazonesFinancieras
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            MenuContainerEstadosFinancieros = new Panel();
            EstadoDeResultadosButton = new Button();
            iconButtonEstadosFinancieros = new FontAwesome.Sharp.IconButton();
            MenuContainerLiquidez = new Panel();
            PruebaRapidaButton = new Button();
            IndiceDeSolvenciaButton = new Button();
            CapitalDeTrabajoNetoButton = new Button();
            iconButtonRazonLiquidez = new FontAwesome.Sharp.IconButton();
            MenuContainerActividad = new Panel();
            RotacionDeActivosTotalesButton = new Button();
            RotacionDeActivosFijosButton = new Button();
            PeriodoDePagoPromedioButton = new Button();
            RazonDeCuentasPorCobrarButton = new Button();
            RazonDeRotacionDeInventarioButton = new Button();
            iconButtonRazonActividad = new FontAwesome.Sharp.IconButton();
            MenuContainerEndeudamiento = new Panel();
            RazonDeRotacionDeInteresAUtilidadesButton = new Button();
            RazonDePasivoACapitalButton = new Button();
            RazonDeDeudaTotalButton = new Button();
            iconButtonRazonEndeudamiento = new FontAwesome.Sharp.IconButton();
            MenuContainerRentabilidad = new Panel();
            MargenDeUtilidadNetaButton = new Button();
            MargenDeUtilidadDeOperacionButton = new Button();
            MargenDeUtilidadBrutaButton = new Button();
            iconButtonRazonRentabilidad = new FontAwesome.Sharp.IconButton();
            MenuActividadesLiquidez = new System.Windows.Forms.Timer(components);
            MenuRazonActividad = new System.Windows.Forms.Timer(components);
            MenuRazonRentabilidad = new System.Windows.Forms.Timer(components);
            MenuRazonEndeudamiento = new System.Windows.Forms.Timer(components);
            MenuEstadosFinancieros = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            MenuContainerEstadosFinancieros.SuspendLayout();
            MenuContainerLiquidez.SuspendLayout();
            MenuContainerActividad.SuspendLayout();
            MenuContainerEndeudamiento.SuspendLayout();
            MenuContainerRentabilidad.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(242, 193, 133);
            panel1.Controls.Add(nightControlBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 50);
            panel1.TabIndex = 0;
            // 
            // nightControlBox1
            // 
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(199, 80, 80);
            nightControlBox1.CloseHoverForeColor = Color.FromArgb(187, 232, 242);
            nightControlBox1.DefaultLocation = true;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.Dock = DockStyle.Right;
            nightControlBox1.EnableCloseColor = Color.FromArgb(217, 102, 102);
            nightControlBox1.EnableMaximizeButton = true;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(217, 102, 102);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(217, 102, 102);
            nightControlBox1.Location = new Point(861, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(187, 232, 242);
            nightControlBox1.MaximizeHoverForeColor = Color.FromArgb(217, 102, 102);
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(187, 232, 242);
            nightControlBox1.MinimizeHoverForeColor = Color.FromArgb(217, 102, 102);
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(360, 9);
            label1.Name = "label1";
            label1.Size = new Size(281, 33);
            label1.TabIndex = 1;
            label1.Text = "Razones financieras";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(59, 55, 64);
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(MenuContainerEstadosFinancieros);
            flowLayoutPanel1.Controls.Add(MenuContainerLiquidez);
            flowLayoutPanel1.Controls.Add(MenuContainerActividad);
            flowLayoutPanel1.Controls.Add(MenuContainerEndeudamiento);
            flowLayoutPanel1.Controls.Add(MenuContainerRentabilidad);
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 50);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(300, 700);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // MenuContainerEstadosFinancieros
            // 
            MenuContainerEstadosFinancieros.BackColor = Color.FromArgb(59, 55, 64);
            MenuContainerEstadosFinancieros.Controls.Add(EstadoDeResultadosButton);
            MenuContainerEstadosFinancieros.Controls.Add(iconButtonEstadosFinancieros);
            MenuContainerEstadosFinancieros.Dock = DockStyle.Top;
            MenuContainerEstadosFinancieros.Location = new Point(0, 0);
            MenuContainerEstadosFinancieros.Margin = new Padding(0);
            MenuContainerEstadosFinancieros.Name = "MenuContainerEstadosFinancieros";
            MenuContainerEstadosFinancieros.Size = new Size(300, 90);
            MenuContainerEstadosFinancieros.TabIndex = 11;
            // 
            // EstadoDeResultadosButton
            // 
            EstadoDeResultadosButton.BackColor = Color.FromArgb(59, 55, 64);
            EstadoDeResultadosButton.Dock = DockStyle.Top;
            EstadoDeResultadosButton.FlatAppearance.BorderSize = 0;
            EstadoDeResultadosButton.FlatStyle = FlatStyle.Flat;
            EstadoDeResultadosButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            EstadoDeResultadosButton.ForeColor = Color.FromArgb(187, 232, 242);
            EstadoDeResultadosButton.Location = new Point(0, 30);
            EstadoDeResultadosButton.Name = "EstadoDeResultadosButton";
            EstadoDeResultadosButton.Size = new Size(300, 25);
            EstadoDeResultadosButton.TabIndex = 5;
            EstadoDeResultadosButton.Text = "Cuentas";
            EstadoDeResultadosButton.TextAlign = ContentAlignment.MiddleLeft;
            EstadoDeResultadosButton.UseVisualStyleBackColor = false;
            EstadoDeResultadosButton.Click += EstadoDeResultadosButton_Click;
            // 
            // iconButtonEstadosFinancieros
            // 
            iconButtonEstadosFinancieros.BackColor = Color.FromArgb(62, 110, 140);
            iconButtonEstadosFinancieros.Dock = DockStyle.Top;
            iconButtonEstadosFinancieros.FlatAppearance.BorderColor = Color.Black;
            iconButtonEstadosFinancieros.FlatStyle = FlatStyle.Flat;
            iconButtonEstadosFinancieros.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            iconButtonEstadosFinancieros.ForeColor = Color.Black;
            iconButtonEstadosFinancieros.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            iconButtonEstadosFinancieros.IconColor = Color.Black;
            iconButtonEstadosFinancieros.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButtonEstadosFinancieros.IconSize = 30;
            iconButtonEstadosFinancieros.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonEstadosFinancieros.Location = new Point(0, 0);
            iconButtonEstadosFinancieros.Margin = new Padding(0);
            iconButtonEstadosFinancieros.Name = "iconButtonEstadosFinancieros";
            iconButtonEstadosFinancieros.Size = new Size(300, 30);
            iconButtonEstadosFinancieros.TabIndex = 10;
            iconButtonEstadosFinancieros.Text = "      Administrar cuentas";
            iconButtonEstadosFinancieros.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonEstadosFinancieros.TextImageRelation = TextImageRelation.ImageAboveText;
            iconButtonEstadosFinancieros.UseVisualStyleBackColor = false;
            iconButtonEstadosFinancieros.Click += iconButtonEstadosFinancieros_Click;
            // 
            // MenuContainerLiquidez
            // 
            MenuContainerLiquidez.BackColor = Color.FromArgb(59, 55, 64);
            MenuContainerLiquidez.Controls.Add(PruebaRapidaButton);
            MenuContainerLiquidez.Controls.Add(IndiceDeSolvenciaButton);
            MenuContainerLiquidez.Controls.Add(CapitalDeTrabajoNetoButton);
            MenuContainerLiquidez.Controls.Add(iconButtonRazonLiquidez);
            MenuContainerLiquidez.Dock = DockStyle.Top;
            MenuContainerLiquidez.Location = new Point(0, 90);
            MenuContainerLiquidez.Margin = new Padding(0);
            MenuContainerLiquidez.Name = "MenuContainerLiquidez";
            MenuContainerLiquidez.Size = new Size(300, 126);
            MenuContainerLiquidez.TabIndex = 3;
            // 
            // PruebaRapidaButton
            // 
            PruebaRapidaButton.BackColor = Color.FromArgb(59, 55, 64);
            PruebaRapidaButton.Dock = DockStyle.Top;
            PruebaRapidaButton.FlatAppearance.BorderSize = 0;
            PruebaRapidaButton.FlatStyle = FlatStyle.Flat;
            PruebaRapidaButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            PruebaRapidaButton.ForeColor = Color.FromArgb(187, 232, 242);
            PruebaRapidaButton.Location = new Point(0, 80);
            PruebaRapidaButton.Name = "PruebaRapidaButton";
            PruebaRapidaButton.Size = new Size(300, 25);
            PruebaRapidaButton.TabIndex = 6;
            PruebaRapidaButton.Text = "Prueba rápida";
            PruebaRapidaButton.TextAlign = ContentAlignment.MiddleLeft;
            PruebaRapidaButton.UseVisualStyleBackColor = false;
            PruebaRapidaButton.Click += PruebaRapidaButton_Click;
            // 
            // IndiceDeSolvenciaButton
            // 
            IndiceDeSolvenciaButton.BackColor = Color.FromArgb(59, 55, 64);
            IndiceDeSolvenciaButton.Dock = DockStyle.Top;
            IndiceDeSolvenciaButton.FlatAppearance.BorderSize = 0;
            IndiceDeSolvenciaButton.FlatStyle = FlatStyle.Flat;
            IndiceDeSolvenciaButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            IndiceDeSolvenciaButton.ForeColor = Color.FromArgb(187, 232, 242);
            IndiceDeSolvenciaButton.Location = new Point(0, 55);
            IndiceDeSolvenciaButton.Name = "IndiceDeSolvenciaButton";
            IndiceDeSolvenciaButton.Size = new Size(300, 25);
            IndiceDeSolvenciaButton.TabIndex = 5;
            IndiceDeSolvenciaButton.Text = "Índice de solvencia";
            IndiceDeSolvenciaButton.TextAlign = ContentAlignment.MiddleLeft;
            IndiceDeSolvenciaButton.UseVisualStyleBackColor = false;
            IndiceDeSolvenciaButton.Click += IndiceDeSolvenciaButton_Click;
            // 
            // CapitalDeTrabajoNetoButton
            // 
            CapitalDeTrabajoNetoButton.BackColor = Color.FromArgb(59, 55, 64);
            CapitalDeTrabajoNetoButton.Dock = DockStyle.Top;
            CapitalDeTrabajoNetoButton.FlatAppearance.BorderSize = 0;
            CapitalDeTrabajoNetoButton.FlatStyle = FlatStyle.Flat;
            CapitalDeTrabajoNetoButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            CapitalDeTrabajoNetoButton.ForeColor = Color.FromArgb(187, 232, 242);
            CapitalDeTrabajoNetoButton.Location = new Point(0, 30);
            CapitalDeTrabajoNetoButton.Name = "CapitalDeTrabajoNetoButton";
            CapitalDeTrabajoNetoButton.Size = new Size(300, 25);
            CapitalDeTrabajoNetoButton.TabIndex = 4;
            CapitalDeTrabajoNetoButton.Text = "Capital de trabajo neto";
            CapitalDeTrabajoNetoButton.TextAlign = ContentAlignment.MiddleLeft;
            CapitalDeTrabajoNetoButton.UseVisualStyleBackColor = false;
            CapitalDeTrabajoNetoButton.Click += CapitalDeTrabajoNetoButton_Click;
            // 
            // iconButtonRazonLiquidez
            // 
            iconButtonRazonLiquidez.BackColor = Color.FromArgb(62, 110, 140);
            iconButtonRazonLiquidez.Dock = DockStyle.Top;
            iconButtonRazonLiquidez.FlatAppearance.BorderColor = Color.Black;
            iconButtonRazonLiquidez.FlatStyle = FlatStyle.Flat;
            iconButtonRazonLiquidez.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            iconButtonRazonLiquidez.ForeColor = Color.Black;
            iconButtonRazonLiquidez.IconChar = FontAwesome.Sharp.IconChar.Coins;
            iconButtonRazonLiquidez.IconColor = Color.Black;
            iconButtonRazonLiquidez.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButtonRazonLiquidez.IconSize = 30;
            iconButtonRazonLiquidez.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonRazonLiquidez.Location = new Point(0, 0);
            iconButtonRazonLiquidez.Margin = new Padding(0);
            iconButtonRazonLiquidez.Name = "iconButtonRazonLiquidez";
            iconButtonRazonLiquidez.Size = new Size(300, 30);
            iconButtonRazonLiquidez.TabIndex = 2;
            iconButtonRazonLiquidez.Text = "      Razones de liquidez";
            iconButtonRazonLiquidez.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonRazonLiquidez.UseVisualStyleBackColor = false;
            iconButtonRazonLiquidez.Click += iconButtonRazonLiquidez_Click_1;
            // 
            // MenuContainerActividad
            // 
            MenuContainerActividad.BackColor = Color.FromArgb(59, 55, 64);
            MenuContainerActividad.Controls.Add(RotacionDeActivosTotalesButton);
            MenuContainerActividad.Controls.Add(RotacionDeActivosFijosButton);
            MenuContainerActividad.Controls.Add(PeriodoDePagoPromedioButton);
            MenuContainerActividad.Controls.Add(RazonDeCuentasPorCobrarButton);
            MenuContainerActividad.Controls.Add(RazonDeRotacionDeInventarioButton);
            MenuContainerActividad.Controls.Add(iconButtonRazonActividad);
            MenuContainerActividad.Dock = DockStyle.Top;
            MenuContainerActividad.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            MenuContainerActividad.Location = new Point(0, 216);
            MenuContainerActividad.Margin = new Padding(0);
            MenuContainerActividad.Name = "MenuContainerActividad";
            MenuContainerActividad.Size = new Size(300, 174);
            MenuContainerActividad.TabIndex = 7;
            // 
            // RotacionDeActivosTotalesButton
            // 
            RotacionDeActivosTotalesButton.BackColor = Color.FromArgb(59, 55, 64);
            RotacionDeActivosTotalesButton.Dock = DockStyle.Top;
            RotacionDeActivosTotalesButton.FlatAppearance.BorderSize = 0;
            RotacionDeActivosTotalesButton.FlatStyle = FlatStyle.Flat;
            RotacionDeActivosTotalesButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            RotacionDeActivosTotalesButton.ForeColor = Color.FromArgb(187, 232, 242);
            RotacionDeActivosTotalesButton.Location = new Point(0, 130);
            RotacionDeActivosTotalesButton.Name = "RotacionDeActivosTotalesButton";
            RotacionDeActivosTotalesButton.Size = new Size(300, 25);
            RotacionDeActivosTotalesButton.TabIndex = 8;
            RotacionDeActivosTotalesButton.Text = "Rotación de activos totales";
            RotacionDeActivosTotalesButton.TextAlign = ContentAlignment.MiddleLeft;
            RotacionDeActivosTotalesButton.UseVisualStyleBackColor = false;
            RotacionDeActivosTotalesButton.Click += RotacionDeActivosTotalesButton_Click;
            // 
            // RotacionDeActivosFijosButton
            // 
            RotacionDeActivosFijosButton.BackColor = Color.FromArgb(59, 55, 64);
            RotacionDeActivosFijosButton.Dock = DockStyle.Top;
            RotacionDeActivosFijosButton.FlatAppearance.BorderSize = 0;
            RotacionDeActivosFijosButton.FlatStyle = FlatStyle.Flat;
            RotacionDeActivosFijosButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            RotacionDeActivosFijosButton.ForeColor = Color.FromArgb(187, 232, 242);
            RotacionDeActivosFijosButton.Location = new Point(0, 105);
            RotacionDeActivosFijosButton.Name = "RotacionDeActivosFijosButton";
            RotacionDeActivosFijosButton.Size = new Size(300, 25);
            RotacionDeActivosFijosButton.TabIndex = 7;
            RotacionDeActivosFijosButton.Text = "Rotación de activos fijos";
            RotacionDeActivosFijosButton.TextAlign = ContentAlignment.MiddleLeft;
            RotacionDeActivosFijosButton.UseVisualStyleBackColor = false;
            RotacionDeActivosFijosButton.Click += RotacionDeActivosFijosButton_Click;
            // 
            // PeriodoDePagoPromedioButton
            // 
            PeriodoDePagoPromedioButton.BackColor = Color.FromArgb(59, 55, 64);
            PeriodoDePagoPromedioButton.Dock = DockStyle.Top;
            PeriodoDePagoPromedioButton.FlatAppearance.BorderSize = 0;
            PeriodoDePagoPromedioButton.FlatStyle = FlatStyle.Flat;
            PeriodoDePagoPromedioButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            PeriodoDePagoPromedioButton.ForeColor = Color.FromArgb(187, 232, 242);
            PeriodoDePagoPromedioButton.Location = new Point(0, 80);
            PeriodoDePagoPromedioButton.Name = "PeriodoDePagoPromedioButton";
            PeriodoDePagoPromedioButton.Size = new Size(300, 25);
            PeriodoDePagoPromedioButton.TabIndex = 6;
            PeriodoDePagoPromedioButton.Text = "Periodo de cobro promedio";
            PeriodoDePagoPromedioButton.TextAlign = ContentAlignment.MiddleLeft;
            PeriodoDePagoPromedioButton.UseVisualStyleBackColor = false;
            PeriodoDePagoPromedioButton.Click += PeriodoDePagoPromedioButton_Click;
            // 
            // RazonDeCuentasPorCobrarButton
            // 
            RazonDeCuentasPorCobrarButton.BackColor = Color.FromArgb(59, 55, 64);
            RazonDeCuentasPorCobrarButton.Dock = DockStyle.Top;
            RazonDeCuentasPorCobrarButton.FlatAppearance.BorderSize = 0;
            RazonDeCuentasPorCobrarButton.FlatStyle = FlatStyle.Flat;
            RazonDeCuentasPorCobrarButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            RazonDeCuentasPorCobrarButton.ForeColor = Color.FromArgb(187, 232, 242);
            RazonDeCuentasPorCobrarButton.Location = new Point(0, 55);
            RazonDeCuentasPorCobrarButton.Name = "RazonDeCuentasPorCobrarButton";
            RazonDeCuentasPorCobrarButton.Size = new Size(300, 25);
            RazonDeCuentasPorCobrarButton.TabIndex = 5;
            RazonDeCuentasPorCobrarButton.Text = "Razón de cuentas por cobrar";
            RazonDeCuentasPorCobrarButton.TextAlign = ContentAlignment.MiddleLeft;
            RazonDeCuentasPorCobrarButton.UseVisualStyleBackColor = false;
            RazonDeCuentasPorCobrarButton.Click += RazonDeCuentasPorCobrarButton_Click;
            // 
            // RazonDeRotacionDeInventarioButton
            // 
            RazonDeRotacionDeInventarioButton.BackColor = Color.FromArgb(59, 55, 64);
            RazonDeRotacionDeInventarioButton.Dock = DockStyle.Top;
            RazonDeRotacionDeInventarioButton.FlatAppearance.BorderSize = 0;
            RazonDeRotacionDeInventarioButton.FlatStyle = FlatStyle.Flat;
            RazonDeRotacionDeInventarioButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            RazonDeRotacionDeInventarioButton.ForeColor = Color.FromArgb(187, 232, 242);
            RazonDeRotacionDeInventarioButton.Location = new Point(0, 30);
            RazonDeRotacionDeInventarioButton.Name = "RazonDeRotacionDeInventarioButton";
            RazonDeRotacionDeInventarioButton.Size = new Size(300, 25);
            RazonDeRotacionDeInventarioButton.TabIndex = 4;
            RazonDeRotacionDeInventarioButton.Text = "Razón de rotación de inventarios";
            RazonDeRotacionDeInventarioButton.TextAlign = ContentAlignment.MiddleLeft;
            RazonDeRotacionDeInventarioButton.UseVisualStyleBackColor = false;
            RazonDeRotacionDeInventarioButton.Click += RazonDeRotacionDeInventarioButton_Click;
            // 
            // iconButtonRazonActividad
            // 
            iconButtonRazonActividad.BackColor = Color.FromArgb(62, 110, 140);
            iconButtonRazonActividad.Dock = DockStyle.Top;
            iconButtonRazonActividad.FlatAppearance.BorderColor = Color.Black;
            iconButtonRazonActividad.FlatStyle = FlatStyle.Flat;
            iconButtonRazonActividad.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            iconButtonRazonActividad.ForeColor = Color.Black;
            iconButtonRazonActividad.IconChar = FontAwesome.Sharp.IconChar.Cogs;
            iconButtonRazonActividad.IconColor = Color.Black;
            iconButtonRazonActividad.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButtonRazonActividad.IconSize = 30;
            iconButtonRazonActividad.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonRazonActividad.Location = new Point(0, 0);
            iconButtonRazonActividad.Margin = new Padding(0);
            iconButtonRazonActividad.Name = "iconButtonRazonActividad";
            iconButtonRazonActividad.Size = new Size(300, 30);
            iconButtonRazonActividad.TabIndex = 7;
            iconButtonRazonActividad.Text = "      Razones de actividad";
            iconButtonRazonActividad.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonRazonActividad.UseVisualStyleBackColor = false;
            iconButtonRazonActividad.Click += iconButtonRazonActividad_Click;
            // 
            // MenuContainerEndeudamiento
            // 
            MenuContainerEndeudamiento.BackColor = Color.FromArgb(59, 55, 64);
            MenuContainerEndeudamiento.Controls.Add(RazonDeRotacionDeInteresAUtilidadesButton);
            MenuContainerEndeudamiento.Controls.Add(RazonDePasivoACapitalButton);
            MenuContainerEndeudamiento.Controls.Add(RazonDeDeudaTotalButton);
            MenuContainerEndeudamiento.Controls.Add(iconButtonRazonEndeudamiento);
            MenuContainerEndeudamiento.Dock = DockStyle.Top;
            MenuContainerEndeudamiento.Location = new Point(0, 390);
            MenuContainerEndeudamiento.Margin = new Padding(0);
            MenuContainerEndeudamiento.Name = "MenuContainerEndeudamiento";
            MenuContainerEndeudamiento.Size = new Size(300, 137);
            MenuContainerEndeudamiento.TabIndex = 9;
            // 
            // RazonDeRotacionDeInteresAUtilidadesButton
            // 
            RazonDeRotacionDeInteresAUtilidadesButton.BackColor = Color.FromArgb(59, 55, 64);
            RazonDeRotacionDeInteresAUtilidadesButton.Dock = DockStyle.Top;
            RazonDeRotacionDeInteresAUtilidadesButton.FlatAppearance.BorderSize = 0;
            RazonDeRotacionDeInteresAUtilidadesButton.FlatStyle = FlatStyle.Flat;
            RazonDeRotacionDeInteresAUtilidadesButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            RazonDeRotacionDeInteresAUtilidadesButton.ForeColor = Color.FromArgb(187, 232, 242);
            RazonDeRotacionDeInteresAUtilidadesButton.Location = new Point(0, 80);
            RazonDeRotacionDeInteresAUtilidadesButton.Name = "RazonDeRotacionDeInteresAUtilidadesButton";
            RazonDeRotacionDeInteresAUtilidadesButton.Size = new Size(300, 46);
            RazonDeRotacionDeInteresAUtilidadesButton.TabIndex = 6;
            RazonDeRotacionDeInteresAUtilidadesButton.Text = "Razón de rotación de interés a utilidades";
            RazonDeRotacionDeInteresAUtilidadesButton.TextAlign = ContentAlignment.MiddleLeft;
            RazonDeRotacionDeInteresAUtilidadesButton.UseVisualStyleBackColor = false;
            RazonDeRotacionDeInteresAUtilidadesButton.Click += RazonDeRotacionDeInteresAUtilidadesButton_Click;
            // 
            // RazonDePasivoACapitalButton
            // 
            RazonDePasivoACapitalButton.BackColor = Color.FromArgb(59, 55, 64);
            RazonDePasivoACapitalButton.Dock = DockStyle.Top;
            RazonDePasivoACapitalButton.FlatAppearance.BorderSize = 0;
            RazonDePasivoACapitalButton.FlatStyle = FlatStyle.Flat;
            RazonDePasivoACapitalButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            RazonDePasivoACapitalButton.ForeColor = Color.FromArgb(187, 232, 242);
            RazonDePasivoACapitalButton.Location = new Point(0, 55);
            RazonDePasivoACapitalButton.Name = "RazonDePasivoACapitalButton";
            RazonDePasivoACapitalButton.Size = new Size(300, 25);
            RazonDePasivoACapitalButton.TabIndex = 5;
            RazonDePasivoACapitalButton.Text = "Razón de pasivo a capital";
            RazonDePasivoACapitalButton.TextAlign = ContentAlignment.MiddleLeft;
            RazonDePasivoACapitalButton.UseVisualStyleBackColor = false;
            RazonDePasivoACapitalButton.Click += RazonDePasivoACapitalButton_Click;
            // 
            // RazonDeDeudaTotalButton
            // 
            RazonDeDeudaTotalButton.BackColor = Color.FromArgb(59, 55, 64);
            RazonDeDeudaTotalButton.Dock = DockStyle.Top;
            RazonDeDeudaTotalButton.FlatAppearance.BorderSize = 0;
            RazonDeDeudaTotalButton.FlatStyle = FlatStyle.Flat;
            RazonDeDeudaTotalButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            RazonDeDeudaTotalButton.ForeColor = Color.FromArgb(187, 232, 242);
            RazonDeDeudaTotalButton.Location = new Point(0, 30);
            RazonDeDeudaTotalButton.Name = "RazonDeDeudaTotalButton";
            RazonDeDeudaTotalButton.Size = new Size(300, 25);
            RazonDeDeudaTotalButton.TabIndex = 4;
            RazonDeDeudaTotalButton.Text = "Razón de deuda total";
            RazonDeDeudaTotalButton.TextAlign = ContentAlignment.MiddleLeft;
            RazonDeDeudaTotalButton.UseVisualStyleBackColor = false;
            RazonDeDeudaTotalButton.Click += RazonDeDeudaTotalButton_Click;
            // 
            // iconButtonRazonEndeudamiento
            // 
            iconButtonRazonEndeudamiento.BackColor = Color.FromArgb(62, 110, 140);
            iconButtonRazonEndeudamiento.Dock = DockStyle.Top;
            iconButtonRazonEndeudamiento.FlatAppearance.BorderColor = Color.Black;
            iconButtonRazonEndeudamiento.FlatStyle = FlatStyle.Flat;
            iconButtonRazonEndeudamiento.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            iconButtonRazonEndeudamiento.ForeColor = Color.Black;
            iconButtonRazonEndeudamiento.IconChar = FontAwesome.Sharp.IconChar.BalanceScaleRight;
            iconButtonRazonEndeudamiento.IconColor = Color.Black;
            iconButtonRazonEndeudamiento.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButtonRazonEndeudamiento.IconSize = 30;
            iconButtonRazonEndeudamiento.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonRazonEndeudamiento.Location = new Point(0, 0);
            iconButtonRazonEndeudamiento.Margin = new Padding(0);
            iconButtonRazonEndeudamiento.Name = "iconButtonRazonEndeudamiento";
            iconButtonRazonEndeudamiento.Size = new Size(300, 30);
            iconButtonRazonEndeudamiento.TabIndex = 9;
            iconButtonRazonEndeudamiento.Text = "      Razones de endeudamiento";
            iconButtonRazonEndeudamiento.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonRazonEndeudamiento.UseVisualStyleBackColor = false;
            iconButtonRazonEndeudamiento.Click += iconButtonRazonEndeudamiento_Click;
            // 
            // MenuContainerRentabilidad
            // 
            MenuContainerRentabilidad.BackColor = Color.FromArgb(59, 55, 64);
            MenuContainerRentabilidad.Controls.Add(MargenDeUtilidadNetaButton);
            MenuContainerRentabilidad.Controls.Add(MargenDeUtilidadDeOperacionButton);
            MenuContainerRentabilidad.Controls.Add(MargenDeUtilidadBrutaButton);
            MenuContainerRentabilidad.Controls.Add(iconButtonRazonRentabilidad);
            MenuContainerRentabilidad.Dock = DockStyle.Top;
            MenuContainerRentabilidad.Location = new Point(0, 527);
            MenuContainerRentabilidad.Margin = new Padding(0);
            MenuContainerRentabilidad.Name = "MenuContainerRentabilidad";
            MenuContainerRentabilidad.Size = new Size(300, 121);
            MenuContainerRentabilidad.TabIndex = 10;
            // 
            // MargenDeUtilidadNetaButton
            // 
            MargenDeUtilidadNetaButton.BackColor = Color.FromArgb(59, 55, 64);
            MargenDeUtilidadNetaButton.Dock = DockStyle.Top;
            MargenDeUtilidadNetaButton.FlatAppearance.BorderSize = 0;
            MargenDeUtilidadNetaButton.FlatStyle = FlatStyle.Flat;
            MargenDeUtilidadNetaButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            MargenDeUtilidadNetaButton.ForeColor = Color.FromArgb(187, 232, 242);
            MargenDeUtilidadNetaButton.Location = new Point(0, 80);
            MargenDeUtilidadNetaButton.Name = "MargenDeUtilidadNetaButton";
            MargenDeUtilidadNetaButton.Size = new Size(300, 25);
            MargenDeUtilidadNetaButton.TabIndex = 6;
            MargenDeUtilidadNetaButton.Text = "Margen de utilidad neta";
            MargenDeUtilidadNetaButton.TextAlign = ContentAlignment.MiddleLeft;
            MargenDeUtilidadNetaButton.UseVisualStyleBackColor = false;
            MargenDeUtilidadNetaButton.Click += MargenDeUtilidadNetaButton_Click;
            // 
            // MargenDeUtilidadDeOperacionButton
            // 
            MargenDeUtilidadDeOperacionButton.BackColor = Color.FromArgb(59, 55, 64);
            MargenDeUtilidadDeOperacionButton.Dock = DockStyle.Top;
            MargenDeUtilidadDeOperacionButton.FlatAppearance.BorderSize = 0;
            MargenDeUtilidadDeOperacionButton.FlatStyle = FlatStyle.Flat;
            MargenDeUtilidadDeOperacionButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            MargenDeUtilidadDeOperacionButton.ForeColor = Color.FromArgb(187, 232, 242);
            MargenDeUtilidadDeOperacionButton.Location = new Point(0, 55);
            MargenDeUtilidadDeOperacionButton.Name = "MargenDeUtilidadDeOperacionButton";
            MargenDeUtilidadDeOperacionButton.Size = new Size(300, 25);
            MargenDeUtilidadDeOperacionButton.TabIndex = 5;
            MargenDeUtilidadDeOperacionButton.Text = "Margen de utilidad de operación";
            MargenDeUtilidadDeOperacionButton.TextAlign = ContentAlignment.MiddleLeft;
            MargenDeUtilidadDeOperacionButton.UseVisualStyleBackColor = false;
            MargenDeUtilidadDeOperacionButton.Click += MargenDeUtilidadDeOperacionButton_Click;
            // 
            // MargenDeUtilidadBrutaButton
            // 
            MargenDeUtilidadBrutaButton.BackColor = Color.FromArgb(59, 55, 64);
            MargenDeUtilidadBrutaButton.Dock = DockStyle.Top;
            MargenDeUtilidadBrutaButton.FlatAppearance.BorderSize = 0;
            MargenDeUtilidadBrutaButton.FlatStyle = FlatStyle.Flat;
            MargenDeUtilidadBrutaButton.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            MargenDeUtilidadBrutaButton.ForeColor = Color.FromArgb(187, 232, 242);
            MargenDeUtilidadBrutaButton.Location = new Point(0, 30);
            MargenDeUtilidadBrutaButton.Name = "MargenDeUtilidadBrutaButton";
            MargenDeUtilidadBrutaButton.Size = new Size(300, 25);
            MargenDeUtilidadBrutaButton.TabIndex = 4;
            MargenDeUtilidadBrutaButton.Text = "Margen de utilidad bruta";
            MargenDeUtilidadBrutaButton.TextAlign = ContentAlignment.MiddleLeft;
            MargenDeUtilidadBrutaButton.UseVisualStyleBackColor = false;
            MargenDeUtilidadBrutaButton.Click += MargenDeUtilidadBrutaButton_Click;
            // 
            // iconButtonRazonRentabilidad
            // 
            iconButtonRazonRentabilidad.BackColor = Color.FromArgb(62, 110, 140);
            iconButtonRazonRentabilidad.Dock = DockStyle.Top;
            iconButtonRazonRentabilidad.FlatAppearance.BorderColor = Color.Black;
            iconButtonRazonRentabilidad.FlatStyle = FlatStyle.Flat;
            iconButtonRazonRentabilidad.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            iconButtonRazonRentabilidad.ForeColor = Color.Black;
            iconButtonRazonRentabilidad.IconChar = FontAwesome.Sharp.IconChar.Donate;
            iconButtonRazonRentabilidad.IconColor = Color.Black;
            iconButtonRazonRentabilidad.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButtonRazonRentabilidad.IconSize = 30;
            iconButtonRazonRentabilidad.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonRazonRentabilidad.Location = new Point(0, 0);
            iconButtonRazonRentabilidad.Margin = new Padding(0);
            iconButtonRazonRentabilidad.Name = "iconButtonRazonRentabilidad";
            iconButtonRazonRentabilidad.Size = new Size(300, 30);
            iconButtonRazonRentabilidad.TabIndex = 10;
            iconButtonRazonRentabilidad.Text = "      Razones de rentabilidad";
            iconButtonRazonRentabilidad.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonRazonRentabilidad.UseVisualStyleBackColor = false;
            iconButtonRazonRentabilidad.Click += iconButtonRazonRentabilidad_Click;
            // 
            // MenuActividadesLiquidez
            // 
            MenuActividadesLiquidez.Interval = 10;
            MenuActividadesLiquidez.Tick += menuExpandLiquidez_Tick;
            // 
            // MenuRazonActividad
            // 
            MenuRazonActividad.Interval = 10;
            MenuRazonActividad.Tick += MenuRazonActividad_Tick;
            // 
            // MenuRazonRentabilidad
            // 
            MenuRazonRentabilidad.Interval = 10;
            MenuRazonRentabilidad.Tick += MenurazonRentabilidad_Tick;
            // 
            // MenuRazonEndeudamiento
            // 
            MenuRazonEndeudamiento.Interval = 10;
            MenuRazonEndeudamiento.Tick += MenuRazonEndeudamiento_Tick;
            // 
            // MenuEstadosFinancieros
            // 
            MenuEstadosFinancieros.Interval = 10;
            MenuEstadosFinancieros.Tick += MenuEstadosFinancieros_Tick;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Black", 10F, FontStyle.Bold);
            button1.ForeColor = Color.FromArgb(187, 232, 242);
            button1.Location = new Point(3, 651);
            button1.Name = "button1";
            button1.Size = new Size(300, 25);
            button1.TabIndex = 11;
            button1.Text = "Generar reporte";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 750);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(187, 232, 242);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            Name = "Home";
            Text = "Home";
            TransparencyKey = Color.Fuchsia;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            MenuContainerEstadosFinancieros.ResumeLayout(false);
            MenuContainerLiquidez.ResumeLayout(false);
            MenuContainerActividad.ResumeLayout(false);
            MenuContainerEndeudamiento.ResumeLayout(false);
            MenuContainerRentabilidad.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel MenuContainerLiquidez;
        private Button IndiceDeSolvenciaButton;
        private Button CapitalDeTrabajoNetoButton;
        private System.Windows.Forms.Timer MenuActividadesLiquidez;
        private Button PruebaRapidaButton;
        private Panel MenuContainerActividad;
        private Button RotacionDeActivosTotalesButton;
        private Button RotacionDeActivosFijosButton;
        private Button PeriodoDePagoPromedioButton;
        private Button RazonDeCuentasPorCobrarButton;
        private Button RazonDeRotacionDeInventarioButton;
        private Panel MenuContainerEndeudamiento;
        private Button RazonDeRotacionDeInteresAUtilidadesButton;
        private Button RazonDePasivoACapitalButton;
        private Button RazonDeDeudaTotalButton;
        private Panel MenuContainerRentabilidad;
        private Button MargenDeUtilidadNetaButton;
        private Button MargenDeUtilidadDeOperacionButton;
        private Button MargenDeUtilidadBrutaButton;
        private System.Windows.Forms.Timer MenuRazonActividad;
        private System.Windows.Forms.Timer MenuRazonRentabilidad;
        private System.Windows.Forms.Timer MenuRazonEndeudamiento;
        private FontAwesome.Sharp.IconButton iconButtonRazonLiquidez;
        private FontAwesome.Sharp.IconButton iconButtonRazonActividad;
        private FontAwesome.Sharp.IconButton iconButtonRazonEndeudamiento;
        private FontAwesome.Sharp.IconButton iconButtonRazonRentabilidad;
        private Panel MenuContainerEstadosFinancieros;
        private Button EstadoDeResultadosButton;
        private FontAwesome.Sharp.IconButton iconButtonEstadosFinancieros;
        private System.Windows.Forms.Timer MenuEstadosFinancieros;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Button button1;
    }
}
