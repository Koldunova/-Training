using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTest
{
    public partial class Form4 : Form
    {
        Form1 main_form;
        string user_name;
        int r;
        MyConnection mc;
        int kol_q;

        public Form4(Form1 f, string name, int res,MyConnection mc,int kol)
        {
            InitializeComponent();
            user_name = name;
            this.ControlBox = false;
            main_form = f;
            r = res;
            this.mc = mc;
            kol_q = kol;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text += "Дорогой, " + user_name + "! " + Environment.NewLine + "Вы прошли тест с результатом " + r + ".";
            if (kol_q == 5)
            {
                r *= 2;
            }
            if (r < 5)
            {
                textBox1.Text += "Попробуйте повторить тему и еще раз пройти тест! Вы сможете";
            }
            else
            {
                if (r < 8)
                {
                    textBox1.Text += "Вы молодцы, но есть еще к чему стремится";
                }
                else
                {
                    textBox1.Text += "Я не знаю, что даже сказать! Совершенство!!!";
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Results (user_name,score) VALUES ( '" + user_name + "'," + r + ")";

            OleDbCommand command = new OleDbCommand(query, mc.myConnection);
            command.ExecuteNonQuery();
            main_form.list_liders();
            main_form.Show();
            this.Close();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
