Imports System.Data
Imports System.Data.SqlClient
Imports commonfunc

Partial Class Player_Details
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

            LoadBank()
            LoadAff()

            If Len(Request.QueryString("id")) > 0 Then
                lblTitle.Text = "회원정보"
                txtLoginID.ReadOnly = True
                txtNickname.ReadOnly = True
                txtEmail.ReadOnly = True
                txtContactNo.ReadOnly = True
                ddlBank.Enabled = False
                txtBankAccountHolderName.ReadOnly = True
                txtBankAccountNo.ReadOnly = True
                txtBankBranch.ReadOnly = True
                txtBankProvince.ReadOnly = True
                txtBankCity.ReadOnly = True
                ddlAffCode.Enabled = False
                btnSave.Visible = False
                btnUpdate.Visible = False
                divPassword.Visible = False
                divConfirmPassword.Visible = False
                LoadContent(Request.QueryString("id").ToString())
            Else
                lblTitle.Text = "Add Player"
            End If

            If Len(Request.QueryString("mode")) > 0 Then
                lblTitle.Text = "Edit Player"
                txtEmail.ReadOnly = False
                txtContactNo.ReadOnly = False
                ddlBank.Enabled = True
                txtBankAccountHolderName.ReadOnly = False
                txtBankAccountNo.ReadOnly = False
                txtBankBranch.ReadOnly = False
                txtBankProvince.ReadOnly = False
                txtBankCity.ReadOnly = False
                ddlAffCode.Enabled = True
                btnUpdate.Visible = True
            End If

            If Session("LoginID") <> "krsuperadmin" And Session("LoginID") <> "sunny" Then
                txtEmail.ReadOnly = True
                txtContactNo.ReadOnly = True
                ddlBank.Enabled = False
                txtBankAccountHolderName.ReadOnly = True
                txtBankAccountNo.ReadOnly = True
                txtBankBranch.ReadOnly = True
                txtBankProvince.ReadOnly = True
                txtBankCity.ReadOnly = True
                ddlAffCode.Enabled = False
                btnUpdate.Visible = False
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
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("kr_player_details").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = strRECID
            sqlcommand.Parameters.Add(New SqlParameter("@Username", SqlDbType.NVarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Mobile_Username", SqlDbType.NVarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Nickname", SqlDbType.NVarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankRECID", SqlDbType.UniqueIdentifier)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankHolder", SqlDbType.NVarChar, 500)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankNo", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankBranch", SqlDbType.NVarChar, 100)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankProvince", SqlDbType.NVarChar, 100)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankCity", SqlDbType.NVarChar, 100)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@RegDate", SqlDbType.DateTime, 100)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@AffCode", SqlDbType.UniqueIdentifier)).Direction = ParameterDirection.Output

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            If IsDBNull(sqlcommand.Parameters("@Username").Value) = False Then
                txtLoginID.Text = sqlcommand.Parameters("@Username").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@Nickname").Value) = False Then
                txtNickname.Text = sqlcommand.Parameters("@Nickname").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@RegDate").Value) = False Then
                lblRegDate.Text = Format(sqlcommand.Parameters("@RegDate").Value, "dd/MMM/yyyy")
            End If

            If IsDBNull(sqlcommand.Parameters("@Email").Value) = False Then
                txtEmail.Text = sqlcommand.Parameters("@Email").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@ContactNo").Value) = False Then
                If Session("ContactDetail") Then
                    txtContactNo.Text = sqlcommand.Parameters("@ContactNo").Value
                Else
                    txtContactNo.Text = "**********"

                    Session("PlayerContactNo") = sqlcommand.Parameters("@ContactNo").Value
                End If
            End If

            If IsDBNull(sqlcommand.Parameters("@BankRECID").Value) = False Then
                For Each item As ListItem In ddlBank.Items
                    Dim split As Array = item.Value.ToString.Split(",")

                    'verify the value is split to 3 values
                    If split.GetUpperBound(0) = 2 Then
                        'get 2nd item which is 1 as array are 0 based
                        If UCase(split(0)) = UCase(sqlcommand.Parameters("@BankRECID").Value.ToString) Then
                            ddlBank.SelectedValue = item.Value
                            Exit For
                        End If
                    End If
                Next
            End If

            If IsDBNull(sqlcommand.Parameters("@BankHolder").Value) = False Then
                txtBankAccountHolderName.Text = sqlcommand.Parameters("@BankHolder").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@BankNo").Value) = False Then
                txtBankAccountNo.Text = sqlcommand.Parameters("@BankNo").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@BankBranch").Value) = False Then
                txtBankBranch.Text = sqlcommand.Parameters("@BankBranch").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@BankProvince").Value) = False Then
                txtBankProvince.Text = sqlcommand.Parameters("@BankProvince").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@BankCity").Value) = False Then
                txtBankCity.Text = sqlcommand.Parameters("@BankCity").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@AffCode").Value) = False Then
                ddlAffCode.SelectedValue = sqlcommand.Parameters("@AffCode").Value.ToString()
            End If

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strPlayer_Username As String
        Dim strPlayer_Mobile_Username As String
        Dim strPlayer_Nickname As String
        Dim strPlayer_Fullname As String
        Dim strPlayer_Email As String
        Dim strPlayer_ContactNo As String
        Dim strPassword As String
        Dim strUserName As String
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strScript As String
        Dim strAffiliateRECID As Guid
        Dim strArray_Bank() As String
        Dim strBankRECID As Guid
        Dim strBankName As String
        Dim strBankCode As String
        Dim strBankHolder As String
        Dim strBankNo As String
        Dim strBankBranch As String
        Dim strBankProvince As String
        Dim strBankCity As String
        Dim strStatus As String
        Dim strMessage As String

        Try
            If Len(txtLoginID.Text) > 0 Then
                strPlayer_Username = txtLoginID.Text
                strPlayer_Mobile_Username = "sbp" + strPlayer_Username
            End If

            If Len(txtPassword.Text) > 0 Then
                strPassword = txtPassword.Text
            End If

            If Len(txtNickname.Text) > 0 Then
                strPlayer_Nickname = txtNickname.Text
            End If

            If Len(txtContactNo.Text) > 0 Then
                If Session("ContactDetail") Then
                    strPlayer_ContactNo = txtContactNo.Text
                Else
                    strPlayer_ContactNo = Session("PlayerContactNo")
                End If
            End If

            If Len(txtEmail.Text) > 0 Then
                strPlayer_Email = txtEmail.Text
            End If

            If Session("LoginID") IsNot Nothing Then
                strUserName = Session("LoginID")
            End If

            If Session("LoginRECID") IsNot Nothing Then
                strAffiliateRECID = Session("LoginRECID")
            End If

            If ddlBank.SelectedIndex > 0 Then
                strArray_Bank = ddlBank.SelectedValue.Split(",")
                strBankRECID = Guid.Parse(strArray_Bank(0))
                strBankName = ddlBank.SelectedItem.Text
                strBankCode = strArray_Bank(2)
            End If

            If Len(txtBankAccountHolderName.Text) > 0 Then
                strBankHolder = txtBankAccountHolderName.Text
                strPlayer_Fullname = strBankHolder
            End If

            If Len(txtBankAccountNo.Text) > 0 Then
                strBankNo = txtBankAccountNo.Text
            End If

            If Len(txtBankBranch.Text) > 0 Then
                strBankBranch = txtBankBranch.Text
            End If

            If Len(txtBankProvince.Text) > 0 Then
                strBankProvince = txtBankProvince.Text
            End If

            If Len(txtBankCity.Text) > 0 Then
                strBankCity = txtBankCity.Text
            End If

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_insert_player").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@AffiliateRECID", SqlDbType.UniqueIdentifier)).Value = strAffiliateRECID
            sqlcommand.Parameters.Add(New SqlParameter("@Player_Username", SqlDbType.NVarChar, 50)).Value = strPlayer_Username
            sqlcommand.Parameters.Add(New SqlParameter("@Player_Mobile_Username", SqlDbType.NVarChar, 50)).Value = strPlayer_Mobile_Username
            sqlcommand.Parameters.Add(New SqlParameter("@Player_Nickname", SqlDbType.NVarChar, 50)).Value = strPlayer_Nickname
            sqlcommand.Parameters.Add(New SqlParameter("@Player_Fullname", SqlDbType.NVarChar, 50)).Value = strPlayer_Fullname
            sqlcommand.Parameters.Add(New SqlParameter("@Player_Email", SqlDbType.VarChar, 50)).Value = strPlayer_Email
            sqlcommand.Parameters.Add(New SqlParameter("@Player_ContactNo", SqlDbType.VarChar, 50)).Value = strPlayer_ContactNo
            sqlcommand.Parameters.Add(New SqlParameter("@BankRECID", SqlDbType.UniqueIdentifier)).Value = strBankRECID
            sqlcommand.Parameters.Add(New SqlParameter("@BankName", SqlDbType.NVarChar, 50)).Value = strBankName
            sqlcommand.Parameters.Add(New SqlParameter("@BankHolder", SqlDbType.NVarChar, 500)).Value = strBankHolder
            sqlcommand.Parameters.Add(New SqlParameter("@BankNo", SqlDbType.VarChar, 50)).Value = strBankNo
            sqlcommand.Parameters.Add(New SqlParameter("@BankCode", SqlDbType.VarChar, 10)).Value = strBankCode
            sqlcommand.Parameters.Add(New SqlParameter("@BankBranch", SqlDbType.NVarChar, 100)).Value = strBankBranch
            sqlcommand.Parameters.Add(New SqlParameter("@BankProvince", SqlDbType.NVarChar, 100)).Value = strBankProvince
            sqlcommand.Parameters.Add(New SqlParameter("@BankCity", SqlDbType.NVarChar, 100)).Value = strBankCity
            sqlcommand.Parameters.Add(New SqlParameter("@UserName", SqlDbType.VarChar, 50)).Value = strUserName

            idnpoker.register(strPlayer_Username, strPlayer_Nickname, strPassword, strBankCode, strBankHolder, strBankNo, strBankBranch, strBankProvince, strBankCity, strStatus, strMessage)

            If strStatus = "1" Then
                'idnpoker.registerMobile(strPlayer_Username, strPlayer_Mobile_Username, strStatus, strMessage)

                'If strStatus = "1" Then
                adapter = New SqlDataAdapter(sqlcommand)
                adapter.Fill(ds)

                strScript = "<script language=""javascript"">alert('New player added successfully !!');window.location.href='Player_Listing.aspx';</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)
                'Else
                '    lblErr_Msg.Text = strMessage
                'End If

            Else
                lblErr_Msg.Text = strMessage
            End If

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

    Private Sub LoadAff()
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
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_get_affcode").ToString
            sqlcommand.Parameters.Add(New SqlParameter("@CountryRECID", SqlDbType.UniqueIdentifier)).Value = CountryRECID

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(dt)

            ddlAffCode.DataSource = dt
            ddlAffCode.DataBind()
            ddlAffCode.Items.Insert(0, New ListItem("-Select Code-", ""))

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strScript As String
        Dim strPlayer_Fullname As String
        Dim strPlayer_Email As String
        Dim strPlayer_ContactNo As String
        Dim strArray_Bank() As String
        Dim strBankRECID As Guid
        Dim strBankName As String
        Dim strBankCode As String
        Dim strBankHolder As String
        Dim strBankNo As String
        Dim strBankBranch As String
        Dim strBankProvince As String
        Dim strBankCity As String

        If Len(txtContactNo.Text) > 0 Then
            strPlayer_ContactNo = txtContactNo.Text
        End If

        If Len(txtEmail.Text) > 0 Then
            strPlayer_Email = txtEmail.Text
        End If

        If ddlBank.SelectedIndex > 0 Then
            strArray_Bank = ddlBank.SelectedValue.Split(",")
            strBankRECID = Guid.Parse(strArray_Bank(0))
            strBankName = ddlBank.SelectedItem.Text
            strBankCode = strArray_Bank(2)
        End If

        If Len(txtBankAccountHolderName.Text) > 0 Then
            strBankHolder = txtBankAccountHolderName.Text
            strPlayer_Fullname = strBankHolder
        End If

        If Len(txtBankAccountNo.Text) > 0 Then
            strBankNo = txtBankAccountNo.Text
        End If

        If Len(txtBankBranch.Text) > 0 Then
            strBankBranch = txtBankBranch.Text
        End If

        If Len(txtBankProvince.Text) > 0 Then
            strBankProvince = txtBankProvince.Text
        End If

        If Len(txtBankCity.Text) > 0 Then
            strBankCity = txtBankCity.Text
        End If

        cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
        sqlConn = New SqlConnection(cs)

        sqlConn.Open()
        SqlCommand.Connection = sqlConn
        SqlCommand.CommandType = CommandType.StoredProcedure
        sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_update_player").ToString

        sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(Request.QueryString("id"))
        sqlcommand.Parameters.Add(New SqlParameter("@Player_Fullname", SqlDbType.NVarChar, 50)).Value = strPlayer_Fullname
        sqlcommand.Parameters.Add(New SqlParameter("@Player_Email", SqlDbType.VarChar, 50)).Value = strPlayer_Email
        sqlcommand.Parameters.Add(New SqlParameter("@Player_ContactNo", SqlDbType.VarChar, 50)).Value = strPlayer_ContactNo
        sqlcommand.Parameters.Add(New SqlParameter("@BankRECID", SqlDbType.UniqueIdentifier)).Value = strBankRECID
        sqlcommand.Parameters.Add(New SqlParameter("@BankName", SqlDbType.NVarChar, 50)).Value = strBankName
        sqlcommand.Parameters.Add(New SqlParameter("@BankHolder", SqlDbType.NVarChar, 500)).Value = strBankHolder
        sqlcommand.Parameters.Add(New SqlParameter("@BankNo", SqlDbType.VarChar, 50)).Value = strBankNo
        sqlcommand.Parameters.Add(New SqlParameter("@BankCode", SqlDbType.VarChar, 10)).Value = strBankCode
        sqlcommand.Parameters.Add(New SqlParameter("@BankBranch", SqlDbType.NVarChar, 100)).Value = strBankBranch
        sqlcommand.Parameters.Add(New SqlParameter("@BankProvince", SqlDbType.NVarChar, 100)).Value = strBankProvince
        sqlcommand.Parameters.Add(New SqlParameter("@BankCity", SqlDbType.NVarChar, 100)).Value = strBankCity
        sqlcommand.Parameters.Add(New SqlParameter("@AffCode", SqlDbType.UniqueIdentifier, 50)).Value = Guid.Parse(ddlAffCode.SelectedValue)

        Adapter = New SqlDataAdapter(SqlCommand)
        Adapter.Fill(ds)

        strScript = "<script language=""javascript"">alert('Player update successfully !!');window.location.href='Player_Listing.aspx';</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)
    End Sub
End Class
