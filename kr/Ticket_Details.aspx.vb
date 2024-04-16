
Imports System.Data
Imports System.Data.SqlClient

Partial Class Ticket_Details
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim strRECID As String = Request.QueryString("id")
            LoadAffiliate()

            If ddlAffiliate.SelectedIndex > 0 Then
                LoadAffiliate(ddlAffiliate.SelectedValue)
            End If

            If Len(strRECID) > 0 Then
                lblTitle.Text = "View Ticket"
                LoadContent()

            Else
                lblTitle.Text = "신규 티켓"
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strAffiliateId As String
        Dim strPlayerId As String = ""
        Dim strUserName As String
        Dim ticketType As Int16
        Dim id As Int32 = 0
        Dim amount As Decimal
        Dim strScript As String

        Try
            If ddlAffiliate.SelectedIndex = 0 Then
                strScript = "<script language=""javascript"">alert('Save ticket Failed !! Please select an affiliate.');</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "saveTicketError", strScript)
                Return
            End If

            If rbDepoToWallet.Checked Then
                If String.Compare(txtDepoToWalletAmt.Text, String.Empty) = 0 Then
                    strScript = "<script language=""javascript"">alert('Save ticket Failed !! Please fill in a valid deposit amount.');</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "saveTicketError", strScript)
                    Return
                End If
            End If

            If rbDepoToPlayer.Checked Then
                If String.Compare(txtDepoToPlayer.Text, String.Empty) = 0 Then
                    strScript = "<script language=""javascript"">alert('Save ticket Failed !! Please fill in a player user ID.');</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "saveTicketError", strScript)
                    Return
                End If

                If String.Compare(txtdepoToPlayerAmt.Text, String.Empty) = 0 Then
                    strScript = "<script language=""javascript"">alert('Save ticket Failed !! Please fill in a valid deposit amount.');</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "saveTicketError", strScript)
                    Return
                End If

                If CheckGameId() = False Then
                    strScript = "<script language=""javascript"">alert('회원 입금 티켓 신청에 실패하였습니다. 회원 별명(User ID)을 다시 확인 하여 주시기 바랍니다.');</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "saveTicketError", strScript)
                    Return
                End If
            End If

            If String.IsNullOrEmpty(Request.QueryString("id")) = False Then
                id = CType(Request.QueryString("id"), Int32)
            End If

            strUserName = Session("LoginID")
            strAffiliateId = ddlAffiliate.SelectedValue.ToString()

            If rbDepoToWallet.Checked Then
                ticketType = 1
                amount = Convert.ToDouble(txtDepoToWalletAmt.Text)
            End If

            If rbDepoToPlayer.Checked Then
                ticketType = 2
                strPlayerId = txtDepoToPlayer.Text
                amount = Convert.ToDouble(txtdepoToPlayerAmt.Text)
            End If

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            If id > 0 Then
                sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_update_ticket").ToString
                sqlcommand.Parameters.Add(New SqlParameter("@ticketId", SqlDbType.BigInt)).Value = id

            Else
                sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_add_ticket").ToString
                sqlcommand.Parameters.Add(New SqlParameter("@AffliateId", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(strAffiliateId)
                sqlcommand.Parameters.Add(New SqlParameter("@TicketType", SqlDbType.Int)).Value = ticketType
                sqlcommand.Parameters.Add(New SqlParameter("@PlayerId", SqlDbType.VarChar, 50)).Value = strPlayerId.Trim().ToUpper()
                sqlcommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.Decimal, 18)).Value = amount
                sqlcommand.Parameters.Add(New SqlParameter("@Creator", SqlDbType.VarChar, 50)).Value = strUserName
            End If

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)
            sqlConn.Close()

            If id > 0 Then
                strScript = "<script language=""javascript"">alert('Ticket edited successfully !!');window.location.href='Ticket_History.aspx';</script>"
            Else
                strScript = "<script language=""javascript"">alert('티켓 신청이 완료 되었습니다.');window.location.href='Ticket_History.aspx';</script>"
            End If

            ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Private Function CheckGameId() As Boolean
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_check_gameid_by_affiliate").ToString
            sqlcommand.Parameters.Add(New SqlParameter("@fUserId", SqlDbType.NVarChar)).Value = txtDepoToPlayer.Text.Trim()
            sqlcommand.Parameters.Add(New SqlParameter("@fAffliate", SqlDbType.NVarChar)).Value = ddlAffiliate.SelectedItem.Text.Trim()

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)
            sqlConn.Close()

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If String.Compare(ds.Tables(0).Rows(0)(0).ToString(), txtDepoToPlayer.Text.Trim().ToUpper()) = 0 Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
            Return False
        End Try
    End Function

    Private Sub LoadAffiliate()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_get_affiliate_list").ToString
            sqlcommand.Parameters.Add(New SqlParameter("@CountryRECID", SqlDbType.UniqueIdentifier)).Value = IIf(Session("CountryRECID") Is Nothing, DBNull.Value, Session("CountryRECID"))

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)
            ddlAffiliate.DataSource = ds.Tables(0)
            ddlAffiliate.DataBind()
            ddlAffiliate.Items.Insert(0, ("--제휴 선택--"))

            If CType(Session("UserType"), Integer) > 0 Then
                ddlAffiliate.SelectedValue = Session("LoginRECID").ToString()
                ddlAffiliate.Enabled = False
            End If

            sqlConn.Close()

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message

        End Try
    End Sub

    Private Sub LoadAffiliate(strAffiliateId As String)
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_get_profile").ToString
            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(strAffiliateId)
            sqlcommand.Parameters.Add(New SqlParameter("@LoginID", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankRECID", SqlDbType.VarChar, 200)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankAccountHolderName", SqlDbType.NVarChar, -1)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@BankAccountNo", SqlDbType.Decimal, 18)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@FullName", SqlDbType.NVarChar, 200)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@WalletBalance", SqlDbType.Decimal, 18)).Direction = ParameterDirection.Output

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)
            lblAffBalance.Text = Convert.ToDecimal(sqlcommand.Parameters("@WalletBalance").Value).ToString("#,0.00")
            sqlConn.Close()

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message

        End Try
    End Sub

    Private Sub LoadContent()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim id As Int32

        id = Convert.ToInt32(Request.QueryString("id"))

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_get_ticket").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@affiliateId", SqlDbType.Int)).Value = id
            sqlcommand.Parameters.Add(New SqlParameter("@status", SqlDbType.UniqueIdentifier)).Value = ""
            sqlcommand.Parameters.Add(New SqlParameter("@ticketId", SqlDbType.BigInt)).Value = 0

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)
            sqlConn.Close()

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If CType(ds.Tables(0).Rows(0)("ticketType"), Integer) = 1 Then
                        rbDepoToWallet.Checked = True
                        txtDepoToWalletAmt.Text = Convert.ToDouble(ds.Tables(0).Rows(0)("amount")).ToString("#,#.00")

                    ElseIf CType(ds.Tables(0).Rows(0)("ticketType"), Integer) = 2 Then
                        rbDepoToPlayer.Checked = True
                        txtDepoToPlayer.Text = ds.Tables(0).Rows(0)("playerId").ToString()
                        txtdepoToPlayerAmt.Text = Convert.ToDouble(ds.Tables(0).Rows(0)("amount")).ToString("#,#.00")
                    End If
                End If
            End If

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Protected Sub ddlAffiliate_SelectedIndexChanged(sender As Object, e As EventArgs)
        lblAffBalance.Text = ""

        If ddlAffiliate.SelectedIndex > 0 Then
            LoadAffiliate(ddlAffiliate.SelectedValue)
        End If

    End Sub
End Class
