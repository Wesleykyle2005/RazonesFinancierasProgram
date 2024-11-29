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
    public partial class CapitalDeTrabajoNetoForm : Form
    {
        public CapitalDeTrabajoNetoForm()
        {
            InitializeComponent();
        }

        private void CapitalDeTrabajoNetoForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            string SqlServerConnection = System.Configuration.ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(SqlServerConnection))
                {
                    connection.Open();

                    // Consulta parametrizada para obtener Activo Circulante y Pasivo Circulante
                    string query = @"
                    SELECT 
                    SUM(CASE 
                    WHEN CE.TipoCuenta = 'Activos' AND A.Clasificacion = 'Activo Circulante' 
                    THEN A.Valor 
                    ELSE 0 
                    END) AS TotalActivosCirculantes,
                    SUM(CASE 
                    WHEN CE.TipoCuenta = 'Pasivos' AND P.Clasificacion = 'Pasivo Corto Plazo' 
                    THEN P.Valor 
                    ELSE 0 
                    END) AS TotalPasivosCortoPlazo
                    FROM CuentaEmpresa CE
                    LEFT JOIN Activos A ON CE.TipoCuenta = 'Activos' AND CE.IdCuenta = A.IdActivo
                    LEFT JOIN Pasivos P ON CE.TipoCuenta = 'Pasivos' AND CE.IdCuenta = P.IdPasivo
                    WHERE CE.IdEmpresa = 1
                    AND CE.TipoCuenta IN ('Activos', 'Pasivos');";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar parámetro a la consulta
                        command.Parameters.AddWithValue("@EmpresaID", 1);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtener los valores de la consulta
                                double activoCirculante = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader.GetDecimal(0));
                                double pasivoCirculante = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader.GetDecimal(1));

                                // Mostrar los valores en los TextBox
                                ActivoCirculantetextBox.Text = activoCirculante.ToString("N2");
                                PasivoCirculantetextBox.Text = pasivoCirculante.ToString("N2");

                                // Calcular el Capital de Trabajo Neto
                                double capitalDeTrabajoNeto = activoCirculante - pasivoCirculante;
                                CapitalDeTrabajoNetotextBox.Text = capitalDeTrabajoNeto.ToString("N2");
                                // Generar la conclusión
                                string conclusion = $"El resultado del Capital de Trabajo Neto es: {capitalDeTrabajoNeto:N2}. ";

                                // Evaluar si el valor es bueno o malo
                                if (capitalDeTrabajoNeto > 0)
                                {
                                    conclusion += "Esto indica que la empresa tiene un margen de seguridad para cumplir con sus obligaciones futuras cercanas, lo cual es positivo. ";

                                    // Evaluar si el valor es excesivo
                                    if (capitalDeTrabajoNeto > activoCirculante * 0.5)
                                    {
                                        conclusion += "Sin embargo, el capital de trabajo parece excesivo, lo que podría indicar fondos ociosos. ";
                                    }
                                }
                                else
                                {
                                    conclusion += "Esto indica que la empresa podría tener problemas de liquidez, ya que el pasivo circulante excede el activo circulante. ";
                                }

                                // Comparar con el promedio de la industria (si está disponible)
                                if (double.TryParse(txtPromedioDeLaIndustria.Text, out double promedioIndustria))
                                {
                                    if (capitalDeTrabajoNeto > promedioIndustria)
                                    {
                                        conclusion += $"Además, el Capital de Trabajo Neto de la empresa es mayor que el promedio de la industria ({promedioIndustria:N2}), lo cual es favorable.";
                                    }
                                    else if (capitalDeTrabajoNeto < promedioIndustria)
                                    {
                                        conclusion += $"Además, el Capital de Trabajo Neto de la empresa es menor que el promedio de la industria ({promedioIndustria:N2}), lo cual podría ser un área de mejora.";
                                    }
                                    else
                                    {
                                        conclusion += "El Capital de Trabajo Neto de la empresa es igual al promedio de la industria.";
                                    }
                                }

                                // Mostrar la conclusión en el TextBox
                                ConclusionTextBox.Text = conclusion;
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos para la empresa seleccionada.", "Información");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al conectar con la base de datos: {ex.Message}", "Error");
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
