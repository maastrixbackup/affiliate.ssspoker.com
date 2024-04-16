<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Summary_Listing.aspx.vb" Inherits="Summary_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("[id$=txtDateFrom]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'Images/calendar.gif',
                dateFormat: 'dd/MM/yy'
            });
        });

        $(function () {
            $("[id$=txtDateTo]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'Images/calendar.gif',
                dateFormat:'dd/MM/yy'
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div><h3><asp:Label ID="lblTitle" runat="server"></asp:Label></h3></div>
    <div><asp:Label ID="lblErr_Msg" runat="server" ForeColor="Red" Text=""></asp:Label></div>
    <div class="row row-padding container-fluid">
            <div class="col-md-1">Date From: </div>
            <div class="col-md-2"><asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox></div>
            <div class="col-md-1">Date To: </div>
            <div class="col-md-2"><asp:TextBox ID="txtDateTo" runat="server"></asp:TextBox></div>
            <div class="col-md-5">
                <asp:LinkButton ID="lnkSearch" runat="server" CssClass="btn btn-info" CausesValidation="false">Search</asp:LinkButton>
                <asp:LinkButton ID="lnkExport" runat="server" CssClass="btn btn-info" CausesValidation="false">Export</asp:LinkButton>
            </div>
        </div>

        <div class="row row-padding container-fluid">
            <div class="col-md-12">
                <asp:GridView ID="Grid1" runat="server"  AllowPaging="true" PageSize="10" OnPageIndexChanging = "OnPaging" AutoGenerateColumns="false">
                    <HeaderStyle CssClass="header-align" />
                    <RowStyle CssClass="row-align" />
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemStyle Width="30px"/>
                            <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Alias" DataField="PokerAlias" />
                        <asp:BoundField HeaderText="Banner Tag" DataField="BannerTag" />
                        <asp:BoundField HeaderText="User Type" DataField="UserType" />
                        <asp:BoundField HeaderText="Loyalty Points Earned" DataField="LoyaltyPointsEarned" />
                        <asp:BoundField HeaderText="Player Currency" DataField="PlayerCurrency" />
                        <asp:BoundField HeaderText="Rake Amount" DataField="RakeAmount" />
                        <asp:BoundField HeaderText="Commission" DataField="Commission" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>

