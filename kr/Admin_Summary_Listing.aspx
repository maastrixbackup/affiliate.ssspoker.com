<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Admin_Summary_Listing.aspx.vb" Inherits="Admin_Summary_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>
                    커미션 확인</h5>
            </div>
           
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="line"></div>
    <form id="form2" class="form" runat="server">
        <div><asp:Label ID="lblErr_Msg" runat="server" ForeColor="Red" Text=""></asp:Label></div>
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
                            시작 날짜:</label>
                        <div class="formRight" style="width:80%;float:left;">
                            <asp:TextBox ID="txtDateFrom" CssClass="ui-wizard-content front-datetime-tb" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width:50%;float:left;">
                        <label style="width:15%;float:left;">
                            종료 날짜:</label>
                        <div class="formRight" style="width:80%;float:left;">
                            <asp:TextBox ID="txtDateTo" CssClass="ui-wizard-content front-datetime-tb" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="title formRow" style="width:100%;float:left;">
                    <div style="width:50%;float:left">
                        <label style="width:15%;float:left">
                            제휴 코드:</label>
                        <div class="formRight" style="width:80%;float:left">
                            <asp:TextBox ID="txtAffCode" CssClass="ui-wizard-content" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width:50%;float:left">
                        <label style="width:15%;float:left">
                           회원 등급:</label>
                        <div class="formRight" style="width:80%;float:left">
                            <asp:DropDownList runat="server" ID="ddlUserType"></asp:DropDownList>
                           <%-- <asp:TextBox ID="TextBox2" CssClass="ui-wizard-content" runat="server"></asp:TextBox>--%>
                        </div>
                    </div>
                </div>
                <hr class="spacer1px">
                <div class="formSubmit">
                    <%--<asp:Button ID="searchBannerBtn" CssClass="blueB ml10" runat="server" Text="Search"
                        OnClick="searchBanner" />--%>
                    <asp:LinkButton ID="lnkSearch" runat="server" CssClass="blueB ml10" CausesValidation="false">검색</asp:LinkButton>
            <asp:LinkButton ID="lnkExport" runat="server" CssClass="blueB ml10" CausesValidation="false">파일 받기</asp:LinkButton>
                </div>
            </div>
        </fieldset>
    </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <div id="gvTable" runat="server" class="wrapper">
            <div id="table" class="widget">
            
                <asp:GridView ID="Grid1" runat="server" CssClass="display dTable"  AllowPaging="true" PageSize="50" OnPageIndexChanging="OnPaging" AutoGenerateColumns="false" AllowSorting="true" OnSorting="Grid1_Sorting">
                    <HeaderStyle CssClass="header-align" />
                    <RowStyle CssClass="row-align" />
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemStyle Width="30px"/>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="제휴 코드" DataField="AffliateCode" SortExpression="AffliateCode" ItemStyle-CssClass="row-align-left" />
                        <asp:BoundField HeaderText="User Type" DataField="UserType" SortExpression="UserType" ItemStyle-CssClass="row-align-left" />
                        <asp:BoundField HeaderText="턴오버" DataField="Real_Turnover" SortExpression="Real_Turnover" ItemStyle-CssClass="row-align-right" />
                        <asp:BoundField HeaderText="커미션" DataField="Comm" SortExpression="Comm" ItemStyle-CssClass="row-align-right" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemStyle Width="60px"/>
                            <ItemTemplate>
                                <a runat="server" onServerClick="ViewDetails" customdata='<%#Eval("RECID").ToString()%>' >View</a>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
            </div>
            </div>
    </form>
     
</asp:Content>

