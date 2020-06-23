<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="게시판.WebForm1" %>

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
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2>게시판 작성</h2>
            <br />
            <asp:HiddenField ID="연번" runat="server" />
            <div class="form-group">
                <label>작성자 :</label>
                <asp:TextBox class="form-control col-lg-3" ID="작성자" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>EMAIL :</label>
                <asp:TextBox class="form-control col-lg-3" ID="EMAIL" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>제목:</label>
                <asp:TextBox class="form-control" ID="제목" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>내용 :</label>
                <asp:TextBox class="form-control" ID="내용" runat="server" TextMode="multiline" Rows="5"></asp:TextBox>
            </div>
            <div class="d-flex justify-content-end">
                <asp:Button class="btn btn-warning mr-1" ID="list" runat="server" Text="목록" OnClick="List_Click" />
                <asp:Button class="btn btn-danger mr-1" ID="reset" runat="server" Text="초기화" OnClick="Reset_Click" />
                <asp:Button class="btn btn-success" ID="save" runat="server" Text="저장" OnClick="Save_Click" OnClientClick="return validationCheck();" />
            </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function emailCheck(email) {
        var regex = /([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        return (email != '' && email != 'undefined' && regex.test(email));
    }

    function validationCheck() {

        var username = document.getElementById('작성자').value;
        var email = document.getElementById('EMAIL').value;
        var title = document.getElementById("제목").value;
        var content = document.getElementById('내용').value;

        if (!username) {
            alert("작성자를 입력하세요");
            return false;
        } else if (!title) {
            alert("제목을 입력하세요");
            return false;
        } else if (!content) {
            alert("내용을 입력하세요");
            return false;
        } else if (!email) {
            return true;
        } else if (email) {
            if (!emailCheck(email)) {
                alert("이메일 형식이 맞지 않습니다");
                return false;
            } else {
                return true;
            }
        } else {
            return true;
        }
    }  
</script>
