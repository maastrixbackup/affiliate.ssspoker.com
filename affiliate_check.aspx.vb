Imports System.IO
Imports System.Data.SqlClient
Imports System.Data

Partial Class affiliate_check
    Inherits System.Web.UI.Page

    Public Const XMLwR As String = "<pkt><methodresponse name=""<#NAME>"" timestamp=""<#TIMESTAMP>""><result <#RESULT>> <extinfo /></result></methodresponse></pkt>"
    Dim ApiLoginName As String = vbNullString
    Dim ApiPassword As String = vbNullString
    Dim sqlConn As New SqlConnection

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            subInitialisation()
            CheckAffiliate()
        End If
    End Sub

    Private Enum ValidAPICredential
        Valid = 1
        InvalidUsername = 2
        InvalidPassword = 3
    End Enum

    Private Sub subInitialisation()
        ApiLoginName = System.Configuration.ConfigurationManager.AppSettings("API_login_name").ToString()
        ApiPassword = System.Configuration.ConfigurationManager.AppSettings("API_login_password").ToString()

        Dim strConn As String
        strConn = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
        sqlConn = New SqlConnection(strConn)
        sqlConn.Open()
    End Sub

    Private Function funcValidAPICredentials(ByVal USERNAME As String, ByVal PASSWORD As String) As ValidAPICredential
        Dim rtn As New ValidAPICredential
        If USERNAME = ApiLoginName Then
            If PASSWORD = ApiPassword Then
                rtn = ValidAPICredential.Valid
            Else
                rtn = ValidAPICredential.InvalidPassword
            End If
        Else
            rtn = ValidAPICredential.InvalidUsername
        End If
        Return rtn
    End Function

    Private Function funcBuildParam(ByVal strAttribute As String, ByVal strValue As String) As String
        Dim strRtn As String = strAttribute & "=""" & strValue & """ "
        Return strRtn
    End Function

    Private Function funcSetParam(ByVal PARAM_NAME As String, ByVal DBType As SqlDbType, Optional ByVal PARAM_VALUE As String = vbNullString, Optional ByVal boolOutput As Boolean = False, Optional ByVal PARAM_LENGTH As Integer = 0) As SqlParameter
        Dim param As New SqlParameter
        Try
            If DBType = SqlDbType.VarChar Or DBType = SqlDbType.NVarChar Then
                param = New SqlParameter("@" & PARAM_NAME, DBType, PARAM_LENGTH)
            Else
                param = New SqlParameter("@" & PARAM_NAME, DBType)
            End If
            If PARAM_VALUE <> vbNullString Then
                param.Value = PARAM_VALUE
            End If

            If boolOutput = True Then
                param.Direction = ParameterDirection.Output
            End If
        Catch ex As Exception

        End Try
        Return param
    End Function

    Private Function subExecSP(ByVal SP_NAME As String, ByVal SP_PARAM() As SqlParameter, Optional ByRef strOUTPUT() As String = Nothing) As Boolean
        Dim strName As String = "subExecSP"
        Dim cmd As New SqlCommand
        Dim boolSuccess As Boolean = False
        Try
            cmd = New SqlCommand(SP_NAME, sqlConn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                For i As Integer = 0 To SP_PARAM.Length - 1
                    .Parameters.Add(SP_PARAM(i))
                Next
                .ExecuteNonQuery()
                If strOUTPUT IsNot Nothing Then
                    For i As Integer = 0 To strOUTPUT.Length - 1
                        If cmd.Parameters("@" & strOUTPUT(i)).Value.ToString <> "" Then
                            strOUTPUT(i) = cmd.Parameters("@" & strOUTPUT(i)).Value.ToString()
                        End If
                    Next
                End If
            End With
            boolSuccess = True
        Catch ex As Exception
            boolSuccess = False
        End Try
        Return boolSuccess
    End Function

    Private Sub CheckAffiliate()
        Dim reader As StreamReader
        Dim strXML As String = vbNullString
        reader = New StreamReader(Request.InputStream)
        strXML = reader.ReadToEnd
        'strXML = "<pkt><methodcall name=""checkaffiliate"" timestamp=""2015-06-03 10:59:44.460""><auth Login=""SBOBETPOKER"" Password=""Sb013eTP0keR"" /><call seq=""480dd25d-f3cc-4b0e-a082-a9a6f9f2431e"" affiliatecode=""cincai""> <extinfo /></call></methodcall></pkt>"
        Dim ds As New DataSet
        Dim srXmlData As New System.IO.StringReader(strXML)
        Dim password As String = vbNullString
        Dim rsp As String = vbNullString
        Dim dt As New DataTable
        Dim Valid As ValidAPICredential

        Try
            ds.ReadXml(srXmlData)
            Valid = funcValidAPICredentials(ds.Tables("auth").Rows(0)("login").ToString, ds.Tables("auth").Rows(0)("password").ToString)
            If Valid = ValidAPICredential.Valid Then
                rsp = get_rsp_affiliate(ds.Tables("call").Rows(0)("affiliatecode"))
            End If

            With Response
                .ContentType = "text/plain"
                .Clear()
                .Write(rsp)
            End With
        Catch ex As Exception

        End Try

        sqlConn.Close()
    End Sub

    Private Function get_rsp_affiliate(ByVal strAffiliate As String) As String
        Dim isValid As String = "0"
        Dim strXML As String = XMLwR
        Dim strParam As String = vbNullString
        Dim strSP As String = "sp_affiliate_check"
        Dim p(1) As SqlParameter
        Dim o(0) As String

        p(0) = funcSetParam("affiliate_code", SqlDbType.VarChar, strAffiliate, , 50)
        p(1) = funcSetParam("affiliate_cnt", SqlDbType.Int, , True, )
        o(0) = "affiliate_cnt"
        If subExecSP(strSP, p, o) = True Then
            If CInt(o(0)) > 0 Then
                isValid = "1"
            Else
                isValid = "0"
            End If
        Else
            isValid = "2"
        End If

        strParam = funcBuildParam("isvalid", isValid)
        strXML = Replace(strXML, "<#RESULT>", strParam)
        strXML = Replace(strXML, "<#TIMESTAMP>", Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
        strXML = Replace(strXML, "<#NAME>", "checkaffiliate")

        Return strXML
    End Function
End Class
