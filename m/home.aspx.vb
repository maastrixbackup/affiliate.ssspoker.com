Imports System.Data
Imports System.Data.SqlClient

Partial Class homeMobile
    Inherits System.Web.UI.Page

    Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim dataset As New DataSet
        Dim url As String
        Dim aff As String

        url = Request.Url.Host().Replace("www.", "")
        aff = Request.QueryString("aff")

        cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
        sqlConn = New SqlConnection(cs)

        sqlConn.Open()
        sqlcommand.Connection = sqlConn
        sqlcommand.CommandType = CommandType.StoredProcedure
        sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_get_register_url").ToString

        sqlcommand.Parameters.Add(New SqlParameter("@Register_Url", SqlDbType.VarChar, 50)).Value = url
        sqlcommand.Parameters.Add(New SqlParameter("@AffCode", SqlDbType.VarChar, 50)).Value = aff

        adapter = New SqlDataAdapter(sqlcommand)
        adapter.Fill(dataset)

        If dataset.Tables(0).Rows.Count < 1 Then
            Response.Redirect("under-maintenance.html")
        End If

    End Sub


End Class
