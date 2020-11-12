using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployEF6
{
    public partial class Regestration : Form
    {
        Db db;
        public Regestration()
        {
            InitializeComponent();
            db = new Db();
            db.Admins.Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regestration reg = new Regestration();
            Adminn admin = new Adminn();

            admin.Name = reg.textBox1.Text;
            admin.Pass = reg.textBox2.Text;

            db.Admins.Add(admin);
            db.SaveChanges();
            MessageBox.Show("Админ добавлен");
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
