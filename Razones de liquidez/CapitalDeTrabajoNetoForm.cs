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
    public partial class CapitalDeTrabajoNetoForm : Form
    {
        public CapitalDeTrabajoNetoForm()
        {
            InitializeComponent();
        }

        private void CapitalDeTrabajoNetoForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            ActivoCirculantetextBox.Text = "a";
            PasivoCirculantetextBoxPasivoCirculantetextBox.Text = "a";
            CapitalDeTrabajoNetotextBox.Text = "a";
            ConclusionTextBox.Text = "qwertyuiiopasdfghjklzxcvbnm";
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
