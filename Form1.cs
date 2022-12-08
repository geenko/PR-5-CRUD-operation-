using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace autoparts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string query = "SELECT id_staff FROM staff WHERE login ='" + textBox1.Text + "' and password = '" + textBox2.Text + "';";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                conn.Open();
                int result = 0;
                result = Convert.ToInt32(cmDB.ExecuteScalar());
                if (result > 1)
                {
                    menu Win = new menu(result);
                    Win.Owner = this;
                    this.Hide();
                    Win.Show();
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                    MessageBox.Show("Возникла ошибка авторизации!");
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }
    }
}
