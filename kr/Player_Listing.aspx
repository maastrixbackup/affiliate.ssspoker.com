<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Player_Listing.aspx.vb" Inherits="Player_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>회원 리스트</h5>
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
                            제휴 코드:</label>
                        <div class="formRight" style="width:80%;float:left;">
                            <asp:TextBox ID="txtAffCode" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width:50%;float:left;">
                        <label style="width:15%;float:left;">
                            회원 ID:</label>
                        <div class="formRight" style="width:80%;float:left;">
                            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        </div>
                        
                    </div>
                </div>
                <div class="title formRow" style="width:100%;float:left;">
                    <div style="width:50%;float:left;">
                        <label style="width:15%;float:left;">
                            사용자 ID:</label>
                        <div class="formRight" style="width:80%;float:left;">
                            <asp:TextBox ID="txtNickname" runat="server"></asp:TextBox>
                        </div>
                        
                    </div>
                    <div style="width:50%;float:left;">
                        <label style="width:15%;float:left;">
                            이름:</label>
                        <div class="formRight" style="width:80%;float:left;">
                            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="title formRow" style="width:100%;float:left;">
                    <div style="width:50%;float:left;">
                        <label style="width:15%;float:left;">
                            가입날짜:</label>
                        <div class="formRight" style="width:80%;float:left;">
                            <asp:TextBox ID="txtRegDate" CssClass="front-datetime-tb" runat="server"></asp:TextBox>
                        </div>
                        
                    </div>
                </div>
                <hr class="spacer1px">
                <div class="formSubmit">
                    <%--<asp:Button ID="searchBannerBtn" CssClass="blueB ml10" runat="server" Text="Search"
                        OnClick="searchBanner" />--%>
                    <asp:LinkButton ID="lnkSearch" runat="server" CssClass="blueB ml10" CausesValidation="false">검색</asp:LinkButton>
                   
                </div>
            </div>
        </fieldset>
    </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <div id="gvTable" runat="server" class="wrapper">
            <div id="table" class="widget">
            
                <asp:GridView ID="Grid1"  CssClass="display dTable" runat="server" AllowPaging="true" PageSize="100" OnPageIndexChanging = "OnPaging" AutoGenerateColumns="false">
                    <HeaderStyle CssClass="header-align" />
                    <RowStyle CssClass="row-align" />
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemStyle Width="30px" />
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="회원 ID" DataField="Player_Username" ItemStyle-CssClass="row-align-left" />
                        <asp:BoundField HeaderText="가입날짜" DataField="CreateDate" DataFormatString="{0:dd/MMM/yyyy}" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemStyle Width="60px" />
                            <ItemTemplate>
                                <a href='Player_Details.aspx?id=<%#Eval("RECID") %>'>View</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

        <asp:GridView ID="Grid2" CssClass="display dTable" runat="server" AllowPaging="true" PageSize="100" OnPageIndexChanging = "OnPaging" AutoGenerateColumns="false" Visible="false" AllowSorting="true" OnSorting="Grid2_Sorting">
                    <HeaderStyle CssClass="header-align" />
                    <RowStyle CssClass="row-align" />
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemStyle Width="30px"/>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="제휴 코드" DataField="AffliateCode"  ItemStyle-CssClass="row-align-left"/>
                        <asp:BoundField HeaderText="회원 ID" DataField="Player_Username" ItemStyle-CssClass="row-align-left" />
                        <asp:BoundField HeaderText="아이디" DataField="Player_Fullname" ItemStyle-CssClass="row-align-left" />
                        <asp:BoundField HeaderText="가입날짜" DataField="CreateDate" DataFormatString="{0:dd/MMM/yyyy}" />
                        <asp:TemplateField HeaderText="Action">
                    <ItemStyle Width="100px"/>
                    <ItemTemplate>
                        <a href='Player_Details.aspx?mode=edit&id=<%#Eval("RECID") %>'>Edit</a> |
                        <a href='Player_Details.aspx?id=<%#Eval("RECID") %>'>View</a>
                    </ItemTemplate>
                </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            </div>
    </form>
</asp:Content>

