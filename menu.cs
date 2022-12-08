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
    public partial class menu : Form
    {
        public menu(int result)
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void fIATToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void автоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            auto Win = new auto();
            Win.Show();
        }

        private void моделиАвтоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model Win = new model();
            Win.Show();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            staff Win = new staff();
            Win.Show();
        }

        private void артиклиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            article Win = new article();
            Win.Show();
        }

        private void характеристикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            har Win = new har();
            Win.Show();
        }

        private void артикльToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detail Win = new detail();
            Win.Show();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            order Win = new order();
            Win.Show();
        }

        private void menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
