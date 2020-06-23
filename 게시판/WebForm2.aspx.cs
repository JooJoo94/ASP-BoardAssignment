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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SelectOne();
        }
        
        // 게시물 클릭 시 조회수 증가
        protected void updateViews(string index)
        {
            Connection connection = new Connection();
            connection.DBConnection("UPDATE 게시판관리 SET 조회수=조회수+1 WHERE 연번=" + index);
        }

        protected void SelectOne()
        {
            String index = Request["index"];
            updateViews(index);

            Connection connection = new Connection();

            DataTable listTable = connection.DBConnection_Select("SELECT 연번, 작성자, EMAIL, 제목, 내용, convert(char(10), 작성일시, 23) AS 작성일시, 조회수 FROM 게시판관리 WHERE 연번 = " + index);

            if (listTable.Rows.Count>0)
            {
                DataRow dr = listTable.Rows[0];

                연번.Value  = dr["연번"].ToString();
                작성자.Text = dr["작성자"].ToString();
                EMAIL.Text = dr["EMAIL"].ToString();
                제목.Text = dr["제목"].ToString();
                내용.Text = dr["내용"].ToString();
            }

        }
        // 목록으로 이동
        protected void List_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm3.aspx");
        }
        // 데이터 수정
        protected void Update_Click(object sender, EventArgs e)
        {
            String index = this.연번.Value;
            Response.Redirect("WebForm1.aspx?index="+ index,false);
        }
       
        // 데이터 삭제
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (this.연번!=null)
            {
                int index = int.Parse(this.연번.Value);

                Connection connection = new Connection();
                int sqlResult = connection.DBConnection("DELETE FROM 게시판관리 WHERE 연번=" + index);

                string script = "<script> alert('삭제되었습니다'); </script>";
                string script2 = "<script> document.location.href='WebForm3.aspx'; </script>";
                this.RegisterStartupScript("script", script);
                this.RegisterStartupScript("script2", script2);
            }
            else
            {
                string script = "<script> alert('삭제할 게시물이 없습니다'); </script>";
                string script2 = "<script> document.location.href='WebForm3.aspx'; </script>";
                this.RegisterStartupScript("script", script);
                this.RegisterStartupScript("script2", script2);
            }
        }
    }
}