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

namespace wplПосуда
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConString);
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int role_id;
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "avtoreg";
            cmd.Parameters.AddWithValue("@login", tb_log.Text);
            cmd.Parameters.AddWithValue("@password", tb_pass.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                role_id = Convert.ToInt32(reader.GetInt32(0));
                Properties.Settings.Default.RoleId = role_id;
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
                tb_log.Text = "";
                tb_pass.Text = "";
            }
            conn.Close();
                switch (role_id)
                {

                    case 1:
                        Main frm_main = new Main();
                        frm_main.Show();
                        this.Hide();

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                }
            

        }
    }
}
