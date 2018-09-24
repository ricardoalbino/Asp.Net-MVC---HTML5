using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_AspMVC
{
    public class Conexao
    {
        public static SqlConnection Conectar()
        {
            string strString = @"Data Source=.\SQLExpress; Initial Catalog=Estudo; User ID=cadu; Password=cadu";

            SqlConnection sqlConnection = new SqlConnection(strString);
            sqlConnection.Open();

            return sqlConnection;

        }
    }
}