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
            // Inicializar las variables
            int activoCirculante = 0;
            int pasivoCirculante = 0;
            int inventarios = 0;

            // Asignar valores iniciales a los TextBox
            ActivoCirculantetxt.Text = activoCirculante.ToString();
            PasivoCirculantetxt.Text = pasivoCirculante.ToString();
            Inventariostxt.Text = inventarios.ToString();

            // Calcular el Capital de Trabajo Neto
            try
            {
                // Parsear los valores de los TextBox
                activoCirculante = int.Parse(ActivoCirculantetxt.Text);
                pasivoCirculante = int.Parse(PasivoCirculantetxt.Text);
                inventarios = int.Parse(Inventariostxt.Text);

                // Calcular y mostrar el resultado
                int PruebaAcida = (activoCirculante - inventarios)/pasivoCirculante;
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
    }
}
