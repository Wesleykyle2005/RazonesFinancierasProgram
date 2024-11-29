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
            double utilidadesDeInteresEImpuestos = 0;
            double cargosPorIntereses = 0;

            // Limpiar los TextBox antes de asignar nuevos valores
            UtilidadesAntesDeInteresTextBox.Clear();
            CargosPorInteresesTextBox.Clear();
            RazonDeInteresAUtilidadesTextBox.Clear();
            ConclusionTextBox.Clear();

            // Conexión a la base de datos
            string SqlServerConnection = ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;
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

                    // Crear el comando SQL
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Ejecutar la consulta y leer los resultados
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Leer el primer registro
                            if (reader.Read())
                            {
                                // Asignar valores a las variables de utilidades y cargos
                                utilidadesDeInteresEImpuestos = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader.GetDecimal(0)); // Total Ingresos
                                cargosPorIntereses = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader.GetDecimal(1)); // Total Gastos

                                // Validar si los valores obtenidos son cero
                                if (utilidadesDeInteresEImpuestos == 0 || cargosPorIntereses == 0)
                                {
                                    string mensajeError = "No se pueden realizar cálculos porque:";
                                    if (utilidadesDeInteresEImpuestos == 0) mensajeError += "\n- Las utilidades antes de intereses e impuestos son cero o no existen.";
                                    if (cargosPorIntereses == 0) mensajeError += "\n- Los cargos por intereses son cero o no existen.";

                                    MessageBox.Show(mensajeError, "Error en datos");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos para la empresa especificada.", "Sin datos");
                                return;
                            }
                        }
                    }
                }

                // Asignar los valores a los TextBox
                UtilidadesAntesDeInteresTextBox.Text = utilidadesDeInteresEImpuestos.ToString("F2");
                CargosPorInteresesTextBox.Text = cargosPorIntereses.ToString("F2");

                // Calcular la razón de cobertura de intereses
                double razonDeRotacionAInteresAUtilidades = 0;

                if (cargosPorIntereses != 0)
                {
                    razonDeRotacionAInteresAUtilidades = utilidadesDeInteresEImpuestos / cargosPorIntereses;
                    RazonDeInteresAUtilidadesTextBox.Text = razonDeRotacionAInteresAUtilidades.ToString("F2");

                    // Evaluar la razón de cobertura de intereses
                    string conclusion = $"La razón de cobertura de intereses es de {razonDeRotacionAInteresAUtilidades:F2}.\n";

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

                    // Comparar con el promedio de la industria
                    string promedioIndustriaText = txtPromedioDeLaIndustria.Text;
                    if (double.TryParse(promedioIndustriaText, out double promedioIndustria))
                    {
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

                    // Mostrar la conclusión
                    ConclusionTextBox.Text = conclusion;
                }
                else
                {
                    MessageBox.Show("No se pueden realizar cálculos con cargos por intereses cero.", "Error en cálculo");
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
