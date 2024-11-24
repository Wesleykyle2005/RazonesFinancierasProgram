using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RazonesFinancieras.Razones_de_endeudamiento
{
    public partial class RazonDeRotaciónDeInteresAUtilidadesForm : Form
    {
        public RazonDeRotaciónDeInteresAUtilidadesForm()
        {
            InitializeComponent();
        }

        private void RazonDeRotaciónDeInteresAUtilidadesForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            Double utilidadesDeInteresEImpuestos = 0;
            Double cargosPorIntereses = 0;

            // Asignar valores iniciales a los TextBox

            UtilidadesAntesDeInteresTextBox.Text = utilidadesDeInteresEImpuestos.ToString();
            CargosPorInteresesTextBox.Text = cargosPorIntereses.ToString();

            // Calcular el Capital de Trabajo Neto
            try
            {
                // Parsear los valores de los TextBox
                utilidadesDeInteresEImpuestos = Double.Parse(UtilidadesAntesDeInteresTextBox.Text);
                cargosPorIntereses = Double.Parse(CargosPorInteresesTextBox.Text);

                // Calcular y mostrar el resultado
                Double razonDeRotacionAInteresAUtilidades = utilidadesDeInteresEImpuestos / cargosPorIntereses;
                RazonDeInteresAUtilidadesTextBox.Text = razonDeRotacionAInteresAUtilidades.ToString();
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
