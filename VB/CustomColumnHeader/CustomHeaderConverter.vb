Imports DevExpress.Xpf.Grid
Imports System
Imports System.Windows.Data
Imports System.Windows.Markup

Namespace CustomColumnHeader

    Public Class CustomHeaderConverter
        Inherits MarkupExtension
        Implements IMultiValueConverter

        Public Function Convert(ByVal values As Object(), ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object
            Return GetCustomHeaderString(CStr(values(0)), CType(values(1), HeaderPresenterType))
        End Function

        Private Function GetCustomHeaderString(ByVal originalHeader As String, ByVal headerType As HeaderPresenterType) As String
            Select Case headerType
                Case HeaderPresenterType.Headers
                    Return originalHeader.Replace("Original ", "Custom" & Microsoft.VisualBasic.Constants.vbLf & "Panel" & Microsoft.VisualBasic.Constants.vbLf)
                Case HeaderPresenterType.GroupPanel
                    Return originalHeader.Replace("Original", "Custom Group")
                Case HeaderPresenterType.ColumnChooser
                    Return originalHeader.Replace("Original", "Custom Column Chooser")
            End Select

            Return originalHeader
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetTypes As Type(), ByVal parameter As Object, ByVal culture As CultureInfo) As Object()
            Throw New NotImplementedException()
        End Function

        Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
            Return Me
        End Function
    End Class
End Namespace
