Imports System.Data.SqlClient
Imports System.Data

Partial Class get_kr_daily_report
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim strStatus As String = ""
            Dim strMessage As String = ""
            Dim strDate As String = Format(DateAdd(DateInterval.Day, -1, Now()), "M/d/yyyy")
            'Dim strDate As String = "11/14/2022"

            Dim isImport As Boolean = checkIsImport()
            'Dim isImport As Boolean = False

            If (isImport = False) Then
                idnpoker.getDailyReport(strDate, strStatus, strMessage)
                If strMessage.Length > 0 Then
                    Response.Write(strMessage)
                End If
            End If
        End If

    End Sub

    Private Function checkIsImport() As Boolean
        Dim import As Boolean = False

        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet

        cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
        sqlConn = New SqlConnection(cs)

        sqlConn.Open()
        sqlcommand.Connection = sqlConn
        sqlcommand.CommandType = CommandType.StoredProcedure
        sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_check_import_data").ToString

        sqlcommand.Parameters.Add(New SqlParameter("@countImport", SqlDbType.Int)).Direction = ParameterDirection.Output

        adapter = New SqlDataAdapter(sqlcommand)
        adapter.Fill(ds)
        If sqlcommand.Parameters("@countImport").Value > 0 Then
            import = True
        End If

        Return import
    End Function


End Class
