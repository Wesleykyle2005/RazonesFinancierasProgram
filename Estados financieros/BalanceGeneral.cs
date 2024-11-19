using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RazonesFinancieras
{
    public partial class BalanceGeneral : Form
    {
        public BalanceGeneral()
        {
            InitializeComponent();
        }

        private void BalanceGeneral_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
