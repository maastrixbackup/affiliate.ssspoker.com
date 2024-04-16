Imports System.Data
Imports System.Data.SqlClient
Imports commonfunc
Imports System.Security.Cryptography

Partial Class Default_old
    Inherits System.Web.UI.Page

    Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Dim strURL As String = Request.Url.Host()
        Dim strReturnURL As String = ""

        'If strURL = "affiliate.ssspoker.com" Then
        '    Response.Redirect("under-maintenance.html")
        'Else
        '    Response.Redirect("index.html")
        'End If
        'Exit Sub

        If strURL = "affiliate.ssspoker.com" Or strURL = "localhost" Then
            Exit Sub
        End If


        'Dim param(1) As SqlParameter
        'Dim param_output(0) As String
        'Dim cmd As New SqlCommand
        'Dim cs As String
        'Dim sqlConn As SqlConnection
        'Dim sqlcommand As New SqlCommand
        'Dim dt As New DataTable

        'cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
        'sqlConn = New SqlConnection(cs)
        'strURL = strURL.Replace("www.", "")

        'sqlConn.Open()
        'SqlCommand.Connection = sqlConn
        'SqlCommand.CommandType = CommandType.StoredProcedure
        'SqlCommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_get_register_url").ToString
        'SqlCommand.Parameters.Add(New SqlParameter("@Register_Url", SqlDbType.VarChar, 50)).Value = strURL
        'SqlCommand.Parameters.Add(New SqlParameter("@AffCode", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output

        'SqlCommand.ExecuteNonQuery()
        'If Not IsDBNull(sqlcommand.Parameters("@AffCode").Value) Then
        'strReturnURL = "/home.aspx?aff=" + sqlcommand.Parameters("@AffCode").Value
        'Else
        'strReturnURL = "/home.aspx"
        'End If

        'sqlConn.Close()
        'If strReturnURL.Length > 0 Then
        'Response.Redirect(strReturnURL)
        'End If
        Response.Redirect("under-maintenance.html")

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
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
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_notification_list_before_Login").ToString

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
        End If
    End Sub

    Public Function func() As String
        Dim R As New Random
        Return R.Next(10000000, 99999999)
    End Function

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim param(1) As SqlParameter
        Dim param_output(0) As String
        Dim cmd As New SqlCommand
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim sqlcommand As New SqlCommand
        Dim dt As New DataTable
        Dim strUserType, strCountry As String
        Dim strLoginID As String = txtLoginID.Text
        Dim strPassword As String = txtPassword.Text

        Dim code As String = Session("VCode")
        If Len(strLoginID) = 0 Or Len(strPassword) = 0 Then
            lblMsg.Text = "Invalid Login ID or Password. Please Try Again."
            Exit Sub
        End If

        If txtCode.Text <> code Then
            lblMsg.Text = "Wrong captcha code"
            txtCode.Text = ""
            txtCode.Focus()
            Exit Sub
        End If

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("login").ToString

            '//add parameter and value
            sqlcommand.Parameters.Add(New SqlParameter("@Password", SqlDbType.VarChar, 50)).Value = GenerateHash(strPassword)
            sqlcommand.Parameters.Add(New SqlParameter("@LoginID", SqlDbType.VarChar, 50)).Value = strLoginID

            '//set parameter and direction
            sqlcommand.Parameters.Add(New SqlParameter("@UserType", SqlDbType.VarChar, 5)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@CommissionRate", SqlDbType.Decimal, 3)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@LoginRECID", SqlDbType.UniqueIdentifier)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@CountryRECID", SqlDbType.UniqueIdentifier)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Aff_Mode", SqlDbType.VarChar, 5)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Country", SqlDbType.VarChar, 5)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@ContactDetail", SqlDbType.Bit)).Direction = ParameterDirection.Output
            sqlcommand.ExecuteNonQuery()

            If IsDBNull(sqlcommand.Parameters("@UserType").Value) = False Then
                strUserType = sqlcommand.Parameters("@UserType").Value
                Session("UserType") = sqlcommand.Parameters("@UserType").Value
            Else
                lblMsg.ForeColor = Drawing.Color.Red
                lblMsg.Text = "Invalid Login ID or Password. Please Try Again."
            End If

            If IsDBNull(sqlcommand.Parameters("@LoginID").Value) = False Then
                Session("LoginID") = sqlcommand.Parameters("@LoginID").Value
            Else
                lblMsg.ForeColor = Drawing.Color.Red
                lblMsg.Text = "Invalid Login ID or Password. Please Try Again."
            End If

            If IsDBNull(sqlcommand.Parameters("@CommissionRate").Value) = False Then
                Session("CommissionRate") = sqlcommand.Parameters("@CommissionRate").Value
            Else
                lblMsg.ForeColor = Drawing.Color.Red
                lblMsg.Text = "Invalid Login ID or Password. Please Try Again."
            End If

            If IsDBNull(sqlcommand.Parameters("@LoginRECID").Value) = False Then
                Session("LoginRECID") = sqlcommand.Parameters("@LoginRECID").Value
            Else
                lblMsg.ForeColor = Drawing.Color.Red
                lblMsg.Text = "Invalid Login ID or Password. Please Try Again."
            End If

            If IsDBNull(sqlcommand.Parameters("@CountryRECID").Value) = False Then
                Session("CountryRECID") = sqlcommand.Parameters("@CountryRECID").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@Aff_Mode").Value) = False Then
                Session("Aff_Mode") = sqlcommand.Parameters("@Aff_Mode").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@Country").Value) = False Then
                strCountry = sqlcommand.Parameters("@Country").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@ContactDetail").Value) = False Then
                Session("ContactDetail") = sqlcommand.Parameters("@ContactDetail").Value
            End If

            If Len(strUserType) > 0 Then
                Select Case strUserType
                    Case 0       '//if superadmin
                        Select Case strCountry
                            Case "KR"
                                Response.Redirect("kr/Admin_Summary_Listing.aspx")
                            Case Else
                                Response.Redirect("Admin_Summary_Listing.aspx")
                        End Select

                    Case 1, 2, 3, 4    '//if normal user
                        Select Case strCountry
                            Case "KR"
                                Response.Redirect("kr/Summary_Listing.aspx")
                            Case Else
                                Response.Redirect("Summary_Listing.aspx")
                        End Select
                    Case Else
                        lblMsg.ForeColor = Drawing.Color.Red
                        lblMsg.Text = "Invalid Login ID or Password. Please Try Again."
                End Select
            End If
        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            sqlConn.Close()
        End Try


    End Sub

End Class
