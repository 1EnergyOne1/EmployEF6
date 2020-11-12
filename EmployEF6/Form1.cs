using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployEF6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adName = "";
            
            using (Db db = new Db())
            {
                if (db.Admins.Any(x => x.Name == adName))

                {
                    // Инициализируем модель с данными администратора
                    Adminn adm = new Adminn();
                    // Инициализируем модель с данными сотрудников
                    Employy emp = new Employy();


                }

                
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Regestration regForm = new Regestration();
            regForm.Show();
        }

       
    }
}
