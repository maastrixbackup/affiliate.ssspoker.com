<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Admin_Details.aspx.vb" Inherits="Admin_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                        Affiliate Mode:</label>
                    <div class="myRadio formRight">
                        <asp:RadioButtonList ID="rblAff_Mode" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" >
                            <asp:ListItem Value="1"> Online</asp:ListItem>
                            <asp:ListItem Value="0" Selected="True"> Corporate</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        국가: </label>
                    <div class="formRight">
                       
                            <asp:DropDownList ID="ddlCountry" DataTextField="CountryName" DataValueField="CountryRECID" AutoPostBack="true" CssClass="form-control required" runat="server">
                            </asp:DropDownList>
                           </div>
                             <asp:Label ID="lblMsg_Country" runat="server"></asp:Label>
                       
                    
                </div>
                <asp:UpdatePanel ID="UPUserType" runat="server">
                    <Triggers ><asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged" /></Triggers>
                    <ContentTemplate>
                        <div class="formRow">
                            <label style="font-size: small">
                                회원 등급: </label>
                            <div class="formRight">
                               
                                    <asp:DropDownList ID="ddlUserType" AutoPostBack="true" CssClass="form-control required" runat="server">
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="rfvUserType" runat="server" ControlToValidate="ddlUserType" InitialValue="-User Type-" ErrorMessage="User Type is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
              
                <asp:UpdatePanel ID="UPCommissionRate" runat="server">
                    <Triggers><asp:AsyncPostBackTrigger ControlID="ddlParent" EventName="SelectedIndexChanged" /></Triggers>
                    <ContentTemplate>
                        <div class="formRow">
                            <label style="font-size: small">
                               회원 레벨: </label>
                            <div class="formRight">
                                
                                    <asp:DropDownList ID="ddlParent" runat="server" CssClass="form-control required" DataTextField="LoginID" DataValueField="RECID" AutoPostBack="true">
                                        <asp:ListItem>Select Upper Affiliate</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                    <asp:Label ID="lblMsg_UpperLevel" runat="server"></asp:Label>
                                
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel runat="server">
                    <Triggers><asp:AsyncPostBackTrigger ControlID="txtLoginID" EventName="TextChanged" /></Triggers>
                    <ContentTemplate>
                        <div class="formRow">
                            <label style="font-size: small">
                                로그인 ID: </label>
                            <div class="formRight">
                                <asp:TextBox ID="txtLoginID" runat="server" CssClass="form-control" OnTextChanged="CheckLoginID" AutoPostBack="true"></asp:TextBox>
                                <asp:Image ID="Img_True" runat="server" ImageUrl="Images/icon-tick.png" Height="20px" Width="20px" Visible="false" />
                                <asp:Image ID="Img_False" runat="server" ImageUrl="Images/icon-cross.png" Height="20px" Width="20px" Visible="false" />
                                <asp:RequiredFieldValidator ID="rfvLoginID" runat="server" ControlToValidate="txtLoginID" ErrorMessage="Login ID is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:Label ID="lblMsg_LoginID" runat="server"></asp:Label>
                            </div>
                        </div>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                

                <div class="formRow">
                    <label style="font-size: small">
                        비밀번호:</label>
                    <div class="formRight">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control required" TextMode="Password"></asp:TextBox>
                         <asp:Label ID="lblMsg_Password" runat="server" ForeColor="Red"></asp:Label>
                        <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z@\d]{6,}$" ErrorMessage="Password must be alphanumeric and no symbol allowed." ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        비밀번호 확인:</label>
                    <div class="formRight">
                        <asp:TextBox ID="txtConfirmPassword" CssClass="form-control required" runat="server" TextMode="Password"></asp:TextBox>
                       <asp:Label ID="lblMsg_ConfirmPassword" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <asp:UpdatePanel ID="UPRate" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="rblAff_Mode" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlUserType" EventName="SelectedIndexChanged" />
                
                    </Triggers>
                    <ContentTemplate>
                        <div class="formRow">
                            <label style="font-size: small">
                                커미션 설정:</label>
                            <div class="formRight">
                                <asp:TextBox ID="txtCommissionRate" runat="server" CssClass="form-control required" Text=""></asp:TextBox>%
                                <asp:Label ID="lblMsg_CommissionRate" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UPBank" runat="server">
                    <Triggers><asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged" /></Triggers>
                    <ContentTemplate>
                        <div class="formRow">
                            <label style="font-size: small">
                               은행 설정:</label>
                            <div class="formRight">
                                
                                    <asp:DropDownList ID="ddlBank" runat="server" DataTextField="BankName" DataValueField="BankDetails" AutoPostBack="true" ></asp:DropDownList>
                             
                                <asp:UpdatePanel ID="UPBankImage" runat="server">
                                    <Triggers><asp:AsyncPostBackTrigger ControlID="ddlBank" EventName="SelectedIndexChanged" /></Triggers>
                                    <ContentTemplate>
                                        <div class="row-padding"><img id="ImgBank" runat="server" height="80" width="200" style="margin-left:30px;"/></div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                
                            </div>
                        </div>
                 
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="formRow">
                    <label style="font-size: small">
                        은행 계좌 명:</label>
                    <div class="formRight">
                        
                            <asp:TextBox ID="txtBankAccountHolderName" CssClass="form-controln required" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvBankAccountHolderName" runat="server" ControlToValidate="txtBankAccountHolderName" ErrorMessage="Bank Account Holder Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        
                    </div>
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        은행 계좌번호:</label>
                    <div class="formRight">
                        
                            <asp:TextBox ID="txtBankAccountNo" CssClass="form-controln required" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvBankAccountNo" runat="server" ControlToValidate="txtBankAccountNo" ErrorMessage="Bank Account No is required." ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:Label ID="lblMsg_BankAccountNo" runat="server"></asp:Label>
                        
                    </div>
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        Register URL:</label>
                    <div class="formRight">
                       
                             <asp:TextBox ID="txtRegisterUrl" CssClass="form-controln required" runat="server"></asp:TextBox>
                            
                            <asp:RequiredFieldValidator ID="rfvUrl" runat="server" ControlToValidate="txtRegisterUrl" ErrorMessage="Register URL is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        
                    </div>
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        Game URL:</label>
                    <div class="formRight">
                        <asp:TextBox ID="txtGameUrl" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvGameUrl" runat="server" ControlToValidate="txtGameUrl" ErrorMessage="Game URL is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formSubmit">
                    <asp:Button ID="btnSave" runat="server" Text="저장하기" class="button basic tipS" style="margin: 5px"/>&nbsp<a id="aCancel" runat="server" href="Admin_Listing.aspx" class="button basic tipS" style="margin: 5px;padding: 8px 18px 8px 18px;">취소하기</a>
                </div>
            </div>
        </fieldset>
    </div>
    </form>
    

</asp:Content>

