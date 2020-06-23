using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 게시판
{
    public class Connection
    {
        private SqlConnection objCon;
        private SqlCommand objCmd;
        private SqlDataReader objDr;

        // Insert, Update, Delete  DB 연결

        private void Connection_Open()
        {
            objCon = new SqlConnection();
            objCon.ConnectionString = "Data Source=211.179.185.248,14336;Initial Catalog=STUDY_IDINO;Persist Security Info=True;User ID=study;Password=dkdlelsh@12";
            objCon.Open();
        }
        public int DBConnection(string strSql)
        {
            Connection_Open();
           
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandText = strSql;
            objCmd.CommandType = CommandType.Text;

            int sqlResult = objCmd.ExecuteNonQuery();
            objCon.Close();

            return sqlResult;
            //return objCmd.ExecuteNonQuery();
        }

        // Select DB연결
        public DataTable DBConnection_Select(string strSql)
        {
            //커넥션 객체
            Connection_Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandText = strSql;
            objCmd.CommandType = CommandType.Text;
            objDr = objCmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(objDr);
            objDr.Close();
            objCon.Close();
            return dt;
        }
        
        // Count하는 Select문 DB연결
        public string DBConnection_Select_Count(string strSql)
        {
            Connection_Open();
            //커맨드 객체
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandText = strSql;
            objCmd.CommandType = CommandType.Text;

            string result = Convert.ToString((int)objCmd.ExecuteScalar());
            objCon.Close();
            return result;
        }
    }
}