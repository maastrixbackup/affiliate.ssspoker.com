Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Partial Class Player_Listing
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lblTitle.Text = "회원정보"
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

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_player_list").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@UserType", SqlDbType.VarChar, 5)).Value = strUserType
            sqlcommand.Parameters.Add(New SqlParameter("@LoginRECID", SqlDbType.UniqueIdentifier)).Value = RECID
            sqlcommand.Parameters.Add(New SqlParameter("@AffCode", SqlDbType.VarChar, 50)).Value = IIf(txtAffCode.Text.Length > 0, txtAffCode.Text, DBNull.Value)
            sqlcommand.Parameters.Add(New SqlParameter("@PlayerUsername", SqlDbType.NVarChar, 50)).Value = IIf(txtUsername.Text.Length > 0, txtUsername.Text, DBNull.Value)
            sqlcommand.Parameters.Add(New SqlParameter("@PlayerNickname", SqlDbType.NVarChar, 50)).Value = IIf(txtNickname.Text.Length > 0, txtNickname.Text, DBNull.Value)
            sqlcommand.Parameters.Add(New SqlParameter("@PlayerFullName", SqlDbType.NVarChar, 50)).Value = IIf(txtFullName.Text.Length > 0, txtFullName.Text, DBNull.Value)
            sqlcommand.Parameters.Add(New SqlParameter("@RegDate", SqlDbType.DateTime)).Value = IIf(txtRegDate.Text.Length > 0, txtRegDate.Text, DBNull.Value)

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(dt)

            If strUserType = 0 Then
                Grid2.DataSource = dt
                Grid2.DataBind()
                Grid1.Visible = False
                Grid2.Visible = True
                ViewState("dtGrid1") = dt
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

    Protected Sub lnkSearch_Click(sender As Object, e As EventArgs) Handles lnkSearch.Click
        LoadGrid()
    End Sub

    Protected Sub Grid2_Sorting(sender As Object, e As GridViewSortEventArgs)
        Dim dtGrid1 As New DataTable
        dtGrid1 = CType(ViewState("dtGrid1"), DataTable)

        If dtGrid1 IsNot Nothing Then

            'Sort the data.
            dtGrid1.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)
            Grid2.DataSource = dtGrid1
            Grid2.DataBind()

        End If
    End Sub

    Private Function GetSortDirection(ByVal column As String) As String

        ' By default, set the sort direction to ascending.
        Dim sortDirection = "ASC"

        ' Retrieve the last column that was sorted.
        Dim sortExpression = TryCast(ViewState("SortExpression"), String)

        If sortExpression IsNot Nothing Then
            ' Check if the same column is being sorted.
            ' Otherwise, the default value can be returned.
            If sortExpression = column Then
                Dim lastDirection = TryCast(ViewState("SortDirection"), String)
                If lastDirection IsNot Nothing _
                  AndAlso lastDirection = "ASC" Then

                    sortDirection = "DESC"

                End If
            End If
        End If

        ' Save new values in ViewState.
        ViewState("SortDirection") = sortDirection
        ViewState("SortExpression") = column

        Return sortDirection

    End Function
End Class
