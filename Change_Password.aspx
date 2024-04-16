<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Change_Password.aspx.vb" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div><h3><asp:Label ID="lblTitle" runat="server"></asp:Label></h3></div>
    <div><asp:Label ID="lblErr_Msg" runat="server" ForeColor="Red" Text=""></asp:Label></div>
    <div class="row row-padding container-fluid"><div id="divDDLUser" runat="server">
        <div class="col-md-2 row-padding">User: </div>
        <div class="col-md-10 row-padding">
            <asp:DropDownList ID="ddlUser" runat="server" DataTextField="LoginID" DataValueField="RECID"></asp:DropDownList>
            
        </div></div>

        <div class="col-md-2 row-padding">New Password: </div>
        <div class="col-md-10 row-padding">
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
                
            <asp:Label ID="lblMsg_Password" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div class="col-md-offset-2"><asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtNewPassword" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$" ErrorMessage="Password must contain at least 1 alphabet and 1 number." ForeColor="Red"></asp:RegularExpressionValidator></div>

        <div class="col-md-2 row-padding">Confirm Password: </div>
        <div class="col-md-10 row-padding">
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password is required." ForeColor="Red"></asp:RequiredFieldValidator>--%>
            <asp:Label ID="lblMsg_ConfirmPassword" runat="server" ForeColor="Red"></asp:Label>
        </div>

        <div class="container-fluid">
            <div class="col-md-offset-5"><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info"/><%--&nbsp<a href="Admin_Listing.aspx" style="color:white" class="btn btn-info">Cancel</a>--%></div>
        </div>

    </div>
</asp:Content>

