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
    public partial class Form2 : Form
    {
       // string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Ananna Rashid\source\repos\Buying_House_Log_In_Form\Buying_House_Log_In_Form\UserDB.mdf;Integrated Security = True; Connect Timeout = 30");

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            f1.Tag = this;
            Hide();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO DataStore VALUES ('" + textBoxName.Text.Trim() + "',  '" + textBoxEmail.Text.Trim() + "', '" + textBoxPass.Text.Trim() + "' , '" + textBoxPhoneNumber.Text.Trim() + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxName.Text = "";
            textBoxEmail.Text = "";
            textBoxPass.Text = "";
            textBoxPhoneNumber.Text = "";
            disp_data();
            MessageBox.Show("Insertion successful!");
        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from DataStore";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
