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
    public partial class model : Form
    {
        public model()
        {
            InitializeComponent();
            getInfo();
        }
        private void getInfo()
        {
            string query = ("SELECT id_model as'№', name as'Название', year as'Год издания', country as'Страна',id_auto as '№ авто' from model;");
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter ada = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void model_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox2.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox3.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox4.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить данные?", "БЕЗВОЗВРАТНОЕ УДАЛЕНИЕ!!!", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string del = "delete from model where id_model = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(del, conn);
                try
                {
                    conn.Open();
                    cmDB.ExecuteReader();
                    conn.Close();
                    MessageBox.Show("Данные удалены!");
                    getInfo();
                }
                catch (Exception)
                {
                    MessageBox.Show("Возникла непредвиденная ошибка.");
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string add = ("insert into model(name, year, country, id_auto) values('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "');");
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(add, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
                MessageBox.Show("Данные внесены!");
                getInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string update = "update model set name = '" + textBox1.Text + "', year = '" + textBox2.Text + "',country = '" + textBox3.Text + "',id_auto = '" + textBox4.Text + "' where id_model = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(update, conn);
            try
            {
                conn.Open();
                cmDB.ExecuteReader();
                conn.Close();
                MessageBox.Show("Данные обновлены!");
                getInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла непредвиденная ошибка.");
            }
        }

    

        private void model_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
