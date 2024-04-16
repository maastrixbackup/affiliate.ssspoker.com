<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Change_Password.aspx.vb" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>
                   Change Password</h5>
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
                 <div class="formRow"  id="divDDLUser" runat="server">
                    <label style="font-size: small">
                       User:</label>
                    <div class="formRight">
                           <asp:DropDownList ID="ddlUser" runat="server" DataTextField="LoginID" DataValueField="RECID"></asp:DropDownList>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                       새로운 비밀번호: </label>
                    <div class="formRight">
                           <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
                
                        <asp:Label ID="lblMsg_Password" runat="server" ForeColor="Red"></asp:Label>
                        <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtNewPassword" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$" ErrorMessage="Password must contain at least 1 alphabet and 1 number." ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="formRow"  >
                    <label style="font-size: small">
                       새로운 비밀번호 확인: </label>
                    <div class="formRight">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:Label ID="lblMsg_ConfirmPassword" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
              
        
               
               
                
              
            
                
                
              
              
                
                

                
                
               
                <div class="formSubmit">
                    <asp:Button ID="btnSave" runat="server" Text="저장하기" class="button basic tipS" style="margin: 5px"/>
                    
                    
                    
                </div>
                </div>
          
        </fieldset>
    </div>
    </form>
    
</asp:Content>

