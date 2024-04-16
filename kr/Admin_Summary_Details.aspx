<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Admin_Summary_Details.aspx.vb" Inherits="Admin_Summary_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="form2" class="form" runat="server">
<div class="titleArea">
    <div class="wrapper">
        <div class="pageTitle">
            <h5>Summary Details</h5>
        </div>
        <div class="middleNav" style="border:none;">
            <asp:LinkButton ID="lnkExport" runat="server" CssClass="blueB ml10" CausesValidation="false">파일 받기</asp:LinkButton>
            <asp:LinkButton ID="lnkBack" runat="server" CssClass="blueB ml10" CausesValidation="false">Back</asp:LinkButton>
        </div>
    </div>
</div>
<div class="line"></div>
    
        <div><asp:Label ID="lblErr_Msg" runat="server" ForeColor="Red" Text=""></asp:Label></div>
        <div class="wrapper">
        <fieldset>
            <div class="widget">
                <div class="title">
                    <h6>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                        <%--asp:Label ID="Label1" runat="server"></asp:Label>--%>
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
                <div class="title formRow">
                    <div style="width:50%;float:left;">
                        <label style="width:15%;float:left;">
                            아이디:</label>
                        <div class="formRight" style="width:80%;float:left;">
                            
                            <asp:TextBox ID="txtPlayerUsername" CssClass="ui-wizard-content" runat="server"></asp:TextBox>
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
            
               <asp:GridView ID="Grid1" runat="server" AllowPaging="true" PageSize="50" AutoGenerateColumns="false" OnPageIndexChanging="Grid1_PageIndexChanging" >
                <HeaderStyle CssClass="header-align" />
                        <RowStyle CssClass="row-align" />
                <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="날짜" DataField="ReportDate" DataFormatString="{0:dd/MMM/yyyy}" SortExpression="ReportDate" />
                    <asp:BoundField HeaderText="아이디" DataField="Username" SortExpression="Username" ItemStyle-CssClass="row-align-left" />
                            <asp:BoundField HeaderText="제휴 코드" DataField="AffliateCode" ItemStyle-CssClass="row-align-left" />
                            <asp:BoundField HeaderText="턴오버" DataField="Real_Turnover" SortExpression="Real_Turnover" ItemStyle-CssClass="row-align-right" />
                            <asp:BoundField HeaderText="커미션" DataField="Comm" SortExpression="Comm" ItemStyle-CssClass="row-align-right" />
                </Columns>
            </asp:GridView>
            </div>
            </div>
        <div class="row row-padding container-fluid">
        <%--<div class="col-md-offset-5">
            <asp:LinkButton ID="lnkExport" runat="server" CssClass="btn btn-info" CausesValidation="false">파일 받기</asp:LinkButton>
            <asp:LinkButton ID="lnkBack" runat="server" CssClass="btn btn-info" CausesValidation="false">Back</asp:LinkButton>

        </div>--%>
    </div>
    </form>
</asp:Content>

