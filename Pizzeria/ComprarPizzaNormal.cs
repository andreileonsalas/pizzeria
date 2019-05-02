using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            MyGlobals.con.Open();
            string q = "USE [tarea] DECLARE	@return_value int EXEC	@return_value = [dbo].[UltimaPizza] SELECT	'Return Value' = @return_value";
            SqlCommand cmd = new SqlCommand(q, MyGlobals.con);
            MyGlobals.pizza = (int)cmd.ExecuteScalar();//se obtiene la ultima pizza
            q = "USE [tarea] DECLARE	@return_value int EXEC	@return_value = [dbo].[Ultima_Orden] SELECT	'Return Value' = @return_value";
            cmd = new SqlCommand(q, MyGlobals.con);
            MyGlobals.orden = (int)cmd.ExecuteScalar();//se obetiene la ultima orden
            int valor_pizza = 0;
            switch (listBox1.SelectedIndex)
            {
                case 1:
                    valor_pizza = 3395;
                    break;
                case 2:
                    valor_pizza = 4795;
                    break;
                case 3:
                    valor_pizza = 5495;
                    break;
                case 4:
                    valor_pizza = 6795;
                    break;
                case 5:
                    valor_pizza = 10995;
                    break;
                default:
                    break;
            }
            

            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++) 
            {
                q = "exec [dbo].[Agregar_pizza] @Costo_Final = N'" + valor_pizza.ToString() + "', @saborizacion = N'" + listBox2.Text.ToString() + "'";
                cmd = new SqlCommand(q, MyGlobals.con);
                cmd.ExecuteNonQuery();//agrega la pizza
                //se agrega una pizza por cada una de las pizza
                string a = checkedListBox1.CheckedItems[0].ToString();
                for (int j = 0; j < checkedListBox1.CheckedItems.Count; j++)
                {

                    if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked) {
                        // Si esta activo, agregar el ingrediente e incrementar el precio de la pizza.
                    }
                }
            }
        }
    }
}
