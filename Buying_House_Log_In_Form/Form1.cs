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

namespace Buying_House_Log_In_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            f2.Tag = this;
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Ananna Rashid\source\repos\Buying_House_Log_In_Form\Buying_House_Log_In_Form\UserDB.mdf; Integrated Security = True; Connect Timeout = 30");
            string query = "select * from DataStore where USEREMAIL = '" + textBoxEmail.Text.Trim() + "' and PASS = '" + textBoxPass.Text.Trim() + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dtbl = new DataTable();

            sda.Fill(dtbl);

            if (dtbl.Rows.Count == 1)
            {
                Form3 a = new Form3();
                this.Hide();
                a.Show();
            }

            else
            {
                MessageBox.Show("Invalid username or password!");

            }

        }
    }
}
