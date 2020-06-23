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
    public partial class WebForm3 : System.Web.UI.Page
    {
          PageMaker pageMaker;
          Criteria cri;

        string startPage, endPage, page, pageStart, pageEnd, prev, next, perPageNum, searchNum;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["searchWord"] != "")
            {
                pageSet();
                cri.keyword = Request["searchWord"];
                Search_Word();
            } else
            {

                List();
            }


        }

        // 전체 데이터 개수
        protected string List_TotalNum()
        {
            Connection connection = new Connection();

            string result = connection.DBConnection_Select_Count("SELECT COUNT(*) AS 총건수 FROM 게시판관리;");
            총건수.Text = result;

            return result;
        }

        // 검색한 데이터 개수
        protected string Search_TotalNum(string searchWord)
        {
            Connection connection = new Connection();

            string result = connection.DBConnection_Select_Count("SELECT COUNT(*) FROM 게시판관리 WHERE 제목 LIKE '%" + searchWord + "%'");
            총건수.Text = result;

            return result;
        }

        // 전체 데이터 출력
        protected void List()
        {
            pageSet();
            string strSql = "SELECT 연번, 작성자, EMAIL, 제목, 내용, convert(char(10), 작성일시, 23) AS 작성일시, 조회수 FROM (SELECT ROW_NUMBER() OVER(ORDER BY 연번 DESC) AS row_num, * FROM 게시판관리 tmp) AS list_number WHERE row_num > " + pageStart + " AND row_num<=" + pageEnd;
           
            List2(strSql);
        }
        protected void Search_Word()
        {
            string searchWord = cri.keyword;
            if(!IsPostBack)
            {
                검색어.Text = searchWord;
            }
            
            string strSql = "SELECT 연번, 작성자, EMAIL, 제목, 내용, convert(char(10), 작성일시, 23) AS 작성일시, 조회수 FROM (SELECT ROW_NUMBER() OVER(ORDER BY 연번 DESC) AS row_num, * FROM 게시판관리 tmp) AS list_number WHERE row_num > " + pageStart + " AND row_num<=" + pageEnd + "AND 제목 LIKE '%" + searchWord + "%'";
            List2(strSql);
            
        }
        protected void pageSet()
        {
            pageMaker = new PageMaker();
            cri = new Criteria();

            // 페이지 당 표시할 게시글 수 
            searchNum = 건수.Text.Substring(0, 건수.Text.Length - 1);
            cri.setPerPageNum(Convert.ToInt32(searchNum));

            // 페이지 번호 
            if (Request["page"] != "")
            {
                cri.setPage(Convert.ToInt32(Request["page"]));
            }
            

            // 페이징 
            pageMaker.setCri(cri);
            pageMaker.setTotalCount(Convert.ToInt32(List_TotalNum()));

            pageStart = Convert.ToString(cri.getPageStart());
            perPageNum = Convert.ToString(cri.getPerPageNum());
            pageEnd = Convert.ToString(cri.getPageEnd());

            prev = Convert.ToString(pageMaker.isPrev());
            next = Convert.ToString(pageMaker.isNext());
            startPage = Convert.ToString(pageMaker.getStartPage());
            endPage = Convert.ToString(pageMaker.getEndPage());

        }

        protected void List2(string strSql)
        {
           
            Connection connection = new Connection();
            DataTable listTable = connection.DBConnection_Select(strSql);

            GridView.DataSource = listTable;
            GridView.DataBind();

            시작페이지.Value = startPage;
            종료페이지.Value = endPage;
            현재페이지.Value = Convert.ToString(cri.getPage());
            이전.Value = prev;
            다음.Value = next;
        }

            // 검색한 데이터 출력
            protected void Search_Click(object sender, EventArgs e)
        {
            pageSet();
            cri.keyword = 검색어.Text;         
            Search_Word();

        }
        protected void Write_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = ((Control)e.CommandSource).NamingContainer as GridViewRow;
            if (e.CommandName == "링크")
            {
                Response.Redirect("WebForm2.aspx?index=" + e.CommandArgument.ToString());

            }

        }
    }
}