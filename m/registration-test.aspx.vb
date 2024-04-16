Imports System.Data.SqlClient
Imports System.Data

Partial Class registrationMobile2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            If Len(Request.QueryString("aff")) > 0 Then
                txtAffCode.Text = Request.QueryString("aff")
                txtAffCode.ReadOnly = True
                getCountry()
                LoadBank()
            End If
        End If
    End Sub

    Private Sub getCountry()
        Dim strAffCode As String = Request.QueryString("aff").ToString()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim dt As New DataTable

        cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
        sqlConn = New SqlConnection(cs)

        sqlConn.Open()
        sqlcommand.Connection = sqlConn
        sqlcommand.CommandType = CommandType.StoredProcedure
        sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_get_country_by_affcode").ToString
        sqlcommand.Parameters.Add(New SqlParameter("@AffCode", SqlDbType.VarChar)).Value = strAffCode

        adapter = New SqlDataAdapter(sqlcommand)
        adapter.Fill(dt)
        sqlConn.Close()

        Session("CountryRECID") = dt.Rows(0)(1)
        Session("AffRECID") = dt.Rows(0)(0)
    End Sub

    Private Sub LoadBank()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim dt As New DataTable
        Dim CountryRECID As Guid

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
        sqlConn.Close()

        ddlBank.DataSource = dt
        ddlBank.DataBind()
        ddlBank.Items.Insert(0, New ListItem("-Select Bank-", ""))
    End Sub

    Private Sub getGameUrl(affilaiteRECID As String, ByRef gameURL As String)
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim dt As New DataTable

        cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
        sqlConn = New SqlConnection(cs)

        sqlConn.Open()
        sqlcommand.Connection = sqlConn
        sqlcommand.CommandType = CommandType.StoredProcedure
        sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_get_game_url").ToString
        sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.VarChar)).Value = affilaiteRECID

        adapter = New SqlDataAdapter(sqlcommand)
        adapter.Fill(dt)
        sqlConn.Close()

        gameURL = dt.Rows(0)(0)
    End Sub

    Protected Sub btnSubmit_ServerClick(sender As Object, e As EventArgs)
        Dim strFromURL As String = Request.Url.Host()
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
        Dim strAffCode As String = Request.QueryString("aff").ToString()
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

        If Len(user_name.Text) > 0 Then
            strPlayer_Username = UCase(user_name.Text)
            strPlayer_Mobile_Username = "SBP" + strPlayer_Username
        End If

        If Len(the_pass.Text) > 0 Then
            strPassword = the_pass.Text
        End If

        If Len(user_nameid.Text) > 0 Then
            strPlayer_Nickname = UCase(user_nameid.Text)
        End If

        If Len(txtFullName.Text) > 0 Then
            strPlayer_Fullname = txtFullName.Text
        End If

        If Len(the_phone.Text) > 0 Then
            strPlayer_ContactNo = ddlContactNo.SelectedValue.ToString() & the_phone.Text
        End If

        If Len(the_email.Text) > 0 Then
            strPlayer_Email = the_email.Text
        End If

        If Session("AffRECID") IsNot Nothing Then
            strAffiliateRECID = Session("AffRECID")
        End If

        If ddlBank.SelectedIndex > 0 Then
            strArray_Bank = ddlBank.SelectedValue.Split(",")
            strBankRECID = Guid.Parse(strArray_Bank(0))
            strBankName = ddlBank.SelectedItem.Text
            strBankCode = strArray_Bank(2)
        End If

        If Len(the_baname.Text) > 0 Then
            strBankHolder = the_baname.Text
        End If

        If Len(the_bano.Text) > 0 Then
            strBankNo = the_bano.Text
        End If

        strUserName = strAffCode
        strBankBranch = "N/A"
        strBankProvince = "N/A"
        strBankCity = "N/A"

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
        sqlcommand.Parameters.Add(New SqlParameter("@Player_Fullname", SqlDbType.NVarChar, 50)).Value = strPlayer_Nickname
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

            sqlConn.Close()

            Dim strGameUrl As String = Request.Url.Host.Replace("com", "info")
            getGameUrl(strAffiliateRECID.ToString(), strGameUrl)

            'strScript = "<script language=""javascript"">alert('가입이 성공적으로 완료 되었습니다.');window.location.href='registration-done.aspx?from=" + strFromURL + "';</script>"
            strScript = "<script language=""javascript"">alert('가입이 성공적으로 완료 되었습니다.');window.location.href='http://" + strGameUrl + "';</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)
            'Else
            '    strScript = "<script language=""javascript"">alert('mobile: " & strMessage & "');</script>"
            '    ClientScript.RegisterStartupScript(Me.GetType(), "clientalert", strScript)
            'End If

        Else
            strScript = "<script language=""javascript"">alert('아이디가 중복 되었습니다.');</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "clientalert", strScript)
        End If
    End Sub

End Class
