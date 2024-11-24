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
            // Inicializar las variables
            int costos = 0;
            int inventarios = 0;

            // Asignar valores iniciales a los TextBox
            Costostxt.Text = costos.ToString();
            Inventariostxt.Text = inventarios.ToString();

            // Calcular el Capital de Trabajo Neto
            try
            {
                // Parsear los valores de los TextBox
                costos = int.Parse(Costostxt.Text);
                inventarios = int.Parse(Inventariostxt.Text);

                // Calcular y mostrar el resultado
                int RotacionDeInventarios = costos/inventarios;
                RotacionInventariostxt.Text = RotacionDeInventarios.ToString();
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
