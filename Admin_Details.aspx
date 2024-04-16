<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Admin_Details.aspx.vb" Inherits="Admin_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div><h3><asp:Label ID="lblTitle" runat="server"></asp:Label></h3></div>
    <div><asp:Label ID="lblErr_Msg" runat="server" Text="" ForeColor="Red"></asp:Label></div>

    <div class="row row-padding container-fluid">

        <div id="divMode" runat="server">
            <div class="col-md-2 row-padding">Affiliate Mode: </div>
            <div class="col-md-10 row-padding">
                <asp:RadioButtonList ID="rblAff_Mode" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" >
                    <asp:ListItem Value="1"> Online&nbsp</asp:ListItem>
                    <asp:ListItem Value="0"> Corporate</asp:ListItem>
                </asp:RadioButtonList>
        </div></div>

        <div class="col-md-2 row-padding">Country: </div>
        <div class="col-md-10 row-padding">
            <asp:DropDownList ID="ddlCountry" runat="server" DataTextField="CountryName" DataValueField="CountryRECID" AutoPostBack="true">
            </asp:DropDownList>
            <asp:Label ID="lblMsg_Country" runat="server"></asp:Label>
        </div>

        <asp:UpdatePanel ID="UPUserType" runat="server">
            <Triggers ><asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged" /></Triggers>
            <ContentTemplate>
                <div id="divUserType" runat="server">
                    <div class="col-md-2 row-padding">User Type: </div>
                    <div class="col-md-10 row-padding">
                        <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvUserType" runat="server" ControlToValidate="ddlUserType" InitialValue="-User Type-" ErrorMessage="User Type is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        

        <asp:UpdatePanel ID="UPCommissionRate" runat="server">
            <Triggers><asp:AsyncPostBackTrigger ControlID="ddlParent" EventName="SelectedIndexChanged" /></Triggers>
            <ContentTemplate>
                <div class="col-md-2 row-padding">Upper Level: </div>
                <div class="col-md-10 row-padding">
                    <asp:DropDownList ID="ddlParent" runat="server" DataTextField="LoginID" DataValueField="RECID" AutoPostBack="true">
                        <asp:ListItem>Select Upper Affiliate</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblMsg_UpperLevel" runat="server"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server">
            <Triggers><asp:AsyncPostBackTrigger ControlID="txtLoginID" EventName="TextChanged" /></Triggers>
            <ContentTemplate>
                <div class="col-md-2 row-padding">Login ID: </div>
                <div class="col-md-10 row-padding">
                    <asp:TextBox ID="txtLoginID" runat="server" OnTextChanged="CheckLoginID" AutoPostBack="true"></asp:TextBox>
                    <asp:Image ID="Img_True" runat="server" ImageUrl="Images/icon-tick.png" Height="20px" Width="20px" Visible="false" />
                    <asp:Image ID="Img_False" runat="server" ImageUrl="Images/icon-cross.png" Height="20px" Width="20px" Visible="false" />
                    <asp:RequiredFieldValidator ID="rfvLoginID" runat="server" ControlToValidate="txtLoginID" ErrorMessage="Login ID is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblMsg_LoginID" runat="server"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <div class="col-md-12 col-md-offset-2"></div>

        <div class="col-md-2 row-padding">Password: </div>
        <div class="col-md-10 row-padding">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>--%>
            <asp:Label ID="lblMsg_Password" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div class="col-md-offset-2"><asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z@\d]{6,}$" ErrorMessage="Password must be alphanumeric and no symbol allowed." ForeColor="Red"></asp:RegularExpressionValidator></div>

        <div class="col-md-2 row-padding">Confirm Password: </div>
        <div class="col-md-10 row-padding">
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password is required." ForeColor="Red"></asp:RequiredFieldValidator>--%>
            <asp:Label ID="lblMsg_ConfirmPassword" runat="server" ForeColor="Red"></asp:Label>
        </div>

        <asp:UpdatePanel ID="UPRate" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="rblAff_Mode" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlUserType" EventName="SelectedIndexChanged" />
                
            </Triggers>
            <ContentTemplate>
                <div class="col-md-2 row-padding">Commission Rate: </div>
                <div class="col-md-10 row-padding">
                    <asp:TextBox ID="txtCommissionRate" runat="server" Text=""></asp:TextBox>%
                    <%--<asp:Label ID="lblCommissionRate" runat="server" Text=""></asp:Label>--%>
                    <asp:Label ID="lblMsg_CommissionRate" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--<div class="col-md-offset-2"><asp:RequiredFieldValidator ID="rfvCommissionRate" runat="server" ControlToValidate="txtCommissionRate" ErrorMessage="Commission Rate is required." ForeColor="Red"></asp:RequiredFieldValidator></div>--%>
    </div>

    <div class="container-fluid">
        <asp:UpdatePanel ID="UPBank" runat="server">
            <Triggers><asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged" /></Triggers>
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-2 row-padding">Bank: </div>
                    <div class="col-md-2 row-padding">
                        <asp:DropDownList ID="ddlBank" runat="server" DataTextField="BankName" DataValueField="BankDetails" AutoPostBack="true" ></asp:DropDownList>
                    </div>
                    <div>
                    <asp:UpdatePanel ID="UPBankImage" runat="server">
                        <Triggers><asp:AsyncPostBackTrigger ControlID="ddlBank" EventName="SelectedIndexChanged" /></Triggers>
                        <ContentTemplate>
                            <div class="row-padding"><img id="ImgBank" runat="server" height="80" width="200"/></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        

        <div class="row">
            <div class="col-md-2 row-padding">Bank Account Holder Name: </div>
            <div class="col-md-10 row-padding">
                <asp:TextBox ID="txtBankAccountHolderName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvBankAccountHolderName" runat="server" ControlToValidate="txtBankAccountHolderName" ErrorMessage="Bank Account Holder Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-md-2 row-padding">Bank Account No: </div>
            <div class="col-md-10 row-padding">
                <asp:TextBox ID="txtBankAccountNo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvBankAccountNo" runat="server" ControlToValidate="txtBankAccountNo" ErrorMessage="Bank Account No is required." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:Label ID="lblMsg_BankAccountNo" runat="server"></asp:Label>
            </div>
        </div>

    </div>
        
    <div class="container-fluid">
        <div class="col-md-offset-5"><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info"/>&nbsp<a id="aCancel" runat="server" href="Admin_Listing.aspx" style="color:white" class="btn btn-info">Cancel</a></div>
    </div>

</asp:Content>

