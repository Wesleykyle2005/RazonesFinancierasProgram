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
            Double activoCirculante = 0;
            Double pasivoCirculante = 0;

            // Asignar valores iniciales a los TextBox
            ActivocirculanteTextbox.Text = activoCirculante.ToString();
            PasivoCirculantetextBox.Text = pasivoCirculante.ToString();

            // Calcular el Capital de Trabajo Neto
            try
            {
                // Parsear los valores de los TextBox
                activoCirculante = Double.Parse(ActivocirculanteTextbox.Text);
                pasivoCirculante = Double.Parse(PasivoCirculantetextBox.Text);

                // Calcular y mostrar el resultado
                Double IndiceDeSolvencia = activoCirculante / pasivoCirculante;
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
