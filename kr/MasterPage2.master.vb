Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Partial Class MasterPage2
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim strUserType As String
            Dim strAff_Mode As String

            'Session("LoginID") = "krsuperadmin"
            'Session("UserType") = "0"
            'Session("LoginRECID") = "EDDCBA27-EA69-434E-BA3C-C16CE0D91449"

            If Session("LoginID") Is Nothing Or Session("UserType") Is Nothing Or Session("LoginRECID") Is Nothing Then
                Response.Redirect("session-expired.aspx")
            End If

            LoadNotification()

            If Session("UserType") IsNot Nothing Then
                strUserType = Session("UserType")
            End If

            If Session("Aff_Mode") IsNot Nothing Then
                strAff_Mode = Session("Aff_Mode")
            End If

            Select Case strUserType
                Case 0 '//superadmin
                    aHome.HRef = "Admin_Summary_Listing.aspx"
                    aUserList.Visible = True
                    aUploadCSV.Visible = True
                    aPlayerDetails.Visible = False
                    aProfile.Visible = False
                    'timerNewTicket.Enabled = True
                Case 1 '//master level
                    aHome.HRef = "Summary_Listing.aspx"
                    aBanner.Visible = False
                    aBannerDetails.Visible = False
                    aNotification.Visible = False
                    aNotificationDetails.Visible = False
                    aUserList.Visible = True
                    aAdd.Visible = False
                    aUploadCSV.Visible = False
                    aPlayerDetails.Visible = False
                    aTicket.Visible = False
                    'timerNewTicket.Enabled = False
                Case 2 '//first level
                    aHome.HRef = "Summary_Listing.aspx"
                    aBanner.Visible = False
                    aBannerDetails.Visible = False
                    aNotification.Visible = False
                    aNotificationDetails.Visible = False
                    aUserList.Visible = True
                    aAdd.Visible = False
                    aUploadCSV.Visible = False
                    aPlayerDetails.Visible = False
                    aTicket.Visible = False
                    'timerNewTicket.Enabled = False
                Case 3 '// second level
                    aHome.HRef = "Summary_Listing.aspx"
                    aBanner.Visible = False
                    aBannerDetails.Visible = False
                    aNotification.Visible = False
                    aNotificationDetails.Visible = False
                    aUserList.Visible = True
                    aAdd.Visible = False
                    aUploadCSV.Visible = False
                    aPlayerDetails.Visible = False
                    aTicket.Visible = False
                   'timerNewTicket.Enabled = False
                Case 4 '//third level
                    aHome.HRef = "Summary_Listing.aspx"
                    aBanner.Visible = False
                    aBannerDetails.Visible = False
                    aNotification.Visible = False
                    aNotificationDetails.Visible = False
                    aUserList.Visible = False
                    aAdd.Visible = False
                    aUploadCSV.Visible = False
                    aPlayerDetails.Visible = False
                    aTicket.Visible = False
                    'timerNewTicket.Enabled = False
                Case Else
                    aHome.HRef = "Summary_Listing.aspx"
                    aBanner.Visible = False
                    aBannerDetails.Visible = False
                    aNotification.Visible = False
                    aNotificationDetails.Visible = False
                    aUserList.Visible = False
                    aAdd.Visible = False
                    aUploadCSV.Visible = False
                    aPlayerDetails.Visible = False
                    aTicket.Visible = False
                    'timerNewTicket.Enabled = False
            End Select

            lblLoginID.InnerHtml = "Welcome, " + Session("LoginID")

        End If
    End Sub

    Protected Sub lnkLogout_Click(sender As Object, e As EventArgs) Handles lnkLogout.ServerClick

        Dim strScript As String

        strScript = "<script language=""javascript"">alert('Logout successfully !!');window.location.href='../default.aspx';</script>"

        Session.Clear()
        Session.Abandon()

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)
    End Sub

    Protected Sub LoadNotification()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim objDT As New DataTable
        Dim strNotification, strHTML As String

        cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
        sqlConn = New SqlConnection(cs)

        sqlConn.Open()
        sqlcommand.Connection = sqlConn
        sqlcommand.CommandType = CommandType.StoredProcedure
        sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_notification_list_after_Login").ToString

        adapter = New SqlDataAdapter(sqlcommand)
        adapter.Fill(objDT)

        For i As Integer = 0 To (objDT.Rows.Count - 1)
            strNotification = objDT.Rows(i)("Notification").ToString()
            strHTML += "<li>" + strNotification + "</li>"
        Next

        sqlcommand.Dispose()
        sqlConn.Close()
        sqlConn.Dispose()

        ltrNotification.Text = strHTML
    End Sub
End Class



