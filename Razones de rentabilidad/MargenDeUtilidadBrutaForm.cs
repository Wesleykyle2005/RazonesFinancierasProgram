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
    public partial class MargenDeUtilidadBrutaForm : Form
    {
        public MargenDeUtilidadBrutaForm()
        {
            InitializeComponent();
        }

        private void MargenDeUtilidadBrutaForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Inicializar las variables
            Double ventas = 0;
            Double costoDeVentas = 0;

            // Asignar valores iniciales a los TextBox
            VentasTextBox.Text = ventas.ToString();
            CostoDeVentasTextBox.Text = costoDeVentas.ToString();

            try
            {
                // Establecer la cadena de conexión
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;

                // Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener las Ventas y Costo de Ventas
                    string query = @"
            SELECT 
    SUM(CASE WHEN CE.TipoCuenta = 'Ventas' THEN V.Valor ELSE 0 END) AS TotalVentas,
    SUM(CASE WHEN CE.TipoCuenta = 'Costos' THEN CV.Valor ELSE 0 END) AS TotalCostoDeVentas
FROM CuentaEmpresa CE
JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
LEFT JOIN Ventas V ON CE.TipoCuenta = 'Ventas' AND CE.IdCuenta = V.IdVenta
LEFT JOIN Costos CV ON  CE.IdCuenta = CV.IdCosto
WHERE E.IdEmpresa = 1
GROUP BY E.IdEmpresa;";

                    // Ejecutar la consulta
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Definir el parámetro de la consulta
                        cmd.Parameters.AddWithValue("@IdEmpresa", 1); // Reemplazar por el Id de la empresa que deseas consultar

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Asignar los valores obtenidos desde la base de datos
                                ventas = reader["TotalVentas"] != DBNull.Value ? Convert.ToDouble(reader["TotalVentas"]) : 0;
                                costoDeVentas = reader["TotalCostoDeVentas"] != DBNull.Value ? Convert.ToDouble(reader["TotalCostoDeVentas"]) : 0;

                                // Mostrar los valores en los TextBox
                                VentasTextBox.Text = ventas.ToString("N2");
                                CostoDeVentasTextBox.Text = costoDeVentas.ToString("N2");

                                // Calcular y mostrar el resultado del Margen de Utilidad Bruta
                                if (ventas != 0)
                                {
                                    double margenDeUtilidadBruta = (ventas - costoDeVentas) / ventas;
                                    MargenDeUtilidadBrutaTextBox.Text = margenDeUtilidadBruta.ToString("N2");
                                    // Comparar con el promedio de la industria si está disponible
                                    string promedioIndustriaText = txtPromedioDeLaIndustria.Text; // Obtener el valor del promedio de la industria
                                    double promedioIndustria;

                                    string conclusion = $"El margen de utilidad bruta es de {margenDeUtilidadBruta:P2}.\n";

                                    // Evaluar la eficiencia
                                    if (margenDeUtilidadBruta < 0.1)
                                    {
                                        conclusion += "Este valor es inferior al promedio esperado, lo que indica un bajo margen de utilidad bruta.";
                                    }
                                    else if (margenDeUtilidadBruta > 0.5)
                                    {
                                        conclusion += "Este valor es superior al promedio esperado, lo que indica un buen margen de utilidad bruta.";
                                    }
                                    else
                                    {
                                        conclusion += "Este valor está dentro del promedio esperado, lo que indica un margen de utilidad bruta equilibrado.";
                                    }

                                    // Comparar con el promedio de la industria si está disponible
                                    if (double.TryParse(promedioIndustriaText, out promedioIndustria))
                                    {
                                        if (margenDeUtilidadBruta < promedioIndustria)
                                        {
                                            conclusion += $"\nEste valor es inferior al promedio de la industria ({promedioIndustria:P2}), lo que sugiere una menor eficiencia en la gestión de costos.";
                                        }
                                        else if (margenDeUtilidadBruta > promedioIndustria)
                                        {
                                            conclusion += $"\nEste valor es superior al promedio de la industria ({promedioIndustria:P2}), lo que indica una mayor eficiencia en la gestión de costos.";
                                        }
                                        else
                                        {
                                            conclusion += $"\nEste valor es similar al promedio de la industria ({promedioIndustria:P2}), lo que sugiere una eficiencia comparable en la gestión de costos.";
                                        }
                                    }
                                    else
                                    {
                                        conclusion += "\nNo se pudo comparar con el promedio de la industria.";
                                    }

                                    // Mostrar la conclusión en el TextBox de conclusiones
                                    ConclusionTextBox.Text = conclusion;
                                }
                                else
                                {
                                    MargenDeUtilidadBrutaTextBox.Text = "N/A";
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
