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
using System.Configuration;

namespace RazonesFinancieras.Razones_de_endeudamiento
{
    public partial class RazonDeRotaciónDeInteresAUtilidadesForm : Form
    {
        public RazonDeRotaciónDeInteresAUtilidadesForm()
        {
            InitializeComponent();
        }

        private void RazonDeRotaciónDeInteresAUtilidadesForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            Double utilidadesDeInteresEImpuestos = 0;
            Double cargosPorIntereses = 0;

            // Conexión a la base de datos
            string SqlServerConnection = ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString; // Reemplaza con tu cadena de conexión
            string query = @"
   SELECT 
        SUM(CASE WHEN CE.TipoCuenta = 'Ventas' THEN I.Valor ELSE 0 END) AS TotalIngresos,
        SUM(CASE WHEN CE.TipoCuenta = 'Gastos' THEN G.Valor ELSE 0 END) AS TotalGastos
    FROM CuentaEmpresa CE
    JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
    LEFT JOIN Ventas I ON CE.TipoCuenta = 'Ventas' AND CE.IdCuenta = I.IdVenta
    LEFT JOIN Gastos G ON CE.TipoCuenta = 'Intereses' AND CE.IdCuenta = G.IdGasto
    WHERE E.IdEmpresa = 1
    GROUP BY E.IdEmpresa";

            try
            {
                // Establecer la conexión con la base de datos
                using (SqlConnection conn = new SqlConnection(SqlServerConnection))
                {
                    conn.Open();

                    // Crear el comando SQL con el parámetro de la empresa
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdEmpresa", 1); // Reemplaza con el ID de la empresa adecuada

                        // Ejecutar la consulta y leer los resultados
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Leer el primer registro
                            if (reader.Read())
                            {
                                // Asignar valores a las variables de utilidades antes de intereses e impuestos y cargos por intereses
                                utilidadesDeInteresEImpuestos = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader.GetDecimal(0)); // Total Ingresos (como ejemplo de utilidades)
                                cargosPorIntereses = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader.GetDecimal(1)); // Total Gastos (como ejemplo de cargos)
                            }
                        }
                    }
                }

                // Asignar los valores de las utilidades y los cargos a los TextBox
                UtilidadesAntesDeInteresTextBox.Text = utilidadesDeInteresEImpuestos.ToString("F2");
                CargosPorInteresesTextBox.Text = cargosPorIntereses.ToString("F2");

                // Calcular la razón de rotación de interés a utilidades
                Double razonDeRotacionAInteresAUtilidades = 0;

                if (cargosPorIntereses != 0)
                {
                    razonDeRotacionAInteresAUtilidades = utilidadesDeInteresEImpuestos / cargosPorIntereses;
                    RazonDeInteresAUtilidadesTextBox.Text = razonDeRotacionAInteresAUtilidades.ToString("F2");
                    string conclusion = $"La razón de cobertura de intereses es de {razonDeRotacionAInteresAUtilidades:F2}.\n";

                    // Promedio de la industria (ejemplo fijo)
                    string promedioIndustriaText = txtPromedioDeLaIndustria.Text; // Obtener el valor del promedio de la industria
                    double promedioIndustria;  // Este es un valor de ejemplo. Se debe actualizar según la industria.

                    // Evaluar la razón de cobertura de intereses
                    if (razonDeRotacionAInteresAUtilidades < 1.5)
                    {
                        conclusion += "La empresa tiene una razón de cobertura de intereses baja, lo que indica que podría tener dificultades para cubrir sus pagos de intereses.";
                    }
                    else if (razonDeRotacionAInteresAUtilidades >= 1.5 && razonDeRotacionAInteresAUtilidades <= 3.0)
                    {
                        conclusion += "La empresa tiene una razón de cobertura de intereses moderada, lo que indica una capacidad razonable para cubrir sus pagos de intereses.";
                    }
                    else
                    {
                        conclusion += "La empresa tiene una alta razón de cobertura de intereses, lo que sugiere que tiene una fuerte capacidad para cumplir con sus pagos de intereses.";
                    }






                    if (double.TryParse(promedioIndustriaText, out promedioIndustria))
                    {

                        // Comparación con el promedio de la industria
                        if (razonDeRotacionAInteresAUtilidades > promedioIndustria)
                        {
                            conclusion += $"\nLa razón de cobertura de intereses de la empresa es superior al promedio de la industria ({promedioIndustria}), lo que indica que la empresa tiene una excelente capacidad para cubrir sus intereses.";
                        }
                        else if (razonDeRotacionAInteresAUtilidades < promedioIndustria)
                        {
                            conclusion += $"\nLa razón de cobertura de intereses de la empresa es inferior al promedio de la industria ({promedioIndustria}), lo que sugiere que la empresa tiene una capacidad de cobertura de intereses por debajo de la media del sector.";
                        }
                        else
                        {
                            conclusion += $"\nLa razón de cobertura de intereses de la empresa es igual al promedio de la industria ({promedioIndustria}), lo que indica que tiene una capacidad de pago de intereses comparable con la media del sector.";
                        }
                    }
                    else
                    {
                        conclusion += "\nNo se pudo comparar con el promedio de la industria.";
                    }





                    // Comparación con el promedio de la industria

                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos.", "Error de Formato");
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error de base de datos: {sqlEx.Message}", "Error de Base de Datos");
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
