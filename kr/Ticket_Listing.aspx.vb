
Imports System.Data
Imports System.Data.SqlClient

Partial Class Ticket_Listing
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lblTitle.Text = "티켓 내역"
            LoadAffiliate()
            LoadGrid()
        End If
    End Sub

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

    Private Sub LoadGrid()
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
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_get_ticket").ToString

            If ddlAffiliate.SelectedIndex > 0 Then
                sqlcommand.Parameters.Add(New SqlParameter("@affiliateId", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(ddlAffiliate.SelectedValue)
            End If

            If ddlStatus.SelectedIndex > 0 Then
                sqlcommand.Parameters.Add(New SqlParameter("@status", SqlDbType.VarChar, 5)).Value = ddlStatus.SelectedValue
            End If

            sqlcommand.Parameters.Add(New SqlParameter("@ticketId", SqlDbType.BigInt)).Value = 0

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)
            sqlConn.Close()

            Grid1.DataSource = ds.Tables(0)
            Grid1.DataBind()

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try

    End Sub

    Protected Sub lnkSearch_Click(sender As Object, e As EventArgs) Handles lnkSearch.Click
        LoadGrid()
    End Sub

    Protected Sub ApproveTicket(sender As Object, e As EventArgs)
        Dim myButton As HtmlAnchor = CType(sender, HtmlAnchor)
        Dim ticketId As String = myButton.Attributes("customdata").Split(","c)(0)
        Dim playerId As String = myButton.Attributes("customdata").Split(","c)(1)
        Dim depositAmt As String = myButton.Attributes("customdata").Split(","c)(2)
        Dim transactionId As String = playerId + ticketId.ToString()
        Dim amount As Decimal = Convert.ToDecimal(depositAmt)

        Dim cs As String
        Dim strScript As String
        Dim strStatus As String = "New"
        Dim strApiStatus As String = "Pen"
        Dim strApiRemarks As String = "Calling API"
        Dim strUserName As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet

        strUserName = Session("LoginID")

        cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
        sqlConn = New SqlConnection(cs)

        sqlConn.Open()
        sqlcommand.Connection = sqlConn
        sqlcommand.CommandType = CommandType.StoredProcedure
        sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_update_ticket").ToString
        sqlcommand.Parameters.Add(New SqlParameter("@ticketId", SqlDbType.BigInt)).Value = ticketId
        If playerId.Length > 0 Then
            sqlcommand.Parameters.Add(New SqlParameter("@updateType", SqlDbType.Int)).Value = 2
            sqlcommand.Parameters.Add(New SqlParameter("@apiStatus", SqlDbType.VarChar, 5)).Value = strApiStatus
            sqlcommand.Parameters.Add(New SqlParameter("@apiRemarks", SqlDbType.VarChar, 255)).Value = strApiRemarks
            sqlcommand.Parameters.Add(New SqlParameter("@status", SqlDbType.VarChar, 5)).Value = strStatus
        Else
            sqlcommand.Parameters.Add(New SqlParameter("@updateType", SqlDbType.Int)).Value = 1
            sqlcommand.Parameters.Add(New SqlParameter("@apiStatus", SqlDbType.VarChar, 5)).Value = ""
            sqlcommand.Parameters.Add(New SqlParameter("@apiRemarks", SqlDbType.VarChar, 255)).Value = ""
            sqlcommand.Parameters.Add(New SqlParameter("@status", SqlDbType.VarChar, 5)).Value = "APP"
        End If

        sqlcommand.Parameters.Add(New SqlParameter("@auditor", SqlDbType.VarChar, 50)).Value = strUserName
        adapter = New SqlDataAdapter(sqlcommand)
        adapter.Fill(ds)
        sqlConn.Close()

        If playerId.Length > 0 Then
            idnpoker.deposit(playerId, transactionId, amount, strApiStatus, strApiRemarks)

            If strApiStatus = "1" Then
                strStatus = "App"
                strScript = "<script language=""javascript"">alert('티켓을 승인 하였습니다.'); window.location.href='Ticket_Listing.aspx';</script>"

            Else
                strStatus = "Fail"
                strScript = "<script language=""javascript"">alert('" + strApiRemarks + "');</script>"
            End If

            sqlConn = New SqlConnection(cs)
            sqlcommand = New SqlCommand
            ds = New DataSet
            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_update_ticket").ToString
            sqlcommand.Parameters.Add(New SqlParameter("@ticketId", SqlDbType.BigInt)).Value = ticketId
            sqlcommand.Parameters.Add(New SqlParameter("@updateType", SqlDbType.Int)).Value = 3
            sqlcommand.Parameters.Add(New SqlParameter("@status", SqlDbType.VarChar, 5)).Value = strStatus
            sqlcommand.Parameters.Add(New SqlParameter("@apiStatus", SqlDbType.VarChar, 5)).Value = strApiStatus
            sqlcommand.Parameters.Add(New SqlParameter("@apiRemarks", SqlDbType.VarChar, 255)).Value = strApiRemarks
            sqlcommand.Parameters.Add(New SqlParameter("@auditor", SqlDbType.VarChar, 50)).Value = strUserName
            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)
            sqlConn.Close()
        Else
            strScript = "<script language=""javascript"">alert('티켓을 승인 하였습니다.'); window.location.href='Ticket_Listing.aspx';</script>"
        End If

        ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)
    End Sub

    Protected Sub RejectTicket(sender As Object, e As EventArgs)
        Dim myButton As HtmlAnchor = CType(sender, HtmlAnchor)
        Dim ticketId As String = myButton.Attributes("customdata")

        Dim cs As String
        Dim strScript As String
        Dim strStatus As String = "Rej"
        Dim strUserName As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet

        strUserName = Session("LoginID")

        cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
        sqlConn = New SqlConnection(cs)

        sqlConn.Open()
        sqlcommand.Connection = sqlConn
        sqlcommand.CommandType = CommandType.StoredProcedure
        sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_update_ticket").ToString
        sqlcommand.Parameters.Add(New SqlParameter("@ticketId", SqlDbType.BigInt)).Value = ticketId
        sqlcommand.Parameters.Add(New SqlParameter("@updateType", SqlDbType.Int)).Value = 1
        sqlcommand.Parameters.Add(New SqlParameter("@status", SqlDbType.VarChar, 5)).Value = strStatus
        sqlcommand.Parameters.Add(New SqlParameter("@apiStatus", SqlDbType.VarChar, 5)).Value = ""
        sqlcommand.Parameters.Add(New SqlParameter("@apiRemarks", SqlDbType.VarChar, 255)).Value = ""
        sqlcommand.Parameters.Add(New SqlParameter("@auditor", SqlDbType.VarChar, 50)).Value = strUserName
        adapter = New SqlDataAdapter(sqlcommand)
        adapter.Fill(ds)
        sqlConn.Close()

        strScript = "<script language=""javascript"">alert('티켓을 취소 하였습니다.'); window.location.href='Ticket_Listing.aspx';</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)
    End Sub
End Class
