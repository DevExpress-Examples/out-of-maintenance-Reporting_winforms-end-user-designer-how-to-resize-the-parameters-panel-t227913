Imports System

Namespace WindowsFormsApplication3
    Partial Public Class XtraReport1
        Inherits DevExpress.XtraReports.UI.XtraReport

        Public Sub New()
            InitializeComponent()
            Me.Parameters("paramLandscape").Value = Me.Landscape
        End Sub
        Private Sub XtraReport1_ParametersRequestSubmit(ByVal sender As Object, ByVal e As DevExpress.XtraReports.Parameters.ParametersRequestEventArgs) Handles MyBase.ParametersRequestSubmit
            Me.Landscape = CBool(Me.Parameters("paramLandscape").Value)
        End Sub
    End Class
End Namespace
