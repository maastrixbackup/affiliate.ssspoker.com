
Imports System.Data
Imports System.Data.SqlClient

Partial Public Class getapifunc
    Inherits System.Web.UI.Page

    <System.Web.Services.WebMethod()>
    Public Shared Function isNewTicket() As String
        Dim strRtn As String = "0"
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim objDT As New DataTable

        cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
        sqlConn = New SqlConnection(cs)

        sqlConn.Open()
        sqlcommand.Connection = sqlConn
        sqlcommand.CommandType = CommandType.StoredProcedure
        sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_get_ticket").ToString
        sqlcommand.Parameters.Add(New SqlParameter("@status", SqlDbType.VarChar, 5)).Value = "New"
        sqlcommand.Parameters.Add(New SqlParameter("@ticketId", SqlDbType.BigInt)).Value = 0

        adapter = New SqlDataAdapter(sqlcommand)
        adapter.Fill(objDT)
        strRtn = objDT.Rows.Count.ToString()

        sqlcommand.Dispose()
        sqlConn.Close()
        sqlConn.Dispose()

        Return strRtn
    End Function
End Class
