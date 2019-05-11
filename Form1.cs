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
    public partial class Form1 : Form
    {
        MyConnection mc;
        public Form1()
        {
            InitializeComponent();
            mc = new MyConnection();
            //open connection in databaze
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(this, mc);
            form5.load();
            form5.Show();

            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(this,mc,10);
            f3.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(this, mc, 5);
            f3.Show();

            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list_liders();
        }
        OleDbDataReader r = null;
        public void list_liders()
        {
            string query = "SELECT user_name, score FROM Results ORDER BY score desc;";
            OleDbCommand command = new OleDbCommand(query, mc.myConnection);
            r = command.ExecuteReader();
            int sh = 0;
            string[,] mas = new string[2,3];
            while (r.Read() && sh!=3)
            {
                mas[0,sh]= r["user_name"].ToString();
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
                    for (int j = 0; j < l ; j++)
                    {
                        mas[0, i] += " ";
                    }
                }
            }
            textBox1.Clear();
            for (int i = 1; i < sh+1; i++)
            {
                string line = i + " место " + mas[0, i - 1] + " рез. " + mas[1, i - 1] + Environment.NewLine;
                textBox1.Text += line;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mc.myConnection.Close();
        }
    }
}
