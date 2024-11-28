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
    public partial class RazonDeCuentasPorCobrarForm : Form
    {
        public RazonDeCuentasPorCobrarForm()
        {
            InitializeComponent();
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Inicializar las variables
            Double ventas = 0;
            Double cuentasporcobrar = 0;

            // Asignar valores iniciales a los TextBox
            Ventastxt.Text = ventas.ToString();
            CuentasPorCobrartxt.Text = cuentasporcobrar.ToString();

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;

                // Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener las Ventas y Cuentas por Cobrar
                    string query = @"
                SELECT 

    SUM(CASE WHEN CE.TipoCuenta = 'Ventas' AND A.NombreCuenta = 'Ventas al credito' THEN V.Valor ELSE 0 END) AS TotalVentas,
    
    SUM(CASE WHEN CE.TipoCuenta = 'Activos' AND A.Clasificacion = 'Activo Circulante' AND A.NombreCuenta = 'Cuentas por Cobrar' THEN A.Valor ELSE 0 END) AS TotalCuentasPorCobrar
FROM CuentaEmpresa CE
JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
LEFT JOIN Ventas V ON CE.TipoCuenta = 'Ventas' AND CE.IdCuenta = V.IdVenta
LEFT JOIN Activos A ON CE.TipoCuenta = 'Activos' AND CE.IdCuenta = A.IdActivo
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
                                ventas = reader["TotalVentas"] != DBNull.Value ? Convert.ToDouble(reader["TotalVentas"]) : 0;
                                cuentasporcobrar = reader["TotalCuentasPorCobrar"] != DBNull.Value ? Convert.ToDouble(reader["TotalCuentasPorCobrar"]) : 0;

                                // Mostrar los valores en los TextBox
                                Ventastxt.Text = ventas.ToString("N2");
                                CuentasPorCobrartxt.Text = cuentasporcobrar.ToString("N2");

                                // Calcular y mostrar la rotación de cuentas por cobrar
                                if (cuentasporcobrar != 0)
                                {
                                    double rotacionDeCuentasPorCobrar = ventas / cuentasporcobrar;
                                    RotacionDeCuentasPorCobrartxt.Text = rotacionDeCuentasPorCobrar.ToString("N2");
                                }
                                else
                                {
                                    RotacionDeCuentasPorCobrartxt.Text = "N/A";
                                    MessageBox.Show("Las cuentas por cobrar no pueden ser cero para este cálculo.", "Advertencia");
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
