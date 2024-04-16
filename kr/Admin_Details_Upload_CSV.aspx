<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Admin_Details_Upload_CSV.aspx.vb" Inherits="Admin_Details_Upload_CSV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>
                   Upload Win / Loss</h5>
            </div>
           
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="line"></div>
    <form id="form1" role="form" class="form" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="wrapper">
        <fieldset>
            <div class="widget">
                <asp:Label ID="lblErr_Msg" runat="server" Text="" ForeColor="Red"></asp:Label>
                <div class="title">
                    <h6>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label></h6>
                </div>
                 <div class="formRow" id="divMode" runat="server">
                    <label style="font-size: small">
                        Upload CSV:</label>
                    <div class="myRadio formRight">
                         <asp:FileUpload ID="FileUpload1"  CssClass="form-control required" runat="server"/>
                        <asp:RequiredFieldValidator ID="rfvFileUpload1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please select a csv file." ForeColor="Red"></asp:RequiredFieldValidator>

                        
                    </div>
                </div>
                
                <div class="formSubmit">
                    <asp:Button ID="btnSave" runat="server" Text="Save" class="button basic tipS" style="margin: 5px"/>
                </div>
            </div>
        </fieldset>
    </div>
    </form>
    
</asp:Content>

