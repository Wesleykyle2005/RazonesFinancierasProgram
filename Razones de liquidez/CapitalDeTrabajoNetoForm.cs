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
