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
    public partial class FinanceForm : Form
    {
        public FinanceForm()
        {
            InitializeComponent();
        }

        private FinanceChangeForm financeChangeForm;

        private void FinanceForm_Load(object sender, EventArgs e)
        {

        }

        public void FinanceChangeFormLoad()
        {
            financeChangeForm = new FinanceChangeForm(this);
            financeChangeForm.TopLevel = false;
            //financeChangeForm.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(financeChangeForm);
            financeChangeForm.BringToFront();
            financeChangeForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}