Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports commonfunc
Imports System.Data.OleDb

Partial Class Admin_Details_Upload_CSV
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lblTitle.Text = "Upload Win/Loss"
        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strScript As String

        Try
            If FileUpload1.HasFile Then
                Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
                Dim FolderPath As String = ConfigurationManager.AppSettings("KR_win_loss_folder")

                If Extension <> ".xls" Then
                    lblErr_Msg.ForeColor = Drawing.Color.Red
                    lblErr_Msg.Text = "Only available for xls file."
                    Exit Sub
                End If

                Dim FilePath As String = Server.MapPath(FolderPath + FileName)
                FileUpload1.SaveAs(FilePath)
                Import_To_Grid(FilePath, Extension, "YES")

                strScript = "<script language=""javascript"">alert('Player win-loss uploaded !!');window.location.href='Admin_Details_Upload_CSV.aspx';</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)
            End If
        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try

    End Sub

    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)
        Dim conStr As String = ""
        Select Case Extension
            Case ".xls"
                'Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings("constringXLS") _
                           .ConnectionString
                Exit Select
            Case ".xlsx"
                'Excel 07
                conStr = ConfigurationManager.ConnectionStrings("constringXLSX") _
                          .ConnectionString
                Exit Select
        End Select
        conStr = String.Format(conStr, FilePath, isHDR)

        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        Dim dt As New DataTable()

        cmdExcel.Connection = connExcel

        'Get the name of First Sheet
        connExcel.Open()
        Dim dtExcelSchema As DataTable
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
        connExcel.Close()

        'Read Data from First Sheet
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        connExcel.Close()

        'Insert data to DB
        Dim array(10) As String
        For i As Integer = 2 To dt.Rows.Count - 1
            array(0) = dt.Rows(i)(10).ToString
            array(1) = dt.Rows(i)(11).ToString
            array(2) = dt.Rows(i)(1).ToString
            array(3) = dt.Rows(i)(2).ToString
            array(4) = dt.Rows(i)(3).ToString
            array(5) = dt.Rows(i)(4).ToString
            array(6) = dt.Rows(i)(5).ToString
            array(7) = dt.Rows(i)(6).ToString
            array(8) = dt.Rows(i)(7).ToString
            array(9) = dt.Rows(i)(8).ToString
            array(10) = dt.Rows(i)(9).ToString

            InsertData(array)
        Next

    End Sub

    Private Sub InsertData(ByVal ParamArray strArray() As String)
        Dim param(10) As SqlParameter
        Dim cmd As New SqlCommand

        Dim connString As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet

        Try
            connString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(connString)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("insert_summary_kr").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@StartDate", SqlDbType.DateTime)).Value = Convert.ToDateTime(strArray(0))
            sqlcommand.Parameters.Add(New SqlParameter("@EndDate", SqlDbType.DateTime)).Value = Convert.ToDateTime(strArray(1))
            sqlcommand.Parameters.Add(New SqlParameter("@Player_ID", SqlDbType.VarChar, 50)).Value = strArray(2)
            sqlcommand.Parameters.Add(New SqlParameter("@Currency", SqlDbType.VarChar, 3)).Value = strArray(3)
            sqlcommand.Parameters.Add(New SqlParameter("@Turnover", SqlDbType.Decimal)).Value = strArray(4)
            sqlcommand.Parameters.Add(New SqlParameter("@Win_Lose", SqlDbType.Decimal)).Value = strArray(5)
            sqlcommand.Parameters.Add(New SqlParameter("@Player_Referral", SqlDbType.Decimal)).Value = strArray(6)
            sqlcommand.Parameters.Add(New SqlParameter("@Gross_Agent_Comm", SqlDbType.Decimal)).Value = strArray(7)
            sqlcommand.Parameters.Add(New SqlParameter("@Agent_Referral", SqlDbType.Decimal)).Value = strArray(8)
            sqlcommand.Parameters.Add(New SqlParameter("@Clean_Agent_Comm", SqlDbType.Decimal)).Value = strArray(9)
            sqlcommand.Parameters.Add(New SqlParameter("@Agent_Bill", SqlDbType.Decimal)).Value = strArray(10)
            sqlcommand.Parameters.Add(New SqlParameter("@Creator", SqlDbType.VarChar, 50)).Value = Session("LoginID").ToString()

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)
            sqlConn.Close()

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub
End Class
