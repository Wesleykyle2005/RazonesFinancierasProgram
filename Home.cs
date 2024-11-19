using RazonesFinancieras.Estados_financieros;
using RazonesFinancieras.Razones_de_actividad;
using RazonesFinancieras.Razones_de_liquidez;

namespace RazonesFinancieras
{
    public partial class Home : Form
    {

        BalanceGeneral BalanceGeneral;
        Estado_de_resultados EstadoDeResultados;
        CapitalDeTrabajoNetoForm CapitalDeTrabajoNeto;
        IndiceDeSolvenciaForm IndiceDeSolvencia;
        PruebaRapidaForm PruebaRapida;
        RazonDeRotacionDeInventarioForm RazonDeRotacion;
        RazonDeCuentasPorCobrarForm RazonDeCuentasPorCobrar;
        PeriodoDePagoPromedioForm PeriodoDePagoPromedio;
        RotacionDeActivosFijosForm RotacionDeActivosFijos;
        RotacionDeActivosTotalesForm RotacionDeActivosTotales;
        public Home()
        {
            InitializeComponent();
            InitializeMenuStates();
            mdiProp();
            this.WindowState = FormWindowState.Maximized;
        }
        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(59, 55, 64);

        }

        private void InitializeMenuStates()
        {
            MenuContainerLiquidez.Height = MaxHeightLiquidez;
            MenuContainerActividad.Height = MaxHeightActividad;
            MenuContainerRentabilidad.Height = MaxHeightRentabilidad;
            MenuContainerEndeudamiento.Height = MaxHeightEndeudamiento;
            MenuContainerEstadosFinancieros.Height = MaxHeightEstadosFinancieros;
        }

        // Variables para la altura mínima y máxima de cada menú
        private const int MinHeightLiquidez = 34, MaxHeightLiquidez = 120 + 5;
        private const int MinHeightActividad = 34, MaxHeightActividad = 170 + 5;
        private const int MinHeightRentabilidad = 34, MaxHeightRentabilidad = 118 + 5;
        private const int MinHeightEndeudamiento = 34, MaxHeightEndeudamiento = 141 + 5;
        private const int MinHeightEstadosFinancieros = 34, MaxHeightEstadosFinancieros = 90;

        // Variables para controlar si el menú está expandido o no
        private bool menuExpandLiquidez = false;
        private bool menuExpandActividad = false;
        private bool menuExpandRentabilidad = false;
        private bool menuExpandEndeudamiento = false;
        private bool menuExpandEstadosFinancieros = false;

        // Método genérico para manejar la expansión/contracción de menús
        private void ToggleMenu(ref bool isExpanded, Panel menuContainer, System.Windows.Forms.Timer menuTimer, int maxHeight, int minHeight)
        {
            if (menuContainer.Height == maxHeight) // Menú ya expandido
            {
                isExpanded = true;
            }
            else if (menuContainer.Height == minHeight) // Menú ya contraído
            {
                isExpanded = false;
            }

            if (isExpanded)
            {
                menuContainer.Height -= 10;
                if (menuContainer.Height <= minHeight)
                {
                    menuTimer.Stop();
                    isExpanded = false; // Ahora está contraído
                }
            }
            else
            {
                menuContainer.Height += 10;
                if (menuContainer.Height >= maxHeight)
                {
                    menuTimer.Stop();
                    isExpanded = true; // Ahora está expandido
                }
            }
        }

        // Controladores para los temporizadores
        private void menuExpandLiquidez_Tick(object sender, EventArgs e)
        {
            ToggleMenu(ref menuExpandLiquidez, MenuContainerLiquidez, MenuActividadesLiquidez, MaxHeightLiquidez, MinHeightLiquidez);
        }

        private void MenuRazonActividad_Tick(object sender, EventArgs e)
        {
            ToggleMenu(ref menuExpandActividad, MenuContainerActividad, MenuRazonActividad, MaxHeightActividad, MinHeightActividad);
        }

        private void MenurazonRentabilidad_Tick(object sender, EventArgs e)
        {
            ToggleMenu(ref menuExpandRentabilidad, MenuContainerRentabilidad, MenuRazonRentabilidad, MaxHeightRentabilidad, MinHeightRentabilidad);
        }

        private void MenuRazonEndeudamiento_Tick(object sender, EventArgs e)
        {
            ToggleMenu(ref menuExpandEndeudamiento, MenuContainerEndeudamiento, MenuRazonEndeudamiento, MaxHeightEndeudamiento, MinHeightEndeudamiento);
        }

        private void MenuEstadosFinancieros_Tick(object sender, EventArgs e)
        {
            ToggleMenu(ref menuExpandEstadosFinancieros, MenuContainerEstadosFinancieros, MenuEstadosFinancieros, MaxHeightEstadosFinancieros, MinHeightEstadosFinancieros);
        }

        // Eventos de clic para iniciar el temporizador
        private void iconButtonRazonLiquidez_Click_1(object sender, EventArgs e)
        {
            MenuActividadesLiquidez.Start();
        }

        private void iconButtonRazonActividad_Click(object sender, EventArgs e)
        {
            MenuRazonActividad.Start();
        }

        private void iconButtonRazonRentabilidad_Click(object sender, EventArgs e)
        {
            MenuRazonRentabilidad.Start();
        }

        private void iconButtonRazonEndeudamiento_Click(object sender, EventArgs e)
        {
            MenuRazonEndeudamiento.Start();
        }

        private void iconButtonEstadosFinancieros_Click(object sender, EventArgs e)
        {
            MenuEstadosFinancieros.Start();
        }

        // Botón para abrir Balance General
        private void BalanceGeneralButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(BalanceGeneral, new BalanceGeneral());
        }

        // Botón para abrir Estado de Resultados
        private void EstadoDeResultadosButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(EstadoDeResultados, new Estado_de_resultados());
        }


        #region RazonesLiquidezForm
        private void CapitalDeTrabajoNetoButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(CapitalDeTrabajoNeto, new CapitalDeTrabajoNetoForm());
        }

        private void IndiceDeSolvenciaButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(IndiceDeSolvencia, new IndiceDeSolvenciaForm());
        }

        private void PruebaRapidaButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(PruebaRapida, new PruebaRapidaForm());
        }
        #endregion

        private void RazonDeRotacionDeInventarioButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(RazonDeRotacion, new RazonDeRotacionDeInventarioForm());
        }

        private void RazonDeCuentasPorCobrarButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(RazonDeCuentasPorCobrar, new RazonDeCuentasPorCobrarForm());
        }

        private void PeriodoDePagoPromedioButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(PeriodoDePagoPromedio, new PeriodoDePagoPromedioForm());
           
        }

        private void RotacionDeActivosFijosButton_Click(object sender, EventArgs e)
        {
            
            AbrirFormulario(RotacionDeActivosFijos, new RotacionDeActivosFijosForm());
        }

        private void RotacionDeActivosTotalesButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(RotacionDeActivosTotales, new RotacionDeActivosTotalesForm());
        }
        




        // Método genérico para abrir formularios MDI
        private void AbrirFormulario<T>(T formulario, T nuevoFormulario) where T : Form
        {
            if (formulario == null)
            {
                formulario = nuevoFormulario;
                formulario.FormClosed += (s, args) => formulario = null; // Liberar referencia al cerrar
                formulario.MdiParent = this;
                formulario.Dock = DockStyle.Fill;
                formulario.Show();
            }
            else
            {
                formulario.Activate();
            }
        }

    }
}
