<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="게시판.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
    <title></title>
</head>
<body>
    <form id="selectForm" runat="server">
        <div class="container" style="margin-top:100px">
            <h2>게시물 조회</h2>
            <br />
            <asp:HiddenField ID="연번" runat="server" />
            <div class="form-group">
                <label>작성자:</label>
                <asp:Label ID="작성자" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <label>EMAIL :</label>
                <asp:Label ID="EMAIL" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <label>제목:</label>
               <asp:Label ID="제목" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <label>내용 :</label>
                <asp:Label ID="내용" runat="server"></asp:Label>
            </div>
            <div class="d-flex justify-content-end">
                <asp:Button class="btn btn-warning mr-1" ID="list" runat="server" Text="목록" OnClick="List_Click" />
                <asp:Button class="btn btn-danger mr-1" ID="update" runat="server" Text="수정" OnClick="Update_Click"/>
                <asp:Button class="btn btn-success" ID="save" runat="server" Text="삭제" OnClick="Delete_Click" OnClientClick="return confirm('삭제하시겠습니까?');" />
            </div>
    </form>
</body>
</html>
