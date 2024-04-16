<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Admin_Listing.aspx.vb" Inherits="Admin_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>
                    제휴 목록</h5>
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
                    <% If Session("UserType") = "0" Then%>
                        <div class="title formRow" style="width:100%;float:left;">
                            <div style="width:50%;float:left;">
                                <label style="width:15%;float:left;">
                                    제휴 코드:</label>
                                <div class="formRight" style="width:80%;float:left;">
                                    <asp:TextBox ID="txtAffCode" CssClass="ui-wizard-content" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div style="width:50%;float:left;">
                                <label style="width:15%;float:left;">
                                    제휴 등급:</label>
                                <div class="formRight" style="width:80%;float:left;">
                                    <div class="selector">
                                    <asp:DropDownList runat="server" ID="ddlUserType"></asp:DropDownList>
                                        </div>
                                </div>
                            </div>
                        </div>
                        <div class="title formRow" style="width:100%;float:left;">
                            <div style="width:33%;float:left">
                                <label style="width:15%;float:left">
                                    이름:</label>
                                <div class="formRight" style="width:80%;float:left">
                                    <asp:TextBox ID="txtFullName" CssClass="ui-wizard-content" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div style="width:33%;float:left">
                                <label style="width:15%;float:left">
                                   전화: </label>
                                <div class="formRight" style="width:80%;float:left">
                                    <asp:TextBox ID="txtContactNo" CssClass="ui-wizard-content" runat="server"></asp:TextBox>
                                   <%-- <asp:TextBox ID="TextBox2" CssClass="ui-wizard-content" runat="server"></asp:TextBox>--%>
                                </div>
                            </div>
                            <div style="width:33%;float:left">
                                <label style="width:15%;float:left">
                                   이메일:</label>
                                <div class="formRight" style="width:80%;float:left">
                                    <asp:TextBox ID="txtEmail" CssClass="ui-wizard-content" runat="server"></asp:TextBox>
                                   <%-- <asp:TextBox ID="TextBox2" CssClass="ui-wizard-content" runat="server"></asp:TextBox>--%>
                                </div>
                            </div>
                        </div>
                        <hr class="spacer1px">
                        <div class="formSubmit">
                            <%--<asp:Button ID="searchBannerBtn" CssClass="blueB ml10" runat="server" Text="Search"
                                OnClick="searchBanner" />--%>
                            <asp:LinkButton ID="lnkSearch" runat="server" CssClass="blueB ml10" CausesValidation="false">검색</asp:LinkButton>
                            
                        </div>
                    <% End If %>
                    <% If Session("UserType") <> "0" Then %>
                        <div class="title formRow" style="width:100%;float:left;">
                            <div style="width:50%;float:left;">
                                <label style="width:15%;float:left;">
                                    Affiliate Code: </label>
                                <div class="formRight" style="width:80%;float:left;">
                                    <asp:Label runat="server" ID="lblAffCode"></asp:Label>
                                </div>
                            </div>
                            <div style="width:50%;float:left;">
                                <label style="width:15%;float:left;">
                                    Commission:</label>
                                <div class="formRight" style="width:80%;float:left;">
                                    <asp:Label runat="server" ID="lblAffComm"></asp:Label>
                                </div>
                            </div>
                        </div>
                    <% End If %>
                </div>
            </fieldset>
        </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <div id="gvTable" runat="server" class="wrapper">
            <div id="table" class="widget">
            
                <asp:GridView ID="Grid_Admin" runat="server" CssClass="display dTable" AllowPaging="true" PageSize="25" OnPageIndexChanging="OnPaging" AutoGenerateColumns="false" AllowSorting="true" OnSorting="Grid_Admin_Sorting" OnRowDataBound="Grid_Admin_Row">
            <HeaderStyle CssClass="header-align" />
            <RowStyle CssClass="row-align" />
                    
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemStyle Width="30px"/>
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="총판 ID" DataField="LoginID" SortExpression="LoginID" ItemStyle-CssClass="row-align-left" />
                <asp:BoundField HeaderText="제휴 등급" DataField="Level" SortExpression="Level" ItemStyle-CssClass="row-align-left" />
                <asp:BoundField HeaderText="커미션 요율(%)" DataField="CommissionRate" />
                <asp:BoundField HeaderText="누적 커미션" DataField="AccumulatedComm" ItemStyle-CssClass="row-align-right" />
                <asp:BoundField HeaderText="이름" DataField="FullName" ItemStyle-CssClass="row-align-left" />
                <asp:BoundField HeaderText="전화" DataField="ContactNo" ItemStyle-CssClass="row-align-left" />
                <asp:BoundField HeaderText="이메일" DataField="Email" ItemStyle-CssClass="row-align-left" />
                <asp:TemplateField HeaderText="Action">
                    <ItemStyle Width="60px"/>
                    <ItemTemplate>
                        <a runat="server" onServerClick="EditDetails" customdata='<%#Eval("RECID") %>'>Edit</a>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    
        <asp:GridView ID="Grid_User" runat="server" CssClass="display dTable" AllowPaging="true" PageSize="25" OnPageIndexChanging="OnPaging" AutoGenerateColumns="false">
            <HeaderStyle CssClass="header-align" />
            <RowStyle CssClass="row-align" />
                    
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemStyle Width="30px"/>
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="총판 ID" DataField="LoginID" />
                <asp:BoundField HeaderText="하부총판 등급" DataField="Level" />
                <asp:BoundField HeaderText="커미션 요율(%)" DataField="CommissionRate" />
            </Columns>
        </asp:GridView>
            </div>
        </div>
    </form>

    
</asp:Content>

