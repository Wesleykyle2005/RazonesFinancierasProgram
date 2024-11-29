using RazonesFinancieras.Estados_financieros;
using RazonesFinancieras.Razones_de_actividad;
using RazonesFinancieras.Razones_de_endeudamiento;
using RazonesFinancieras.Razones_de_liquidez;
using RazonesFinancieras.Razones_de_rentabilidad;

namespace RazonesFinancieras
{
    public partial class Home : Form
    {

        Estado_de_resultados EstadoDeResultados;
        CapitalDeTrabajoNetoForm CapitalDeTrabajoNeto;
        IndiceDeSolvenciaForm IndiceDeSolvencia;
        PruebaRapidaForm PruebaRapida;
        RazonDeRotacionDeInventarioForm RazonDeRotacion;
        RazonDeCuentasPorCobrarForm RazonDeCuentasPorCobrar;
        PeriodoDeCobroPromedioForm PeriodoDePagoPromedio;
        RotacionDeActivosFijosForm RotacionDeActivosFijos;
        RotacionDeActivosTotalesForm RotacionDeActivosTotales;
        RazonDeDeudaTotalForm RazonDeDeudaTotal;
        RazonDePasivoACapitalForm RazonDePasivoACapital;
        RazonDeRotaciónDeInteresAUtilidadesForm RazonDeRotaciónDeInteresAUtilidades;
        MargenDeUtilidadBrutaForm MargenDeUtilidadBruta;
        MargenDeUtilidadDeOperacionForm MargenDeUtilidadDeOperacion;
        MargenDeUtilidadNetaForm MargenDeUtilidadNeta;
        public Home()
        {
            InitializeComponent();
            InitializeMenuStates();
            mdiProp();
            this.WindowState = FormWindowState.Maximized;
            nightControlBox1.EnableMaximizeButton = false;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(255, 242, 193, 133);

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
            AbrirFormulario(PeriodoDePagoPromedio, new PeriodoDeCobroPromedioForm());

        }

        private void RotacionDeActivosFijosButton_Click(object sender, EventArgs e)
        {

            AbrirFormulario(RotacionDeActivosFijos, new RotacionDeActivosFijosForm());
        }

        private void RotacionDeActivosTotalesButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(RotacionDeActivosTotales, new RotacionDeActivosTotalesForm());
        }

        private void RazonDeDeudaTotalButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(RazonDeDeudaTotal, new RazonDeDeudaTotalForm());
        }

        private void RazonDePasivoACapitalButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(RazonDePasivoACapital, new RazonDePasivoACapitalForm());
        }

        private void RazonDeRotacionDeInteresAUtilidadesButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(RazonDeRotaciónDeInteresAUtilidades, new RazonDeRotaciónDeInteresAUtilidadesForm());
        }

        private void MargenDeUtilidadBrutaButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MargenDeUtilidadBruta, new MargenDeUtilidadBrutaForm());

        }

        private void MargenDeUtilidadDeOperacionButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MargenDeUtilidadDeOperacion, new MargenDeUtilidadDeOperacionForm());

        }

        private void MargenDeUtilidadNetaButton_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MargenDeUtilidadNeta, new MargenDeUtilidadNetaForm());
        }







        // Método genérico para abrir formularios MDI
        private void AbrirFormulario<T>(T formulario, T nuevoFormulario) where T : Form
        {
            if (formulario == null)
            {
                formulario = nuevoFormulario;
                formulario.FormClosed += (s, args) => formulario = null; // Liberar referencia al cerrar
                formulario.MdiParent = this;

                formulario.StartPosition = FormStartPosition.Manual; // Evitar que el sistema sobreescriba la posición
                formulario.Location = new Point(0, 0);

                formulario.Shown += (s, args) =>
                {
                    // Desplazar los controles después de que el formulario se muestre
                    DesplazarControles(formulario, (this.Height - formulario.Height) / 2);
                    formulario.Dock = DockStyle.Fill;

                };

                formulario.Show();
            }
            else
            {
                formulario.Activate();
            }
        }






        private void DesplazarControles(Control parent, int desplazamientoHorizontal)
        {
            foreach (Control control in parent.Controls)
            {
                // Ajustar la posición horizontal del control
                control.Location = new Point(control.Location.X + desplazamientoHorizontal, control.Location.Y);

                // Si el control contiene otros controles, desplazar recursivamente
                if (control.HasChildren)
                {
                    DesplazarControles(control, desplazamientoHorizontal);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia del SaveFileDialog
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // Establecer las propiedades del dialogo
                    saveFileDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*"; // Filtro para archivos CSV y Excel
                    saveFileDialog.DefaultExt = "xlsx"; // Extensión por defecto
                    saveFileDialog.FileName = "conclusiones"; // Nombre por defecto del archivo

                    // Mostrar el dialogo para que el usuario seleccione la ruta y el archivo
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Obtener la ruta seleccionada por el usuario
                        string rutaArchivo = saveFileDialog.FileName;

                        // Verificar la extensión del archivo elegido
                        if (rutaArchivo.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                        {
                            // Guardar todas las conclusiones en el archivo Excel
                            ConclusionesFinancieras.GuardarConclusionesEnExcel(rutaArchivo);
                           
                        }
                        else
                        {
                            MessageBox.Show("El formato de archivo seleccionado no es compatible.", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar las conclusiones: {ex.Message}", "Error");
            }
        }
    }
}
