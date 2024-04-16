<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Profile.aspx.vb" Inherits="Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>
                   Profile</h5>
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
                        <asp:Label ID="lblTitle" runat="server">Profile</asp:Label></h6>
                </div>
                 <div class="formRow" id="divMode" runat="server">
                    <label style="font-size: small">
                       로그인 ID:</label>
                    <div class="formRight">
                          <asp:TextBox ID="txtLoginID" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                
                <div class="formRow">
                    <label style="font-size: small">
                       이름:</label>
                    <div class="formRight">
                       <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="txtFullName" ErrorMessage="Full Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        이메일:</label>
                    <div class="formRight">
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        휴대폰:</label>
                    <div class="formRight">
                         <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Contact Number is required." ForeColor="Red"></asp:RequiredFieldValidator> 
                    </div>
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        정산받을 은행:</label>
                    <div class="formRight">
                       <asp:DropDownList ID="ddlBank" runat="server" DataTextField="BankName" DataValueField="BankDetails"></asp:DropDownList>
                       <asp:RequiredFieldValidator ID="rfvBank" runat="server" ControlToValidate="ddlBank" ErrorMessage="Bank Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div> 
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        예금주:</label>
                    <div class="formRight">
                        <asp:TextBox ID="txtBankAccountHolderName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBankAccountHolderName" runat="server" ControlToValidate="txtBankAccountHolderName" ErrorMessage="Bank Account Holder Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div> 
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        계좌번호:</label>
                    <div class="formRight">
                        <asp:TextBox ID="txtBankAccountNo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBankAccountNo" runat="server" ControlToValidate="txtBankAccountNo" ErrorMessage="Bank Account No is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblMsg_BankAccountNo" runat="server"></asp:Label>
                    </div> 
                </div>
                <div class="formSubmit">
                    <asp:Button ID="btnSave" runat="server" Text="저장하기" class="button basic tipS" style="margin: 5px"/></div>
                    
                    
                </div>
                
          
        </fieldset>
    </div>
    </form>
    

</asp:Content>

