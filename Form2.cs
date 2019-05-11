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
    public partial class Form2 : Form
    {
        string user_name;

        int counter;
        Form1 main_form;
        MyConnection mc;
        public Form2(Form1 form1, MyConnection mc, string n)
        {
            InitializeComponent();
            main_form = form1;
            this.mc = mc;
            user_name = n;
            this.ControlBox = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            counter = 1;
            label2.Text = counter.ToString();
            create_list_quest();
            next_q();
        }
        
        //следующий вопрос
        void next_q()
        {
            textBox1.Text = questions[counter - 1].quest;

            Random r = new Random();
            int ran = r.Next(1, 4);
            int[] mas = new int[3];
            //генерация вопросов
            for (int i = 0; i < 3; i++)
            {
                while (check_in(mas, ran) != false)
                {
                    ran = r.Next(1, 4);
                }
                mas[i] = ran;
            }
            
            //запись в Radio вариантов
            if (mas[0] == 1)
            {
                radioButton1.Text = questions[counter - 1].ans_1;
            }
            else
            {
                if (mas[0] == 2)
                {
                    radioButton1.Text = questions[counter - 1].ans_2;
                }
                else
                {
                    radioButton1.Text = questions[counter - 1].ans_3;
                }
            }

            if (mas[1] == 1)
            {
                radioButton2.Text = questions[counter - 1].ans_1;
            }
            else
            {
                if (mas[1] == 2)
                {
                    radioButton2.Text = questions[counter - 1].ans_2;
                }
                else
                {
                    radioButton2.Text = questions[counter - 1].ans_3;
                }
            }

            if (mas[2] == 1)
            {
                radioButton3.Text = questions[counter - 1].ans_1;
            }
            else
            {
                if (mas[2] == 2)
                {
                    radioButton3.Text = questions[counter - 1].ans_2;
                }
                else
                {
                    radioButton3.Text = questions[counter - 1].ans_3;
                }
            }

        }

        List<Question> questions;
        //проверка вхождение в массив
        bool check_in(int[] mas, int r)
        {
            foreach (int el in mas)
            {
                if (r == el)
                {
                    return true;
                }
            }
            return false;
        }

        //генерация рандомного порядка вопросов
        void create_list_quest()
        {
            Random r = new Random();
            int ran = 0;
            int[] order = new int[10];
            for (int i = 0; i < 10; i++)
            {
                ran = r.Next(1, 10);
                while (check_in(order, ran)!=false)
                {
                    ran = r.Next(1, 11);
                }
                order[i] = ran;   
            }
            questions =new List<Question>();
            foreach (int el in order)
            {
                 label2.Text = counter.ToString();
                string query = "SELECT question FROM Tests WHERE id_que = " + el + ";";
                OleDbCommand command = new OleDbCommand(query, mc.myConnection);
                string q= command.ExecuteScalar().ToString();
                query = "SELECT answer_f FROM Tests WHERE id_que = " + el + ";";
                command = new OleDbCommand(query, mc.myConnection);
                string a1 = command.ExecuteScalar().ToString();
                query = "SELECT answer_s FROM Tests WHERE id_que = " + el + ";";
                command = new OleDbCommand(query, mc.myConnection);
                string a2 = command.ExecuteScalar().ToString();
                query = "SELECT answer_t FROM Tests WHERE id_que = " + el + ";";
                command = new OleDbCommand(query, mc.myConnection);
                string a3 = command.ExecuteScalar().ToString();
                query = "SELECT answer_r FROM Tests WHERE id_que = " + el + ";";
                command = new OleDbCommand(query, mc.myConnection);
                string ar =command.ExecuteScalar().ToString();

                Question qu = new Question(q.Trim(), a1.Trim(), a2.Trim(), a3.Trim(), ar.Trim());
                questions.Add(qu);
            }
        }

        int res = 0;
        //проверка ответов
        void check_ans()
        {
            foreach (Question el in questions)
            {
                if (el.quest == textBox1.Text)
                {
                    if (radioButton1.Checked)
                    {
                        res+=el.check_ans(radioButton1.Text);
                    }

                    if (radioButton2.Checked)
                    {
                        res += el.check_ans(radioButton2.Text);
                    }

                    if (radioButton3.Checked)
                    {
                        res += el.check_ans(radioButton3.Text);
                    }
                }

            }
        }

        public int kol_q = 10;

        private void button3_Click(object sender, EventArgs e)
        {
            if (counter < kol_q)
            {
                check_ans();
                counter++;
                label2.Text = counter.ToString();
                next_q();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
            else
            {
                check_ans();

                Form4 f4 = new Form4(main_form, user_name, res,mc, kol_q);
                f4.Show();
                this.Close();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
