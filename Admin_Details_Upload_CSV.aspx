<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Admin_Details_Upload_CSV.aspx.vb" Inherits="Admin_Details_Upload_CSV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div><h3><asp:Label ID="lblTitle" runat="server"></asp:Label></h3></div>
    <div><asp:Label ID="lblErr_Msg" runat="server" ForeColor="Red" Text=""></asp:Label></div>
    <div class="row row-padding">
            <div class="col-md-1 col-md-offset-4">Upload CSV: </div>
            <div class="col-md-7"><asp:FileUpload ID="FileUpload1" runat="server"/></div>
            <div class="col-md-offset-5"><asp:RequiredFieldValidator ID="rfvFileUpload1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please select a csv file." ForeColor="Red"></asp:RequiredFieldValidator></div>
        </div>

        <div class="row row-padding">
            <div class="col-md-1 col-md-offset-5"><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info"/></div>
        </div>
</asp:Content>

