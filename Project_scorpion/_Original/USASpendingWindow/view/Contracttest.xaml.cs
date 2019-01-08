using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace USAspendingWindow
{
    /// <summary>
    /// Interaction logic for Contracttest.xaml
    /// </summary>
    public partial class Contracttest : UserControl
    {
        public Contracttest()
        {

            InitializeComponent();
            _reportViewer.Load += ReportViewer_Load;

        }

        private bool _isReportViewerLoaded;

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                using (USAspendEF ef = new USAspendEF())
                {
                    //fill data into table
                   // List<Current_usaspend> tablelist// = new List<Current_usaspend>();


                    //tablelist = ef.Contracts.ToList<Current_usaspend>();

                    var temptable = from c in ef.Contracts
                                    where c.fiscal_year == "2016"
                                    select c;

                    List<Current_usaspend> tablelist = new List<Current_usaspend>(temptable.ToList<Current_usaspend>()); 
                    

                    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();




                    reportDataSource1.Name = "DataSet2"; //Name of the report dataset in our .RDLC file
                    reportDataSource1.Value = tablelist;
                    this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                    this._reportViewer.LocalReport.ReportEmbeddedResource = "USAspendingWindow.rdlc.contracttest.rdlc";




                //    //Microsoft.Reporting.WinForms.ReportParameter[] pars = new Microsoft.Reporting.WinForms.ReportParameter[2];
                //    //pars[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter1", "Austin Service Center");
                //    //pars[1] = new Microsoft.Reporting.WinForms.ReportParameter("Totalrecords", IMFFromEditDS.GetImfFromEdit().Count.ToString());
                //    //this._reportViewer.LocalReport.SetParameters(pars);     


                //_reportViewer.LocalReport.ReportPath = "C:\\Users\\jon.rock\\Documents\\Visual Studio 2010\\Projects\\USAspendingWindow\\USAspendingWindow\\rdlc\\contracttest.rdlc";


                    _reportViewer.RefreshReport();

                    _isReportViewerLoaded = true;

                }
            }
        }


    }
}
