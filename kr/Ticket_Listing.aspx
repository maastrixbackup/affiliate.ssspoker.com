<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Ticket_Listing.aspx.vb" Inherits="Ticket_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>티켓 내역</h5>
            </div>
           
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="line"></div>
    <form id="form2" class="form" runat="server">
        <div><asp:Label ID="lblErr_Msg" runat="server"></asp:Label></div>
        <div class="wrapper">
        <fieldset>
            <div class="widget">
                <div class="title">
                    <h6>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </h6>
                </div>
                
                <div class="title formRow" style="width:100%;float:left;">
                    <div style="width:50%;float:left;">
                        <label style="width:15%;float:left;">
                            제휴 :</label>
                        <div class="formRight" style="width:80%;float:left;">
                            <asp:DropDownList runat="server" ID="ddlAffiliate" DataTextField="LoginID" DataValueField="RECID"></asp:DropDownList>
                        </div>
                    </div>
                    <div style="width:50%;float:left;">
                        <label style="width:15%;float:left;">
                            상태 :</label>
                        <div class="formRight" style="width:80%;float:left;">
                            <asp:DropDownList runat="server" ID="ddlStatus">
                                <asp:ListItem Value="All">전체</asp:ListItem>
                                <asp:ListItem Value="New" Selected="True">신규</asp:ListItem>
                                <asp:ListItem Value="Pro">진행중</asp:ListItem>
                                <asp:ListItem Value="App">승인완료</asp:ListItem>
                                <asp:ListItem Value="Rej">취소완료</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <hr class="spacer1px">
                <div class="formSubmit">
                    <asp:LinkButton ID="lnkSearch" runat="server" CssClass="blueB ml10" CausesValidation="false">검색</asp:LinkButton>
                </div>
            </div>
        </fieldset>
    </div>
        <div class="wrapper">
            <div id="table" class="widget">
                <asp:GridView ID="Grid1" runat="server" AutoGenerateColumns="false" Width="100%" AllowPaging="true" PageSize="50" >
                    <HeaderStyle CssClass="header-align" />
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemStyle Width="30px"/>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="제휴" DataField="LoginID" ItemStyle-CssClass="cell-text-align-left" />
                        <asp:BoundField HeaderText="회원" DataField="playerId" ItemStyle-CssClass="cell-text-align-left" />
                        <asp:BoundField HeaderText="금액(원화)" DataField="amount" DataFormatString="{0:#,0.00}"  ItemStyle-CssClass="cell-text-align-right" />
                        <asp:BoundField HeaderText="현재 지갑 잔액(원화)" DataField="walletBalance" DataFormatString="{0:#,0.00}"  ItemStyle-CssClass="cell-text-align-right" />
                        <asp:BoundField HeaderText="상태" DataField="status" />
                        <asp:TemplateField HeaderText="승인여부">
                            <ItemStyle Width="120px"/>
                            <ItemTemplate>
                                <a runat="server" class="greenB" onServerClick="ApproveTicket" customdata='<%#Eval("id").ToString() + "," + Eval("playerId") + "," + Eval("amount").ToString() %>'>승인</a>  
                                <a runat="server" class="blueB" onServerClick="RejectTicket" customdata='<%#Eval("id") %>'>취소</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            </div>
    </form>
</asp:Content>

