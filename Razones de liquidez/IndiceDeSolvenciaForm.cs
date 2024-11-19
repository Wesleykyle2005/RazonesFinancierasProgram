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
            this.ControlBox=false;
        }
    }
}
