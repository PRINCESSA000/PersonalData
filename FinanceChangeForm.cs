using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PD
{
    public partial class FinanceChangeForm : Form
    {

        private readonly FinanceForm _financeForm;

        public FinanceChangeForm(FinanceForm financeForm)
        {
            InitializeComponent();
            _financeForm = financeForm;
        }

        private void FinanceChangeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
