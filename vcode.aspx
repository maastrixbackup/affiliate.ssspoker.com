<%@ Page Language="VB" %>
<script runat="server">
    Dim codeWidth As Integer = 45
    Dim codeHeight As Integer = 28

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim code As String = GenerateVCodeImage(4)
        Session("VCode") = code
    End Sub



    Private Function generateHatchStyle() As Drawing.Drawing2D.HatchStyle
        Dim slist As New ArrayList
        For Each style As Drawing.Drawing2D.HatchStyle In System.Enum.GetValues(GetType(Drawing.Drawing2D.HatchStyle))
            slist.Add(style)
        Next

        Dim randObj As New Random()
        Dim index As Integer = randObj.Next(slist.Count - 1)

        Return CType(slist(index), Drawing.Drawing2D.HatchStyle)
    End Function





    Private Function GenerateVCodeImage(Optional ByVal codeLength As Integer = 4) As String

        Dim oBitmap As Drawing.Bitmap = New Drawing.Bitmap(codeWidth, codeHeight)
        Dim oGraphic As Drawing.Graphics = Drawing.Graphics.FromImage(oBitmap)
        Dim foreColor As System.Drawing.Color
        Dim backColor As System.Drawing.Color

        Dim sText As String = ""
        Dim R As New Random
        Dim i As Integer = 0

        For i = 1 To codeLength
            'If common.generateNumCode(1) Mod 2 = 0 Then
            sText &= R.Next(0, 9) 'common.generateNumCode(1)
            'Else
            'sText &= common.generateAlphaCode(1)
            'End If
        Next


        Dim sFont As String = "Arial"

        Dim oBrushWrite As New Drawing.SolidBrush(Drawing.Color.FromArgb(156, 156, 156))

        ' color scheme
        'foreColor = System.Drawing.Color.FromArgb(255, 102, 102)
        foreColor = System.Drawing.Color.FromArgb(255, 152, 152)
        backColor = System.Drawing.Color.FromArgb(204, 204, 204)
        'oBrushWrite.Color = Drawing.Color.FromArgb(102, 102, 102) ' code text color
        oBrushWrite.Color = Drawing.Color.FromArgb(62, 62, 62)


        Dim oBrush As New Drawing.Drawing2D.HatchBrush(CType(generateHatchStyle(), Drawing.Drawing2D.HatchStyle), foreColor, backColor)

        oGraphic.FillRectangle(oBrush, 0, 0, codeWidth, codeHeight)
        oGraphic.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        Dim oFont As New Drawing.Font(sFont, 12, Drawing.FontStyle.Bold)
        Dim oPoint As New Drawing.PointF(0.0F, 0.0F)

        oGraphic.DrawString(sText, oFont, oBrushWrite, oPoint)

        Response.ContentType = "image/png"
        oBitmap.Save(Response.OutputStream, Drawing.Imaging.ImageFormat.Gif)
        oBitmap.Dispose()

        Return sText
    End Function

</script>