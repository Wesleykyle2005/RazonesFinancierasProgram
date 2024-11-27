using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
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
    public partial class RazonDeDeudaTotalForm : Form
    {
        public RazonDeDeudaTotalForm()
        {
            InitializeComponent();
        }

        private void RazonDeDeudaTotalForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            Double pasivosTotales = 0;
            Double activosTotales = 0;

            string SqlServerConnection = ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;
            string query = @"
                SELECT 
                    SUM(CASE WHEN CE.TipoCuenta = 'Pasivos' THEN P.Valor ELSE 0 END) AS TotalPasivos,
                    SUM(CASE WHEN CE.TipoCuenta = 'Activos' THEN A.Valor ELSE 0 END) AS TotalActivos
                FROM CuentaEmpresa CE
                JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
                LEFT JOIN Activos A ON CE.TipoCuenta = 'Activos' AND CE.IdCuenta = A.IdActivo
                LEFT JOIN Pasivos P ON CE.TipoCuenta = 'Pasivos' AND CE.IdCuenta = P.IdPasivo
                WHERE E.IdEmpresa = @IdEmpresa
                GROUP BY E.IdEmpresa";

            try
            {
                using (SqlConnection conn = new SqlConnection(SqlServerConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdEmpresa", 1);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                activosTotales = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader.GetDecimal(1)); // Total Activos
                                pasivosTotales = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader.GetDecimal(0)); // Total Pasivos
                            }
                        }
                    }
                }

                PaivosTotalesTextBox.Text = pasivosTotales.ToString("F2");
                ActivosTotalesTextBox.Text = activosTotales.ToString("F2");

                Double razonDeDeuda = 0;

                if (activosTotales != 0)
                {
                    razonDeDeuda = pasivosTotales / activosTotales;
                    RazonDeLaDeudaTextBox.Text = razonDeDeuda.ToString("F2");
                    if (razonDeDeuda < 0.5)
                    {
                        ConclusionTextBox.Text = 
                            "La empresa tiene una baja razón de deuda, lo que indica que tiene una buena solvencia y capacidad para pagar sus deudas.";
                    }
                    else if (razonDeDeuda >= 0.5 && razonDeDeuda <= 1.0)
                    {
                        ConclusionTextBox.Text = 
                            "La empresa tiene una razón de deuda moderada, lo que indica un balance aceptable entre los activos y pasivos.";
                    }
                    else
                    {
                        ConclusionTextBox.Text = 
                            "La empresa tiene una alta razón de deuda, lo que sugiere que podría tener dificultades para cumplir con sus obligaciones financieras.";
                    }
                }
                else
                {
                    MessageBox.Show("Los activos totales no pueden ser cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
