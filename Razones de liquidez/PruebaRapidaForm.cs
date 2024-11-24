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
    public partial class PruebaRapidaForm : Form
    {
        public PruebaRapidaForm()
        {
            InitializeComponent();
        }

        private void PruebaRapidaForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {

            Double activoCirculante = 0;
            Double pasivoCirculante = 0;
            Double inventarios = 0;

            ActivoCirculantetxt.Text = activoCirculante.ToString();
            PasivoCirculantetxt.Text = pasivoCirculante.ToString();
            Inventariostxt.Text = inventarios.ToString();
            try
            {

                activoCirculante = Double.Parse(ActivoCirculantetxt.Text);
                pasivoCirculante = Double.Parse(PasivoCirculantetxt.Text);
                inventarios = Double.Parse(Inventariostxt.Text);

                Double PruebaAcida = (activoCirculante - inventarios) / pasivoCirculante;
                PruebaRapidatxt.Text = PruebaAcida.ToString();
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

        }

        private void copyButton_Click_1(object sender, EventArgs e)
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
