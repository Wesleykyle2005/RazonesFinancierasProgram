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

namespace RazonesFinancieras.Razones_de_liquidez
{
    public partial class IndiceDeSolvenciaForm : Form
    {
        public IndiceDeSolvenciaForm()
        {
            InitializeComponent();
        }

        private void IndiceDeSolvenciaForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Inicializar las variables
            double activoCirculante = 0;
            double pasivoCirculante = 0;

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;
                // Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener el Activo Circulante y Pasivo Circulante
                    string query = @"
            SELECT 
    SUM(CASE WHEN CE.TipoCuenta = 'Activos' AND A.Clasificacion = 'Activo circulante' THEN A.Valor ELSE 0 END) AS TotalActivoCirculante,
    SUM(CASE WHEN CE.TipoCuenta = 'Pasivos' AND P.Clasificacion = 'Pasivo corto plazo' THEN P.Valor ELSE 0 END) AS TotalPasivoCirculante
FROM CuentaEmpresa CE
JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
LEFT JOIN Activos A ON CE.TipoCuenta = 'Activos' AND CE.IdCuenta = A.IdActivo
LEFT JOIN Pasivos P ON CE.TipoCuenta = 'Pasivos' AND CE.IdCuenta = P.IdPasivo
WHERE E.IdEmpresa = 1
GROUP BY E.IdEmpresa;
";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Ejecutar la consulta
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Asignar los valores obtenidos desde la base de datos
                                activoCirculante = reader["TotalActivoCirculante"] != DBNull.Value ? Convert.ToDouble(reader["TotalActivoCirculante"]) : 0;
                                pasivoCirculante = reader["TotalPasivoCirculante"] != DBNull.Value ? Convert.ToDouble(reader["TotalPasivoCirculante"]) : 0;

                                // Mostrar los valores en los TextBox
                                ActivocirculanteTextbox.Text = activoCirculante.ToString("N2");
                                PasivoCirculantetextBox.Text = pasivoCirculante.ToString("N2");

                                // Calcular y mostrar el resultado del Índice de Solvencia
                                if (pasivoCirculante != 0)
                                {
                                    double indiceDeSolvencia = activoCirculante / pasivoCirculante;
                                    IndiceSolvenciatxtBox.Text = indiceDeSolvencia.ToString("N2");
                                    // Generar conclusión
                                    string conclusion = $"El índice de solvencia calculado es: {indiceDeSolvencia:N2}. ";

                                    // Interpretar el índice de solvencia
                                    if (indiceDeSolvencia > 1)
                                    {
                                        conclusion += "Esto significa que los activos circulantes de la empresa son suficientes para cubrir sus pasivos circulantes, lo cual es una señal positiva de liquidez. ";
                                    }
                                    else if (indiceDeSolvencia == 1)
                                    {
                                        conclusion += "Esto significa que los activos circulantes de la empresa son exactamente iguales a sus pasivos circulantes, lo cual es una situación de equilibrio. ";
                                    }
                                    else
                                    {
                                        conclusion += "Esto indica que los activos circulantes de la empresa no son suficientes para cubrir sus pasivos circulantes, lo que representa un riesgo de liquidez. ";
                                    }

                                    // Evaluar porcentaje de reducción posible
                                    double porcentajeReduccion = (1.0 - (1.0 / indiceDeSolvencia)) * 100;
                                    conclusion += $"La empresa puede reducir sus activos circulantes hasta en un {porcentajeReduccion:N2}% sin perder la capacidad de cubrir sus pasivos a corto plazo. ";

                                    // Comparar con el promedio de la industria (si está disponible)
                                    if (double.TryParse(txtPromedioDeLaIndustria.Text, out double promedioIndustria))
                                    {
                                        if (indiceDeSolvencia > promedioIndustria)
                                        {
                                            conclusion += $"Además, el índice de solvencia de la empresa es mayor que el promedio de la industria ({promedioIndustria:N2}), lo cual es favorable.";
                                        }
                                        else if (indiceDeSolvencia < promedioIndustria)
                                        {
                                            conclusion += $"Además, el índice de solvencia de la empresa es menor que el promedio de la industria ({promedioIndustria:N2}), lo que podría ser una debilidad comparativa.";
                                        }
                                        else
                                        {
                                            conclusion += "El índice de solvencia de la empresa es igual al promedio de la industria.";
                                        }
                                    }

                                    // Mostrar la conclusión en el TextBox
                                    ConclusionTextBox.Text = conclusion;
                                }
                                else
                                {
                                    IndiceSolvenciatxtBox.Text = "N/A";
                                    ConclusionTextBox.Text = "El pasivo circulante no puede ser cero para calcular el índice de solvencia.";
                                    MessageBox.Show("El pasivo circulante no puede ser cero para este cálculo.", "Advertencia");
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
