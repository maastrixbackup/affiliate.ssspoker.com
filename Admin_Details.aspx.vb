Imports System.Data
Imports System.Data.SqlClient
Imports commonfunc

Partial Class Admin_Details
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
                    Response.Redirect("Admin_Listing.aspx")
                End If

            End If
            
            rblAff_Mode.SelectedValue = strAff_Mode
            LoadUserType()
            LoadCountry()
            LoadBank()

            If Len(Request.QueryString("id")) > 0 Then
                lblTitle.Text = "Edit User"
                txtLoginID.ReadOnly = True
                LoadContent(Request.QueryString("id").ToString())
            Else
                lblTitle.Text = "Add User"
            End If

            If strUserType = 0 Then
                rblAff_Mode.Enabled = True
                txtCommissionRate.ReadOnly = False
                divMode.Visible = True
            Else
                rblAff_Mode.Enabled = False
                txtCommissionRate.ReadOnly = True
                divMode.Visible = False
            End If

            ddlParent.Items.Insert(0, New ListItem("-Select Upper Affiliate-", ""))
            'ddlCommissionRate.Items.Insert(0, New ListItem("Select Rate", ""))
        End If

    End Sub

    Private Sub LoadContent(Optional ByVal strLoginRECID As String = "")
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strRECID As Guid
        Dim strValue As String
        Dim strParentRate() As String
        Dim strArray_Bank() As String
        Dim strBankImage As String
        Dim strUserType As String = Session("UserType")

        strRECID = Guid.Parse(strLoginRECID)

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("admin_details").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = strRECID
            sqlcommand.Parameters.Add(New SqlParameter("@LoginID", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Password", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@UserType", SqlDbType.VarChar, 5)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@CommissionRate", SqlDbType.Decimal, 3)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@ParentRECID", SqlDbType.VarChar, 100)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankRECID", SqlDbType.VarChar, 100)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankAccountHolderName", SqlDbType.VarChar, -1)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankAccountNo", SqlDbType.Decimal, 18)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@CountryRECID", SqlDbType.UniqueIdentifier)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Aff_Mode", SqlDbType.VarChar, 5)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Register_Url", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Game_Url", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            If IsDBNull(sqlcommand.Parameters("@LoginID").Value) = False Then
                txtLoginID.Text = sqlcommand.Parameters("@LoginID").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@UserType").Value) = False Then
                ddlUserType.SelectedValue = sqlcommand.Parameters("@UserType").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@CommissionRate").Value) = False Then
                Session("CommissionRate") = sqlcommand.Parameters("@CommissionRate").Value
                txtCommissionRate.Text = sqlcommand.Parameters("@CommissionRate").Value
                'ddlCommissionRate.SelectedValue = sqlcommand.Parameters("@CommissionRate").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@ParentRECID").Value) = False Then
                If ddlUserType.SelectedIndex > 0 Then
                    GetUpperUser()
                    ddlParent.SelectedValue = sqlcommand.Parameters("@ParentRECID").Value

                    strValue = sqlcommand.Parameters("@ParentRECID").Value
                    strParentRate = strValue.Split(",")
                    'LoadCommissionRate(strParentRate(1))
                    'ddlCommissionRate.SelectedValue = sqlcommand.Parameters("@CommissionRate").Value
                End If
            Else
                ddlParent.Items.Insert(0, New ListItem("Select Upper Affiliate", ""))
                ddlParent.Enabled = False
            End If

            If IsDBNull(sqlcommand.Parameters("@CountryRECID").Value) = False Then
                ddlCountry.SelectedValue = sqlcommand.Parameters("@CountryRECID").Value.ToString
                LoadBank()
            End If

            If IsDBNull(sqlcommand.Parameters("@BankRECID").Value) = False Then
                ddlBank.SelectedValue = sqlcommand.Parameters("@BankRECID").Value.ToString
                'ddlBank.Enabled = False
                strArray_Bank = ddlBank.SelectedValue.Split(",")
                If ddlBank.SelectedIndex > 0 Then
                    strBankImage = strArray_Bank(1)
                    ImgBank.Visible = True
                    ImgBank.Src = "Images/Bank/" + strBankImage
                Else
                    ImgBank.Visible = False
                    ImgBank.Src = ""
                End If

            End If

            If IsDBNull(sqlcommand.Parameters("@BankAccountHolderName").Value) = False Then
                txtBankAccountHolderName.Text = sqlcommand.Parameters("@BankAccountHolderName").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@BankAccountNo").Value) = False Then
                txtBankAccountNo.Text = sqlcommand.Parameters("@BankAccountNo").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@Aff_Mode").Value) = False Then
                rblAff_Mode.SelectedValue = sqlcommand.Parameters("@Aff_Mode").Value.ToString
            End If

            If strUserType = 0 Then
                ddlBank.Enabled = True
                txtBankAccountHolderName.ReadOnly = False
                txtBankAccountNo.ReadOnly = False
                ddlCountry.Enabled = True
            Else
                ddlBank.Enabled = False
                txtBankAccountHolderName.ReadOnly = True
                txtBankAccountNo.ReadOnly = True
                ddlCountry.Enabled = False
            End If
            
        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strUserType As String
        Dim strLoginID As String
        Dim strPassword As String
        Dim strCommission As String
        Dim strParentRECID As String = vbNullString
        Dim strUserName As String
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strScript As String
        Dim bool_Err As Boolean = False
        Dim strRECID As String = Request.QueryString("id")
        Dim strRECID_1 As Guid = Guid.NewGuid()
        Dim strArray_UserType() As String
        Dim strArray_Parent() As String
        Dim strArray_Bank() As String
        Dim BankRECID As Guid
        Dim strBankAccountHolderName As String
        Dim strBankAccountNo As String
        Dim CountryRECID As Guid
        Dim strAff_Mode As String

        If Img_False.Visible = True Then
            lblErr_Msg.Text = "This Login Id is not available. Kindly input another one."
            Exit Sub
        Else
            lblErr_Msg.Text = ""
        End If

        If Len(strRECID) > 0 Then
            strRECID_1 = Guid.Parse(strRECID)

            GoTo SkipChecking
        Else

            If Len(txtPassword.Text) = 0 Then
                lblMsg_Password.Text = "Password is required."
                Exit Sub
            End If
        End If

        If Len(txtConfirmPassword.Text) > 0 Then
            ComparePassword(txtPassword.Text, txtConfirmPassword.Text, bool_Err)
        ElseIf Len(txtConfirmPassword.Text) = 0 Then
            lblMsg_ConfirmPassword.Text = "Confirm Password is required."
            Exit Sub
        End If
SkipChecking:
        'If Len(txtCommissionRate.Text) > 0 Then
        '    Select Case ddlUserType.SelectedIndex
        '        Case 1
        '            If txtCommissionRate.Text < 1 Or txtCommissionRate.Text > 33 Then
        '                lblMsg_CommissionRate.Text = "Commission rate should in range 1% - 33%."
        '                Exit Sub
        '            End If
        '        Case 2
        '            If txtCommissionRate.Text < 1 Or txtCommissionRate.Text > 27 Then
        '                lblMsg_CommissionRate.Text = "Commission rate should in range 1% - 27%."
        '                Exit Sub
        '            End If
        '        Case 3
        '            If txtCommissionRate.Text < 1 Or txtCommissionRate.Text > 22 Then
        '                lblMsg_CommissionRate.Text = "Commission rate should in range 1% - 22%."
        '                Exit Sub
        '            End If
        '    End Select
        'End If

        If bool_Err = True Then
            Exit Sub
        End If

        Try
            strAff_Mode = rblAff_Mode.SelectedValue

            If ddlUserType.SelectedIndex > 0 Then
                strArray_UserType = ddlUserType.SelectedValue.Split(",")
                strUserType = strArray_UserType(0)
            End If

            If Len(txtLoginID.Text) > 0 Then
                strLoginID = txtLoginID.Text
            End If

            If Len(txtCommissionRate.Text) > 0 Then
                strCommission = txtCommissionRate.Text
            End If

            If Session("LoginID") IsNot Nothing Then
                strUserName = Session("LoginID")
            End If

            If Len(txtPassword.Text) > 0 Then
                strPassword = GenerateHash(txtPassword.Text)
            Else
                strPassword = "-"
            End If

            If ddlCountry.SelectedIndex > 0 Then
                CountryRECID = Guid.Parse(ddlCountry.SelectedValue)
            End If

            If Convert.ToInt16(strUserType) > 1 Then
                If ddlParent.SelectedIndex = 0 Then
                    lblMsg_UpperLevel.Text = "Please select upper level affiliate."
                    Exit Sub
                Else
                    strArray_Parent = ddlParent.SelectedValue.Split(",")
                    strParentRECID = strArray_Parent(0)
                End If
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

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            If Len(strRECID) > 0 Then
                sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("update_admin").ToString
            Else
                sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("insert_admin").ToString
            End If

            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = strRECID_1
            sqlcommand.Parameters.Add(New SqlParameter("@UserType", SqlDbType.VarChar, 5)).Value = strUserType
            sqlcommand.Parameters.Add(New SqlParameter("@LoginID", SqlDbType.VarChar, 50)).Value = strLoginID
            sqlcommand.Parameters.Add(New SqlParameter("@Password", SqlDbType.VarChar, 50)).Value = strPassword
            sqlcommand.Parameters.Add(New SqlParameter("@CommissionRate", SqlDbType.Decimal, 3)).Value = strCommission
            If strParentRECID <> vbNullString Then
                sqlcommand.Parameters.Add(New SqlParameter("@ParentRECID", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(strParentRECID)
            End If
            sqlcommand.Parameters.Add(New SqlParameter("@BankRECID", SqlDbType.UniqueIdentifier)).Value = BankRECID
            sqlcommand.Parameters.Add(New SqlParameter("@BankAccountHolderName", SqlDbType.VarChar, -1)).Value = strBankAccountHolderName
            sqlcommand.Parameters.Add(New SqlParameter("@BankAccountNo", SqlDbType.Decimal, 18)).Value = strBankAccountNo
            sqlcommand.Parameters.Add(New SqlParameter("@UserName", SqlDbType.VarChar, 50)).Value = strUserName
            sqlcommand.Parameters.Add(New SqlParameter("@CountryRECID", SqlDbType.UniqueIdentifier)).Value = CountryRECID
            sqlcommand.Parameters.Add(New SqlParameter("@Aff_Mode", SqlDbType.VarChar, 5)).Value = strAff_Mode
            sqlcommand.Parameters.Add(New SqlParameter("@Register_Url", SqlDbType.VarChar, 50)).Value = "N/A"
            sqlcommand.Parameters.Add(New SqlParameter("@Game_Url", SqlDbType.VarChar, 50)).Value = "N/A"

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            If Len(strRECID) > 0 Then
                strScript = "<script language=""javascript"">alert('user edited successfully !!');window.location.href='Admin_Listing.aspx';</script>"
            Else
                strScript = "<script language=""javascript"">alert('New user added successfully !!');window.location.href='Admin_Listing.aspx';</script>"
            End If


            ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Private Sub ComparePassword(ByVal strPassword As String, ByVal strConfirmPassword As String, ByRef bool_Err As Boolean)
        If strPassword <> strConfirmPassword Then
            lblMsg_ConfirmPassword.Text = "Password not matched."
            bool_Err = True

        End If
    End Sub

    Protected Sub CheckLoginID(sender As Object, e As EventArgs) Handles txtLoginID.TextChanged
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strLoginID As String = txtLoginID.Text

        Try

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("login_id").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@LoginID", SqlDbType.VarChar, 50)).Value = strLoginID
            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Direction = ParameterDirection.Output

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            If txtLoginID.Text = "" Then
                Img_True.Visible = False
                Img_False.Visible = False
                Exit Sub
            End If

            If Len(sqlcommand.Parameters("@RECID").Value.ToString) = 0 Then
                Img_True.Visible = True
                Img_False.Visible = False
            Else
                Img_True.Visible = False
                Img_False.Visible = True
            End If


        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Protected Sub ddlUserType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUserType.SelectedIndexChanged
        ddlParent.Items.Clear()

        If ddlUserType.SelectedIndex > 0 Then
            If ddlUserType.SelectedValue = 1 Then
                GoTo SkipGetUpperUser
            End If
            GetUpperUser()
        End If
SkipGetUpperUser:

        If ddlParent.Items.Count = 0 Then
            If ddlUserType.SelectedIndex = 0 Or ddlUserType.SelectedIndex = 1 Then
                ddlParent.Items.Insert(0, New ListItem("Select Upper Affiliate", ""))
                ddlParent.Enabled = False
            Else
                ddlParent.Items.Insert(0, New ListItem("Select Upper Affiliate", ""))
                ddlParent.Enabled = True
            End If
            
        Else
            ddlParent.Enabled = True
            ddlParent.Items.Insert(0, New ListItem("Select Upper Affiliate", ""))
        End If

        Select Case ddlUserType.SelectedValue
            Case 1
                If ddlCountry.SelectedItem.Text = "Thailand" Then
                    txtCommissionRate.Text = "33"
                    'txtCommissionRate.ReadOnly = False
                Else
                    txtCommissionRate.Text = "33"
                    'txtCommissionRate.ReadOnly = True
                End If

            Case 2
                If ddlCountry.SelectedItem.Text = "Thailand" Then
                    txtCommissionRate.Text = "20"
                    'txtCommissionRate.ReadOnly = False
                Else
                    txtCommissionRate.Text = "27"
                    'txtCommissionRate.ReadOnly = True
                End If
            Case 3
                If ddlCountry.SelectedItem.Text = "Thailand" Then
                    txtCommissionRate.Text = "17"
                    'txtCommissionRate.ReadOnly = False
                Else
                    txtCommissionRate.Text = "22"
                    'txtCommissionRate.ReadOnly = True
                End If
            Case 4
                If ddlCountry.SelectedItem.Text = "Thailand" Then
                    txtCommissionRate.Text = ""
                    'txtCommissionRate.ReadOnly = False
                Else
                    txtCommissionRate.Text = "17"
                    'txtCommissionRate.ReadOnly = True
                End If
        End Select

        'LoadCommissionRate()
    End Sub

    Private Sub GetUpperUser()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim RECID As Guid
        Dim strUserType As String
        Dim CountryRECID As Guid

        Try
            If Session("UserType") IsNot Nothing Then
                strUserType = Session("UserType")
            End If

            If Session("LoginRECID") IsNot Nothing Then
                RECID = Session("LoginRECID")
            End If

            If ddlCountry.SelectedIndex > 0 Then
                CountryRECID = Guid.Parse(ddlCountry.SelectedValue)
            End If

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("upper_level_user").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@UserType", SqlDbType.VarChar, 5)).Value = strUserType
            sqlcommand.Parameters.Add(New SqlParameter("@SelectedUserType", SqlDbType.VarChar, 5)).Value = ddlUserType.SelectedValue.ToString()
            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = RECID
            sqlcommand.Parameters.Add(New SqlParameter("@CountryRECID", SqlDbType.UniqueIdentifier)).Value = CountryRECID

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            ddlParent.DataSource = ds.Tables(0)
            ddlParent.DataBind()

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Private Sub LoadUserType()
        Dim strUserType As String = Session("UserType")

        Select Case strUserType
            Case 0
                ddlUserType.Items.Insert(0, New ListItem("-User Type-", ""))
                ddlUserType.Items.Insert(1, New ListItem("Master", 1))
                ddlUserType.Items.Insert(2, New ListItem("First Level", 2))
                ddlUserType.Items.Insert(3, New ListItem("Second Level", 3))
                ddlUserType.Items.Insert(4, New ListItem("Third Level", 4))
            Case 1
                ddlUserType.Items.Insert(0, New ListItem("-User Type-", ""))
                ddlUserType.Items.Insert(1, New ListItem("First Level", 2))
                ddlUserType.Items.Insert(2, New ListItem("Second Level", 3))
                ddlUserType.Items.Insert(3, New ListItem("Third Level", 4))
            Case 2
                ddlUserType.Items.Insert(0, New ListItem("-User Type-", ""))
                ddlUserType.Items.Insert(1, New ListItem("Second Level", 3))
                ddlUserType.Items.Insert(2, New ListItem("Third Level", 4))
            Case Else
                ddlUserType.Items.Insert(0, New ListItem("-User Type-", ""))
                ddlUserType.Enabled = False
        End Select
    End Sub

    'Private Sub LoadCommissionRate(Optional strParentRate As String = "")
    '    Dim strUserType As String = Session("UserType")
    '    Dim intCnt As Integer
    '    Dim strArray() As String = ddlParent.SelectedValue.Split(",")
    '    Dim dcParentRate As Decimal

    '    If Len(strParentRate) > 0 Then
    '        dcParentRate = Convert.ToDecimal(strParentRate)
    '    End If
    '    'ddlCommissionRate.Items.Clear()

    '    '//if superadmin
    '    If strUserType = 0 Then
    '        Select Case ddlUserType.SelectedValue
    '            Case 1
    '                For intCnt = 0 To 33
    '                    ddlCommissionRate.Items.Insert(intCnt, New ListItem(intCnt, intCnt))
    '                Next
    '            Case 2
    '                If dcParentRate > 27 Then
    '                    For intCnt = 0 To 27
    '                        ddlCommissionRate.Items.Insert(intCnt, New ListItem(intCnt, intCnt))
    '                    Next
    '                Else
    '                    For intCnt = 0 To dcParentRate - 1
    '                        ddlCommissionRate.Items.Insert(intCnt, New ListItem(intCnt, intCnt))
    '                    Next
    '                End If
    '            Case 3
    '                If dcParentRate > 22 Then
    '                    For intCnt = 0 To 22
    '                        ddlCommissionRate.Items.Insert(intCnt, New ListItem(intCnt, intCnt))
    '                    Next
    '                Else
    '                    For intCnt = 0 To dcParentRate - 1
    '                        ddlCommissionRate.Items.Insert(intCnt, New ListItem(intCnt, intCnt))
    '                    Next
    '                End If
    '        End Select
    '    Else '//if normal user
    '        Select Case ddlUserType.SelectedValue
    '            Case 1
    '                For intCnt = 0 To 33
    '                    ddlCommissionRate.Items.Insert(intCnt, New ListItem(intCnt, intCnt))
    '                Next
    '            Case 2
    '                If dcParentRate > 27 Then
    '                    For intCnt = 0 To 27
    '                        ddlCommissionRate.Items.Insert(intCnt, New ListItem(intCnt, intCnt))
    '                    Next
    '                Else
    '                    For intCnt = 0 To dcParentRate - 1
    '                        ddlCommissionRate.Items.Insert(intCnt, New ListItem(intCnt, intCnt))
    '                    Next
    '                End If
    '            Case 3
    '                If dcParentRate > 22 Then
    '                    For intCnt = 0 To 22
    '                        ddlCommissionRate.Items.Insert(intCnt, New ListItem(intCnt, intCnt))
    '                    Next
    '                Else
    '                    For intCnt = 0 To dcParentRate - 1
    '                        ddlCommissionRate.Items.Insert(intCnt, New ListItem(intCnt, intCnt))
    '                    Next
    '                End If
    '        End Select
    '    End If

    'End Sub

    'Protected Sub ddlParent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlParent.SelectedIndexChanged
    '    Dim strArray() As String = ddlParent.SelectedValue.Split(",")

    '    LoadCommissionRate(strArray(1))
    'End Sub

    Private Sub LoadBank()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim dt As New DataTable
        Dim CountryRECID As Guid = Session("CountryRECID")
        Dim strUserType As String

        If Session("UserType") IsNot Nothing Then
            strUserType = Session("UserType")
        End If

        Try
            If ddlCountry.SelectedIndex > 0 Then
                CountryRECID = Guid.Parse(ddlCountry.SelectedValue.ToString)
            End If

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("get_bank").ToString

            'sqlcommand.Parameters.Add(New SqlParameter("@UserType", SqlDbType.VarChar, 5)).Value = strUserType
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

    Private Sub ddlBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBank.SelectedIndexChanged
        Dim strArray() As String = ddlBank.SelectedValue.Split(",")
        Dim strBankImage As String

        If ddlBank.SelectedIndex > 0 Then
            strBankImage = strArray(1)
            ImgBank.Visible = True
            ImgBank.Src = "Images/Bank/" + strBankImage
        Else
            ImgBank.Visible = False
            ImgBank.Src = ""
        End If

    End Sub

    Private Sub LoadCountry()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim dt As New DataTable
        Dim strUserType As String
        Dim CountryRECID As Guid
        'Dim strRECID As String = Request.QueryString("id")

        Try
            If Session("UserType") IsNot Nothing Then
                strUserType = Session("UserType")
            End If

            If Session("CountryRECID") IsNot Nothing Then
                CountryRECID = Session("CountryRECID")
            End If

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("get_country").ToString

            'sqlcommand.Parameters.Add(New SqlParameter("@UserType", SqlDbType.VarChar, 5)).Value = strUserType
            'sqlcommand.Parameters.Add(New SqlParameter("@CountryRECID", SqlDbType.UniqueIdentifier)).Value = CountryRECID

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(dt)

            ddlCountry.DataSource = dt
            ddlCountry.DataBind()
            ddlCountry.Items.Insert(0, New ListItem("-Select Country-", ""))

            If strUserType <> 0 Then
                ddlCountry.SelectedValue = CountryRECID.ToString
                ddlCountry.Enabled = False

                If ddlCountry.SelectedItem.Text = "Thailand" Then
                    txtCommissionRate.ReadOnly = False
                End If
            Else
                ddlCountry.Enabled = True
            End If

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Protected Sub ddlCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCountry.SelectedIndexChanged
        If ddlCountry.SelectedIndex > 0 Then
            '//if select thailand, remove third level
            If ddlCountry.SelectedItem.Text = "Thailand" Then
                ddlUserType.Items.RemoveAt(4)
            Else
                If ddlUserType.Items.FindByText("Third Level") Is Nothing Then
                    ddlUserType.Items.Insert(4, New ListItem("Third Level", 4))
                End If
            End If

            If ddlUserType.SelectedIndex > 0 Then
                Select Case ddlUserType.SelectedValue
                    Case 1 '//if master
                        If ddlCountry.SelectedItem.Text = "Thailand" Then
                            txtCommissionRate.Text = "33"
                            txtCommissionRate.ReadOnly = False
                        Else
                            If rblAff_Mode.SelectedValue = "1" Then
                                txtCommissionRate.ReadOnly = True
                            Else
                                txtCommissionRate.ReadOnly = False
                            End If
                            txtCommissionRate.Text = "35"
                            ddlUserType.Items.Insert(3, New ListItem("Third Level", 4))
                        End If
                    Case 2 '//if first level
                        If ddlCountry.SelectedItem.Text = "Thailand" Then
                            txtCommissionRate.Text = "20"
                            txtCommissionRate.ReadOnly = False
                        Else
                            If rblAff_Mode.SelectedValue = "1" Then
                                txtCommissionRate.ReadOnly = True
                            Else
                                txtCommissionRate.ReadOnly = False
                            End If
                            txtCommissionRate.Text = "27"
                            'txtCommissionRate.ReadOnly = True
                        End If
                    Case 3 '//if second level
                        If ddlCountry.SelectedItem.Text = "Thailand" Then
                            txtCommissionRate.Text = "17"
                            txtCommissionRate.ReadOnly = False
                        Else
                            If rblAff_Mode.SelectedValue = "1" Then
                                txtCommissionRate.ReadOnly = True
                            Else
                                txtCommissionRate.ReadOnly = False
                            End If
                            txtCommissionRate.Text = "22"
                            'txtCommissionRate.ReadOnly = True
                        End If
                    Case 4 '//if third level
                        If rblAff_Mode.SelectedValue = "1" Then
                            txtCommissionRate.ReadOnly = True
                        Else
                            txtCommissionRate.ReadOnly = False
                        End If
                        txtCommissionRate.Text = "17"
                End Select
            End If

        End If


        LoadBank()

    End Sub

    Protected Sub rblAff_Mode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblAff_Mode.SelectedIndexChanged
        If rblAff_Mode.SelectedValue = 1 Then
            txtCommissionRate.ReadOnly = True
        Else
            txtCommissionRate.ReadOnly = False
        End If         
    End Sub
End Class
