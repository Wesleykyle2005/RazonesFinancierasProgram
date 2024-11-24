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
    public partial class PeriodoDeCobroPromedioForm : Form
    {
        public PeriodoDeCobroPromedioForm()
        {
            InitializeComponent();
        }

        private void PeriodoDePagoPromedioForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Inicializar las variables
            int ventas = 0;
            int cuentasporcobrar = 0;

            // Asignar valores iniciales a los TextBox
            VentasTxt.Text = ventas.ToString();
            CuentasPorCobrarTxt.Text = cuentasporcobrar.ToString();

            // Calcular el Capital de Trabajo Neto
            try
            {
                // Parsear los valores de los TextBox
                cuentasporcobrar = int.Parse(CuentasPorCobrarTxt.Text);
                ventas = int.Parse(VentasTxt.Text);

                // Calcular y mostrar el resultado
                int periodopromediodecobro = cuentasporcobrar/(ventas/360);
                PeriodoPromedioDeCobrotxt.Text = periodopromediodecobro.ToString();
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
