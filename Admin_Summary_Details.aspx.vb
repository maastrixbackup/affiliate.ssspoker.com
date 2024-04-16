Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Partial Class Admin_Summary_Details
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lblTitle.Text = "Summary Details"
            LoadGrid()
        End If
    End Sub

    Private Sub LoadGrid()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strLoginID As String = Request.QueryString("id").ToString()
        Dim strDateFrom As String = Request.QueryString("from")
        Dim strDateTo As String = Request.QueryString("to")

        Try
            
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("admin_summary_details").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@DateFrom", SqlDbType.DateTime)).Value = strDateFrom
            sqlcommand.Parameters.Add(New SqlParameter("@DateTo", SqlDbType.DateTime)).Value = strDateTo
            If Len(strLoginID) > 0 Then
                sqlcommand.Parameters.Add(New SqlParameter("@LoginRECID", SqlDbType.UniqueIdentifier, 50)).Value = Guid.Parse(strLoginID)
            End If

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)
            Grid1.DataSource = ds.Tables(0)
            Grid1.DataBind()
            ViewState("dtGrid1") = ds.Tables(0)
        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        Finally
            'sqlConn.Close()
        End Try

    End Sub

    Protected Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        Dim strDateFrom As String = Request.QueryString("from")
        Dim strDateTo As String = Request.QueryString("to")

        If Len(strDateFrom) > 0 And Len(strDateTo) > 0 Then
            Response.Redirect("Admin_Summary_Listing.aspx?from=" + strDateFrom + "&to=" + strDateTo)
        Else
            Response.Redirect("Admin_Summary_Listing.aspx")
        End If
    End Sub

    Protected Sub Grid1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Grid1.PageIndex = e.NewPageIndex
        LoadGrid()
    End Sub

    Public Sub Grid1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid1.RowDataBound
        'Dim strUsedAmount As String

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(5).Text = Format(Convert.ToDecimal(e.Row.Cells(5).Text), "#,##0").ToString
            e.Row.Cells(6).Text = Format(Convert.ToDecimal(e.Row.Cells(6).Text), "#,##0").ToString
        End If

    End Sub

    Protected Sub lnkExport_Click(sender As Object, e As EventArgs) Handles lnkExport.Click
        subDepositCSV()
    End Sub

    Private Sub subExportExcel(ByVal isDeposit As Boolean, ByVal strContent As String, Optional ByVal strFrom As String = vbNullString, Optional ByVal strTo As String = vbNullString)
        Dim strFilename As String = vbNullString
        'Select Case isDeposit
        '    Case True
        '        strFilename = "deposit-"
        '    Case Else
        '        strFilename = "withdrawal-"
        'End Select
        strFilename = "affiliate-"
        If strTo = vbNullString Then
            strFilename &= Now.ToString("yyyy-MM-dd_HHmmss")
        Else
            strFilename &= strFrom & "-" & strTo
        End If
        Try
            Response.Clear()
            Response.AddHeader("cache-control", "must-revalidate")
            Response.AddHeader("Content-type", "application/vnd.ms-excel")
            Response.AddHeader("Content-Disposition", "attachment;filename=" & strFilename & ".csv")
            Response.ContentType = "text/csv"
            Response.Write(strContent)
            Response.End()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub subDepositCSV()
        Dim dap As New SqlDataAdapter
        Dim dtGrid1 As New DataTable
        Dim row As New TableRow
        Dim cell As New TableCell
        Dim hlink As New HyperLink
        Dim sb As New StringBuilder()

        dtGrid1 = CType(ViewState("dtGrid1"), DataTable)

        For intCol As Integer = 0 To dtGrid1.Columns.Count - 1
            sb.Append(dtGrid1.Columns(intCol).ColumnName + ",")
        Next
        sb.Append(Environment.NewLine)
        For intRow As Integer = 0 To dtGrid1.Rows.Count - 1
            For intCol_1 As Integer = 0 To dtGrid1.Columns.Count - 1
                sb.Append(dtGrid1.Rows(intRow)(intCol_1).ToString() + ",")
            Next
            sb.Append(vbCrLf)
        Next

        subExportExcel(True, sb.ToString)
    End Sub


End Class
