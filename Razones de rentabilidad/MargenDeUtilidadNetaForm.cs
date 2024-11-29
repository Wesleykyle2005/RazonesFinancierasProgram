using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RazonesFinancieras.Razones_de_rentabilidad
{
    public partial class MargenDeUtilidadNetaForm : Form
    {
        public MargenDeUtilidadNetaForm()
        {
            InitializeComponent();
        }

        private void MargenDeUtilidadNetaForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Inicializar las variables
            Double ventasTotales = 0;
            Double utilidadNetaDespuesDeImpuestos = 0;

            // Asignar valores iniciales a los TextBox
            VentasTextBox.Text = ventasTotales.ToString();
            UtilidadNetaDespuesDeImpuestosTextBox.Text = utilidadNetaDespuesDeImpuestos.ToString();

            try
            {
                // Establecer la cadena de conexión
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;

                // Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener los valores necesarios
                    string query = @"
                                    SELECT 
                    SUM(CASE WHEN CE.TipoCuenta = 'Ventas' THEN V.Valor ELSE 0 END) AS TotalVentas,
                    SUM(CASE WHEN CE.TipoCuenta = 'Costos' THEN C.Valor ELSE 0 END) AS TotalCostos,
                    SUM(CASE WHEN CE.TipoCuenta = 'Gastos' THEN G.Valor ELSE 0 END) AS TotalGastos,
                    SUM(CASE WHEN CE.TipoCuenta = 'OtrosIngresos' THEN OI.Valor ELSE 0 END) AS OtrosIng,
	                SUM(CASE WHEN CE.TipoCuenta = 'Pasivos' THEN P.Valor ELSE 0 END) AS Imp
                    FROM CuentaEmpresa CE
                    JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
                    LEFT JOIN Ventas V ON CE.IdCuenta = V.IdVenta
                    LEFT JOIN Costos C ON CE.TipoCuenta = 'Costos' AND CE.IdCuenta = C.IdCosto
                    LEFT JOIN Gastos G ON CE.TipoCuenta = 'Gastos' AND CE.IdCuenta = G.IdGasto
                    LEFT JOIN OtrosIngresos OI ON CE.TipoCuenta = 'OtrosIngresos' AND CE.IdCuenta = OI.Id
                    LEFT JOIN Pasivos P ON CE.TipoCuenta = 'Pasivos' AND P.NombreCuenta='Impuestos por pagar' AND CE.IdCuenta=P.IdPasivo
                    WHERE E.IdEmpresa = 1
                    GROUP BY E.IdEmpresa;";

                    // Ejecutar la consulta
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Parámetro de la consulta
                        cmd.Parameters.AddWithValue("@IdEmpresa", 1); // Reemplazar con el Id de la empresa deseada

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtener los valores desde la base de datos
                                ventasTotales = reader["TotalVentas"] != DBNull.Value ? Convert.ToDouble(reader["TotalVentas"]) : 0;
                                Double costosTotales = reader["TotalCostos"] != DBNull.Value ? Convert.ToDouble(reader["TotalCostos"]) : 0;
                                Double gastosTotales = reader["TotalGastos"] != DBNull.Value ? Convert.ToDouble(reader["TotalGastos"]) : 0;
                                Double OtrosIng = reader["OtrosIng"] != DBNull.Value ? Convert.ToDouble(reader["OtrosIng"]) : 0;
                                Double Impuestos = reader["Imp"] != DBNull.Value ? Convert.ToDouble(reader["Imp"]) : 0;

                                // Calcular la utilidad neta después de impuestos
                                utilidadNetaDespuesDeImpuestos = ventasTotales - costosTotales - gastosTotales + OtrosIng-Impuestos;

                                // Mostrar los valores en los TextBox
                                VentasTextBox.Text = ventasTotales.ToString("N2");
                                UtilidadNetaDespuesDeImpuestosTextBox.Text = utilidadNetaDespuesDeImpuestos.ToString("N2");

                                // Calcular y mostrar el margen de utilidad neta
                                if (ventasTotales != 0)
                                {
                                    Double margendeUtilidadNeta = utilidadNetaDespuesDeImpuestos / ventasTotales;
                                    MargenDeUtilidadNetaTextBox.Text = margendeUtilidadNeta.ToString("P2");
                                }
                                else
                                {
                                    MargenDeUtilidadNetaTextBox.Text = "N/A";
                                    MessageBox.Show("Las ventas no pueden ser cero para este cálculo.", "Advertencia");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos para la empresa especificada.", "Sin datos");
                            }
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos.", "Error de Formato");
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error al acceder a la base de datos: {sqlEx.Message}", "Error SQL");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error");
            }
        }


        private void copyButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ConclusionTextBox.Text))
            {
                Clipboard.SetText(ConclusionTextBox.Text);
                MessageBox.Show("Contenido copiado al portapapeles.", "Copiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay contenido para copiar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
