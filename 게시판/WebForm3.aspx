<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="게시판.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
    <title>게시판 </title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <h2 class="text-center m-2">게시판</h2>
        <div>
            <label style="margin-left: 250px;">총 건수 :  </label>
            <asp:Label ID="총건수" runat="server"></asp:Label>                 
            <asp:DropDownList ID="건수" runat="server" CssClass="form-control col-lg-2 mb-4 " Style="width: 100px; margin-left: 1600px;" OnSelectedIndexChanged="Page_Load" AutoPostBack="true">
                <asp:ListItem Text="10건" />
                <asp:ListItem Text="20건" />
                <asp:ListItem Text="50건" />
                <asp:ListItem Text="100건" />
            </asp:DropDownList>
        </div>
        <div class="container d-flex justify-content-center">
            <asp:GridView ID="GridView" class="table" Style="border:2px solid gray;" runat="server" OnRowCommand="GridView_RowCommand" Width="1515px" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="연번" DataField="연번">
                        <HeaderStyle CssClass="table-primary text-center" />
                        <ItemStyle CssClass="hidden-xs d-none d-md-table-cell text-center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="제목" HeaderStyle-CssClass="table-primary text-center">
                        <ItemTemplate>
                            <asp:LinkButton ID="링크" runat="server" Text='<%# Eval("제목") %>' CommandName="링크"
                                CommandArgument='<%# Eval("연번") %>'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="text-center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="작성자" DataField="작성자">
                        <HeaderStyle CssClass="table-primary text-center" />
                        <ItemStyle CssClass="text-center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="작성일시" DataField="작성일시">
                        <HeaderStyle CssClass="table-primary text-center" />
                        <ItemStyle CssClass="text-center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="조회수" DataField="조회수">
                        <HeaderStyle CssClass="table-primary text-center" />
                        <ItemStyle CssClass="text-center" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="text-center" />
                <EmptyDataTemplate>게시글이 없습니다</EmptyDataTemplate>
            </asp:GridView>
        </div>
        <asp:HiddenField ID="검색어저장" runat="server" />
        <asp:HiddenField ID="시작페이지" runat="server" />
        <asp:HiddenField ID="종료페이지" runat="server" />
        <asp:HiddenField ID="현재페이지" runat="server" />
        <asp:HiddenField ID="이전" runat="server" />
        <asp:HiddenField ID="다음" runat="server" />

        <div class="container" style="margin-left: 800px">
            <ul class="pagination m-4 " >
                <li class="page-item" id="prevList"><a class="page-link" id="prevLink">이전</a></li>
                <li class="page-item"><a class="page-link" id="nextLink">다음</a></li>
            </ul>
          </div>
            <asp:TextBox class="form-control col-lg-2 mr-2 mb-3" Style="margin-left: 750px; float: left" ID="검색어" runat="server"> </asp:TextBox>
            <asp:Button class="btn btn-warning" ID="search" runat="server" Text="검색" OnClick="Search_Click" />
            <asp:Button class="btn btn-success" ID="write" runat="server" Text="신규" OnClick="Write_Click" />
      
    </form>
</body>
</html>
<script>

    var startPage = document.getElementById('시작페이지').value;
    var endPage = document.getElementById('종료페이지').value;
    var perPage = document.getElementById('현재페이지').value;
    var prev = document.getElementById('이전').value;
    var next = document.getElementById('다음').value;
    var searchWord = document.getElementById('검색어').value;

    console.log('현재페이지 : ' + perPage);
    console.log('시작페이지 : ' + startPage);
    console.log('종료페이지 : ' + endPage);
    console.log('이전 : ' + prev);
    console.log('다음 : ' + next);
    console.log('검색어 : ' + searchWord);

    var script, index, page;

    // 페이지 번호 생성
    for (var i = startPage; i <= endPage; i++) {
        if (i == startPage) {
            script = "<li class='page-item' id='listPage" + i + "'><a class='page-link' href='WebForm3.aspx?page=" + i + "&searchWord=" + searchWord + "' id= 'pageNum" + i + "'></a></li>";
            $('#prevList').after(script);
            $('#pageNum' + i).html(i);
        }
        else {
            script = "<li class='page-item' id='listPage" + i + "'><a class='page-link' href='WebForm3.aspx?page=" + i + "&searchWord=" + searchWord + "' id= 'pageNum" + i + "'></a></li>";
            index = parseInt(i) - 1;
            $('#listPage' + index).after(script);
            index = parseInt(i);
            $('#pageNum' + index).html(i);
        }
    }


    $('#pageNum' + perPage).parent().addClass('active');

    var prevPage = parseInt(startPage) - 1;
    var nextPage = parseInt(endPage) + 1;

    if (prev=='True') {
        $('#prevLink').attr('href', 'WebForm3.aspx?page=' + prevPage + '&searchWord=' + searchWord);
    }

    if (next =='True') {
        $('#nextLink').attr('href', 'WebForm3.aspx?page=' + nextPage + '&searchWord=' + searchWord);
    } 

</script>
