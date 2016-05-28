using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Test.DataAccess
{
    public class MyConnection
    {
        public MyConnection()
        {

        }

        public void OpenConnection(SqlConnection connection)
        {
            connection.Open();
        }
    }
}
