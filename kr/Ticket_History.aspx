<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Ticket_History.aspx.vb" Inherits="Ticket_History" %>

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
                        <asp:BoundField HeaderText="날짜 및 시간" DataField="createDate" DataFormatString="{0:dd/MM/yyyy hh:mm:ss tt}" />
                        <asp:BoundField HeaderText="제휴" DataField="LoginID" ItemStyle-CssClass="cell-text-align-left" />
                        <asp:BoundField HeaderText="요청" DataField="ticketType" />
                        <asp:BoundField HeaderText="회원" DataField="playerId" ItemStyle-CssClass="cell-text-align-left" />
                        <asp:BoundField HeaderText="금액(원화)" DataField="amount" ItemStyle-CssClass="cell-text-align-right" DataFormatString="{0:#,0.00}" />
                        <asp:BoundField HeaderText="상태" DataField="status" />
                        <asp:BoundField HeaderText="처리자" DataField="auditor" ItemStyle-CssClass="cell-text-align-left" />
                        <asp:BoundField HeaderText="처리 전 잔액(원화)" DataField="balanceBefore" ItemStyle-CssClass="cell-text-align-right" DataFormatString="{0:#,0.00}" />
                        <asp:BoundField HeaderText="처리 후 잔액(원화)" DataField="balanceAfter" ItemStyle-CssClass="cell-text-align-right" DataFormatString="{0:#,0.00}" />
                    </Columns>
                </asp:GridView>
            </div>
            </div>
    </form>
</asp:Content>

