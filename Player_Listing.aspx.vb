Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Partial Class Player_Listing
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
        Dim strLoginID As String
        Dim strUserType As String
        Dim RECID As Guid

        If Session("LoginID") Is Nothing Or Session("UserType") Is Nothing Or Session("LoginRECID") Is Nothing Then
            Response.Redirect("session-expired.aspx")
        Else
            strLoginID = Session("LoginID")
            strUserType = Session("UserType")
            RECID = Session("LoginRECID")
        End If

        Try

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString_SBOPOKER").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("player_list").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@UserType", SqlDbType.VarChar, 5)).Value = strUserType
            sqlcommand.Parameters.Add(New SqlParameter("@LoginID", SqlDbType.VarChar, 50)).Value = strLoginID

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(dt)

            If strUserType = 0 Then
                Grid2.DataSource = dt
                Grid2.DataBind()
                Grid1.Visible = False
                Grid2.Visible = True
            Else
                Grid1.DataSource = dt
                Grid1.DataBind()
                Grid1.Visible = True
                Grid2.Visible = False
            End If
        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Protected Sub OnPaging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Grid1.PageIndex = e.NewPageIndex
        Grid2.PageIndex = e.NewPageIndex
        LoadGrid()
    End Sub

End Class
