using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace RazonesFinancieras.Estados_financieros
{
    public partial class Estado_de_resultados : Form
    {
        public Estado_de_resultados()
        {
            InitializeComponent();
            EnableDoubleBuffering(tlpER);

            // Ajustar el tamaño de panel1 cuando el formulario cambie de tamaño
            this.Resize += (s, e) => AdjustPanelHeight();
            AdjustPanelHeight();
        }

        private void Estado_de_resultados_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            LoadCuentasToTextBox("Ventas");
            LoadCuentasToTextBox("Costos");
            LoadCuentasToTextBox("Gastos");

        }

        private void EnableDoubleBuffering(TableLayoutPanel tableLayoutPanel)
        {
            typeof(TableLayoutPanel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, tableLayoutPanel, new object[] { true });
        }

        string sqlServerConnectionString = ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;

        // Método general para obtener cuentas desde cualquier tabla
        public IEnumerable<(string NombreCuenta, decimal Valor)> GetCuentas(string tableName)
        {
            var cuentas = new List<(string NombreCuenta, decimal Valor)>();

            try
            {
                using (var connection = new SqlConnection(sqlServerConnectionString))
                {
                    connection.Open();
                    string query = $"SELECT NombreCuenta, Valor FROM {tableName}";
                    using (var command = new SqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var nombreCuenta = reader["NombreCuenta"]?.ToString() ?? "Sin nombre";
                            var valor = reader["Valor"] != DBNull.Value
                                ? Convert.ToDecimal(reader["Valor"])
                                : 0m;
                            cuentas.Add((nombreCuenta, valor));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las cuentas de la tabla {tableName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return cuentas;
        }

        private void LoadCuentasToTextBox(string tableName)
        {
            try
            {
                ClearTextBoxes(); // Limpiar todos los TextBox antes de cargar datos
                var cuentas = GetCuentas(tableName);

                foreach (var cuenta in cuentas)
                {
                    if (cuenta.NombreCuenta == "Ventas")
                        VentasTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Descuentos sobre ventas")
                        DescuentosSobreVentasTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Devoluciones sobre ventas")
                        DevolucionesSobreVentasTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Inventario Inicial")
                        InventarioInicialTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Compras")
                        ComprasTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Mas Gastos de compras")
                        GastosDeComprasTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Menos descuentos sobre Compra")
                        DescuentosSobreCompraTextBox.Text = cuenta.Valor.ToString("N2");
                    /*else if (cuenta.NombreCuenta == "Inventario Final")
                        InventarioFinalTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Sueldos y comisiones a vendedores")
                        SueldosComisionesVendedoresTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Sueldos de la oficina de ventas")
                        SueldosOficinaVentasTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Viáticos")
                        ViaticosTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Fletes de mercancía remitidas")
                        FletesMercanciaRemitidaTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Depreciación del equipo de transporte")
                        DepreciacionEquipoTransporteTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Teléfono")
                        TelefonoTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Sueldos de oficina")
                        SueldosOficinaTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Servicios públicos")
                        ServiciosPublicosTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Depreciación del edificio")
                        DepreciacionEdificioTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Depreciación del equipo de oficina")
                        DepreciacionEquipoOficinaTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Dividendos cobrados")
                        DividendosCobradosTextBox.Text = cuenta.Valor.ToString("N2");
                    else if (cuenta.NombreCuenta == "Impuestos a la utilidad")
                        ImpuestosUtilidadTextBox.Text = cuenta.Valor.ToString("N2");*/
                }

                // Validar y convertir los valores antes de realizar operaciones
                double descuentosSobreVentas = 0;
                double devolucionesSobreVentas = 0;
                double ventasNetas = 0;
                double ventas = 0;

                // Verificar si el valor de cada TextBox es numérico y convertirlo
                if (!string.IsNullOrEmpty(DescuentosSobreVentasTextBox.Text) &&
                    double.TryParse(DescuentosSobreVentasTextBox.Text, out double tempDescuentos))
                {
                    descuentosSobreVentas = tempDescuentos;
                }

                if (!string.IsNullOrEmpty(DevolucionesSobreVentasTextBox.Text) &&
                    double.TryParse(DevolucionesSobreVentasTextBox.Text, out double tempDevoluciones))
                {
                    devolucionesSobreVentas = tempDevoluciones;
                }
                if (!string.IsNullOrEmpty(VentasTextBox.Text) &&
                    double.TryParse(VentasTextBox.Text, out double tempVentas))
                {
                    ventas = tempVentas;
                }

                // Calcular la sumatoria
                double sumatoriaDevolucionesDescuentos = descuentosSobreVentas + devolucionesSobreVentas;
                SumatoriaDevolucionesDescuentosTextBox.Text = sumatoriaDevolucionesDescuentos.ToString("N2");

                ventasNetas=ventas- sumatoriaDevolucionesDescuentos;
                VentasNetasTextBox.Text = ventasNetas.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos en los TextBox: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ClearTextBoxes()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
            }
        }

        private void ActualizarButton_Click(object sender, EventArgs e)
        {
            LoadCuentasToTextBox("Ventas"); // Cambiar el nombre de la tabla según corresponda
        }

        private void AdjustPanelHeight()
        {
            if (panel1 != null && this.MdiParent != null)
            {
                int newHeight = (int)(this.MdiParent.Height / 1.5);
                panel1.Height = newHeight;
            }
        }
    }
}
