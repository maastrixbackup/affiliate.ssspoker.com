<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Admin_Summary_Details.aspx.vb" Inherits="Admin_Summary_Details" %>

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
        <asp:GridView ID="Grid1" runat="server" AllowPaging="true" AutoGenerateColumns="false" OnPageIndexChanging="Grid1_PageIndexChanging">
            <HeaderStyle CssClass="header-align" />
                    <RowStyle CssClass="row-align" />
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Alias" DataField="PokerAlias" />
                        <asp:BoundField HeaderText="Banner Tag" DataField="BannerTag" />
                        <asp:BoundField HeaderText="User Type" DataField="UserType" />
                        <asp:BoundField HeaderText="Loyalty Points Earned" DataField="LoyaltyPointsEarned" />
                        <asp:BoundField HeaderText="Rake Amount" DataField="RakeAmount" />
                        <asp:BoundField HeaderText="Commission" DataField="Commission" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="row row-padding container-fluid">
        <div class="col-md-offset-5">
            <asp:LinkButton ID="lnkExport" runat="server" CssClass="btn btn-info" CausesValidation="false">Export</asp:LinkButton>
            <asp:LinkButton ID="lnkBack" runat="server" CssClass="btn btn-info" CausesValidation="false">Back</asp:LinkButton>

        </div>
    </div>

</asp:Content>

