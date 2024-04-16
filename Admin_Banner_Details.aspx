<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Admin_Banner_Details.aspx.vb" Inherits="Admin_Banner_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div><h3><asp:Label ID="lblTitle" runat="server"></asp:Label></h3></div>
    <div><asp:Label ID="lblErr_Msg" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    <div class="row row-padding container-fluid">
            
        <div class="col-md-2 row-padding">Banner Name(Optional) :</div>
        <div class="col-md-10 row-padding">
            <asp:TextBox ID="txtBannerName" runat="server" ></asp:TextBox>
            <%--<asp:Label ID="lblMsg_BannerName" runat="server" ForeColor="Red"></asp:Label>--%>
        </div>
        
        <div class="col-md-2 row-padding">Category :</div>
        <div class="col-md-10 row-padding">
            <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="CategoryName" DataValueField="RECID"></asp:DropDownList>
        </div>
           
        <div class="col-md-2 row-padding">Upload Banner :<br />(.jpg/ .png/ .gif) Only</div>
        <div class="col-md-10 row-padding">
            <asp:FileUpload ID="ruImage" runat="server" />
            <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="Images/icon-cross.png" Height="20" Width="20" visible="false"/>
            <asp:Label ID="lblBannerImage" runat="server" Text="no image."></asp:Label>
        </div>

        <div class="col-md-2 row-padding">Height :</div>
        <div class="col-md-2 row-padding">
            <asp:TextBox ID="txtBanner_Height" runat="server"></asp:TextBox> pixel
        </div>
        <div class="col-md-1 row-padding">Width :</div>
        <div class="col-md-7 row-padding">
            <asp:TextBox ID="txtBanner_Width" runat="server"></asp:TextBox> pixel
        </div>

        <div class="col-md-2 row-padding">Status :</div>
        <div class="col-md-10 row-padding">
            <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="A" Selected="True">Active</asp:ListItem>
                <asp:ListItem Value="I">Inactive</asp:ListItem>
            </asp:RadioButtonList>
        </div>

    </div>

    <div class="container-fluid">
        <div class="col-md-offset-5"><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info"/>&nbsp<a href="Admin_Banner_Listing.aspx" style="color:white" class="btn btn-info">Cancel</a></div>
    </div>

</asp:Content>

