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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        //public string conString = "Data Source=DESKTOP-6CG1JKA\\ANDREI;Initial Catalog=tarea;Integrated Security=True";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            
            MyGlobals.con.Open();
//
            //string q = "exec @return_value = [dbo].[Agregar_usuario] @nombre = N'"+textBox1.ToString()+ "', @correo = N'"+textBox1.ToString()+"'";
            //string q = "exec [dbo].[Agregar_usuario] @nombre = N'" + textBox1.Text.ToString() + "', @correo = N'" + textBox2.Text.ToString() + "',@contrasena = N'"+ textBox2.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand("Agregar_usuario", MyGlobals.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@correo", textBox2.Text.ToString());
            MyGlobals.rdr = cmd.ExecuteReader();
            //cmd.ExecuteNonQuery();
            MyGlobals.con.Close();
                    }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
                MyGlobals.con.Close();
            }
}

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection con = new SqlConnection(MyGlobals.conString);
                MyGlobals.con.Open();

                //string q = "exec [dbo].[Login] @user = N'" + textBox1.Text.ToString() + "',@password = N'" + textBox2.Text.ToString() + "'";
                //SqlCommand cmd = new SqlCommand(q, MyGlobals.con);


                SqlCommand cmd = new SqlCommand("Login", MyGlobals.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", textBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@password", textBox2.Text.ToString());
                cmd.Parameters.AddWithValue("@output", SqlDbType.Int);
                MyGlobals.rdr = cmd.ExecuteReader();
                //MyGlobals.rdr.Close();
                //int returnValue = (int)MyGlobals.rdr.Parameters["@output"].Value;

                //int test1 = (int)MyGlobals.rdr[0];
                //string test = MyGlobals.rdr[0].ToString();
                //MyGlobals.rdr.GetFieldValue(0);

                int a = 0;
                a = cmd.ExecuteNonQuery(); //ejecuta un comando, pero no retorna nada
                a = (int)cmd.ExecuteScalar(); //ejecuta un comando y devuelve una fila
                MyGlobals.con.Close();
                if (a == 1)
                {
                    MyGlobals.Usuario = textBox1.Text.ToString();
                    MyGlobals.Contrasena = textBox2.Text.ToString();
                    //MessageBox.Show(MyGlobals.Usuario);
                    var menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("usuario o contraseña erronea");
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
        }
    }
}
