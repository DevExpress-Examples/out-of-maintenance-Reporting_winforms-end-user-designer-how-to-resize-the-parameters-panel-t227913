Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraPrinting.Preview
Imports DevExpress.XtraReports.Design
Imports DevExpress.XtraReports.UI

Namespace WindowsFormsApplication3
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
            ShowDesigner()
        End Sub
        Private Sub ShowDesigner()
            Dim dt As New ReportDesignTool(New XtraReport1())
            AddHandler dt.DesignForm.DesignMdiController.DesignPanelLoaded, AddressOf DesignMdiController_DesignPanelLoaded
            dt.ShowDesigner()
        End Sub
        Private Sub DesignMdiController_DesignPanelLoaded(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs)
            Dim tabControl As ReportTabControl = TryCast(e.DesignerHost.GetService(GetType(ReportTabControl)), ReportTabControl)
            If tabControl Is Nothing Then
                Return
            End If
            AddHandler tabControl.SelectedTabIndexChanged, AddressOf tabControl_SelectedTabIndexChanged
        End Sub
        Private Sub tabControl_SelectedTabIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim tabControl As ReportTabControl = TryCast(sender, ReportTabControl)
            If tabControl IsNot Nothing AndAlso tabControl.PreviewReport IsNot Nothing Then
                Dim paramsPanel As DevExpress.XtraBars.Docking.DockPanel = GetParamsPanel(tabControl)
                If paramsPanel IsNot Nothing Then
                    paramsPanel.Width = 500
                End If
            End If
        End Sub
        Private Function GetParamsPanel(ByVal tabControl As ReportTabControl) As DevExpress.XtraBars.Docking.DockPanel
            Return tabControl.PreviewControl.DockManager.Panels.FirstOrDefault(Function(x) x.Text = GetParametersPanelText())
        End Function
        Private Function GetParametersPanelText() As System.String
            Return DevExpress.XtraPrinting.Localization.PreviewLocalizer.GetString(DevExpress.XtraPrinting.Localization.PreviewStringId.ParametersRequest_Caption)
        End Function
    End Class
End Namespace
