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
    public partial class RazonDeRotacionDeInventarioForm : Form
    {
        public RazonDeRotacionDeInventarioForm()
        {
            InitializeComponent();
        }

        private void RazonDeRotacionDeInventarioForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Declarar las variables
            double costos = 0;
            double inventarios = 0;

            // Cadena de conexión (ajusta según tu servidor y autenticación)
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;
            string queryCostos = "SELECT SUM(Valor) FROM Costos WHERE Clasificacion = 'Compras';";
            string queryInventarios = "SELECT SUM(Valor) FROM Activos WHERE Clasificacion = 'Activo Circulante' AND NombreCuenta = 'Inventarios';";

            try
            {
                // Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Ejecutar la consulta para obtener el total de costos
                    using (SqlCommand cmdCostos = new SqlCommand(queryCostos, connection))
                    {
                        object resultCostos = cmdCostos.ExecuteScalar();
                        if (resultCostos != DBNull.Value)
                        {
                            costos = Convert.ToDouble(resultCostos);
                        }
                    }

                    // Ejecutar la consulta para obtener el total de inventarios
                    using (SqlCommand cmdInventarios = new SqlCommand(queryInventarios, connection))
                    {
                        object resultInventarios = cmdInventarios.ExecuteScalar();
                        if (resultInventarios != DBNull.Value)
                        {
                            inventarios = Convert.ToDouble(resultInventarios);
                        }
                    }
                }

                // Mostrar los valores en los TextBox
                Costostxt.Text = costos.ToString("F2");
                Inventariostxt.Text = inventarios.ToString("F2");

                // Validar que inventarios no sea cero
                if (inventarios == 0)
                {
                    MessageBox.Show("El valor de inventarios no puede ser cero.", "Error");
                    return;
                }

                // Calcular y mostrar la rotación de inventarios
                double rotacionDeInventarios = costos / inventarios;
                RotacionInventariostxt.Text = rotacionDeInventarios.ToString("F2");
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {sqlEx.Message}", "Error de Base de Datos");
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos.", "Error de Formato");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error");
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
