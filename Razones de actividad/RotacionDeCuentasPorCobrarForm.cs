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
    public partial class RazonDeCuentasPorCobrarForm : Form
    {
        public RazonDeCuentasPorCobrarForm()
        {
            InitializeComponent();
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Inicializar las variables
            Double ventas = 0;
            Double cuentasporcobrar = 0;

            // Asignar valores iniciales a los TextBox
            Ventastxt.Text = ventas.ToString();
            CuentasPorCobrartxt.Text = cuentasporcobrar.ToString();

            // Calcular el Capital de Trabajo Neto
            try
            {
                // Parsear los valores de los TextBox
                cuentasporcobrar = Double.Parse(CuentasPorCobrartxt.Text);
                ventas = Double.Parse(Ventastxt.Text);

                // Calcular y mostrar el resultado
                Double rotaciondecuentasporcobrar = ventas / cuentasporcobrar;
                RotacionDeCuentasPorCobrartxt.Text = rotaciondecuentasporcobrar.ToString();
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
