<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Admin_Banner_Listing.aspx.vb" Inherits="Admin_Banner_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>배너 리스트</h5>
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
                            카테고리 :</label>
                        <div class="formRight" style="width:80%;float:left;">
                            <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="CategoryName" DataValueField="RECID" ></asp:DropDownList>
                        </div>
                    </div>
                    <div style="width:50%;float:left;">
                        
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
                                <img src="Images/Banner/<%#Eval("Banner_Image")%>" height="240" width="320" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="카테고리" DataField="CategoryName"/>
                        <asp:BoundField HeaderText="Banner Name" DataField="Banner_Name" />
                        <asp:TemplateField HeaderText="HTML Code">
                            <ItemTemplate>
                                <div><textarea disabled="disabled" draggable="false" style="height:150px;width:300px" readonly="readonly"><%#Eval("Banner_HTML_Code")%></textarea></div>
                                <%--<asp:TextBox ID="txtHTML_Code" runat="server" Height="100" Width="400" Wrap="true" Text=<%#Eval("Banner_HTML_Code")%> ReadOnly="true"></asp:TextBox>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="상태" DataField="Status" />
                        <asp:TemplateField HeaderText="수정">
                            <ItemStyle Width="60px"/>
                            <ItemTemplate>
                                <a runat="server" onServerClick="EditDetails" customdata='<%#Eval("RECID") %>'>Edit</a>
                                <a ></a>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
            </div>
    </form>
    
</asp:Content>

