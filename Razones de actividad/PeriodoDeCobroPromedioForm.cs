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
    public partial class PeriodoDeCobroPromedioForm : Form
    {
        public PeriodoDeCobroPromedioForm()
        {
            InitializeComponent();
        }

        private void PeriodoDePagoPromedioForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Inicializar las variables
            Double ventas = 0;
            Double cuentasPorCobrar = 0;

            // Conexión a la base de datos
            string SqlServerConnection = System.Configuration.ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString; // Reemplaza con tu cadena de conexión
            string query = @"
    SELECT 
    SUM(CASE WHEN CE.TipoCuenta = 'Ventas' THEN V.Valor ELSE 0 END) AS TotalVentas,
    SUM(CASE 
        WHEN CE.TipoCuenta = 'Activos' AND A.Clasificacion = 'Activo Circulante' AND A.NombreCuenta = 'Cuentas por Cobrar' 
        THEN A.Valor 
        ELSE 0 
    END) AS TotalCuentasPorCobrar
FROM CuentaEmpresa CE
JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
LEFT JOIN Ventas V ON CE.TipoCuenta = 'Ventas' AND CE.IdCuenta = V.IdVenta
LEFT JOIN Activos A ON CE.TipoCuenta = 'Activos' AND CE.IdCuenta = A.IdActivo
WHERE E.IdEmpresa = 1
GROUP BY E.IdEmpresa;";

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
                            if (reader.Read())
                            {
                                ventas = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader.GetDecimal(0)); // Total Ventas
                                cuentasPorCobrar = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader.GetDecimal(1)); // Total Cuentas por Cobrar
                            }
                        }
                    }
                }

                // Asignar los valores de las ventas y cuentas por cobrar a los TextBox
                VentasTxt.Text = ventas.ToString("F2");
                CuentasPorCobrarTxt.Text = cuentasPorCobrar.ToString("F2");

                // Calcular el Periodo Promedio de Cobro
                if (ventas != 0)
                {
                    Double periodoPromedioDeCobro = cuentasPorCobrar / (ventas / 360);
                    PeriodoPromedioDeCobrotxt.Text = periodoPromedioDeCobro.ToString("F2");
                    // Comparar con el promedio de la industria
                    string promedioIndustriaText = txtPromedioDeLaIndustria.Text; // Obtener el valor del promedio de la industria del TextBox
                    double promedioIndustria;

                    if (double.TryParse(promedioIndustriaText, out promedioIndustria))
                    {
                        string conclusion = $"El período promedio de cobro es de {periodoPromedioDeCobro:F2} días.\n";

                        if (periodoPromedioDeCobro < promedioIndustria)
                        {
                            conclusion += $"Este valor es inferior al promedio de la industria ({promedioIndustria:F2} días), lo cual indica una rápida recuperación de las cuentas por cobrar.";
                        }
                        else if (periodoPromedioDeCobro > promedioIndustria)
                        {
                            conclusion += $"Este valor es superior al promedio de la industria ({promedioIndustria:F2} días), lo que podría indicar un retraso en la recuperación de cuentas por cobrar.";
                        }
                        else
                        {
                            conclusion += $"Este valor es similar al promedio de la industria ({promedioIndustria:F2} días), lo que sugiere una recuperación normal de las cuentas por cobrar.";
                        }

                        // Mostrar la conclusión en el TextBox de conclusiones
                        ConclusionTextBox.Text = conclusion;
                    }
                    else
                    {
                        ConclusionTextBox.Text=$"El periodo promedio de cobro es de: {periodoPromedioDeCobro:F2} días.";
                    }
                }
                else
                {
                    MessageBox.Show("Las ventas totales no pueden ser cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
