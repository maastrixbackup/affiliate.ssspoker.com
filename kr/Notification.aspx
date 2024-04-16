<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Notification.aspx.vb" Inherits="Notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>공지</h5>
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
                    <h6>공지</h6>
                </div>
                
                <div class="title formRow" style="width:100%;float:left;">
                    
                    <label >
                        공지 :</label>
                    <div class="formRight" >
                        <asp:TextBox ID="txtNotification" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="title formRow" style="width:100%;float:left;">
                    
                    <label >
                        상태 :</label>
                    <div class="formRight" >
                        <asp:RadioButtonList runat="server" ID="rblStatus" RepeatDirection="Horizontal"><asp:ListItem Text="활성화" Value="True" Selected="True"></asp:ListItem><asp:ListItem Text="비활성화" Value="False"></asp:ListItem></asp:RadioButtonList>
                    </div>
                </div>
                    
                
                <div class="formSubmit">
                    <%--<asp:Button ID="searchBannerBtn" CssClass="blueB ml10" runat="server" Text="Search"
                        OnClick="searchBanner" />--%>
                    <asp:LinkButton ID="lnkSearch" runat="server" CssClass="blueB ml10" CausesValidation="false">찾기</asp:LinkButton>
                   
                </div>
                </div>
            
        </fieldset>
    </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <div id="gvTable" runat="server" class="wrapper">
            <div id="table" class="widget">
            
                <asp:GridView ID="Grid1" CssClass="display dTable" runat="server" AllowPaging="true" PageSize="100" OnPageIndexChanging = "OnPaging" AutoGenerateColumns="false">
                    <HeaderStyle CssClass="header-align" />
                    <RowStyle CssClass="row-align" />
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemStyle Width="30px" />
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="공지" DataField="Notification" ItemStyle-CssClass="row-align-left" />
                        <asp:BoundField HeaderText="노출" DataField="IsAfterLogin" />
                        <asp:BoundField HeaderText="상태" DataField="Status" />
                        <asp:TemplateField HeaderText="수정">
                            <ItemStyle Width="120px" />
                            <ItemTemplate>
                                <a href='Notification_Details.aspx?id=<%#Eval("RECID") %>'>Edit</a> | <asp:LinkButton runat="server" ID="lnkDelete" CommandName="DEL" CommandArgument='<%#Eval("RECID") %>'>Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            </div>
            
    </form>
    
                

</asp:Content>

