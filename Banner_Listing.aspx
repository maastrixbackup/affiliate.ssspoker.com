<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Banner_Listing.aspx.vb" Inherits="Banner_Listing" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div><h3><asp:Label ID="lblTitle" runat="server"></asp:Label></h3></div>
    <div><asp:Label ID="lblErr_Msg" runat="server" ForeColor="Red" Text=""></asp:Label></div>

    <div class="row row-padding container-fluid">
        <div class="col-md-1">Category :</div>
        <div class="col-md-2">
            <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="CategoryName" DataValueField="RECID" ></asp:DropDownList>
        </div>
        <div class="col-md-9">
            <div class="col-md-2"><asp:LinkButton ID="lnkSearch" runat="server" CssClass="btn btn-info" CausesValidation="false">Search</asp:LinkButton></div>
        </div>
    </div>

    <div class="row row-padding container-fluid">
                <asp:GridView ID="Grid1" runat="server" AutoGenerateColumns="false" >
                    <HeaderStyle CssClass="header-align" />
                    <RowStyle CssClass="row-align" />
                    
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemStyle Width="30px"/>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Banner">
                            
                            <ItemTemplate>
                                <img src="http://affiliate.sbobetpoker.com/Images/Banner/<%#Eval("Banner_Image")%>" height="240" width="320" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Category" DataField="CategoryName"/>
                        <asp:BoundField HeaderText="Banner Name" DataField="Banner_Name" />
                        <asp:TemplateField HeaderText="HTML Code">
                            <ItemTemplate>
                                <div><textarea id="txtHTML_Code" runat="server" draggable="false" style="height:150px;width:300px" readonly="readonly"><%#Replace(Eval("Banner_HTML_Code"), "[aff_code]", Session("LoginID").ToString)%></textarea></div>
                                <%--<asp:TextBox ID="txtHTML_Code" runat="server" Height="100" Width="400" Wrap="true" Text=<%#Eval("Banner_HTML_Code")%> ReadOnly="true"></asp:TextBox>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
            </div>
</asp:Content>

