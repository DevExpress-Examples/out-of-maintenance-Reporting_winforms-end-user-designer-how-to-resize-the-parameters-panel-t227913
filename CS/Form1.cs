using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.UI;

namespace WindowsFormsApplication3 {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
        }
        private void simpleButton1_Click(object sender, EventArgs e) {
            ShowDesigner();
        }
        private void ShowDesigner() {
            ReportDesignTool dt = new ReportDesignTool(new XtraReport1());
            dt.DesignForm.DesignMdiController.DesignPanelLoaded += DesignMdiController_DesignPanelLoaded;
            dt.ShowDesigner();
        }
        private void DesignMdiController_DesignPanelLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e) {
            ReportTabControl tabControl = e.DesignerHost.GetService(typeof(ReportTabControl)) as ReportTabControl;
            if(tabControl == null) {
                return;
            }
            tabControl.SelectedTabIndexChanged += tabControl_SelectedTabIndexChanged;
        }
        private void tabControl_SelectedTabIndexChanged(object sender, EventArgs e) {
            ReportTabControl tabControl = sender as ReportTabControl;
            if(tabControl != null && tabControl.PreviewReport != null) {
                DevExpress.XtraBars.Docking.DockPanel paramsPanel = GetParamsPanel(tabControl);
                if(paramsPanel != null) {
                    paramsPanel.Width = 500;
                }
            }
        }
        private DevExpress.XtraBars.Docking.DockPanel GetParamsPanel(ReportTabControl tabControl) {
            return tabControl.PreviewControl.DockManager.Panels.FirstOrDefault(x => x.Text == GetParametersPanelText());
        }
        private System.String GetParametersPanelText() {
            return DevExpress.XtraPrinting.Localization.PreviewLocalizer.GetString(DevExpress.XtraPrinting.Localization.PreviewStringId.ParametersRequest_Caption);
        }
    }
}
