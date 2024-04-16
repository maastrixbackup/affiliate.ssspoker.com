<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Ticket_Details.aspx.vb" Inherits="Ticket_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>티켓 신청</h5>
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
                <div class="formRow">
                    <label style="font-size: small">
                        제휴 :</label>
                    <div class="formRight">
                        <asp:DropDownList runat="server" ID="ddlAffiliate" DataTextField="LoginID" DataValueField="RECID" CssClass="form-control" OnSelectedIndexChanged="ddlAffiliate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        현재 잔액 :</label>
                    <div class="formRight">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                            <ContentTemplate>
                                <asp:Label runat="server" ID="lblAffBalance"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        <asp:RadioButton runat="server" ID="rbDepoToWallet" Text="지갑 입금 :" GroupName="depoTo" /></label>
                    <div class="formRight">
                       <asp:TextBox runat="server" CssClass="form-control row-textbox-30" ID="txtDepoToWalletAmt" placeholder="금액 (원화)"></asp:TextBox>
                    </div>
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        <asp:RadioButton runat="server" ID="rbDepoToPlayer" Text="회원 입금 :" GroupName="depoTo" /></label>
                    <div class="formRight">
                            <asp:TextBox ID="txtDepoToPlayer" CssClass="form-control row-textbox-40" runat="server" placeholder="회원 별명 (게임 내 아이디)"></asp:TextBox>
                            <asp:TextBox ID="txtdepoToPlayerAmt" CssClass="form-control row-textbox-30" runat="server" placeholder="금액 (원화)"></asp:TextBox>
                    </div> 
                </div>
                <div class="formSubmit">
                    <asp:Button ID="btnSave" runat="server" Text="신청" class="button basic tipS" style="margin: 5px"/>
                </div>
            </div>
       
        </fieldset>
    </div>
    </form>
</asp:Content>

