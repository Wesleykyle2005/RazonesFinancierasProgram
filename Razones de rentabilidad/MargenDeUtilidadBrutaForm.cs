using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RazonesFinancieras.Razones_de_rentabilidad
{
    public partial class MargenDeUtilidadBrutaForm : Form
    {
        public MargenDeUtilidadBrutaForm()
        {
            InitializeComponent();
        }

        private void MargenDeUtilidadBrutaForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Inicializar las variables
            Double ventas = 0;
            Double CostoDeVentas = 0;

            // Asignar valores iniciales a los TextBox
            VentasTextBox.Text = ventas.ToString();
            CostoDeVentasTextBox.Text = CostoDeVentas.ToString();

            // Calcular el Capital de Trabajo Neto
            try
            {
                // Parsear los valores de los TextBox
                ventas = Double.Parse(VentasTextBox.Text);
                ventas = Double.Parse(CostoDeVentasTextBox.Text);

                // Calcular y mostrar el resultado
                Double margenDeUtilidadBruta = (ventas - CostoDeVentas) / ventas;
                MargenDeUtilidadBrutaTextBox.Text = margenDeUtilidadBruta.ToString();
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
