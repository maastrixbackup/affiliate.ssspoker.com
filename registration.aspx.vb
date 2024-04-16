Imports System.Data.SqlClient
Imports System.Data

Partial Class registration
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim userAgent As String = Request.ServerVariables("HTTP_USER_AGENT")
        Dim OS As New Regex("(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        Dim device As New Regex("1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        Dim device_info As String = String.Empty

        If OS.IsMatch(userAgent) Then
            device_info = OS.Match(userAgent).Groups(0).Value
        End If

        If device.IsMatch(userAgent.Substring(0, 4)) Then
            device_info += device.Match(userAgent).Groups(0).Value
        End If

        If Not String.IsNullOrEmpty(device_info) Then
            Response.Redirect("/m/registration.aspx?aff=" + Request.QueryString("aff"))
        End If

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

        If Len(txtUsername.Text) > 0 Then
            strPlayer_Username = UCase(txtUsername.Text)
            strPlayer_Mobile_Username = "SBP" + strPlayer_Username
        End If

        If Len(txtPassword.Text) > 0 Then
            strPassword = txtPassword.Text
        End If

        If Len(txtNickname.Text) > 0 Then
            strPlayer_Nickname = UCase(txtNickname.Text)
        End If

        If Len(txtFullName.Text) > 0 Then
            strPlayer_Fullname = txtFullName.Text
        End If

        If Len(txtContactNo.Text) > 0 Then
            strPlayer_ContactNo = ddlContactNo.SelectedValue.ToString() & txtContactNo.Text
        End If

        If Len(txtEmail.Text) > 0 Then
            strPlayer_Email = txtEmail.Text
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

        If Len(txtBankName.Text) > 0 Then
            strBankHolder = txtBankName.Text
        End If

        If Len(txtBankAccount.Text) > 0 Then
            strBankNo = txtBankAccount.Text
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
