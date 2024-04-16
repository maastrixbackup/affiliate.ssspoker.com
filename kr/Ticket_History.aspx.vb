
Imports System.Data
Imports System.Data.SqlClient

Partial Class Ticket_History
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

            'sqlcommand.Parameters.Add(New SqlParameter("@status", SqlDbType.VarChar, 5)).Value = ""
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
End Class
