Imports System.Data
Imports System.Data.SqlClient
Imports commonfunc

Partial Class Profile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim strUserType As String = Session("UserType")
            Dim strAff_Mode As String = Session("Aff_Mode")

            If Session("UserType") Is Nothing Then
                Response.Redirect("session-expired.aspx")
            End If

            LoadBank()
            LoadContent(Session("LoginRECID").ToString())
        End If

    End Sub

    Private Sub LoadContent(Optional ByVal strLoginRECID As String = "")
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strRECID As Guid
        Dim strUserType As String = Session("UserType")

        strRECID = Guid.Parse(strLoginRECID)

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_get_profile").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = strRECID
            sqlcommand.Parameters.Add(New SqlParameter("@LoginID", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankRECID", SqlDbType.VarChar, 100)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankAccountHolderName", SqlDbType.NVarChar, -1)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankAccountNo", SqlDbType.Decimal, 18)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@FullName", SqlDbType.NVarChar, 200)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@WalletBalance", SqlDbType.Decimal, 18)).Direction = ParameterDirection.Output

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            If IsDBNull(sqlcommand.Parameters("@LoginID").Value) = False Then
                txtLoginID.Text = sqlcommand.Parameters("@LoginID").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@FullName").Value) = False Then
                txtFullName.Text = sqlcommand.Parameters("@FullName").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@Email").Value) = False Then
                txtEmail.Text = sqlcommand.Parameters("@Email").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@ContactNo").Value) = False Then
                txtContactNo.Text = sqlcommand.Parameters("@ContactNo").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@BankRECID").Value) = False Then
                ddlBank.SelectedValue = sqlcommand.Parameters("@BankRECID").Value.ToString
            End If

            If IsDBNull(sqlcommand.Parameters("@BankAccountHolderName").Value) = False Then
                txtBankAccountHolderName.Text = sqlcommand.Parameters("@BankAccountHolderName").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@BankAccountNo").Value) = False Then
                txtBankAccountNo.Text = sqlcommand.Parameters("@BankAccountNo").Value
            End If

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strUserName As String
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strScript As String
        Dim strRECID As Guid = Session("LoginRECID")
        Dim strArray_Bank() As String
        Dim BankRECID As Guid
        Dim strBankAccountHolderName As String
        Dim strBankAccountNo As String
        Dim CountryRECID As Guid
        Dim strFUllName As String
        Dim strEmail As String
        Dim strContactNo As String

        Try
            If Session("LoginID") IsNot Nothing Then
                strUserName = Session("LoginID")
            End If

            If ddlBank.SelectedIndex > 0 Then
                strArray_Bank = ddlBank.SelectedValue.Split(",")
                BankRECID = Guid.Parse(strArray_Bank(0))
            End If

            If Len(txtBankAccountHolderName.Text) > 0 Then
                strBankAccountHolderName = txtBankAccountHolderName.Text
            End If

            If Len(txtBankAccountNo.Text) > 0 Then
                strBankAccountNo = txtBankAccountNo.Text
            End If

            If Len(txtFullName.Text) > 0 Then
                strFUllName = txtFullName.Text
            End If

            If Len(txtEmail.Text) > 0 Then
                strEmail = txtEmail.Text
            End If

            If Len(txtContactNo.Text) > 0 Then
                strContactNo = txtContactNo.Text
            End If

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_update_profile").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = strRECID
            sqlcommand.Parameters.Add(New SqlParameter("@FullName", SqlDbType.NVarChar, 200)).Value = strFUllName
            sqlcommand.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar, 50)).Value = strEmail
            sqlcommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.VarChar, 50)).Value = strContactNo
            sqlcommand.Parameters.Add(New SqlParameter("@BankRECID", SqlDbType.UniqueIdentifier)).Value = BankRECID
            sqlcommand.Parameters.Add(New SqlParameter("@BankAccountHolderName", SqlDbType.NVarChar, -1)).Value = strBankAccountHolderName
            sqlcommand.Parameters.Add(New SqlParameter("@BankAccountNo", SqlDbType.Decimal, 18)).Value = strBankAccountNo
            sqlcommand.Parameters.Add(New SqlParameter("@UserName", SqlDbType.VarChar, 50)).Value = strUserName

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            strScript = "<script language=""javascript"">alert('Profile updated successfully !!');window.location.href='Summary_Listing.aspx';</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "cs_update_profile", strScript)

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Private Sub LoadBank()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim dt As New DataTable
        Dim CountryRECID As Guid

        Try
            CountryRECID = Session("CountryRECID")

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("get_bank").ToString
            sqlcommand.Parameters.Add(New SqlParameter("@CountryRECID", SqlDbType.UniqueIdentifier)).Value = CountryRECID

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(dt)

            ddlBank.DataSource = dt
            ddlBank.DataBind()
            ddlBank.Items.Insert(0, New ListItem("-Select Bank-", ""))

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub
End Class
