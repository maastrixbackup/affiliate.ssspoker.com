Imports System.Data
Imports System.Data.SqlClient
Imports commonfunc
Imports System.IO
Imports System.IO.Directory

Partial Class Admin_Banner_Details
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim strRECID As String = Request.QueryString("id")

            If Len(strRECID) > 0 Then
                lblTitle.Text = "Edit Banner"
                LoadContent()
            Else
                lblTitle.Text = "Add Banner"
            End If

            LoadCategory()
        End If

    End Sub

    Private Sub LoadContent()
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strRECID As Guid

        strRECID = Guid.Parse(Request.QueryString("id"))

        Try
            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("admin_banner_details").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = strRECID
            sqlcommand.Parameters.Add(New SqlParameter("@CategoryRECID", SqlDbType.UniqueIdentifier)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Banner_Name", SqlDbType.VarChar, -1)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Banner_Image", SqlDbType.VarChar, -1)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Height", SqlDbType.Int)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Width", SqlDbType.Int)).Direction = ParameterDirection.Output
            sqlcommand.Parameters.Add(New SqlParameter("@Status", SqlDbType.VarChar, 5)).Direction = ParameterDirection.Output

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            If IsDBNull(sqlcommand.Parameters("@Banner_Name").Value) = False Then
                txtBannerName.Text = sqlcommand.Parameters("@Banner_Name").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@Banner_Image").Value) = False Then
                If Len(sqlcommand.Parameters("@Banner_Image").Value) > 0 Then
                    'btnDelete.Visible = True
                    lblBannerImage.Text = sqlcommand.Parameters("@Banner_Image").Value
                Else
                    'btnDelete.Visible = False
                    lblBannerImage.Text = "no image."
                End If

            End If

            If IsDBNull(sqlcommand.Parameters("@Height").Value.ToString) = False Then
                txtBanner_Height.Text = sqlcommand.Parameters("@Height").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@Width").Value.ToString) = False Then
                txtBanner_Width.Text = sqlcommand.Parameters("@Width").Value
            End If

            If IsDBNull(sqlcommand.Parameters("@CategoryRECID").Value) = False Then
                ddlCategory.SelectedValue = sqlcommand.Parameters("@CategoryRECID").Value.ToString
            End If

            If IsDBNull(sqlcommand.Parameters("@Status").Value) = False Then
                rblStatus.SelectedValue = sqlcommand.Parameters("@Status").Value
            End If

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim cs As String
        Dim sqlConn As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sqlcommand As New SqlCommand
        Dim ds As New DataSet
        Dim strPath As String = Server.MapPath("/Images/Banner")
        Dim strBanner_Name As String
        Dim strBanner_Image As String
        Dim strHeight As String
        Dim strWidth As String
        Dim strBanner_HTMLCode As String
        Dim strStatus As String
        Dim strUserName As String
        Dim strFileExt As String
        Dim strRECID As String = Request.QueryString("id")
        Dim strRECID_1 As Guid
        Dim CategoryRECID As Guid
        Dim strScript As String
        Dim strFileName As String
        Dim strNewFileName As String
        Dim IsNewFileName As Boolean = False
        Dim SysImage As System.Drawing.Image

        Try
            If ruImage.PostedFile.ContentLength > 0 Then

                If Directory.Exists(strPath) = False Then
                    Directory.CreateDirectory(strPath)
                End If

                strFileName = ruImage.FileName.ToLower
                strFileExt = System.IO.Path.GetExtension(ruImage.FileName)

                If strFileName.Contains(".jpg") Or strFileName.Contains(".png") Or strFileName.Contains(".gif") Then
                    If File.Exists((strPath + "/" + ruImage.PostedFile.FileName)) Then
                        IsNewFileName = True
                        strNewFileName = Path.GetFileNameWithoutExtension(strFileName) + "_1"

                        ruImage.PostedFile.SaveAs((strPath + "/" + strNewFileName + strFileExt))
                    Else
                        ruImage.PostedFile.SaveAs((strPath + "/" + ruImage.PostedFile.FileName))
                    End If
                Else
                    lblErr_Msg.Text = "Only available for imgae file format: .jpg/.png/.gif. "
                    Exit Sub
                End If

                If IsNewFileName = True Then
                    strBanner_Image = strNewFileName + strFileExt
                Else
                    strBanner_Image = ruImage.FileName.ToString
                End If
            Else
                strBanner_Image = lblBannerImage.Text

            End If

            If ddlCategory.SelectedIndex = 0 Then
                lblErr_Msg.Text = "Please select category."
                Exit Sub
            End If

            strRECID_1 = Guid.NewGuid()
            CategoryRECID = Guid.Parse(ddlCategory.SelectedValue)
            strBanner_Name = txtBannerName.Text

            If Len(txtBanner_Height.Text) > 0 Then
                strHeight = txtBanner_Height.Text
            Else
                SysImage = System.Drawing.Image.FromStream(ruImage.PostedFile.InputStream)
                strHeight = SysImage.Height
            End If

            If Len(txtBanner_Width.Text) > 0 Then
                strWidth = txtBanner_Width.Text
            Else
                SysImage = System.Drawing.Image.FromStream(ruImage.PostedFile.InputStream)
                strWidth = SysImage.Width
            End If

            If strHeight > 750 Or strWidth > 750 Then
                lblErr_Msg.Text = "Image cannot more than 750px width x 750px height."
                Exit Sub
            End If

            If Len(strHeight) > 0 Or Len(strWidth) > 0 Then
                strBanner_HTMLCode = "<a href=http://sbobetpoker.com><img src=http://affiliate.sbobetpoker.com/Images/Banner/" + strBanner_Image + " height=" + strHeight + " width=" + strWidth + "/></a>"
            Else
                strBanner_HTMLCode = "<a href=><img src=Images/Banner/" + strBanner_Image + "/></a>"
            End If
            strStatus = rblStatus.SelectedValue
            strUserName = Session("LoginID")

            cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
            sqlConn = New SqlConnection(cs)

            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            If Len(strRECID) > 0 Then
                sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("update_banner").ToString
                sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(strRECID)
            Else
                sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("insert_banner").ToString
                sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = strRECID_1
	    End If

            sqlcommand.Parameters.Add(New SqlParameter("@CategoryRECID", SqlDbType.UniqueIdentifier)).Value = CategoryRECID
            sqlcommand.Parameters.Add(New SqlParameter("@Banner_Name", SqlDbType.VarChar, -1)).Value = strBanner_Name
            sqlcommand.Parameters.Add(New SqlParameter("@Banner_Image", SqlDbType.VarChar, -1)).Value = strBanner_Image
            sqlcommand.Parameters.Add(New SqlParameter("@Height", SqlDbType.Int)).Value = strHeight
            sqlcommand.Parameters.Add(New SqlParameter("@Width", SqlDbType.Int)).Value = strWidth
            sqlcommand.Parameters.Add(New SqlParameter("@Banner_HTML_Code", SqlDbType.VarChar, -1)).Value = strBanner_HTMLCode
            sqlcommand.Parameters.Add(New SqlParameter("@Status", SqlDbType.VarChar, 5)).Value = strStatus
            sqlcommand.Parameters.Add(New SqlParameter("@UserName", SqlDbType.VarChar, 50)).Value = strUserName

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)

            If Len(strRECID) > 0 Then
                strScript = "<script language=""javascript"">alert('banner edited successfully !!');window.location.href='Admin_Banner_Listing.aspx';</script>"
            Else
                strScript = "<script language=""javascript"">alert('New banner added successfully !!');window.location.href='Admin_Banner_Listing.aspx';</script>"
            End If

            ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
    End Sub

    'Protected Sub btnDelete_Click(sender As Object, e As ImageClickEventArgs) Handles btnDelete.Click
    '    Dim cs As String
    '    Dim sqlConn As SqlConnection
    '    Dim adapter As SqlDataAdapter
    '    Dim sqlcommand As New SqlCommand
    '    Dim ds As New DataSet
    '    Dim strRECID As String = Request.QueryString("id")
    '    'Dim strPath As String = Server.MapPath("/Images/Banner")
    '    Dim strUserName As String = Session("LoginID")
    '    Dim strScript As String

    '    cs = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
    '    sqlConn = New SqlConnection(cs)

    '    sqlConn.Open()
    '    sqlcommand.Connection = sqlConn
    '    sqlcommand.CommandType = CommandType.StoredProcedure

    '    If Len(strRECID) > 0 Then
    '        sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("delete_banner").ToString
    '    End If

    '    sqlcommand.Parameters.Add(New SqlParameter("@RECID", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(strRECID)
    '    sqlcommand.Parameters.Add(New SqlParameter("@UserName", SqlDbType.VarChar, 50)).Value = strUsername

    '    adapter = New SqlDataAdapter(sqlcommand)
    '    adapter.Fill(ds)



    '    strScript = "<script language=""javascript"">alert('Banner deleted.');</script>"
    '    ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)

    '    Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    'End Sub

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

End Class
