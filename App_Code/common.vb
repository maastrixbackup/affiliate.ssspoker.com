Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.Configuration.ConfigurationManager
Imports System.Security.Cryptography
Imports System.Net.Mail
Imports System.IO
Imports System.Xml

Public Class commonfunc

    Public Shared strServer As String
    Public Shared strUsername As String
    Public Shared strPassword As String
    Public Shared strDatabase As String
    Public Shared strConn As String
    Private TripleDes As New TripleDESCryptoServiceProvider

    Public Shared Function getDBIDRValue(ByVal Value As String) As String
        'To Insert to DB
        Dim strRtn As String = vbNullString
        Try
            strRtn = Value / 10
        Catch ex As Exception
            subSP_EXCEPTION_INSERT("getDBIDRValue", ex)
            strRtn = 0
        End Try
        Return strRtn
    End Function

    Public Shared Function getDisplayIDRValue(ByVal value As String) As String
        'To Display On Screen
        Dim strRtn As String = vbNullString
        Try
            strRtn = value * 10
        Catch ex As Exception
            subSP_EXCEPTION_INSERT("getDisplayIDRValue", ex)
            strRtn = 0
        End Try
        Return strRtn
    End Function
    Public Shared Function GetAmount(ByVal currency As String, ByVal loginname As String, ByVal val As String, ByRef bool As Boolean) As String
        Dim amount As String = vbNullString
        bool = False
        Try
            amount = val
            If currency = Nothing Or currency = "" Or currency = vbNullString Then
                Dim sp As String = getConfig("sp_member_get_currency_bymemberlogin")
                Dim p(2) As SqlParameter
                Dim o(1) As String
                p(0) = funcSetParam("member_login", SqlDbType.VarChar, loginname, , 50)
                p(1) = funcSetParam("member_balance", SqlDbType.Money, , True)
                p(2) = funcSetParam("member_currency", SqlDbType.VarChar, , True, 30)
                o(0) = "member_balance"
                o(1) = "member_currency"
                If subExecSP(sp, p, o) = True Then
                    currency = o(1)
                End If
                'Session("currency") = getCurrency
            End If
            If currency = "VND" Or currency = "IDR" Then
                amount = amount * 1000
            End If
            bool = True
        Catch ex As Exception
            bool = False
            subSP_EXCEPTION_INSERT("GetAmount", ex)
            amount = 0
        End Try
        Return amount
    End Function

    Public Shared Function padZero(ByVal str As String, Optional int As Integer = 0) As String
        Select Case int
            Case int = 0
                For i As Integer = 0 To 7
                    If str.Length < 7 Then
                        str &= "0" & str
                    End If
                Next
                Return str
            Case Else
                For i As Integer = 0 To int - 1
                    str &= "0" & str
                Next
        End Select
        Return str
    End Function

    Public Shared Function formatDate(ByVal str As String) As String
        Return CDate(str).ToString("yyyy-MM-dd HH:mm:ss")
    End Function

    Public Shared Sub subInitialisation()
        strServer = getConfig("Server")
        strDatabase = getConfig("Database")
        strUsername = getConfig("Username")
        strPassword = getConfig("Password")
        strConn = "Server=" & strServer & ";Database=" & strDatabase & ";User Id=" & strUsername & ";Password=" & strPassword & ";"
    End Sub

    Public Shared Function randomNum() As String
        Dim R As New Random
        Return R.Next(10000000, 99999999)
    End Function

    Public Shared Function getConfig(strKeyName As String, Optional strDelimiter As String = vbNullString) As String
        Dim strReturn As String = vbNullString
        Dim strRtn() As String = Nothing
        If String.IsNullOrEmpty(AppSettings.Item(strKeyName)) Then
            strReturn = vbNullString
        Else
            strReturn = AppSettings.Item(strKeyName).ToString
        End If
        Return strReturn
    End Function

    Public Shared Function funcSetParam(ByVal PARAM_NAME As String, ByVal DBType As SqlDbType, Optional ByVal PARAM_VALUE As String = vbNullString, Optional ByVal boolOutput As Boolean = False, Optional ByVal int As Integer = 0) As SqlParameter
        Dim param As New SqlParameter
        Try
            If DBType = SqlDbType.VarChar Or DBType = SqlDbType.NVarChar Then
                param = New SqlParameter("@" & PARAM_NAME, DBType, int)
            Else
                param = New SqlParameter("@" & PARAM_NAME, DBType)
            End If
            If PARAM_VALUE <> vbNullString Then
                Select Case DBType
                    Case SqlDbType.UniqueIdentifier
                        param.Value = Guid.Parse(PARAM_VALUE)
                    Case Else
                        param.Value = PARAM_VALUE
                End Select
            End If

            If boolOutput = True Then
                param.Direction = ParameterDirection.Output
            End If
        Catch ex As Exception
            subSP_EXCEPTION_INSERT("funcSetParam", ex)
        End Try
        Return param
    End Function

    Public Shared Function subExecSP(ByVal SP_NAME As String, ByVal SP_PARAM() As SqlParameter, Optional ByRef strOUTPUT() As String = Nothing) As Boolean
        Dim strName As String = "subExecSP"
        Dim sqlConn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim boolSuccess As Boolean = False
        Try
            strServer = getConfig("Server")
            strDatabase = getConfig("Database")
            strUsername = getConfig("Username")
            strPassword = getConfig("Password")
	    strConn = ConnectionStrings("ConnectionString").ToString
            'strConn = "Server=" & strServer & ";Database=" & strDatabase & ";User Id=" & strUsername & ";Password=" & strPassword & ";"
            'strConn = "Server=2SA-Gan;Database=SBOPOKER_AFFILIATE;Integrated Security=true;"
            sqlConn = New SqlConnection(strConn)
            sqlConn.Open()
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
            sqlConn.Close()
            sqlConn.Dispose()
            boolSuccess = True
        Catch ex As Exception
            sqlConn.Close()
            sqlConn.Dispose()
            boolSuccess = False
            subSP_EXCEPTION_INSERT(strName & " " & SP_NAME, ex)
        End Try
        Return boolSuccess
    End Function

    Public Shared Sub subSP_EXCEPTION_INSERT(ByVal function_name As String, ByVal ex As Exception)
        Dim PARAM_SP_EXCEPTION_INSERT(2) As SqlParameter
        PARAM_SP_EXCEPTION_INSERT(0) = funcSetParam_Exception("function_name", SqlDbType.VarChar, function_name)
        PARAM_SP_EXCEPTION_INSERT(1) = funcSetParam_Exception("exception_string", SqlDbType.VarChar, ex.ToString)
        PARAM_SP_EXCEPTION_INSERT(2) = funcSetParam_Exception("exception_message", SqlDbType.VarChar, ex.Message)
        subExecSP("sp_log_exception", PARAM_SP_EXCEPTION_INSERT)
    End Sub

    Public Shared Function funcSetParam_Exception(ByVal PARAM_NAME As String, ByVal DBType As SqlDbType, Optional ByVal PARAM_VALUE As String = vbNullString, Optional ByVal boolOutput As Boolean = False) As SqlParameter
        Dim param As New SqlParameter
        Try
            If DBType = SqlDbType.VarChar Or DBType = SqlDbType.NVarChar Then
                param = New SqlParameter("@" & PARAM_NAME, DBType, 2000)
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
            subSP_EXCEPTION_INSERT("funcSetParam_Exception", ex)
        End Try
        Return param
    End Function

    'Private Sub subAlert(ByVal strString As String)
    '    Dim sb As New StringBuilder()
    '    sb.Append("<script type = 'text/javascript'>")
    '    sb.Append("alert('")
    '    sb.Append(strString)
    '    sb.Append("');")
    '    sb.Append("</script>")
    '    ClientScript.RegisterStartupScript(Me.GetType(), "script", sb.ToString())
    'End Sub

    Public Shared Function GenerateHash(ByVal SourceText As String) As String
        Dim Ue As New UnicodeEncoding()
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        Dim Md5 As New MD5CryptoServiceProvider()
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        Return Convert.ToBase64String(ByteHash)
    End Function

    Public Function DecryptData(
    ByVal encryptedtext As String) As String

        ' Convert the encrypted text string to a byte array. 
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream. 
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream. 
        Dim decStream As New CryptoStream(ms,
            TripleDes.CreateDecryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string. 
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)

    End Function

    Public Shared Function readXMLTag(myXML As String, tag As String) As String
        myXML = myXML.Replace("&", "%26")

        Dim value As String = Nothing
        Using reader As XmlReader = XmlReader.Create(New StringReader(myXML))
            If reader.ReadToFollowing(tag) Then
                value = reader.ReadElementContentAsString()
            Else
                value = "-0"
            End If
        End Using

        Return value.Replace("%26", "&")
    End Function

    Public Shared Function logAPIRequest(ByVal objRequest As String, ByVal strAPI As String, ByVal strUsername As String) As String
        Dim log_id As String
        Dim objParameter(3) As SqlParameter
        Dim strParameter_Output(0) As String

        objParameter(0) = funcSetParam("api", SqlDbType.VarChar, strAPI, False, 50)
        objParameter(1) = funcSetParam("request", SqlDbType.NVarChar, objRequest, False, -1)
        objParameter(2) = funcSetParam("username", SqlDbType.VarChar, strUsername, False, 50)
        objParameter(3) = funcSetParam("log_id", SqlDbType.UniqueIdentifier, "", True)
        strParameter_Output(0) = "log_id"

        If subExecSP("sp_insert_log_api", objParameter, strParameter_Output) = True Then
            log_id = strParameter_Output(0).ToString()
        End If

        Return log_id
    End Function

    Public Shared Sub logAPIResponse(ByVal log_id As String, ByVal objResponse As String, ByVal strUsername As String)
        Dim objParameter(2) As SqlParameter

        objParameter(0) = funcSetParam("log_id", SqlDbType.UniqueIdentifier, log_id, False, 50)
        objParameter(1) = funcSetParam("response", SqlDbType.NVarChar, objResponse, False, -1)
        objParameter(2) = funcSetParam("username", SqlDbType.VarChar, strUsername, False, 50)

        subExecSP("sp_update_log_api", objParameter)
    End Sub
End Class
