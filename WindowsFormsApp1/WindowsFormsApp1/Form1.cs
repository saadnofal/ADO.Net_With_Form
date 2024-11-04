using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
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
       /* public void AddPerson()
        {
            Person person = new Person();
            person.Name = textBox1.Text;
            person.Email= textBox2.Text;

        }*/

        public void button1_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            person.Name = textBox1.Text;
            person.Email = textBox2.Text;
            AdoContext context = new AdoContext();
            context.CreateUser(person.Name,person.Email);
            List_Persons list_Persons = new List_Persons();
            list_Persons.Show();
            this.Hide();
        }
    }
}
