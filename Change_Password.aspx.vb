Imports System.Data
Imports System.Data.SqlClient
Imports commonfunc

Partial Class ChangePassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim strUserType As String = Session("UserType")

            lblTitle.Text = "Change Password"
            LoadUser()

            If strUserType = 0 Then
                divDDLUser.Visible = True
            Else
                divDDLUser.Visible = False
            End If
        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strNewPassword As String = txtNewPassword.Text
        Dim strConPassword As String = txtConfirmPassword.Text
        Dim strUserType As String = Session("UserType")
        Dim strRECID As String
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim dt As New DataTable
        Dim bool_Err As Boolean
        Dim strScript As String

        Try
            If strUserType = 0 Then   '//if superadmin
                If ddlUser.SelectedIndex = 0 Then
                    lblErr_Msg.Text = "Please select a user."
                    Exit Sub
                End If

                strRECID = ddlUser.SelectedValue

            Else
                If Session("LoginRECID") IsNot Nothing Then
                    strRECID = Session("LoginRECID").ToString
                Else
                    lblErr_Msg.Text = "Error occurred. Please login again."
                    Exit Sub
                End If
            End If

            If Len(txtNewPassword.Text) = 0 Then
                'lblMsg_Password.ForeColor = Drawing.Color.Red
                lblMsg_Password.Text = "Password is required."
                Exit Sub
            End If

            If Len(txtConfirmPassword.Text) > 0 Then
                ComparePassword(txtNewPassword.Text, txtConfirmPassword.Text, bool_Err)
            ElseIf Len(txtConfirmPassword.Text) = 0 Then
                lblMsg_ConfirmPassword.ForeColor = Drawing.Color.Red
                lblMsg_ConfirmPassword.Text = "Confirm Password is required."
                Exit Sub
            End If

            If bool_Err = True Then
                Exit Sub
            End If

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("change_password").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(strRECID)
            sqlcommand.Parameters.Add(New SqlParameter("@Password", SqlDbType.VarChar, 50)).Value = GenerateHash(strNewPassword)

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(dt)

            If Len(strRECID) > 0 Then
                strScript = "<script language=""javascript"">alert('Password changed successfully !!');</script>"
            End If

            ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)
            ddlUser.SelectedIndex = 0

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        Finally
            'sqlConn.Close()
        End Try
    End Sub

    Private Sub LoadUser()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim dt As New DataTable

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("user_list").ToString

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(dt)
            ddlUser.DataSource = dt
            ddlUser.DataBind()
            ddlUser.Items.Insert(0, ("--Select User--"))

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        Finally
            sqlConn.Close()
        End Try
    End Sub

    Private Sub ComparePassword(ByVal strPassword As String, ByVal strConfirmPassword As String, ByRef bool_Err As Boolean)
        If strPassword <> strConfirmPassword Then
            lblMsg_ConfirmPassword.ForeColor = Drawing.Color.Red
            lblMsg_ConfirmPassword.Text = "Password not matched."
            bool_Err = True
        Else
            lblMsg_ConfirmPassword.Text = ""
            bool_Err = False
        End If
    End Sub

End Class
