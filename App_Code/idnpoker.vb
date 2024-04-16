Imports Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web
Imports System.Xml
Imports System.Data.SqlClient
Imports System.Data

Public Class idnpoker
    Public Const objXML As String = "<?xml version=""1.0"" encoding=""utf-8"" ?><request><secret_key>##secretkey##</secret_key><id>##id##</id>##param##</request>"
    Public Const _SecretKey As String = "9ab5b0c58f3c1dffdb443e655"
    Public Const _ServiceURL As String = "http://​devapi.idnpoker.com:2802/"

    Public Shared Function _SecretFunctionParameters() As String
        Dim XML As String = objXML
        XML = objXML.Replace("##secretkey##", _SecretKey)

        Return XML
    End Function

    Public Shared Function buildParam(strAttribute As String, strValue As String) As String
        Return "<" + strAttribute + ">" + strValue + "</" + strAttribute + ">"
    End Function

    Public Shared Function postHTTP(strXml As String) As String
        Dim reqData As Byte() = Encoding.UTF8.GetBytes(strXml)
        Dim webReq As HttpWebRequest = DirectCast(WebRequest.Create(_ServiceURL), HttpWebRequest)
        webReq.Method = "POST"
        webReq.ContentLength = reqData.Length
        webReq.ContentType = "text/xml; encoding='utf-8'"
        Dim strResponse As String = ""

        Try
            Dim log_id As String = ""
            log_id = commonfunc.logAPIRequest(strXml, "IDNPOKER", "KR-AFF")

            Dim reqStream As Stream = webReq.GetRequestStream()
            reqStream.Write(reqData, 0, reqData.Length)
            reqStream.Flush()
            reqStream.Close()

            Dim webRes As HttpWebResponse = DirectCast(webReq.GetResponse(), HttpWebResponse)
            If webRes.StatusCode = HttpStatusCode.OK Then
                Dim objStream As Stream = webRes.GetResponseStream()
                strResponse = New StreamReader(objStream).ReadToEnd()
                commonfunc.logAPIResponse(log_id, strResponse, "KR-AFF")
            Else
                HttpContext.Current.Response.Write(webRes.StatusCode + webRes.StatusDescription)
                HttpContext.Current.Response.[End]()
            End If
        Catch webex As WebException
            HttpContext.Current.Response.Write(webex.Message.ToString())
            HttpContext.Current.Response.[End]()
        Catch ex As Exception
            ' log error
            ' return false
            HttpContext.Current.Response.Write(ex.Message.ToString())
            HttpContext.Current.Response.[End]()
        End Try

        Return strResponse
    End Function

    Public Shared Function register(username As String, nickname As String, password As String, bankname As String, bankaccname As String, bankaccno As String, bankbranch As String, bankprovince As String, bankcity As String, ByRef strStatus As String, ByRef strMessage As String) As String
        Dim strParam As String
        Dim strXML As String = _SecretFunctionParameters()
        Dim strRtnXML As String

        Try
            strParam = buildParam("userid", nickname)
            strParam += buildParam("loginid", username)
            strParam += buildParam("password", password)
            strParam += buildParam("confirm_password", password)
            strParam += buildParam("username", username)
            strParam += buildParam("bankname", bankname)
            strParam += buildParam("bankaccname", bankaccname)
            strParam += buildParam("bankaccno", bankaccno)
            strParam += buildParam("bankbranch", bankbranch)
            strParam += buildParam("bankprovince", bankprovince)
            strParam += buildParam("bankcity", bankcity)
            strXML = strXML.Replace("##id##", "1111")
            strXML = strXML.Replace("##param##", strParam)
            strRtnXML = postHTTP(strXML)

            strStatus = commonfunc.readXMLTag(strRtnXML, "status")
            strMessage = commonfunc.readXMLTag(strRtnXML, "message")

            Return strStatus
        Catch ex As Exception
            strMessage = "System Error. Please try again later."
            ' log error
            ' return false
            Return "-1"
        End Try
    End Function

    Public Shared Sub getDailyReport(report_date As String, ByRef strStatus As String, ByRef strMessage As String)
        Dim strParam As String
        Dim strXML As String = _SecretFunctionParameters()
        Dim strRtnXML As String
        Dim xFile As XmlDocument
        Dim cnode As XmlNode
        Dim intPlayer As Integer
        Dim strUsername As String
        Dim dblTotal_Turnover As Double, dblTurnover_Poker As Double, dblTurnover_Domino As Double, dblTurnover_Ceme As Double, dblTurnover_Blackjack As Double, dblTurnover_Capsa As Double, dblTurnover_Livepoker As Double, dblTurnover_Ceme_Keliling As Double, dblTurnover_Superten As Double, dblTurnover_Ohama As Double
        Dim dblWinlose_Capsa As Double, dblWinlose_Texaspoker As Double, dblWinlose_Domino As Double, dblWinlose_Ceme As Double, dblWinlose_Blackjack As Double, dblWinlose_Livepoker As Double, dblWinlose_Tournament As Double, dblWinlose_Ceme_Keliling As Double, dblWinlose_Superten As Double, dblWinlose_Ohama As Double

        Dim dblAgent_Comm As Double, dblAgent_Bill As Double
	Dim connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString)
        Dim command As New SqlCommand
        Dim sql As String

        Try
            strParam = buildParam("date", report_date)
            ' month/date/year
            strXML = strXML.Replace("##id##", "8")
            strXML = strXML.Replace("##param##", strParam)
            strRtnXML = postHTTP(strXML)

            'strRtnXML = "<?xml version="1.0" encoding="utf-8"?><response><id>8</id><data type="array"><detail><userid>AKSLFFKFL</userid><total_turnover>5594679.083</total_turnover><turnover_poker>5594679.083</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>1071210.971</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>167840.372</agent_commission><agent_bill>1239051.344</agent_bill></detail><detail><userid>AKZKDHWNS</userid><total_turnover>2399649.583</total_turnover><turnover_poker>2399649.583</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-362968.046</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>71989.487</agent_commission><agent_bill>-290978.559</agent_bill></detail><detail><userid>ALSWO307</userid><total_turnover>1064233.833</total_turnover><turnover_poker>1064233.833</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-184449.572</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>31927.015</agent_commission><agent_bill>-152522.557</agent_bill></detail><detail><userid>ANTHONY11</userid><total_turnover>32615882.5</total_turnover><turnover_poker>32615882.5</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-1262779.190</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>978476.475</agent_commission><agent_bill>-284302.715</agent_bill></detail><detail><userid>AREA0123</userid><total_turnover>42163.75</total_turnover><turnover_poker>42163.75</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-22179.931</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>1264.912</agent_commission><agent_bill>-20915.019</agent_bill></detail><detail><userid>ARH0896</userid><total_turnover>13553</total_turnover><turnover_poker>13553</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-6.545</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>406.59</agent_commission><agent_bill>400.044</agent_bill></detail><detail><userid>CHOI1800</userid><total_turnover>79440.5</total_turnover><turnover_poker>79440.5</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>30891.736</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>2383.215</agent_commission><agent_bill>33274.951</agent_bill></detail><detail><userid>DKDRLAHFP</userid><total_turnover>173989.916</total_turnover><turnover_poker>173989.916</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>22275.922</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>5219.697</agent_commission><agent_bill>27495.62</agent_bill></detail><detail><userid>DLDNWJD1</userid><total_turnover>603980.416</total_turnover><turnover_poker>603980.416</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>140016.130</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>18119.412</agent_commission><agent_bill>158135.543</agent_bill></detail><detail><userid>DLSHTPSTM1</userid><total_turnover>634135.25</total_turnover><turnover_poker>634135.25</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-258946.983</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>19024.057</agent_commission><agent_bill>-239922.925</agent_bill></detail><detail><userid>DLSHTPSTM2</userid><total_turnover>14459339.916</total_turnover><turnover_poker>14459339.916</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-79452.670</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>433780.197</agent_commission><agent_bill>354327.526</agent_bill></detail><detail><userid>DLWLGP22</userid><total_turnover>237691.916</total_turnover><turnover_poker>237691.916</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-101420.739</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>7130.757</agent_commission><agent_bill>-94289.981</agent_bill></detail><detail><userid>DONGHYUNG</userid><total_turnover>542397.333</total_turnover><turnover_poker>542397.333</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>19639.743</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>16271.92</agent_commission><agent_bill>35911.663</agent_bill></detail><detail><userid>FERAGANO1</userid><total_turnover>108404.083</total_turnover><turnover_poker>108404.083</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-56262.046</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>3252.122</agent_commission><agent_bill>-53009.924</agent_bill></detail><detail><userid>GREENZEBRA</userid><total_turnover>164553592.416</total_turnover><turnover_poker>164553592.416</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>11130063.291</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>4936607.772</agent_commission><agent_bill>16066671.064</agent_bill></detail><detail><userid>HEROHKY</userid><total_turnover>18659477.75</total_turnover><turnover_poker>18659477.75</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-5092283.770</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>559784.332</agent_commission><agent_bill>-4532499.438</agent_bill></detail><detail><userid>HIFRAND</userid><total_turnover>139845.416</total_turnover><turnover_poker>139845.416</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-41666.705</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>4195.362</agent_commission><agent_bill>-37471.342</agent_bill></detail><detail><userid>HOTBANABA</userid><total_turnover>66166.666</total_turnover><turnover_poker>66166.666</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-50000</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>1985</agent_commission><agent_bill>-48015</agent_bill></detail><detail><userid>ICKSTREAM</userid><total_turnover>8509192.75</total_turnover><turnover_poker>8509192.75</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>2861703.706</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>255275.782</agent_commission><agent_bill>3116979.489</agent_bill></detail><detail><userid>ILDJJANG</userid><total_turnover>377077</total_turnover><turnover_poker>377077</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>41076.42</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>11312.31</agent_commission><agent_bill>52388.73</agent_bill></detail><detail><userid>JJAPSA112</userid><total_turnover>3095057.083</total_turnover><turnover_poker>3095057.083</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-695738.965</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>92851.712</agent_commission><agent_bill>-602887.252</agent_bill></detail><detail><userid>K6W1O0N1</userid><total_turnover>1580073.833</total_turnover><turnover_poker>1580073.833</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-461338.236</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>47402.215</agent_commission><agent_bill>-413936.021</agent_bill></detail><detail><userid>KURGAST</userid><total_turnover>220739</total_turnover><turnover_poker>220739</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>70376.591</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>6622.17</agent_commission><agent_bill>76998.761</agent_bill></detail><detail><userid>LEEJAMI</userid><total_turnover>241877</total_turnover><turnover_poker>241877</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-37473.911</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>7256.31</agent_commission><agent_bill>-30217.601</agent_bill></detail><detail><userid>LEIGHSY</userid><total_turnover>302432.916</total_turnover><turnover_poker>302432.916</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>175563.036</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>9072.987</agent_commission><agent_bill>184636.024</agent_bill></detail><detail><userid>LIFEGOESON</userid><total_turnover>640457.916</total_turnover><turnover_poker>640457.916</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-200000.074</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>19213.737</agent_commission><agent_bill>-180786.336</agent_bill></detail><detail><userid>LIM6101</userid><total_turnover>2290088.166</total_turnover><turnover_poker>2290088.166</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>371678.81</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>68702.645</agent_commission><agent_bill>440381.455</agent_bill></detail><detail><userid>LIMESLIDE</userid><total_turnover>64631.833</total_turnover><turnover_poker>64631.833</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-47858.916</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>1938.955</agent_commission><agent_bill>-45919.961</agent_bill></detail><detail><userid>LMG229</userid><total_turnover>2897502.166</total_turnover><turnover_poker>2897502.166</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>54889.08</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>86925.065</agent_commission><agent_bill>141814.145</agent_bill></detail><detail><userid>LSHOUTL</userid><total_turnover>1682616.666</total_turnover><turnover_poker>1682616.666</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>288587.100</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>50478.5</agent_commission><agent_bill>339065.600</agent_bill></detail><detail><userid>NAURI79</userid><total_turnover>459196.583</total_turnover><turnover_poker>459196.583</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-32020.061</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>13775.897</agent_commission><agent_bill>-18244.164</agent_bill></detail><detail><userid>NERDYSMURF</userid><total_turnover>46460340.25</total_turnover><turnover_poker>46460340.25</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>3746841.077</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>1393810.207</agent_commission><agent_bill>5140651.285</agent_bill></detail><detail><userid>NOML0516</userid><total_turnover>3380909</total_turnover><turnover_poker>3380909</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-164768.956</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>101427.27</agent_commission><agent_bill>-63341.686</agent_bill></detail><detail><userid>POKER1233</userid><total_turnover>2216631</total_turnover><turnover_poker>2216631</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>1193438.627</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>66498.93</agent_commission><agent_bill>1259937.557</agent_bill></detail><detail><userid>PSKGOLDS84</userid><total_turnover>4249327.5</total_turnover><turnover_poker>4249327.5</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>299505.388</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>127479.825</agent_commission><agent_bill>426985.213</agent_bill></detail><detail><userid>RAREN1</userid><total_turnover>703653.666</total_turnover><turnover_poker>703653.666</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-82940.724</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>21109.61</agent_commission><agent_bill>-61831.114</agent_bill></detail><detail><userid>RIGHTRAIN4</userid><total_turnover>1362160.333</total_turnover><turnover_poker>1362160.333</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>95829.691</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>40864.81</agent_commission><agent_bill>136694.501</agent_bill></detail><detail><userid>ROCKERLYC3</userid><total_turnover>642105.75</total_turnover><turnover_poker>642105.75</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>416810.916</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>19263.172</agent_commission><agent_bill>436074.089</agent_bill></detail><detail><userid>RTD3385</userid><total_turnover>463693.666</total_turnover><turnover_poker>463693.666</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>44205.77</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>13910.81</agent_commission><agent_bill>58116.58</agent_bill></detail><detail><userid>RTD3387</userid><total_turnover>139033.333</total_turnover><turnover_poker>139033.333</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>34933.175</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>4171</agent_commission><agent_bill>39104.175</agent_bill></detail><detail><userid>RTD3388</userid><total_turnover>45968.416</total_turnover><turnover_poker>45968.416</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-24922.003</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>1379.052</agent_commission><agent_bill>-23542.950</agent_bill></detail><detail><userid>S123457</userid><total_turnover>156193.75</total_turnover><turnover_poker>156193.75</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-385.398</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>4685.812</agent_commission><agent_bill>4300.414</agent_bill></detail><detail><userid>SIRASONI88</userid><total_turnover>1854.166</total_turnover><turnover_poker>1854.166</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-1854.166</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>55.625</agent_commission><agent_bill>-1798.541</agent_bill></detail><detail><userid>SKARE888</userid><total_turnover>573342.166</total_turnover><turnover_poker>573342.166</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>228344.712</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>17200.265</agent_commission><agent_bill>245544.977</agent_bill></detail><detail><userid>SUNGSOO</userid><total_turnover>11862</total_turnover><turnover_poker>11862</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-9032.833</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>355.86</agent_commission><agent_bill>-8676.973</agent_bill></detail><detail><userid>SWHA1012</userid><total_turnover>68265545.083</total_turnover><turnover_poker>68265545.083</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>8047008.480</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>2047966.352</agent_commission><agent_bill>10094974.833</agent_bill></detail><detail><userid>TAEWOONG</userid><total_turnover>9672550.333</total_turnover><turnover_poker>9672550.333</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>100506.953</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>290176.51</agent_commission><agent_bill>390683.463</agent_bill></detail><detail><userid>TAUSETAUSE</userid><total_turnover>4420226.5</total_turnover><turnover_poker>4420226.5</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>214730.406</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>132606.795</agent_commission><agent_bill>347337.201</agent_bill></detail><detail><userid>THRHRL1</userid><total_turnover>1275482.333</total_turnover><turnover_poker>1275482.333</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>328936.252</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>38264.47</agent_commission><agent_bill>367200.722</agent_bill></detail><detail><userid>TONGGUE</userid><total_turnover>5265946.416</total_turnover><turnover_poker>5265946.416</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>463493.630</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>157978.392</agent_commission><agent_bill>621472.023</agent_bill></detail><detail><userid>UPSIN</userid><total_turnover>13617997.75</total_turnover><turnover_poker>13617997.75</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-1007758.54</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>408539.932</agent_commission><agent_bill>-599218.607</agent_bill></detail><detail><userid>USEI2</userid><total_turnover>514082.583</total_turnover><turnover_poker>514082.583</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-14570.655</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>15422.477</agent_commission><agent_bill>851.821</agent_bill></detail><detail><userid>VKFKDFPWHD</userid><total_turnover>874214.333</total_turnover><turnover_poker>874214.333</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-540000.025</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>26226.43</agent_commission><agent_bill>-513773.595</agent_bill></detail><detail><userid>WRCHOI123</userid><total_turnover>52733</total_turnover><turnover_poker>52733</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-19946.03</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>1581.99</agent_commission><agent_bill>-18364.04</agent_bill></detail><detail><userid>ZORBA0319</userid><total_turnover>2482266.25</total_turnover><turnover_poker>2482266.25</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-1135197.018</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>74467.987</agent_commission><agent_bill>-1060729.030</agent_bill></detail><detail><userid>ZZ1973</userid><total_turnover>53166.666</total_turnover><turnover_poker>53166.666</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-53250</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>1595</agent_commission><agent_bill>-51655</agent_bill></detail></data></response><?xml version="1.0" encoding="utf-8"?><response><id>8</id><data type="array"><detail><userid>AKSLFFKFL</userid><total_turnover>5594679.083</total_turnover><turnover_poker>5594679.083</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>1071210.971</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>167840.372</agent_commission><agent_bill>1239051.344</agent_bill></detail><detail><userid>AKZKDHWNS</userid><total_turnover>2399649.583</total_turnover><turnover_poker>2399649.583</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-362968.046</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>71989.487</agent_commission><agent_bill>-290978.559</agent_bill></detail><detail><userid>ALSWO307</userid><total_turnover>1064233.833</total_turnover><turnover_poker>1064233.833</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-184449.572</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>31927.015</agent_commission><agent_bill>-152522.557</agent_bill></detail><detail><userid>ANTHONY11</userid><total_turnover>32615882.5</total_turnover><turnover_poker>32615882.5</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-1262779.190</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>978476.475</agent_commission><agent_bill>-284302.715</agent_bill></detail><detail><userid>AREA0123</userid><total_turnover>42163.75</total_turnover><turnover_poker>42163.75</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-22179.931</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>1264.912</agent_commission><agent_bill>-20915.019</agent_bill></detail><detail><userid>ARH0896</userid><total_turnover>13553</total_turnover><turnover_poker>13553</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-6.545</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>406.59</agent_commission><agent_bill>400.044</agent_bill></detail><detail><userid>CHOI1800</userid><total_turnover>79440.5</total_turnover><turnover_poker>79440.5</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>30891.736</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>2383.215</agent_commission><agent_bill>33274.951</agent_bill></detail><detail><userid>DKDRLAHFP</userid><total_turnover>173989.916</total_turnover><turnover_poker>173989.916</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>22275.922</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>5219.697</agent_commission><agent_bill>27495.62</agent_bill></detail><detail><userid>DLDNWJD1</userid><total_turnover>603980.416</total_turnover><turnover_poker>603980.416</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>140016.130</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>18119.412</agent_commission><agent_bill>158135.543</agent_bill></detail><detail><userid>DLSHTPSTM1</userid><total_turnover>634135.25</total_turnover><turnover_poker>634135.25</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-258946.983</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>19024.057</agent_commission><agent_bill>-239922.925</agent_bill></detail><detail><userid>DLSHTPSTM2</userid><total_turnover>14459339.916</total_turnover><turnover_poker>14459339.916</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0</turnover_ceme_keliling><texaspoker>-79452.670</texaspoker><domino>0</domino><ceme>0</ceme><blackjack>0</blackjack><capsa>0</capsa><livepoker>0</livepoker><poker_tournament>0</poker_tournament><ceme_keliling>0</ceme_keliling><agent_commission>433780.197</agent_commission><agent_bill>354327.526</agent_bill></detail><detail><userid>DLWLGP22</userid><total_turnover>237691.916</total_turnover><turnover_poker>237691.916</turnover_poker><turnover_domino>0</turnover_domino><turnover_ceme>0</turnover_ceme><turnover_blackjack>0</turnover_blackjack><turnover_capsa>0</turnover_capsa><turnover_livepoker>0</turnover_livepoker><turnover_ceme_keliling>0<"
            'strRtnXML = strRtnXML.Replace(" type=array", "")
            strStatus = "1"
            strMessage = ""

            xFile = New XmlDocument()
            xFile.LoadXml(strRtnXML)
            xFile.GetElementsByTagName("data")(0).Attributes.RemoveNamedItem("type")

            Dim strNewXML As String = xFile.InnerXml
            Dim objNewXML As XmlDocument = New XmlDocument()
            objNewXML.LoadXml(strNewXML)
            intPlayer = objNewXML.ChildNodes(1)("data").ChildNodes.Count

	    sql = "INSERT INTO tblkr_Player_Transaction (Username, ReportDate, Total_Turnover, Turnover_Poker, Turnover_Ceme, Turnover_Domino, Turnover_Blackjack, Turnover_Capsa, Turnover_Livepoker, Turnover_Ceme_Keliling, Turnover_Superten, Turnover_Ohama, " &
	"Winlose_Poker, Winlose_Ceme, Winlose_Domino, Winlose_Blackjack, Winlose_Capsa, Winlose_Livepoker, Winlose_Tournament, Winlose_Ceme_Keliling, Winlose_Superten, Winlose_Ohama, Agent_Comm, Agent_Bill) VALUES "
	    Dim strDate() As String = report_date.Split("/")
            Dim dtReportDate As DateTime = Convert.ToDateTime(strDate(1) + "-" + MonthName(strDate(0)) + "-" + strDate(2))
            
            If intPlayer > 0 Then
                For i As Integer = 0 To intPlayer - 1
                    cnode = objNewXML.ChildNodes(1)("data").ChildNodes(i)

                    For j As Integer = 0 To cnode.ChildNodes.Count - 1
                        Select Case cnode.ChildNodes(j).Name
                            Case "userid"
                                strUsername = cnode.ChildNodes(j).InnerText
                                Exit Select
                            Case "total_turnover"
                                dblTotal_Turnover = (cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "turnover_poker"
                                dblTurnover_Poker = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "turnover_domino"
                                dblTurnover_Domino = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "turnover_ceme"
                                dblTurnover_Ceme = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "turnover_blackjack"
                                dblTurnover_Blackjack = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "turnover_capsa"
                                dblTurnover_Capsa = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "turnover_livepoker"
                                dblTurnover_Livepoker = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "turnover_Ceme_Keliling"
                                dblTurnover_Ceme_Keliling = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "turnover_Superten"
                                dblTurnover_Superten = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "turnover_Ohama"
                                dblTurnover_Ohama = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "capsa"
                                dblWinlose_Capsa = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "texaspoker"
                                dblWinlose_Texaspoker = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "domino"
                                dblWinlose_Domino = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "ceme"
                                dblWinlose_Ceme = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "blackjack"
                                dblWinlose_Blackjack = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "livepoker"
                                dblWinlose_Livepoker = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "poker_tournament"
                                dblWinlose_Tournament = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "ceme_keliling"
                                dblWinlose_Ceme_Keliling = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "superten"
                                dblWinlose_Superten = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "ohama"
                                dblWinlose_Ohama = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "agent_commission"
                                dblAgent_Comm = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case "agent_bill"
                                dblAgent_Bill = Convert.ToDouble(cnode.ChildNodes(j).InnerText)
                                Exit Select
                            Case Else
                                Exit Select
                        End Select
                    Next
                    'insert data into DB
		    sql &= "('" & strUsername & "', '" & dtReportDate & "', " & dblTotal_Turnover & ", " & dblTurnover_Poker & ", " & dblTurnover_Ceme & ", " & dblTurnover_Domino & ", " & dblTurnover_Blackjack & ", " & dblTurnover_Capsa & ", " & dblTurnover_Livepoker & ", " & dblTurnover_Ceme_Keliling & ", " & dblTurnover_Superten & ", " & dblTurnover_Ohama & ", " & dblWinlose_Texaspoker & ", " & dblWinlose_Ceme & ", " & dblWinlose_Domino & ", " & dblWinlose_Blackjack & ", " & dblWinlose_Capsa & ", " & dblWinlose_Livepoker & ", " & dblWinlose_Tournament & ", " & dblWinlose_Ceme_Keliling & ", " & dblWinlose_Superten & ", " & dblWinlose_Ohama & ", " & dblAgent_Comm & ", " & dblAgent_Bill & "), "
		    'InsertPlayerTransaction(strUsername, report_date, dblTotal_Turnover, dblTurnover_Poker, dblTurnover_Domino, dblTurnover_Ceme, dblTurnover_Blackjack, dblTurnover_Capsa, dblTurnover_Livepoker,
                                            'dblTurnover_Ceme_Keliling, dblTurnover_Superten, dblTurnover_Ohama, dblWinlose_Capsa, dblWinlose_Texaspoker, dblWinlose_Domino, dblWinlose_Ceme, dblWinlose_Blackjack,
                                            'dblWinlose_Livepoker, dblWinlose_Tournament, dblWinlose_Ceme_Keliling, dblWinlose_Superten, dblWinlose_Ohama, dblAgent_Comm, dblAgent_Bill)
                Next
            End If
	    Dim index As Integer
            index = sql.LastIndexOf(", ")
            If index > -1
		sql = sql.Remove(index, 2)
		connection.Open()
                command = New SqlCommand(sql, connection)
                command.ExecuteNonQuery()
                connection.Close()
            End If
        Catch ex As Exception
            strMessage = ex.Message() '"System Error. Please try again later."
            ' log error
            ' return false
            strStatus = "-1"
        End Try
    End Sub

    Public Shared Function getPlayer(username As String, ByRef nickname As String, ByRef strStatus As String, ByRef strMessage As String) As String
        Dim strParam As String
        Dim strXML As String = _SecretFunctionParameters()
        Dim strRtnXML As String

        Try
            strParam = buildParam("userid", username)
            strXML = strXML.Replace("##id##", "10")
            strXML = strXML.Replace("##param##", strParam)
            strRtnXML = postHTTP(strXML)

            nickname = commonfunc.readXMLTag(strRtnXML, "username")
            strStatus = commonfunc.readXMLTag(strRtnXML, "status")
            strMessage = commonfunc.readXMLTag(strRtnXML, "message")

            Return strStatus
        Catch ex As Exception
            strMessage = "System Error. Please try again later."
            ' log error
            ' return false
            Return "-1"
        End Try
    End Function

    Public Shared Function registerMobile(username As String, login As String, ByRef strStatus As String, ByRef strMessage As String) As String
        Dim strParam As String
        Dim strXML As String = _SecretFunctionParameters()
        Dim strRtnXML As String

        Try
            strParam = buildParam("userid", username)
            strParam += buildParam("loginid", login)
            strXML = strXML.Replace("##id##", "17")
            strXML = strXML.Replace("##param##", strParam)
            strRtnXML = postHTTP(strXML)

            strStatus = commonfunc.readXMLTag(strRtnXML, "status")
            ' 0 = available, 1 = already exist
            strMessage = commonfunc.readXMLTag(strRtnXML, "message")

            Return strStatus
        Catch ex As Exception
            strMessage = "System Error. Please try again later."
            ' log error
            ' return false
            Return "-1"
        End Try
    End Function

    Private Shared Sub InsertPlayerTransaction(ByVal strUsername As String, ByVal strReportDate As String, ByVal dblTotal_Turnover As Double, ByVal dblTurnover_Poker As Double, ByVal dblTurnover_Domino As Double, ByVal dblTurnover_Ceme As Double, ByVal dblTurnover_Blackjack As Double, ByVal dblTurnover_Capsa As Double, ByVal dblTurnover_Livepoker As Double, ByVal dblTurnover_Ceme_Keliling As Double, ByVal dblTurnover_Superten As Double, ByVal dblTurnover_Ohama As Double, ByVal dblwinlose_Capsa As Double, ByVal dblWinlose_Poker As Double, ByVal dblWinlose_Domino As Double, ByVal dblWinlose_Ceme As Double, ByVal dblWinlose_Blackjack As Double, ByVal dblWinlose_Livepoker As Double, ByVal dblWinlose_Tournament As Double, ByVal dblWinlose_Ceme_Keliling As Double, ByVal dblWinlose_Superten As Double, ByVal dblWinlose_Ohama As Double, ByVal dblAgent_Comm As Double, ByVal dblAgent_Bill As Double)
        Dim cs As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString
        Dim sqlConn As SqlConnection = New SqlConnection(cs)
        Dim sqlcommand As New SqlCommand
        Dim strDate() As String = strReportDate.Split("/")
        Dim dtReportDate As DateTime = Convert.ToDateTime(strDate(1) + "-" + MonthName(strDate(0)) + "-" + strDate(2))

        Try
            sqlConn.Open()
            sqlcommand.Connection = sqlConn
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = System.Configuration.ConfigurationManager.AppSettings("KR_insert_player_trans").ToString

            sqlcommand.Parameters.Add(New SqlParameter("@Username", SqlDbType.NVarChar)).Value = strUsername
            sqlcommand.Parameters.Add(New SqlParameter("@ReportDate", SqlDbType.DateTime)).Value = dtReportDate
            sqlcommand.Parameters.Add(New SqlParameter("@Total_Turnover", SqlDbType.Decimal)).Value = dblTotal_Turnover
            sqlcommand.Parameters.Add(New SqlParameter("@Turnover_Poker", SqlDbType.Decimal)).Value = dblTurnover_Poker
            sqlcommand.Parameters.Add(New SqlParameter("@Turnover_Ceme", SqlDbType.Decimal)).Value = dblTurnover_Ceme
            sqlcommand.Parameters.Add(New SqlParameter("@Turnover_Domino", SqlDbType.Decimal)).Value = dblTurnover_Domino
            sqlcommand.Parameters.Add(New SqlParameter("@Turnover_Blackjack", SqlDbType.Decimal)).Value = dblTurnover_Blackjack
            sqlcommand.Parameters.Add(New SqlParameter("@Turnover_Capsa", SqlDbType.Decimal)).Value = dblTurnover_Capsa
            sqlcommand.Parameters.Add(New SqlParameter("@Turnover_Livepoker", SqlDbType.Decimal)).Value = dblTurnover_Livepoker
            sqlcommand.Parameters.Add(New SqlParameter("@Turnover_Ceme_Keliling", SqlDbType.Decimal)).Value = dblTurnover_Ceme_Keliling
            sqlcommand.Parameters.Add(New SqlParameter("@Turnover_Superten", SqlDbType.Decimal)).Value = dblTurnover_Superten
            sqlcommand.Parameters.Add(New SqlParameter("@Turnover_Ohama", SqlDbType.Decimal)).Value = dblTurnover_Ohama
            sqlcommand.Parameters.Add(New SqlParameter("@Winlose_Poker", SqlDbType.Decimal)).Value = dblWinlose_Poker
            sqlcommand.Parameters.Add(New SqlParameter("@Winlose_Ceme", SqlDbType.Decimal)).Value = dblWinlose_Ceme
            sqlcommand.Parameters.Add(New SqlParameter("@Winlose_Domino", SqlDbType.Decimal)).Value = dblWinlose_Domino
            sqlcommand.Parameters.Add(New SqlParameter("@Winlose_Blackjack", SqlDbType.Decimal)).Value = dblWinlose_Blackjack
            sqlcommand.Parameters.Add(New SqlParameter("@Winlose_Capsa", SqlDbType.Decimal)).Value = dblwinlose_Capsa
            sqlcommand.Parameters.Add(New SqlParameter("@Winlose_Livepoker", SqlDbType.Decimal)).Value = dblWinlose_Livepoker
            sqlcommand.Parameters.Add(New SqlParameter("@Winlose_Tournament", SqlDbType.Decimal)).Value = dblWinlose_Tournament
            sqlcommand.Parameters.Add(New SqlParameter("@Winlose_Ceme_keliling", SqlDbType.Decimal)).Value = dblWinlose_Ceme_Keliling
            sqlcommand.Parameters.Add(New SqlParameter("@Winlose_Superten", SqlDbType.Decimal)).Value = dblWinlose_Superten
            sqlcommand.Parameters.Add(New SqlParameter("@Winlose_Ohama", SqlDbType.Decimal)).Value = dblWinlose_Ohama
            sqlcommand.Parameters.Add(New SqlParameter("@Agent_Comm", SqlDbType.Decimal)).Value = dblAgent_Comm
            sqlcommand.Parameters.Add(New SqlParameter("@Agent_Bill", SqlDbType.Decimal)).Value = dblAgent_Bill

            sqlcommand.ExecuteNonQuery()
        Catch ex As Exception
            commonfunc.subSP_EXCEPTION_INSERT("InsertPlayerTransaction", ex)
        Finally
            sqlConn.Close()
        End Try
    End Sub

    '-- KC Yap on 23/07/2022 - To support deposit
    Public Shared Sub deposit(username As String, transactionId As String, depositAmt As Decimal, ByRef strStatus As String, ByRef strMessage As String)
        Dim strParam As String
        Dim strXML As String = _SecretFunctionParameters()
        Dim strRtnXML As String

        Try
            strParam = buildParam("userid", username)
            strParam += buildParam("id_transaction", transactionId)
            strParam += buildParam("deposit", Math.Floor(depositAmt))
            strXML = strXML.Replace("##id##", "3")
            strXML = strXML.Replace("##param##", strParam)
            strRtnXML = postHTTP(strXML)

            strStatus = commonfunc.readXMLTag(strRtnXML, "status")
            strMessage = commonfunc.readXMLTag(strRtnXML, "message")

        Catch ex As Exception
            strStatus = "0"
            strMessage = "System Error. Please try again later."
        End Try
    End Sub

    '-- Kael on 18/03/2024 - To validate registration
    Public Shared Sub registerValidation(strColumn As String, strValue As String, strValueAdd As String, ByRef strStatus As String, ByRef strMessage As String)
        Dim strParam As String
        Dim strXML As String = _SecretFunctionParameters()
        Dim strRtnXML As String

        Try
            strParam = buildParam("column", strColumn)
            strParam += buildParam("value", strValue)
            strParam += buildParam("value_add", strValueAdd)
            strXML = strXML.Replace("##id##", "19")
            strXML = strXML.Replace("##param##", strParam)
            strRtnXML = postHTTP(strXML)

            strStatus = commonfunc.readXMLTag(strRtnXML, "status")
            strMessage = commonfunc.readXMLTag(strRtnXML, "message")

        Catch ex As Exception
            strStatus = "0"
            strMessage = "System Error. Please try again later."
        End Try
    End Sub
End Class
