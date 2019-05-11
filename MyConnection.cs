using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest
{
    public class MyConnection
    {

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyDataBaze.mdb;";
        public OleDbConnection myConnection { get; set; }

        public MyConnection()
        { 
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

    }
}
