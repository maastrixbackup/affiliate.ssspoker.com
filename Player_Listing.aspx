<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Player_Listing.aspx.vb" Inherits="Player_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div><h3><asp:Label ID="lblTitle" runat="server"></asp:Label></h3></div>
    <div><asp:Label ID="lblErr_Msg" runat="server" Text="" ForeColor="Red"></asp:Label></div>

    <div class="row row-padding container-fluid">
                <asp:GridView ID="Grid1" runat="server" AllowPaging="true" PageSize="20" OnPageIndexChanging = "OnPaging" AutoGenerateColumns="false">
                    <HeaderStyle CssClass="header-align" />
                    <RowStyle CssClass="row-align" />
                    
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemStyle Width="30px"/>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Player" DataField="PokerAlias" />
                    </Columns>
                </asp:GridView>

        <asp:GridView ID="Grid2" runat="server" AllowPaging="true" PageSize="20" OnPageIndexChanging = "OnPaging" AutoGenerateColumns="false" Visible="false">
                    <HeaderStyle CssClass="header-align" />
                    <RowStyle CssClass="row-align" />
                    
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemStyle Width="30px"/>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Banner Tag" DataField="BannerTag" />
                        <asp:BoundField HeaderText="Poker Alias" DataField="PokerAlias" />
                        
                    </Columns>
                </asp:GridView>
            </div>

</asp:Content>

