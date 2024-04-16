Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Partial Class Summary_Listing
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then

            If Session("LoginRECID") Is Nothing Then
                Response.Redirect("session-expired.aspx")
            End If

            txtDateFrom.Text = Format(Now(), "dd/MMM/yyyy").ToString
            txtDateTo.Text = Format(Now(), "dd/MMM/yyyy").ToString
            lblTitle.Text = "Summary List"
            LoadGrid()
        End If
    End Sub

    Private Sub LoadGrid()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strLoginRECID As String
        Dim strDateFrom As String
        Dim strDateTo As String

        If Session("LoginRECID") IsNot Nothing Then
            strLoginRECID = Session("LoginRECID").ToString()
        End If

        If Len(txtDateFrom.Text) > 0 Then
            strDateFrom = txtDateFrom.Text
        End If

        If Len(txtDateTo.Text) > 0 Then
            strDateTo = txtDateTo.Text
        End If

        Try
            If IsDate(strDateFrom) = False Then
                lblErr_Msg.Text = "Please input valid date."
                Exit Sub
            Else
                lblErr_Msg.Text = ""
            End If

            If IsDate(strDateTo) = False Then
                lblErr_Msg.Text = "Please input valid date."
                Exit Sub
            Else
                lblErr_Msg.Text = ""
            End If

            If Len(strDateFrom) = 0 Then
                strDateFrom = Format(Now(), "dd/MMM/yyyy").ToString
                txtDateFrom.Text = strDateFrom
            End If

            If Len(strDateTo) = 0 Then
                strDateTo = Format(Now(), "dd/MMM/yyyy").ToString
                txtDateTo.Text = strDateTo
            End If

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("summary_listing").ToString

            '//add parameter
            sqlcommand.Parameters.Add(New SqlParameter("@LoginRECID", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(strLoginRECID)
            sqlcommand.Parameters.Add(New SqlParameter("@DateFrom", SqlDbType.DateTime)).Value = txtDateFrom.Text
            sqlcommand.Parameters.Add(New SqlParameter("@DateTo", SqlDbType.DateTime)).Value = txtDateTo.Text

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)
            Grid1.DataSource = ds.Tables(0)
            Grid1.DataBind()
            ViewState("dtGrid1") = ds.Tables(0)
        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Protected Sub lnkSearch_Click(sender As Object, e As EventArgs) Handles lnkSearch.Click
        LoadGrid()
    End Sub

    Protected Sub OnPaging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Grid1.PageIndex = e.NewPageIndex
        LoadGrid()
    End Sub

    Public Sub Grid1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid1.RowDataBound
        'Dim strUsedAmount As String

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(4).Text = Format(Convert.ToDecimal(e.Row.Cells(4).Text), "#,##0").ToString
            e.Row.Cells(6).Text = Format(Convert.ToDecimal(e.Row.Cells(6).Text), "#,##0").ToString
            e.Row.Cells(7).Text = Format(Convert.ToDecimal(e.Row.Cells(7).Text), "#,##0").ToString
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
            lblErr_Msg.Text = ex.Message
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
            If intCol = 7 Then
                Continue For
            Else
                sb.Append(dtGrid1.Columns(intCol).ColumnName + ",")
            End If

        Next
        sb.Append(Environment.NewLine)
        For intRow As Integer = 0 To dtGrid1.Rows.Count - 1
            For intCol_1 As Integer = 0 To dtGrid1.Columns.Count - 1
                If intCol_1 = 7 Then
                    Continue For
                Else
                    sb.Append(dtGrid1.Rows(intRow)(intCol_1).ToString() + ",")
                End If

            Next
            sb.Append(vbCrLf)
        Next

        subExportExcel(True, sb.ToString)
    End Sub
End Class
