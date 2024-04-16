Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Partial Class Notification
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            LoadGrid()
        End If
    End Sub

    Private Sub LoadGrid()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim dt As New DataTable

        If Session("LoginID") Is Nothing Or Session("UserType") Is Nothing Or Session("LoginRECID") Is Nothing Then
            Response.Redirect("session-expired.aspx")
        End If

        Try

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_notification_list").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@Notification", SqlDbType.NVarChar, -1)).Value = IIf(txtNotification.Text.Length > 0, txtNotification.Text.Trim(), DBNull.Value)
            sqlcommand.Parameters.Add(New SqlParameter("@Status", SqlDbType.Bit)).Value = Convert.ToBoolean(rblStatus.SelectedValue)

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(dt)

            Grid1.DataSource = dt
            Grid1.DataBind()

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Protected Sub OnPaging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Grid1.PageIndex = e.NewPageIndex
        LoadGrid()
    End Sub

    Protected Sub lnkSearch_Click(sender As Object, e As EventArgs) Handles lnkSearch.Click
        LoadGrid()
    End Sub
End Class
