<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Admin_Listing.aspx.vb" Inherits="Admin_Listing" %>

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
        <asp:GridView ID="Grid_Admin" runat="server" AllowPaging="true" PageSize="25" OnPageIndexChanging="OnPaging" AutoGenerateColumns="false">
            <HeaderStyle CssClass="header-align" />
            <RowStyle CssClass="row-align" />
                    
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemStyle Width="30px"/>
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="LoginID" DataField="LoginID" />
                <asp:BoundField HeaderText="Level" DataField="Level" />
                <asp:BoundField HeaderText="CommissionRate" DataField="CommissionRate" />
                <asp:BoundField HeaderText="Affiliate Mode" DataField="Aff_Mode" />
                <asp:TemplateField HeaderText="Action">
                    <ItemStyle Width="60px"/>
                    <ItemTemplate>
                        <a runat="server" onServerClick="EditDetails" customdata='<%#Eval("RECID") %>'>Edit</a>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    
        <asp:GridView ID="Grid_User" runat="server" AllowPaging="true" PageSize="25" OnPageIndexChanging="OnPaging" AutoGenerateColumns="false">
            <HeaderStyle CssClass="header-align" />
            <RowStyle CssClass="row-align" />
                    
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemStyle Width="30px"/>
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="LoginID" DataField="LoginID" />
                <asp:BoundField HeaderText="Level" DataField="Level" />
                <asp:BoundField HeaderText="CommissionRate" DataField="CommissionRate" />
                <asp:TemplateField HeaderText="Action">
                    <ItemStyle Width="60px"/>
                    <ItemTemplate>
                        <a runat="server" onServerClick="EditDetails" customdata='<%#Eval("RECID") %>'>Edit</a>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

