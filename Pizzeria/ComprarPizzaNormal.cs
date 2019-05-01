using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria
{
    public partial class ComprarPizzaNormal : Form
    {
        public ComprarPizzaNormal()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a= checkedListBox1.CheckedItems[0].ToString();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked) { 
                // hacer update en la tabla de ingredientes y recalcular precio de la pizza
                }
            }   
        }
    }
}
