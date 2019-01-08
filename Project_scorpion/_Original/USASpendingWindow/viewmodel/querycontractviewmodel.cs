using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Configuration;

namespace USAspendingWindow
{
    class querycontractviewmodel : INotifyPropertyChanged
    {
        # region properties



        private ObservableCollection<Current_usaspend> _sumitems;

        private ObservableCollection<ComboBoxDisplayValue> _fielditems;
        private ObservableCollection<ComboBoxDisplayValue> _opitems;
        private ObservableCollection<ComboBoxDisplayValue> _stringopitems;
        private ObservableCollection<ComboBoxDisplayValue> _agencyitems;
        private int _fieldindex;



        private String _filtertext;
        private String _selectfield;
        private String _selectop;
        private String _selectstringop;
        private DateTime _selectdate;
        private String _numstrtext;
        private String _selecttestagency;
        private String _selectfilteragency;
        private ObservableCollection<ComboBoxDisplayValue> _yearitems;
        private String _selectyear;
        private Cursor _cursor;




        public Cursor cursor
        {
            get
            {

                return _cursor;
            }
            set
            {
                _cursor = value;
                NotifyPropertyChanged("cursor");

            }

        }

        public String selectyear
        {
            get
            {

                return _selectyear;
            }
            set
            {
                _selectyear = value;
                NotifyPropertyChanged("selectyear");

            }

        }
        public ObservableCollection<ComboBoxDisplayValue> yearitems
        {
            get
            {

                return _yearitems;
            }
            set
            {
                _yearitems = value;
                NotifyPropertyChanged("yearitems");

            }

        }
        public ObservableCollection<ComboBoxDisplayValue> agencyitems
        {
            get
            {

                return _agencyitems;
            }
            set
            {
                _agencyitems = value;
                NotifyPropertyChanged("agencyitems");

            }

        }

        public String selecttestagency
        {
            get
            {

                return _selecttestagency;
            }
            set
            {
                _selecttestagency = value;
                NotifyPropertyChanged("selecttestagency");

            }

        }
        public String selectfilteragency
        {
            get
            {

                return _selectfilteragency;
            }
            set
            {
                _selectfilteragency = value;
                NotifyPropertyChanged("selectfilteragency");

            }

        }

        public String numstrtext
        {
            get
            {

                return _numstrtext;
            }
            set
            {
                _numstrtext = value;
                NotifyPropertyChanged("numstrtext");

            }

        }

        public int fieldindex
        {
            get
            {

                return _fieldindex;
            }
            set
            {
                _fieldindex = value;
                NotifyPropertyChanged("fieldindex");

            }

        }


        public ObservableCollection<ComboBoxDisplayValue> stringopitems
        {
            get
            {

                return _stringopitems;
            }
            set
            {
                _stringopitems = value;
                NotifyPropertyChanged("stringopitems");

            }

        }

        public ObservableCollection<ComboBoxDisplayValue> opitems
        {
            get
            {

                return _opitems;
            }
            set
            {
                _opitems = value;
                NotifyPropertyChanged("opitems");

            }

        }

        public String selectstringop
        {
            get
            {

                return _selectstringop;
            }
            set
            {
                _selectstringop = value;
                NotifyPropertyChanged("selectstringop");

            }

        }
        public DateTime selectdate
        {
            get
            {

                return _selectdate;
            }
            set
            {
                _selectdate = value;
                NotifyPropertyChanged("selectdate");

            }

        }
        public String selectop
        {
            get
            {

                return _selectop;
            }
            set
            {
                _selectop = value;
                NotifyPropertyChanged("selectop");

            }

        }
        public String selectfield
        {
            get
            {

                return _selectfield;
            }
            set
            {
                _selectfield = value;
                NotifyPropertyChanged("selectfield");

            }

        }

        public String filtertext
        {
            get
            {

                return _filtertext;
            }
            set
            {
                _filtertext = value;
                NotifyPropertyChanged("filtertext");

            }

        }

        public ObservableCollection<Current_usaspend> sumitems
        {
            get
            {

                return _sumitems;
            }
            set
            {
                _sumitems = value;
                NotifyPropertyChanged("sumitems");

            }

        }


        public ObservableCollection<ComboBoxDisplayValue> fielditems
        {
            get
            {

                return _fielditems;
            }
            set
            {
                _fielditems = value;
                NotifyPropertyChanged("fielditems");

            }

        }



        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }


        private ICommand viewSwitchCommand;
        public ICommand ViewSwitchCommand
        {
            get
            {
                return viewSwitchCommand;
            }
            set
            {
                viewSwitchCommand = value;
            }
        }
        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return clickCommand;
            }
            set
            {
                clickCommand = value;
            }
        }
        public System.Action CloseAction { get; set; }
        public System.Action ClearAction { get; set; }
        # endregion

        public querycontractviewmodel()
        {
            ViewSwitchCommand = new RelayCommand(new Action<object>(SwitchViews));
            ClickCommand = new RelayCommand(new Action<object>(Selectedrecord));
            setupcombo();
            fieldindex = -1;
            //selectdate = DateTime.Now;
        }

        public void Selectedrecord(object obj)
        {

            if (obj.ToString() != "Hello World")
            {
                Current_usaspend par = obj as Current_usaspend;

                DialogService dialog = new DialogService();

                recorddetailsviewmodel vm = new recorddetailsviewmodel();
                recorddetails win = new recorddetails();

                vm.logitems = new ObservableCollection<ComboBoxDisplayValue>(Utility.USAspendRecordDetaildisplay(par));
                win.DataContext = vm;
                dialog.ShowDialog(win);
            }
        }

        void setupcombo()
        {


            fielditems = new ObservableCollection<ComboBoxDisplayValue>(new List<ComboBoxDisplayValue>() 
            {
                new ComboBoxDisplayValue("fiscal_year","String"),
                new ComboBoxDisplayValue("vendorname","String"),
                new ComboBoxDisplayValue("productorservicecode","String"),
                new ComboBoxDisplayValue("principalnaicscode","String"),
                new ComboBoxDisplayValue("piid","String"),
                new ComboBoxDisplayValue("idvpiid","String"),
                new ComboBoxDisplayValue("contract_vehicle","String"),
                new ComboBoxDisplayValue("work","String"),
                new ComboBoxDisplayValue("completion_date", "DateTime"),
                new ComboBoxDisplayValue("completion_year","String")
            });




            stringopitems = new ObservableCollection<ComboBoxDisplayValue>(new List<ComboBoxDisplayValue>() 
            {
                new ComboBoxDisplayValue("STARTS WITH","start like"),
                new ComboBoxDisplayValue("DOES NOT START WITH","start not like"),
                new ComboBoxDisplayValue("CONTAINS","like"),
                new ComboBoxDisplayValue("DOES NOT CONTAINS","not like"),
                new ComboBoxDisplayValue("EXACT MATCH","="),
                new ComboBoxDisplayValue("DOES NOT MATCH","<>"),
                new ComboBoxDisplayValue("IS NULL/NOTHING","is null"),
                new ComboBoxDisplayValue("MATCH A LIST OF VALUES","in"),
                 new ComboBoxDisplayValue("DOES NOT MATCH A LIST OF VALUES","not in")
            });

            opitems = new ObservableCollection<ComboBoxDisplayValue>(new List<ComboBoxDisplayValue>() 
            {
                new ComboBoxDisplayValue("equals","="),
                new ComboBoxDisplayValue("greater than",">"),
                new ComboBoxDisplayValue("less than","<"),
                new ComboBoxDisplayValue("greater than or equal",">="),
                new ComboBoxDisplayValue("less than or equal", "<="),
                new ComboBoxDisplayValue("not equal to", "<>"),
                new ComboBoxDisplayValue("is null/nothing", "is null")

            });

            agencyitems = Utility.GetagencyCB();
            yearitems = Utility.GetyearCB();



        }

        private void getfilter()
        {
            // may need to validate that all controls are set before adding filter.
            //make a fitler 
            if (String.IsNullOrEmpty(selectfilteragency))
            {
                DialogService dialog = new DialogService();
                dialog.ShowMessageBox("Please select an agency.", "Input Error", System.Windows.MessageBoxButton.OK);
                return;

            }
            //if (String.IsNullOrEmpty(selectyear))
            //{
            //    DialogService dialog = new DialogService();
            //    dialog.ShowMessageBox("Please select year.", "Input Error", System.Windows.MessageBoxButton.OK);
            //    return;

            //}

            if (String.IsNullOrEmpty(selectfield))
            {
                DialogService dialog = new DialogService();
                dialog.ShowMessageBox("Please select a field.", "Input Error", System.Windows.MessageBoxButton.OK);
                return;

            }

            StringBuilder sb = new StringBuilder();

            String selectfieldname = fielditems[fieldindex].Display;


            switch (selectfield)
            {
                case "DateTime":// date only operators where time is always 00:00:00
                    //validate

                    if (String.IsNullOrEmpty(selectop)) //||
                    {
                        DialogService dialog = new DialogService();
                        dialog.ShowMessageBox("Please select an operator.", "Input Error", System.Windows.MessageBoxButton.OK);
                        return;

                    }

                    // setup
                    sb.Append(selectfieldname);
                    String op = selectop;
                    sb.Append(" " + op + " ");
                    String seldt = selectdate.ToString("MM-dd-yyyy");
                    sb.Append("'" + seldt + "'");
                    break;
                case "String":
                    String strop = selectstringop;
                    if (String.IsNullOrEmpty(selectstringop) ||
                        String.IsNullOrEmpty(numstrtext))
                    {
                        DialogService dialog = new DialogService();
                        dialog.ShowMessageBox("Please select an operator and text to compare.", "Input Error", System.Windows.MessageBoxButton.OK);
                        return;

                    }
                    if (strop == "in")
                    {
                        sb.Append(selectfieldname);
                        sb.Append(" " + strop + " ");
                        String[] tokquery = new String[1] { "," };
                        String[] filterinparts = numstrtext.Split(tokquery, StringSplitOptions.None);
                        StringBuilder vsb = new StringBuilder();
                        foreach (string s in filterinparts)
                        {
                            if (vsb.Length > 0)
                                vsb.Append(",'" + s + "'");
                            else
                                vsb.Append("'" + s + "'");
                        }
                        sb.Append("(" + vsb.ToString() + ")");
                    }
                    if (strop == "not in")
                    {
                        sb.Append(selectfieldname);
                        sb.Append(" " + strop + " ");
                        String[] tokquery = new String[1] { "," };
                        String[] filterinparts = numstrtext.Split(tokquery, StringSplitOptions.None);
                        StringBuilder vsb = new StringBuilder();
                        foreach (string s in filterinparts)
                        {
                            if (vsb.Length > 0)
                                vsb.Append(",'" + s + "'");
                            else
                                vsb.Append("'" + s + "'");
                        }
                        sb.Append("(" + vsb.ToString() + ")");
                    }
                    if (strop == "like")
                    {
                        sb.Append(selectfieldname);
                        sb.Append(" " + strop + " ");
                        sb.Append(" '%" + numstrtext + "%' ");
                    }
                    if (strop == "not like")
                    {
                        sb.Append("(ISNULL(" + selectfieldname + ",'ZZZZZZZZZZZZZZZZZZZZZ')) ");

                        sb.Append(" " + strop + " ");
                        sb.Append(" '%" + numstrtext + "%' ");
                    }
                    else if (strop == "start like")
                    {
                        sb.Append(selectfieldname);
                        sb.Append(" " + "like" + " ");
                        sb.Append(" '" + numstrtext + "%' ");
                    }
                    if (strop == "start not like")
                    {
                        sb.Append("(ISNULL(" + selectfieldname + ",'ZZZZZZZZZZZZZZZZZZZZZ')) ");

                        sb.Append(" " + "not like" + " ");
                        sb.Append(" '" + numstrtext + "%' ");
                    }
                    else if (strop == "<>")
                    {
                        sb.Append("(ISNULL(" + selectfieldname + ",'ZZZZZZZZZZZZZZZZZZZZZ')) ");

                        sb.Append(" " + strop + " ");
                        sb.Append(" '" + numstrtext + "' ");
                    }
                    else if (strop == "=")
                    {
                        sb.Append(selectfieldname);
                        sb.Append(" " + strop + " ");
                        sb.Append(" '" + numstrtext + "' ");
                    }
                    else if (strop == "is null")
                    {
                        sb.Append(selectfieldname);
                        sb.Append(" " + strop);

                    }
                    break;
                case "decimal":
                    if (String.IsNullOrEmpty(selectop) ||
                       String.IsNullOrEmpty(numstrtext))
                    {
                        DialogService dialog = new DialogService();
                        dialog.ShowMessageBox("Please select an operator and text to compare.", "Input Error", System.Windows.MessageBoxButton.OK);
                        return;

                    }
                    int test;
                    if (selectop != "is null")
                    {
                        if (!Int32.TryParse(numstrtext, out test))
                        {
                            DialogService dialog = new DialogService();
                            dialog.ShowMessageBox("Value must be a number.", "Input Error", System.Windows.MessageBoxButton.OK);
                            return;


                        }
                    }
                    sb.Append(selectfieldname);
                    String decop = selectop;
                    if (decop == "is null")
                    {
                        sb.Append(" " + decop);
                    }
                    else
                    {
                        sb.Append(" " + decop + " ");
                        sb.Append(numstrtext);
                    }
                    break;
            }
            //now reset screen


            if (!String.IsNullOrEmpty(filtertext))
                filtertext = filtertext + " and " + sb.ToString();
            else
            {
                // set agency 
                // sb.Append(String.Format("{0}:", selectfilteragency));
                //if(String.IsNullOrEmpty(selectyear))
                    filtertext = String.Format("{0}:NULL:", selectfilteragency) + sb.ToString();
                //else
                //    filtertext = String.Format("{0}:{1}:", selectfilteragency, selectyear) + sb.ToString();
            }
        }

        public void SwitchViews(object obj)
        {

            string par = obj.ToString();

            switch (par)
            {
                case "excelpivot":
                    //DialogService dialogpivot = new DialogService();
                    //   String filepathpivot = dialogpivot.ShowFileDialog();

                    //   if (String.IsNullOrEmpty(filepathpivot))
                    //       break;
                    //String filetext = Utility.USAspendRecordtoCSV(sumitems);
                    //File.AppendAllText(filepathpivot, filetext);
                    cursor = Cursors.Wait;
                    Microsoft.Office.Interop.Excel.Application xlsxApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook newWorkBook = xlsxApp.Workbooks.Add();
                    newWorkBook.Activate();
                    String connection = "OLEDB;Provider=SQLOLEDB.1;" + ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    Microsoft.Office.Interop.Excel.PivotCache pivotCache =
                         xlsxApp.ActiveWorkbook.PivotCaches().Add(
                         Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlExternal, Type.Missing);
                    String[] tok = new String[1] { ":" };
                    String[] filterparts = filtertext.Split(tok, StringSplitOptions.None);
                    StringBuilder sbr = new StringBuilder();
                    if (filterparts[1] == "NULL")
                                sbr.Append("select * from Current_usaspend where " + filterparts[2] + "  and maj_agency_cat like '" + filterparts[0] + "%' ");
                            else
                                sbr.Append("select * from Current_usaspend where " + filterparts[2] + "  and maj_agency_cat like '" + filterparts[0] + "%' and fiscal_year = '" + filterparts[1] + "'");
                           
                    pivotCache.CommandText = sbr.ToString();
                    pivotCache.CommandType = Microsoft.Office.Interop.Excel.XlCmdType.xlCmdSql;
                    pivotCache.Connection = connection;
                    pivotCache.MaintainConnection = true;


                    Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsxApp.ActiveSheet;
                    Microsoft.Office.Interop.Excel.PivotTables pivotTables = (Microsoft.Office.Interop.Excel.PivotTables)sheet.PivotTables(Type.Missing);
                    Microsoft.Office.Interop.Excel.PivotTable pivotTable = pivotTables.Add(pivotCache, xlsxApp.ActiveCell, "Contracts by vendor",
                                                                                            Type.Missing, Type.Missing);


                    pivotTable.SmallGrid = false;
                    pivotTable.ShowTableStyleRowStripes = true;
                    pivotTable.TableStyle2 = "PivotStyleLight1";

                    //page field
                    Microsoft.Office.Interop.Excel.PivotField pageField =
    (Microsoft.Office.Interop.Excel.PivotField)pivotTable.PivotFields("fundingrequestingagencyid");
                    pageField.Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlPageField;
                    //row fields
                    Microsoft.Office.Interop.Excel.PivotField rowField;
                    rowField = (Microsoft.Office.Interop.Excel.PivotField)pivotTable.PivotFields("vendorname");
                    rowField.Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlRowField;
                    rowField = (Microsoft.Office.Interop.Excel.PivotField)pivotTable.PivotFields("contract_vehicle");
                    rowField.Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlRowField;
                    rowField = (Microsoft.Office.Interop.Excel.PivotField)pivotTable.PivotFields("work");
                    rowField.Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlRowField;
                    rowField = (Microsoft.Office.Interop.Excel.PivotField)pivotTable.PivotFields("piid");
                    rowField.Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlRowField;
                    rowField = (Microsoft.Office.Interop.Excel.PivotField)pivotTable.PivotFields("idvpiid");
                    rowField.Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlRowField;
                    //data fields
                    pivotTable.AddDataField(pivotTable.PivotFields("dollarsobligated"), "Dollars Obligated", Microsoft.Office.Interop.Excel.XlConsolidationFunction.xlSum);

                    xlsxApp.Visible = true;
                    cursor = Cursors.Arrow;
                    break;
                case "excelcsv":
                    if (sumitems.Count > 0)
                    {
                        DialogService dialogcsv = new DialogService();
                        String filepathcsv = dialogcsv.ShowFileDialog();

                        if (String.IsNullOrEmpty(filepathcsv))
                            break;
                        String filetextcsv = Utility.USAspendRecordtoCSV(sumitems);
                        File.AppendAllText(filepathcsv, filetextcsv);
                        Microsoft.Office.Interop.Excel.Application xlsxAppcsv = new Microsoft.Office.Interop.Excel.Application();
                        Workbook workbookcsv = xlsxAppcsv.Workbooks.Open(filepathcsv);
                        xlsxAppcsv.Visible = true; //Excel will open, I don't want this.
                    }
                    break;
                case "clear":
                    //do something..

                    filtertext = String.Empty;
                    sumitems = null;
                    ClearAction();
                    break;
                case "query":
                    //do something..
                    if (!String.IsNullOrEmpty(filtertext))
                    {
                        using (USAspendEF ef = new USAspendEF())
                        {
                            cursor = Cursors.Wait;
                            String[] tokquery = new String[1] { ":" };
                            String[] filterpartsquery = filtertext.Split(tokquery, StringSplitOptions.None);
                            StringBuilder sb = new StringBuilder();
                            if (filterpartsquery[1] == "NULL")
                                sb.Append("select * from Current_usaspend where " + filterpartsquery[2] + "  and maj_agency_cat like '" + filterpartsquery[0] + "%' ");
                            else
                                sb.Append("select * from Current_usaspend where " + filterpartsquery[2] + "  and maj_agency_cat like '" + filterpartsquery[0] + "%' and fiscal_year = '" + filterpartsquery[1] + "'");
                            var results = ef.Contracts.SqlQuery(sb.ToString()).ToList<Current_usaspend>();

                            sumitems = new System.Collections.ObjectModel.ObservableCollection<Current_usaspend>(results.ToList<Current_usaspend>());
                            cursor = Cursors.Arrow;
                        }
                    }


                    break;
                case "try":
                    //do something..
                    if (!String.IsNullOrEmpty(filtertext))
                    {

                        using (USAspendEF ef = new USAspendEF())
                        {
                            cursor = Cursors.Wait;
                            String[] toktry = new String[1] { ":" };
                            String[] filterpartstry = filtertext.Split(toktry, StringSplitOptions.None);
                            StringBuilder sb = new StringBuilder();
                            if (filterpartstry[1] == "NULL")
                                sb.Append("select * from Current_usaspend where " + filterpartstry[2] + "  and maj_agency_cat like '" + filterpartstry[0] + "%' ");
                            else
                                sb.Append("select * from Current_usaspend where " + filterpartstry[2] + "  and maj_agency_cat like '" + filterpartstry[0] + "%' and fiscal_year = '" + filterpartstry[1] + "'");
                            var results = ef.Contracts.SqlQuery(sb.ToString()).ToList<Current_usaspend>();
                            DialogService dialogtry = new DialogService();

                            filtertestviewmodel vm = new filtertestviewmodel();
                            filtertest thelog = new filtertest();
                            thelog.DataContext = vm;
                            vm.logitems = new System.Collections.ObjectModel.ObservableCollection<Current_usaspend>(results.ToList<Current_usaspend>());
                            dialogtry.ShowDialog(thelog);
                            cursor = Cursors.Arrow;
                        }

                    }

                    break;
                case "add":
                    //do something..
                    getfilter();
                    CloseAction();
                    break;


            }

        }
    }
}
