Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Partial Class Admin_Listing
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lblTitle.Text = "User Listing"
            LoadGrid()
        End If
    End Sub

    Private Sub LoadGrid()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
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


            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = RECID
            sqlcommand.Parameters.Add(New SqlParameter("@UserType", SqlDbType.VarChar, 5)).Value = strUserType

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            If strUserType = 0 Then
                Grid_Admin.DataSource = ds.Tables(0)
                Grid_Admin.DataBind()
                Grid_Admin.Visible = True
                Grid_User.Visible = False
            Else
                Grid_User.DataSource = ds.Tables(0)
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

    Public Sub Grid_Admin_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid_Admin.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Select Case e.Row.Cells(4).Text
                Case 0
                    e.Row.Cells(4).Text = "Corporate"
                Case 1
                    e.Row.Cells(4).Text = "Online"
            End Select
        End If
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

End Class
