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
    public partial class Form1 : Form
    {
        Db db;
        public Form1()
        {
            InitializeComponent();
            db = new Db();
            db.Admins.Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employ empForm = new Employ();
            DialogResult result = empForm.ShowDialog(this); //переход к форме учета сотрудников
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Regestration regForm = new Regestration();
            DialogResult result = regForm.ShowDialog(this);//    Открытие формы регистрации администраторов
            if (result == DialogResult.Cancel)
              return;
            
            Adminn admin = new Adminn();

            admin.Name = regForm.textBox1.Text;
            admin.Pass = regForm.textBox2.Text;

            db.Admins.Add(admin);
            db.SaveChanges();
            MessageBox.Show("Админ добавлен");
            

        }

       
    }
}
