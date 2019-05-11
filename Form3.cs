using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTest
{
    public partial class Form3 : Form
    {
        Form1 f1;
        MyConnection mc;
        int kol;
        public Form3(Form1 form1,MyConnection m,int k)
        {
            InitializeComponent();
            f1 = form1;
            kol = k;
            mc = m;
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox1.Text.Length < 20)
            {
                Form2 f = new Form2(f1, mc,textBox1.Text);
                f.kol_q = kol;
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show( "Заполните корректно имя. (максимум 20 символов)", "Внимание", MessageBoxButtons.OK);
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
