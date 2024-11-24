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
            int ventas = 0;
            int activosfijos = 0;

            // Asignar valores iniciales a los TextBox
            Ventastxt.Text = ventas.ToString();
            ActivosFijosTxt.Text = activosfijos.ToString();

            // Calcular el Capital de Trabajo Neto
            try
            {
                // Parsear los valores de los TextBox
                activosfijos = int.Parse(ActivosFijosTxt.Text);
                ventas = int.Parse(Ventastxt.Text);

                // Calcular y mostrar el resultado
                int rotaciondeactivosfijos = ventas / activosfijos;
                RotacionDeActivosFijostxt.Text = rotaciondeactivosfijos.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos.", "Error de Formato");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error");
            }
        }
    }
}
