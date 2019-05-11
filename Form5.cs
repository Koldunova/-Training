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
    public partial class Form5 : Form
    {
        Form1 main_form;
        MyConnection mc;
        public Form5(Form1 f, MyConnection m)
        {
            InitializeComponent();
            main_form = f;
            mc = m;
        }

        public void load()
        {
            OleDbDataReader r = null;
            string query = "SELECT COUNT(user_name) FROM Results ;";
            OleDbCommand command = new OleDbCommand(query, mc.myConnection);
            int sh1 =(int)command.ExecuteScalar();
            string[,] mas = new string[2, sh1];
            query = "SELECT user_name, score FROM Results ;";
            command = new OleDbCommand(query, mc.myConnection);
            r = command.ExecuteReader();
            int sh = 0;
            while (r.Read())
            {
                mas[0, sh] = r["user_name"].ToString();
                mas[1, sh] = r["score"].ToString();
                sh++;
            }

            int max_length = mas[0, 0].Length;
            for (int i = 0; i < sh; i++)
            {
                if (max_length < mas[0, i].Length)
                {
                    max_length = mas[0, i].Length;
                }
            }

            for (int i = 0; i < sh; i++)
            {
                if (max_length > mas[0, i].Length)
                {
                    int l = max_length - mas[0, i].Length;
                    for (int j = 0; j < l; j++)
                    {
                        mas[0, i] += " ";
                    }
                }
            }
            textBox1.Clear();
            for (int i = 1; i < sh + 1; i++)
            {
                string line = mas[0, i - 1] + " результат " + mas[1, i - 1] + Environment.NewLine;
                textBox1.Text += line;
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            main_form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main_form.Show();
            this.Close();
        }
    }
}
