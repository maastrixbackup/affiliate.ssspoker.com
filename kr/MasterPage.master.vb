Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            If Session("LoginID") Is Nothing Then
                Response.Redirect("default.aspx")
            End If

            lblLoginID.Text = "Welcome, " + Session("LoginID")
            
        End If
    End Sub

    Protected Sub lnkLogout_Click(sender As Object, e As EventArgs) Handles lnkLogout.Click
        Dim strScript As String

        strScript = "<script language=""javascript"">alert('Logout successfully !!');window.location.href='../default.aspx';</script>"

        Session.Clear()
        Session.Abandon()

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)
    End Sub
End Class

