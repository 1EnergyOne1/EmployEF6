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
    public partial class Employ : Form
    {
        Db db;
        public Employ()
        {
            InitializeComponent();
            db = new Db();
            db.Employes.Load();
            dataGridView1.DataSource = db.Employes.Local.ToBindingList();
        }

        //Добавление
        private void button1_Click(object sender, EventArgs e)
        {
            AddEmploy AddForm = new AddEmploy();

            DialogResult result = AddForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;
            Employy empl = new Employy(); // Выделение памяти для модели базы сотрудников            
            empl.Name = AddForm.EmployName.Text;
            empl.Sorname = AddForm.EmploySorname.Text;                      
            
            db.Employes.Add(empl);
            db.SaveChanges();

            MessageBox.Show("Новый сотрудник добавлен");
        }

        //Редактирование
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Employy emp = db.Employes.Find(id);

                Employ emForm = new Employ();

                emForm.EmployName.Text = emp.Name;
                emForm.EmploySorname.Text = emp.Sorname;

                DialogResult result = emForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                emp.Name = emForm.EmployName.Text;
                emp.Sorname = emForm.EmploySorname.Text;

                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                dataGridView1.Refresh();
                MessageBox.Show("Данные сотрудника обновлены");
            }
        }

        //Удаление
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Employy player = db.Employes.Find(id);

                db.Employes.Remove(player);
                db.SaveChanges();

                MessageBox.Show("Сотрудник удален");
            }
            
        }      

        
    }
}
