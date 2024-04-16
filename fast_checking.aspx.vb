Imports System.Web.Script.Services
Imports System.Web.Services

Partial Class fast_checking
    Inherits System.Web.UI.Page

    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Shared Function RegisterValidation(column As String, value1 As String, value2 As String) As RegisterStatus
        Dim oResponse As RegisterStatus = New RegisterStatus()
        Dim fStatus As String = String.Empty
        Dim fMessage As String = String.Empty

        'idnpoker.registerValidation(column, value1, value2, fStatus, fMessage)

        '// test success case
        fStatus = 1
        fMessage = "success"

        '// test fail case
        'fStatus = 0
        'fMessage = "error message"

        oResponse.status = fStatus
        oResponse.message = fMessage

        Return oResponse
    End Function

End Class

Public Class RegisterStatus
    Public Property status As String
    Public Property message As String
End Class