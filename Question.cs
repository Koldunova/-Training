using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest
{
    public class Question
    {
        public string quest { get; set; }
        public string ans_1 { get; set; }
        public string ans_2 { get; set; }
        public string ans_3 { get; set; }
        public string ans_rigth { get; set; }

        public Question (string q, string a1, string a2, string a3, string ar)
        {
            quest = q;
            ans_1 = a1;
            ans_2 = a2;
            ans_3 = a3;
            ans_rigth = create_rigth_ans(ar);
        }

        public int check_ans(string ans)
        {
            if (ans == ans_rigth)
            {
                return 1;
            }
            return 0;
        }

        string create_rigth_ans(string ar)
        {
            if (ar == "1")
            {
                return ans_1;
            }
            if (ar == "2")
            {
                return ans_2;
            }
            else
            {
                return ans_3;
            }
        }
    }
}
