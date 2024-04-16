Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Partial Class Admin_Banner_Listing
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lblTitle.Text = "배너 리스트"
            LoadCategory()
            LoadGrid()
        End If
    End Sub

    Private Sub LoadGrid()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim CategoryRECID As Guid
        Dim strCategoryRECID As String = vbNullString

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("admin_banner_listing").ToString

            If ddlCategory.SelectedIndex > 0 Then
                CategoryRECID = Guid.Parse(ddlCategory.SelectedValue)
                sqlcommand.Parameters.Add(New SqlParameter("@IsFilter", SqlDbType.Bit)).Value = True
            Else
                CategoryRECID = Nothing
                sqlcommand.Parameters.Add(New SqlParameter("@IsFilter", SqlDbType.Bit)).Value = False
            End If

            sqlcommand.Parameters.Add(New SqlParameter("@CategoryRECID", SqlDbType.UniqueIdentifier)).Value = CategoryRECID
	    sqlcommand.Parameters.Add(New SqlParameter("@CountryRECID", SqlDbType.UniqueIdentifier)).Value = IIf(Session("CountryRECID") Is Nothing, DBNull.Value, Session("CountryRECID"))

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            Grid1.DataSource = ds.Tables(0)
            Grid1.DataBind()

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        Finally
            'sqlConn.Close()
        End Try

    End Sub

    Private Sub LoadCategory()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim dt As New DataTable

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("get_category").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@CategoryName", SqlDbType.VarChar, 100)).Direction = ParameterDirection.Output

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(dt)

            ddlCategory.DataSource = dt
            ddlCategory.DataBind()
            ddlCategory.Items.Insert(0, ("-카테고리 선택-"))

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Protected Sub lnkSearch_Click(sender As Object, e As EventArgs) Handles lnkSearch.Click
        LoadGrid()
    End Sub

    Protected Sub EditDetails(sender As Object, e As EventArgs)
        Dim myButton As HtmlAnchor = CType(sender, HtmlAnchor)
        Dim strRECID As String = myButton.Attributes("customdata")

        Response.Redirect("Admin_Banner_Details.aspx?id=" + strRECID)
    End Sub

    Public Sub Grid1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid1.RowDataBound
        'e.Row.Cells(1).Style("display") = "none"

        'If e.Row.RowType = DataControlRowType.DataRow Then
        'Select Case e.Row.Cells(3).Text
        '    Case "A"
        '        e.Row.Cells(3).Text = "Active"
        '    Case Else
        '        e.Row.Cells(3).Text = "Inactive"
        'End Select
        '    e.Row.Cells(1).Text = "<img src=Banner/" + e.Row.Cells(5).Text + " >"
        'End If

    End Sub

    'Protected Sub OnPaging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
    '    Grid1.PageIndex = e.NewPageIndex
    '    LoadGrid()
    'End Sub

End Class
