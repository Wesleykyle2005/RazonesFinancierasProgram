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
    public partial class PruebaRapidaForm : Form
    {
        public PruebaRapidaForm()
        {
            InitializeComponent();
        }

        private void PruebaRapidaForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Inicializar las variables
            double activoCirculante = 0;
            double pasivoCirculante = 0;
            double inventarios = 0;

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;
                // Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener el Activo Circulante, Pasivo Circulante e Inventarios
                    string query = @"
                    SELECT 
                    SUM(CASE WHEN CE.TipoCuenta = 'Activos' AND A.Clasificacion = 'Activo Circulante' THEN A.Valor ELSE 0 END) AS TotalActivoCirculante,
                    SUM(CASE WHEN CE.TipoCuenta = 'Pasivos' AND P.Clasificacion = 'Pasivo corto plazo' THEN P.Valor ELSE 0 END) AS TotalPasivoCirculante,
                    SUM(CASE WHEN CE.TipoCuenta = 'Activos' AND I.NombreCuenta = 'Inventarios' THEN I.Valor ELSE 0 END) AS TotalInventarios
                    FROM CuentaEmpresa CE
                    JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
                    LEFT JOIN Activos A ON CE.TipoCuenta = 'Activos' AND CE.IdCuenta = A.IdActivo
                    LEFT JOIN Pasivos P ON CE.TipoCuenta = 'Pasivos' AND CE.IdCuenta = P.IdPasivo
                    LEFT JOIN Activos I ON CE.TipoCuenta = 'Activos' AND CE.IdCuenta = I.IdActivo AND I.NombreCuenta = 'Inventarios' 
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
                                inventarios = reader["TotalInventarios"] != DBNull.Value ? Convert.ToDouble(reader["TotalInventarios"]) : 0;

                                // Mostrar los valores en los TextBox
                                ActivoCirculantetxt.Text = activoCirculante.ToString("N2");
                                PasivoCirculantetxt.Text = pasivoCirculante.ToString("N2");
                                Inventariostxt.Text = inventarios.ToString("N2");

                                // Calcular y mostrar el resultado de la prueba ácida
                                if (pasivoCirculante != 0)
                                {
                                    double pruebaAcida = (activoCirculante - inventarios) / pasivoCirculante;
                                    PruebaRapidatxt.Text = pruebaAcida.ToString("N2");
                                    // Generar conclusión
                                    string conclusion = $"La prueba ácida calculada es: {pruebaAcida:N2}. ";

                                    // Interpretar el resultado
                                    if (pruebaAcida >= 1.0)
                                    {
                                        conclusion += "Esto significa que la empresa tiene activos líquidos suficientes para cubrir sus pasivos circulantes sin tener que liquidar su inventario, lo cual es una señal positiva. ";
                                    }
                                    else
                                    {
                                        conclusion += "Esto indica que la empresa podría tener problemas de liquidez, ya que no tiene suficientes activos líquidos para cubrir sus pasivos circulantes. ";
                                    }

                                    // Comparar con el promedio de la industria (si está disponible)
                                    if (double.TryParse(txtPromedioDeLaIndustria.Text, out double promedioIndustria))
                                    {
                                        if (pruebaAcida > promedioIndustria)
                                        {
                                            conclusion += $"Además, la prueba ácida de la empresa es mayor que el promedio de la industria ({promedioIndustria:N2}), lo cual es favorable.";
                                        }
                                        else if (pruebaAcida < promedioIndustria)
                                        {
                                            conclusion += $"Además, la prueba ácida de la empresa es menor que el promedio de la industria ({promedioIndustria:N2}), lo que podría ser una debilidad comparativa.";
                                        }
                                        else
                                        {
                                            conclusion += "La prueba ácida de la empresa es igual al promedio de la industria.";
                                        }
                                    }

                                    // Mostrar la conclusión en el TextBox
                                    ConclusionTextBox.Text = conclusion;
                                }
                                else
                                {
                                    PruebaRapidatxt.Text = "N/A";
                                    ConclusionTextBox.Text = "El pasivo circulante no puede ser cero para calcular la prueba ácida.";
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

        }

        private void copyButton_Click_1(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén la conclusión del TextBox
                string conclusion = ConclusionTextBox.Text;

                if (!string.IsNullOrWhiteSpace(conclusion))
                {
                    // Agregar la conclusión a la lista en la clase ConclusionesFinancieras
                    ConclusionesFinancieras.AgregarConclusion(this.Text, conclusion);

                    MessageBox.Show("Conclusión guardada exitosamente.", "Éxito");
                }
                else
                {
                    MessageBox.Show("No hay ninguna conclusión para guardar.", "Advertencia");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la conclusión: {ex.Message}", "Error");
            }
        }
    }
}
