<%@ Page Title="" Language="VB" MasterPageFile="~/kr/MasterPage2.master" AutoEventWireup="false" CodeFile="Admin_Banner_Details.aspx.vb" Inherits="Admin_Banner_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titleArea">
        <div class="wrapper">
            <div class="pageTitle">
                <h5>배너 추가</h5>
            </div>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="line"></div>
    <form id="form1" role="form" class="form" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="wrapper">
        <fieldset>
            <div class="widget">
                <asp:Label ID="lblErr_Msg" runat="server" Text="" ForeColor="Red"></asp:Label>
                <div class="title">
                    <h6>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label></h6>
                </div>
                 <div class="formRow" id="divMode" runat="server">
                    <label style="font-size: small">
                       배너 이름(선택사항) :</label>
                    <div class="formRight">
                         <asp:TextBox ID="txtBannerName" CssClass="form-control required" runat="server" ></asp:TextBox>
                    </div>
                </div>
                
                <div class="formRow">
                    <label style="font-size: small">
                        카테고리 :</label>
                    <div class="formRight">
                       
                            <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="CategoryName" DataValueField="RECID"></asp:DropDownList>
                    </div>
                            
                       
                    
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        배너 업로드 :<br />(.jpg/ .png/ .gif) 가능</label>
                    <div class="formRight">
                       
                            <asp:FileUpload ID="ruImage" CssClass="form-control required" runat="server" />
                            <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="Images/icon-cross.png"  Height="20" Width="20" visible="false"/>
                            <asp:Label ID="lblBannerImage" runat="server" Text="이미지 없음."></asp:Label>
                    </div>
                            
                       
                    
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        세로 :</label>
                    <div class="formRight">
                       
                            <asp:TextBox ID="txtBanner_Height" CssClass="form-control required" runat="server"></asp:TextBox> pixel
                            
                    </div>
                            
                       
                    
                </div>
                <div class="formRow">
                    <label style="font-size: small">
                        가로 :</label>
                    <div class="formRight">
                       
                            <asp:TextBox ID="txtBanner_Width" CssClass="form-control required" runat="server"></asp:TextBox> pixel
                            
                    </div>
                            
                       
                    
                </div>
                <div class="formRow">
                            <label style="font-size: small">
                               상태 : </label>
                            <div class="formRight">
                                
                                    <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="A" Selected="True">활성화</asp:ListItem>
                                        <asp:ListItem Value="I">비활성화</asp:ListItem>
                                    </asp:RadioButtonList>
                                
                            </div>
                </div>
                
                

                
                
               
                <div class="formSubmit">
                    <asp:Button ID="btnSave" runat="server" Text="저장" class="button basic tipS" style="margin: 5px"/>&nbsp<a href="Admin_Banner_Listing.aspx" class="button basic tipS" style="margin: 5px;padding: 8px 18px 8px 18px;">취소</a>
                    
                </div>
                </div>
          
        </fieldset>
    </div>
    </form>
    

</asp:Content>

