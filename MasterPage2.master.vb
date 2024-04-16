Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Partial Class MasterPage2
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim strUserType As String
            Dim strAff_Mode As String

            If Session("LoginID") Is Nothing Or Session("UserType") Is Nothing Or Session("LoginRECID") Is Nothing Then
                Response.Redirect("session-expired.aspx")
            End If

            If Session("UserType") IsNot Nothing Then
                strUserType = Session("UserType")
            End If

            If Session("Aff_Mode") IsNot Nothing Then
                strAff_Mode = Session("Aff_Mode")
            End If


            Select Case strUserType
                Case 0 '//superadmin
                    aHome.HRef = "Admin_Summary_Listing.aspx"
                    aBanner.HRef = "Admin_Banner_Listing.aspx"
                    aBannerDetails.Visible = True
                    aUserList.Visible = True
                    aUploadCSV.Visible = True
                Case 1 '//master level
                    aHome.HRef = "Summary_Listing.aspx"
                    aBanner.HRef = "Banner_Listing.aspx"
                    aBannerDetails.Visible = False
                    aUserList.Visible = True
                    aAdd.Visible = True
                    aUploadCSV.Visible = False
                Case 2 '//first level
                    aHome.HRef = "Summary_Listing.aspx"
                    aBanner.HRef = "Banner_Listing.aspx"
                    aBannerDetails.Visible = False
                    aUserList.Visible = True
                    aAdd.Visible = True
                    aUploadCSV.Visible = False
                Case 3 '// second level
                    aHome.HRef = "Summary_Listing.aspx"
                    aBanner.HRef = "Banner_Listing.aspx"
                    aBannerDetails.Visible = False
                    aUserList.Visible = True
                    aAdd.Visible = False
                    aUploadCSV.Visible = False
                Case 4 '//third level
                    aHome.HRef = "Summary_Listing.aspx"
                    aBanner.HRef = "Banner_Listing.aspx"
                    aBannerDetails.Visible = False
                    aUserList.Visible = False
                    aAdd.Visible = True
                    aUploadCSV.Visible = False
                Case Else
                    aHome.HRef = "Summary_Listing.aspx"
                    aBanner.HRef = "Banner_Listing.aspx"
                    aBannerDetails.Visible = False
                    aUserList.Visible = False
                    aAdd.Visible = False
                    aUploadCSV.Visible = False
            End Select

            '//if not superadmin, check online/offline
            If strUserType <> 0 Then
                If strAff_Mode = 1 Then
                    aAdd.Visible = False
                Else
                    aAdd.Visible = True
                End If
            End If

            lblLoginID.Text = "Welcome, " + Session("LoginID")

        End If
    End Sub

    Protected Sub lnkLogout_Click(sender As Object, e As EventArgs) Handles lnkLogout.Click
        Dim strScript As String

        strScript = "<script language=""javascript"">alert('Logout successfully !!');window.location.href='default.aspx';</script>"

        Session.Clear()
        Session.Abandon()

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)
    End Sub

End Class

