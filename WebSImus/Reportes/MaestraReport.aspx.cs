using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSImus.Reportes
{
    public partial class MaestraReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderReport();
            }
        }

        private void RenderReport()
        {
            ReportViewer1.Reset();
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reportes/ReporteDatosBasicos.rdlc");
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSetReporteDatosBasicos";
            DataTable dataTable = new DataTable();
            reportDataSource.Value = dataTable;
          
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
           

        }
    }
}