<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Player_Details.aspx.vb" Inherits="Player_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>
                   Player</h5>
            </div>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="line"></div>
    <form id="form1" role="form" class="form" runat="server">
   
    <div class="wrapper">
        <fieldset>
            <div class="widget">
                <asp:Label ID="lblErr_Msg" runat="server" Text="" ForeColor="Red"></asp:Label>
                <div class="title">
                    <h6>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label></h6>
                </div>
                 <div class="formRow"  >
                    <label style="font-size: small">
                       아이디:</label>
                    <div class="formRight">
                          <asp:TextBox ID="txtLoginID" runat="server" CssClass="form-control required" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLoginID" runat="server" ControlToValidate="txtLoginID" ErrorMessage="Login ID is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblMsg_LoginID" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                       별명:</label>
                    <div class="formRight">
                          <asp:TextBox ID="txtNickname" runat="server" CssClass="form-control required" MaxLength="25"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNickname" runat="server" ControlToValidate="txtNickname" ErrorMessage="Nickname is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblMsg_Nickname" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                      가입날짜: </label>
                    <div class="formRight">
                         <asp:Label runat="server" ID="lblRegDate"></asp:Label>
                    </div>
                </div>
                 <% If Session("UserType") = "0" Then%>
                <div class="formRow"  runat="server" id="divPassword">
                    <label style="font-size: small">
                      비밀번호: </label>
                    <div class="formRight">
                          <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control required" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z@\d]{6,}$" ErrorMessage="Password must be alphanumeric and no symbol allowed." ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:Label ID="lblMsg_Password" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="formRow"  runat="server" id="divConfirmPassword">
                    <label style="font-size: small">
                      비밀번호 확인: </label>
                    <div class="formRight">
                           <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control required" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:CompareValidator runat="server" ID="cvPassword" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password NOT match." ForeColor="Red"></asp:CompareValidator>
                            <asp:Label ID="lblMsg_ConfirmPassword" runat="server" ForeColor="Red"></asp:Label>t="server" ControlToValidate="txtPassword" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z@\d]{6,}$" ErrorMessage="Password must be alphanumeric and no symbol allowed." ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                      전화: </label>
                    <div class="formRight">
                           <asp:TextBox runat="server" CssClass="form-control required" ID="txtContactNo"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Contact No. is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                      이메일: </label>
                    <div class="formRight">
                          <asp:TextBox runat="server" CssClass="form-control required" ID="txtEmail"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Address is required." ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email Address." ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                      은행 설정:</label>
                    <div class="formRight">
                          <asp:DropDownList ID="ddlBank" runat="server" DataTextField="BankName" DataValueField="BankDetails"></asp:DropDownList>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                      은행 설정예금주:</label>
                    <div class="formRight">
                          <asp:TextBox ID="txtBankAccountHolderName" CssClass="form-control required" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBankAccountHolderName" runat="server" ControlToValidate="txtBankAccountHolderName" ErrorMessage="Bank Account Holder Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                      계좌 번호:</label>
                    <div class="formRight">
                          <asp:TextBox ID="txtBankAccountNo" CssClass="form-control required" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBankAccountNo" runat="server" ControlToValidate="txtBankAccountNo" ErrorMessage="Bank Account No is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblMsg_BankAccountNo" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                      Bank Branch:</label>
                    <div class="formRight">
                          <asp:TextBox ID="txtBankBranch" CssClass="form-control required" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBankBranch" runat="server" ControlToValidate="txtBankBranch" ErrorMessage="Bank Branch is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                      Bank Province: </label>
                    <div class="formRight">
                          <asp:TextBox ID="txtBankProvince" CssClass="form-control required" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvBankProvince" runat="server" ControlToValidate="txtBankProvince" ErrorMessage="Bank Province is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                      Bank City: </label>
                    <div class="formRight">
                          <asp:TextBox ID="txtBankCity" CssClass="form-control required" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvBankCity" runat="server" ControlToValidate="txtBankCity" ErrorMessage="Bank City No is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                      Affiliate Code: </label>
                    <div class="formRight">
                          <asp:DropDownList runat="server" ID="ddlAffCode" DataTextField="LoginID" DataValueField="RECID"></asp:DropDownList>
                    </div>
                </div>
                
                
                <% End If%>
               
               
                
                 
                
                
                
                
                
                

                
                
               
                <div class="formSubmit">
                    <asp:Button ID="btnSave" runat="server" Text="저장하기" class="button basic tipS" style="margin: 5px"/><asp:Button ID="btnUpdate" runat="server" Text="Update" class="button basic tipS" style="margin: 5px"/>&nbsp<a id="aCancel" runat="server" href="Player_Listing.aspx" class="button basic tipS" style="margin: 5px;padding: 8px 18px 8px 18px;">뒤로가기</a>
                   
                    
                    
                </div>
                </div>
          
        </fieldset>
    </div>
    </form>
    
</asp:Content>

