using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_.NET
{
    class Database
    {
        SqlConnection sqlConn;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cb;
        public Database() {
            string strCnn = "Data Source=PHAMVANTOAN; database=quanlyhanghoa; User Id = sa; Password=231003; ";
            sqlConn = new SqlConnection(strCnn);
        }

        public DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
            cb = new SqlCommandBuilder(da);
            return ds.Tables[0];
        }

        public void ExecuteNonQuery(string sqlStr)
        {
            SqlCommand sqlcmd = new SqlCommand(sqlStr, sqlConn);
            sqlConn.Open();
            sqlcmd.ExecuteNonQuery();
            sqlConn.Close();
        }


        public void update(DataTable dt)
        {
            da.Update(dt);
        }
    }
}
