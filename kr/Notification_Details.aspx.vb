Imports System.Data
Imports System.Data.SqlClient
Imports commonfunc

Partial Class Notification_Details
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim strUserType As String = Session("UserType")
            Dim strAff_Mode As String = Session("Aff_Mode")

            If Session("UserType") Is Nothing Then
                Response.Redirect("session-expired.aspx")
            End If

            '//force non-admin(online type) out from this page
            If strUserType <> 0 Then
                If Session("Aff_Mode") = 1 Then
                    Response.Redirect("Player_Listing.aspx")
                End If
            End If

            If Len(Request.QueryString("id")) > 0 Then
                lblTitle.Text = "공지 수정"
                btnAdd.Visible = False
                LoadContent(Request.QueryString("id").ToString())
            Else
                lblTitle.Text = "공지 추가"
                btnSave.Visible = False
            End If
        End If

    End Sub

    Private Sub LoadContent(Optional ByVal strLoginRECID As String = "")
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strRECID As Guid = Guid.Parse(strLoginRECID)

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("kr_notification_details").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = strRECID
            sqlcommand.Parameters.Add(New SqlParameter("@Notification", SqlDbType.NVarChar, -1)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@IsAfterLogin", SqlDbType.Bit)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Status", SqlDbType.Bit)).Direction = ParameterDirection.Output
            
            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            If IsDBNull(sqlcommand.Parameters("@Notification").Value) = False Then
                txtNotification.Text = sqlcommand.Parameters("@Notification").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@IsAfterLogin").Value) = False Then
                rblDisplay.SelectedValue = sqlcommand.Parameters("@IsAfterLogin").Value.ToString()
            End If

            If IsDBNull(sqlcommand.Parameters("@Status").Value) = False Then
                rblStatus.SelectedValue = sqlcommand.Parameters("@Status").Value.ToString()
            End If

            sqlcommand.Dispose()
            sqlConn.Close()
            sqlConn.Dispose()

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim strUserName As String = Session("LoginID")
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strScript As String

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_insert_notification").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@Notification", SqlDbType.NVarChar, -1)).Value = txtNotification.Text.Trim()
            sqlcommand.Parameters.Add(New SqlParameter("@IsAfterLogin", SqlDbType.Bit)).Value = Convert.ToBoolean(rblDisplay.SelectedValue)
            sqlcommand.Parameters.Add(New SqlParameter("@Status", SqlDbType.Bit)).Value = Convert.ToBoolean(rblStatus.SelectedValue)
            sqlcommand.Parameters.Add(New SqlParameter("@Creator", SqlDbType.NVarChar, 50)).Value = strUserName

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            sqlcommand.Dispose()
            sqlConn.Close()
            sqlConn.Dispose()

            strScript = "<script language=""javascript"">alert('New notification added successfully !!');window.location.href='Notification.aspx';</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strUserName As String = Session("LoginID")
        Dim strRECID As String = Request.QueryString("id")
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strScript As String

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_update_notification").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(strRECID)
            sqlcommand.Parameters.Add(New SqlParameter("@Notification", SqlDbType.NVarChar, -1)).Value = txtNotification.Text.Trim()
            sqlcommand.Parameters.Add(New SqlParameter("@IsAfterLogin", SqlDbType.Bit)).Value = Convert.ToBoolean(rblDisplay.SelectedValue)
            sqlcommand.Parameters.Add(New SqlParameter("@Status", SqlDbType.Bit)).Value = Convert.ToBoolean(rblStatus.SelectedValue)
            sqlcommand.Parameters.Add(New SqlParameter("@Auditor", SqlDbType.VarChar, 50)).Value = strUserName
            sqlcommand.Parameters.Add(New SqlParameter("@AuditDate", SqlDbType.DateTime)).Value = Now()

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            sqlcommand.Dispose()
            sqlConn.Close()
            sqlConn.Dispose()

            strScript = "<script language=""javascript"">alert('Notification update successfully !!');window.location.href='Notification.aspx';</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub
End Class
