using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class List_Persons : Form
    {
        public List_Persons()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void List_Persons_Load(object sender, EventArgs e)
        {
            AdoContext context = new AdoContext();
            context.ReadUsers(dataGridView1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdoContext adoContext = new AdoContext();
            adoContext.DeleteAll();
            adoContext.ReadUsers(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdoContext adoContext = new AdoContext();
            Person person = new Person();
            person.Id = textBox1.Text;
            adoContext.DeleteUser(person.Id);
            adoContext.ReadUsers(dataGridView1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdoContext ado = new AdoContext();
            Person person = new Person();
            person.Id = textBox2.Text;
            person.Name= textBox3.Text;
            person.Email = textBox4.Text;
            ado.UpdateUser(person.Id , person.Name , person.Email);
            ado.ReadUsers(dataGridView1);
           

            
        }
    }
}
