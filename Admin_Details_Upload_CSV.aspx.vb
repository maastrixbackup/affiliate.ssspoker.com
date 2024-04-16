Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports commonfunc

Partial Class Admin_Details_Upload_CSV
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lblTitle.Text = "Upload CSV File"
        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strFileName As String = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
        Dim strPath As String = Server.MapPath("~/temp/")
        Dim array(50) As String
        Dim line() As String
        Dim strScript As String
        Dim strFileExt As String

        Try
            If FileUpload1.PostedFile.ContentLength > 0 Then
                strFileExt = System.IO.Path.GetExtension(FileUpload1.FileName)

                If strFileExt = ".csv" Then
                    GoTo ContSaveFile
                Else
                    lblErr_Msg.ForeColor = Drawing.Color.Red
                    lblErr_Msg.Text = "Only available for csv file."
                    Exit Sub
                End If
ContSaveFile:
                FileUpload1.PostedFile.SaveAs(strPath + strFileName)

                Dim csvData As String = File.ReadAllText(strPath + strFileName)
                Dim cnt As Integer = 0

                line = csvData.Replace(", ", "_").Split(ControlChars.CrLf)

                For intCnt As Int64 = 1 To line.Length - 1
                    cnt = 0

                    For Each column As String In line(intCnt).Split(","c)

                        If Len(column) = 0 Then
                            column = "NULLTAG"
                        End If
                        array(cnt) = Replace(column, """", "").Trim()

                        cnt += 1
                    Next

                    InsertData(array)

                Next

                strScript = "<script language=""javascript"">alert('csv file uploaded !!');window.location.href='Admin_Details_Upload_CSV.aspx';</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", strScript)
            End If
        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try
        
    End Sub

    Private Sub InsertData(ByVal ParamArray strArray() As String)
        Dim param(51) As SqlParameter
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
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("insert_summary").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime)).Value = Convert.ToDateTime(strArray(1) + "/" + strArray(2) + "/" + strArray(3))
            sqlcommand.Parameters.Add(New SqlParameter("@Day", SqlDbType.Int)).Value = strArray(1)
            sqlcommand.Parameters.Add(New SqlParameter("@Month", SqlDbType.VarChar, 50)).Value = strArray(2)
            sqlcommand.Parameters.Add(New SqlParameter("@Year", SqlDbType.Int)).Value = strArray(3)
            sqlcommand.Parameters.Add(New SqlParameter("@Regulated", SqlDbType.VarChar, 50)).Value = strArray(4)
            sqlcommand.Parameters.Add(New SqlParameter("@PokerGameType", SqlDbType.VarChar, 50)).Value = strArray(5)
            sqlcommand.Parameters.Add(New SqlParameter("@Stakes", SqlDbType.VarChar, 50)).Value = strArray(6)
            sqlcommand.Parameters.Add(New SqlParameter("@TableType", SqlDbType.VarChar, 50)).Value = strArray(7)
            sqlcommand.Parameters.Add(New SqlParameter("@TableID", SqlDbType.Int)).Value = strArray(8)
            sqlcommand.Parameters.Add(New SqlParameter("@TableName", SqlDbType.NVarChar, 50)).Value = strArray(9)
            sqlcommand.Parameters.Add(New SqlParameter("@VisibleTable", SqlDbType.VarChar, 50)).Value = strArray(10)
            sqlcommand.Parameters.Add(New SqlParameter("@DisabledTable", SqlDbType.VarChar, 50)).Value = strArray(11)
            sqlcommand.Parameters.Add(New SqlParameter("@BlazeTable", SqlDbType.VarChar, 50)).Value = strArray(12)
            sqlcommand.Parameters.Add(New SqlParameter("@MaxSeats", SqlDbType.Int)).Value = strArray(13)
            sqlcommand.Parameters.Add(New SqlParameter("@MinBuyInAmount", SqlDbType.Decimal)).Value = strArray(14)
            sqlcommand.Parameters.Add(New SqlParameter("@MaxBuyInAmount", SqlDbType.Decimal)).Value = strArray(15)
            sqlcommand.Parameters.Add(New SqlParameter("@TableLanguage", SqlDbType.VarChar, 50)).Value = strArray(16)
            sqlcommand.Parameters.Add(New SqlParameter("@PlayerCurrency", SqlDbType.VarChar, 50)).Value = strArray(17)
            sqlcommand.Parameters.Add(New SqlParameter("@TableCurrency", SqlDbType.VarChar, 50)).Value = "-"
            sqlcommand.Parameters.Add(New SqlParameter("@Private", SqlDbType.VarChar, 50)).Value = strArray(18)
            sqlcommand.Parameters.Add(New SqlParameter("@BetLimitType", SqlDbType.VarChar, 50)).Value = strArray(19)
            sqlcommand.Parameters.Add(New SqlParameter("@GamingAccount", SqlDbType.VarChar, 50)).Value = strArray(20)
            sqlcommand.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.VarChar, 50)).Value = strArray(21)
            sqlcommand.Parameters.Add(New SqlParameter("@LastName", SqlDbType.VarChar, 50)).Value = strArray(22)
            sqlcommand.Parameters.Add(New SqlParameter("@PokerAlias", SqlDbType.VarChar, 50)).Value = strArray(23)
            sqlcommand.Parameters.Add(New SqlParameter("@PlayerID", SqlDbType.Int)).Value = strArray(24)
            'sqlcommand.Parameters.Add(New SqlParameter("@PlayerCurrency", SqlDbType.VarChar, 50)).Value = "-"
            sqlcommand.Parameters.Add(New SqlParameter("@VIP", SqlDbType.VarChar, 50)).Value = strArray(25)
            sqlcommand.Parameters.Add(New SqlParameter("@BannerTag", SqlDbType.VarChar, 50)).Value = strArray(26)
            sqlcommand.Parameters.Add(New SqlParameter("@RegisteredLanguage", SqlDbType.VarChar, 50)).Value = strArray(27)
            sqlcommand.Parameters.Add(New SqlParameter("@RegisteredCasino", SqlDbType.VarChar, 50)).Value = strArray(28)
            sqlcommand.Parameters.Add(New SqlParameter("@RegisteredCountry", SqlDbType.VarChar, 50)).Value = strArray(29)
            sqlcommand.Parameters.Add(New SqlParameter("@SessionCasino", SqlDbType.VarChar, 50)).Value = strArray(30)
            sqlcommand.Parameters.Add(New SqlParameter("@Platform", SqlDbType.VarChar, 50)).Value = strArray(31)
            sqlcommand.Parameters.Add(New SqlParameter("@PlayerGroups", SqlDbType.VarChar, 100)).Value = strArray(32).Replace("_", ", ").Replace("""", "")
            sqlcommand.Parameters.Add(New SqlParameter("@NoOfPlayers", SqlDbType.Int)).Value = strArray(33)
            sqlcommand.Parameters.Add(New SqlParameter("@LoyaltyPointsEarned", SqlDbType.Int)).Value = strArray(34)
            sqlcommand.Parameters.Add(New SqlParameter("@PayoutAmount", SqlDbType.Decimal)).Value = strArray(35)
            sqlcommand.Parameters.Add(New SqlParameter("@WagerAmount", SqlDbType.Decimal)).Value = strArray(36)
            sqlcommand.Parameters.Add(New SqlParameter("@RakeAmount", SqlDbType.Decimal)).Value = strArray(37)
            sqlcommand.Parameters.Add(New SqlParameter("@NoOfRakes", SqlDbType.Int)).Value = strArray(38)
            sqlcommand.Parameters.Add(New SqlParameter("@NoOfQualifiedRakes", SqlDbType.Int)).Value = strArray(39)
            sqlcommand.Parameters.Add(New SqlParameter("@NoOfPayouts", SqlDbType.Int)).Value = strArray(40)
            sqlcommand.Parameters.Add(New SqlParameter("@NoOfGames", SqlDbType.Int)).Value = strArray(41)
            sqlcommand.Parameters.Add(New SqlParameter("@AvgWagerAmount", SqlDbType.Decimal)).Value = strArray(42)
            sqlcommand.Parameters.Add(New SqlParameter("@AvgPayoutAmount", SqlDbType.Decimal)).Value = strArray(43)
            sqlcommand.Parameters.Add(New SqlParameter("@AvgRakeAmount", SqlDbType.Decimal)).Value = strArray(44)
            sqlcommand.Parameters.Add(New SqlParameter("@MaxWagerAmount", SqlDbType.Decimal)).Value = strArray(45)
            sqlcommand.Parameters.Add(New SqlParameter("@MaxPayoutAmount", SqlDbType.Decimal)).Value = strArray(46)
            sqlcommand.Parameters.Add(New SqlParameter("@MaxRakeAmount", SqlDbType.Decimal)).Value = strArray(47)
            sqlcommand.Parameters.Add(New SqlParameter("@BadBeatProgressiveContribution", SqlDbType.Decimal)).Value = strArray(48)
            sqlcommand.Parameters.Add(New SqlParameter("@CashGameGGR", SqlDbType.Decimal)).Value = strArray(49)
            sqlcommand.Parameters.Add(New SqlParameter("@PlayerGrossProfit", SqlDbType.Decimal)).Value = strArray(50)

            adapter = New SqlDataAdapter(sqlcommand)
            adapter.Fill(ds)
            sqlConn.Close()

        Catch ex As Exception
            lblErr_Msg.Text = ex.Message
        End Try

    End Sub


End Class
