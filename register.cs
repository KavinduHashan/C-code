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

namespace ex1
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\code\C# (visual studio)\curd operations\ex1db.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string n = regusertxt.Text;
                string p = regpasstxt.Text;

                String insertquery = "INSERT INTO log (userName, password) VALUES ('" +n + "','" + p + "')";
                SqlCommand cmd = new SqlCommand(insertquery, conn);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registration successfully..!");

                login l = new login();
                this.Hide();
                l.Show();
            }
            catch (SqlException es)
            {
                MessageBox.Show("Error..!" + es);
            }
            finally
            {
                conn.Close();                  
            }
        }

        private void register_Load(object sender, EventArgs e)
        {

        }
    }
}
