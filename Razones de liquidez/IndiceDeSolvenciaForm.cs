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
    public partial class IndiceDeSolvenciaForm : Form
    {
        public IndiceDeSolvenciaForm()
        {
            InitializeComponent();
        }

        private void IndiceDeSolvenciaForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Inicializar las variables
            int activoCirculante = 0;
            int pasivoCirculante = 0;

            // Asignar valores iniciales a los TextBox
            ActivocirculanteTextbox.Text = activoCirculante.ToString();
            PasivoCirculantetextBox.Text = pasivoCirculante.ToString();

            // Calcular el Capital de Trabajo Neto
            try
            {
                // Parsear los valores de los TextBox
                activoCirculante = int.Parse(ActivocirculanteTextbox.Text);
                pasivoCirculante = int.Parse(PasivoCirculantetextBox.Text);

                // Calcular y mostrar el resultado
                int IndiceDeSolvencia = activoCirculante/pasivoCirculante;
                IndiceSolvenciatxtBox.Text = IndiceDeSolvencia.ToString();
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
