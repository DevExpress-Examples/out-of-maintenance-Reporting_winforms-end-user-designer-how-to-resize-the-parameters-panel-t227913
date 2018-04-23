using System;

namespace WindowsFormsApplication3 {
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport {
        public XtraReport1() {
            InitializeComponent();
            this.Parameters["paramLandscape"].Value = this.Landscape;
        }
        private void XtraReport1_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
            this.Landscape = (bool)this.Parameters["paramLandscape"].Value;
        }
    }
}
