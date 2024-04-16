Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Partial Class Admin_Listing
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lblTitle.Text = "제휴 목록"
            If Session("UserType") = "0" Then
                LoadUserType()
            End If
            If Session("UserType") <> "0" Then
                lblAffCode.Text = Session("LoginID").ToString()
                lblAffComm.Text = Session("CommissionRate").ToString() + "%"
            End If
            LoadGrid()
        End If
    End Sub

    Private Sub LoadUserType()
        Dim strUserType As String = Session("UserType")

        Select Case strUserType
            Case 0
                ddlUserType.Items.Insert(0, New ListItem("-User Type-", ""))
                ddlUserType.Items.Insert(1, New ListItem("Master", 1))
                ddlUserType.Items.Insert(2, New ListItem("First Level", 2))
                ddlUserType.Items.Insert(3, New ListItem("Second Level", 3))
                ddlUserType.Items.Insert(4, New ListItem("Third Level", 4))
            Case 1
                ddlUserType.Items.Insert(0, New ListItem("-User Type-", ""))
                ddlUserType.Items.Insert(1, New ListItem("First Level", 2))
                ddlUserType.Items.Insert(2, New ListItem("Second Level", 3))
                ddlUserType.Items.Insert(3, New ListItem("Third Level", 4))
            Case 2
                ddlUserType.Items.Insert(0, New ListItem("-User Type-", ""))
                ddlUserType.Items.Insert(1, New ListItem("Second Level", 3))
                ddlUserType.Items.Insert(2, New ListItem("Third Level", 4))
            Case 3
                ddlUserType.Items.Insert(0, New ListItem("-User Type-", ""))
                ddlUserType.Items.Insert(1, New ListItem("Third Level", 4))
            Case Else
                ddlUserType.Items.Insert(0, New ListItem("-User Type-", ""))
                ddlUserType.Enabled = False
        End Select
    End Sub

    Private Sub LoadGrid()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim objDV As DataView
        Dim strUserType As String = Session("UserType")
        Dim RECID As Guid

        Try
            RECID = Session("LoginRECID")
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("admin_listing").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@CountryRECID", SqlDbType.UniqueIdentifier)).Value = IIf(Session("CountryRECID") Is Nothing, DBNull.Value, Session("CountryRECID"))
            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = RECID
            sqlcommand.Parameters.Add(New SqlParameter("@UserType", SqlDbType.VarChar, 5)).Value = strUserType
            sqlcommand.Parameters.Add(New SqlParameter("@AffCode", SqlDbType.VarChar, 50)).Value = IIf(txtAffCode.Text.Length > 0, txtAffCode.Text, DBNull.Value)
            sqlcommand.Parameters.Add(New SqlParameter("@UserType2", SqlDbType.VarChar, 5)).Value = IIf(ddlUserType.SelectedIndex > 0, ddlUserType.SelectedValue, DBNull.Value)

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            objDV = New DataView(ds.Tables(0))
            If txtFullName.Text.Length > 0 Then
                objDV.RowFilter = "FullName like '%" + txtFullName.Text.Replace("'", "''") + "%'"
            End If
            If txtContactNo.Text.Length > 0 Then
                objDV.RowFilter = "ContactNo like '%" + txtContactNo.Text.Replace("'", "''") + "%'"
            End If
            If txtEmail.Text.Length > 0 Then
                objDV.RowFilter = "Email like '%" + txtEmail.Text.Replace("'", "''") + "%'"
            End If

            If strUserType = 0 Then
                Grid_Admin.DataSource = objDV.ToTable()
                Grid_Admin.DataBind()
                Grid_Admin.Visible = True
                Grid_User.Visible = False
                ViewState("dtGrid1") = objDV.ToTable()
            Else
                Grid_User.DataSource = objDV.ToTable()
                Grid_User.DataBind()
                Grid_Admin.Visible = False
                Grid_User.Visible = True
            End If
            

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        Finally
            'sqlConn.Close()
        End Try

    End Sub

    Protected Sub EditDetails(sender As Object, e As EventArgs)
        Dim myButton As HtmlAnchor = CType(sender, HtmlAnchor)
        Dim strID As String = myButton.Attributes("customdata")

        Response.Redirect("Admin_Details.aspx?id=" + strID)
    End Sub

    Protected Sub lnkSearch_Click(sender As Object, e As EventArgs) Handles lnkSearch.Click
        LoadGrid()
    End Sub

    Protected Sub OnPaging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Dim strUserType As String = Session("UserType")

        If strUserType = 0 Then
            Grid_Admin.PageIndex = e.NewPageIndex
            LoadGrid()
        Else
            Grid_User.PageIndex = e.NewPageIndex
            LoadGrid()
        End If

    End Sub

    Protected Sub Grid_Admin_Row(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If Not Session("ContactDetail") Then
            If e.Row.Cells.Count > 6 Then
                e.Row.Cells(6).Visible = False
            End If
        End If
    End Sub

    Protected Sub Grid_Admin_Sorting(sender As Object, e As GridViewSortEventArgs)
        Dim dtGrid1 As New DataTable
        dtGrid1 = CType(ViewState("dtGrid1"), DataTable)

        If dtGrid1 IsNot Nothing Then

            'Sort the data.
            dtGrid1.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)
            Grid_Admin.DataSource = dtGrid1
            Grid_Admin.DataBind()

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
