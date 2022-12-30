Imports DevExpress.Xpf.Grid
Imports System
Imports System.Windows.Data
Imports System.Windows.Markup

Namespace CustomColumnHeader

    Public Class CustomHeaderConverter
        Inherits MarkupExtension
        Implements IMultiValueConverter

        Public Function Convert(ByVal values As Object(), ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object
            Dim originalHeader As String = Nothing, headerType As HeaderPresenterType = Nothing
            If CSharpImpl.__Assign(originalHeader, TryCast(values(0), String)) IsNot Nothing AndAlso CSharpImpl.__Assign(headerType, TryCast(values(1), HeaderPresenterType)) IsNot Nothing Then
                Return GetCustomHeaderString(originalHeader, headerType)
            End If

            Return values(0)
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

        Private Class CSharpImpl

            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
