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
            string queryCostos = "SELECT SUM(Valor) \r\nFROM Costos \r\nWHERE Clasificacion IN ('Compras', 'Descuentos');";
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
                // Calcular el período en meses y días
                double periodoEnMeses = 12 / rotacionDeInventarios;
                double periodoEnDias = 360 / rotacionDeInventarios;



                // Generar interpretación
                string conclusion = $"La rotación de inventarios es {rotacionDeInventarios:N2}. Esto significa que la empresa renueva su inventario aproximadamente cada {periodoEnMeses:F2} meses o cada {periodoEnDias:F2} días. ";

                // Evaluar eficiencia
                if (rotacionDeInventarios > 6)
                {
                    conclusion += "Esto indica una alta eficiencia en el manejo de inventarios, con un buen ritmo de ventas. ";
                }
                else if (rotacionDeInventarios >= 3 && rotacionDeInventarios <= 6)
                {
                    conclusion += "El índice es moderado, lo que sugiere un manejo aceptable de inventarios, aunque podría mejorarse. ";
                }
                else
                {
                    conclusion += "El índice es bajo, indicando posibles problemas con exceso de inventarios o baja rotación de los mismos. ";
                }

                // Comparar con el promedio de la industria
                if (double.TryParse(txtPromedioDeLaIndustria.Text, out double promedioIndustria))
                {
                    if (rotacionDeInventarios > promedioIndustria)
                    {
                        conclusion += $"La rotación de inventarios es superior al promedio de la industria ({promedioIndustria:N2}), lo cual es positivo.";
                    }
                    else if (rotacionDeInventarios < promedioIndustria)
                    {
                        conclusion += $"La rotación de inventarios es inferior al promedio de la industria ({promedioIndustria:N2}), lo que indica que hay margen de mejora.";
                    }
                    else
                    {
                        conclusion += "La rotación de inventarios está en línea con el promedio de la industria.";
                    }
                }

                // Mostrar la conclusión en el TextBox
                ConclusionTextBox.Text = conclusion;
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
