<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Notification_Details.aspx.vb" Inherits="Notification_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>공지 추가</h5>
            </div>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="line"></div>
    <form id="form1" role="form" class="form" runat="server">
    <div class="wrapper">
        <fieldset>
            <div class="widget">
                <asp:Label ID="lblErr_Msg" runat="server" Text="" ForeColor="Red"></asp:Label>
                <div class="title">
                    <h6>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label></h6>
                </div>
                 <div class="formRow"  >
                    <label style="font-size: small">
                       공지:</label>
                    <div class="formRight">
                          <asp:TextBox ID="txtNotification" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvNotification" runat="server" ControlToValidate="txtNotification" ErrorMessage="Notification is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formRow" >
                    <label style="font-size: small">
                       노출:</label>
                    <div class="formRight">
                         <asp:RadioButtonList runat="server" ID="rblDisplay" RepeatDirection="Horizontal">
                            <asp:ListItem Text="After Login" Value="True"></asp:ListItem>
                            <asp:ListItem Text="Before Login" Value="False"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rfvDisplay" runat="server" ControlToValidate="rblDisplay" ErrorMessage="Display is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formRow">
                            <label style="font-size: small">
                               상태 : </label>
                            <div class="formRight">
                                    <asp:RadioButtonList runat="server" ID="rblStatus" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="활성화" Value="True"></asp:ListItem>
                                    <asp:ListItem Text="비활성화" Value="False"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="rblStatus" ErrorMessage="Status is required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                </div>
                <div class="formSubmit">
                    <asp:Button ID="btnSave" runat="server" Text="저장" class="button basic tipS" style="margin: 5px"/><asp:Button ID="btnAdd" runat="server" Text="저장" CssClass="btn btn-info"/>&nbsp<a id="aCancel" class="button basic tipS" style="margin: 5px;padding: 8px 18px 8px 18px;" runat="server" href="Notification.aspx" >취소</a>
                </div>
                </div>
        </fieldset>
    </div>
    </form>
</asp:Content>

