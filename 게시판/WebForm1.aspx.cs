using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 게시판
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String index = Request["index"];
                if (index != null)
                {

                    SelectOne(index);
                }
                else
                {
                    return;
                }
            }

        }
        protected void List_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm3.aspx");
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            this.작성자.Text = "";
            this.EMAIL.Text = "";
            this.제목.Text = "";
            this.내용.Text = "";
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            this.savei();
        }

        protected void SelectOne(String index)
        {

            Connection connection = new Connection();
            DataTable listTable = connection.DBConnection_Select("SELECT * FROM 게시판관리 WHERE 연번 = " + index);

            if (listTable.Rows.Count > 0)
            {
                DataRow dr = listTable.Rows[0];

                연번.Value = dr["연번"].ToString();
                작성자.Text = dr["작성자"].ToString();
                EMAIL.Text = dr["EMAIL"].ToString();
                제목.Text = dr["제목"].ToString();
                내용.Text = dr["내용"].ToString();
            }

            //종료
            //connection.objDr.Close();
            //connection.objCon.Close();
        }
        private void savei()
        {
            string index = this.연번.Value;
            string username = this.작성자.Text;
            string email = this.EMAIL.Text;
            string title = this.제목.Text;
            string content = this.내용.Text;
            string date = DateTime.Now.ToString("yyyy-MM-dd");


            if (this.연번.Value != "")
            {
                Connection connection = new Connection();
                int sqlResult = connection.DBConnection("UPDATE 게시판관리 SET 작성자 = '" + username + "', EMAIL = '" + email + "', 제목 = '" + title + "', 내용 = '" + content + "' WHERE 연번 =" + index);

                if (sqlResult == 1)
                {
                    string script = "<script> alert('수정되었습니다'); </script>";
                    string script2 = "<script> document.location.href='WebForm3.aspx'; </script>";
                    this.RegisterStartupScript("script", script);
                    this.RegisterStartupScript("script2", script2);

                }
                else
                {
                    string script = "<script> alert('수정 실패하였습니다'); </script>";
                    string script2 = "<script> document.location.href='WebForm3.aspx'; </script>";
                    this.RegisterStartupScript("script", script);
                    this.RegisterStartupScript("script2", script2);
                }
            }
            else
            {
                Connection connection = new Connection();
                int sqlResult = connection.DBConnection("INSERT INTO 게시판관리(작성자, EMAIL, 제목, 내용, 작성일시, 조회수) VALUES('" + username + "', '" + email + "', '" + title + "', '" + content + "', '" + date + "', " + 0 + ");");
                //connection.objCon.Close();

                string script = "<script> alert('저장되었습니다'); </script>";
                string script2 = "<script> document.location.href='WebForm3.aspx'; </script>";
                this.RegisterStartupScript("script", script);
                this.RegisterStartupScript("script2", script2);
            }
        }
    }
}