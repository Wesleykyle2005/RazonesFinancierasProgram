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

namespace RazonesFinancieras.Razones_de_actividad
{
    public partial class RotacionDeActivosFijosForm : Form
    {
        public RotacionDeActivosFijosForm()
        {
            InitializeComponent();
        }

        private void RotacionDeActivosFijosForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Inicializar las variables
            double ventas = 0;
            double activosfijos = 0;

            try
            {

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;
                // Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener las Ventas y Activos Fijos
                    string query = @"
                SELECT 
    SUM(CASE WHEN CE.TipoCuenta = 'Ventas' AND  v.NombreCuenta='Ventas' THEN V.Valor ELSE 0 END) AS TotalVentas,
    SUM(CASE 
        WHEN CE.TipoCuenta = 'Activos' AND A.Clasificacion = 'Activo No Circulante'  
        THEN A.Valor 
        ELSE 0 
    END) AS TotalActivosFijos
            FROM CuentaEmpresa CE
            JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
            LEFT JOIN Ventas V ON CE.TipoCuenta = 'Ventas' AND CE.IdCuenta = V.IdVenta
            LEFT JOIN Activos A ON CE.TipoCuenta = 'Activos' AND CE.IdCuenta = A.IdActivo
            WHERE E.IdEmpresa = 1
            GROUP BY E.IdEmpresa;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Ejecutar la consulta
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Asignar los valores obtenidos desde la base de datos
                                ventas = reader["TotalVentas"] != DBNull.Value ? Convert.ToDouble(reader["TotalVentas"]) : 0;
                                activosfijos = reader["TotalActivosFijos"] != DBNull.Value ? Convert.ToDouble(reader["TotalActivosFijos"]) : 0;

                                // Mostrar los valores en los TextBox
                                Ventastxt.Text = ventas.ToString("N2");
                                ActivosFijosTxt.Text = activosfijos.ToString("N2");

                                // Calcular y mostrar la rotación de activos fijos
                                if (activosfijos != 0)
                                {
                                    double rotaciondeactivosfijos = ventas / activosfijos;
                                    RotacionDeActivosFijostxt.Text = rotaciondeactivosfijos.ToString("N2");
                                    // Comparar con el promedio de la industria si está disponible
                                    string promedioIndustriaText = txtPromedioDeLaIndustria.Text; // Obtener el valor del promedio de la industria
                                    double promedioIndustria;

                                    string conclusion = $"La rotación de activos fijos es de {rotaciondeactivosfijos:F2} veces.\n";

                                    // Evaluar si el coeficiente es mayor que 1.0
                                    if (rotaciondeactivosfijos < 1.0)
                                    {
                                        conclusion += "Este valor es inferior a 1.0, lo que sugiere una ineficiencia en el uso de los activos fijos.";
                                    }
                                    else if (rotaciondeactivosfijos > 1.0)
                                    {
                                        conclusion += "Este valor es superior a 1.0, lo que indica eficiencia en el uso de los activos fijos.";
                                    }
                                    else
                                    {
                                        conclusion += "Este valor es igual a 1.0, lo que sugiere un uso equilibrado de los activos fijos.";
                                    }

                                    // Comparar con el promedio de la industria si está disponible
                                    if (double.TryParse(promedioIndustriaText, out promedioIndustria))
                                    {
                                        if (rotaciondeactivosfijos < promedioIndustria)
                                        {
                                            conclusion += $"\nEste valor es inferior al promedio de la industria ({promedioIndustria:F2} veces), lo que sugiere una menor eficiencia en el uso de los activos fijos.";
                                        }
                                        else if (rotaciondeactivosfijos > promedioIndustria)
                                        {
                                            conclusion += $"\nEste valor es superior al promedio de la industria ({promedioIndustria:F2} veces), lo que indica una mayor eficiencia en el uso de los activos fijos.";
                                        }
                                        else
                                        {
                                            conclusion += $"\nEste valor es similar al promedio de la industria ({promedioIndustria:F2} veces), lo que sugiere una eficiencia comparable en el uso de los activos fijos.";
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
                                    RotacionDeActivosFijostxt.Text = "N/A";
                                    MessageBox.Show("Los activos fijos no pueden ser cero para este cálculo.", "Advertencia");
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
