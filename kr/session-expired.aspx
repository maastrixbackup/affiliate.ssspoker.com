<%@ Page Language="VB" AutoEventWireup="false" CodeFile="session-expired.aspx.vb" Inherits="session_expired" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" type="image/x-icon" href="/favicon.ico" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class=" well row">
        <div class="container-fluid">
            <div><h2><b>세션이 종료 되었습니다</b></h2></div>
            <div><h4>세션이 종료 되었습니다. 다시 로그인 해 주시기 바랍니다.</h4></div>
            <div class="btn btn-info"><a class="btn" style="color:white" href="../default.aspx">로그인 하기</a></div>

        </div>
    </div>
    </form>
</body>
</html>
