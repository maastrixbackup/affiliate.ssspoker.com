Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Partial Class Banner_Listing
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lblTitle.Text = "Banner List"
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
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("banner_listing").ToString

            If ddlCategory.SelectedIndex > 0 Then
                CategoryRECID = Guid.Parse(ddlCategory.SelectedValue)
                sqlcommand.Parameters.Add(New SqlParameter("@IsFilter", SqlDbType.Bit)).Value = True
            Else
                CategoryRECID = Nothing
                sqlcommand.Parameters.Add(New SqlParameter("@IsFilter", SqlDbType.Bit)).Value = False
            End If

            sqlcommand.Parameters.Add(New SqlParameter("@CategoryRECID", SqlDbType.UniqueIdentifier)).Value = CategoryRECID

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
            ddlCategory.Items.Insert(0, ("-Select Category-"))

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Protected Sub lnkSearch_Click(sender As Object, e As EventArgs) Handles lnkSearch.Click
        LoadGrid()
    End Sub

    'Public Sub Grid1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid1.RowDataBound

    '    Dim strLoginID As String = Session("LoginID")
    '    Dim txtHTMLCode As HtmlTextArea = DirectCast(e.Row.FindControl("txtHTML_Code"), HtmlTextArea)

    '    If e.Row.RowType = DataControlRowType.DataRow Then

    '        txtHTMLCode.InnerText = Replace(txtHTMLCode.InnerText, "[aff_code]", strLoginID)
    '    End If

    'End Sub

End Class
