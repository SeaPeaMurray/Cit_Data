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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Net;
using Awesomium.Core;

namespace USAspendingWindow
{
    /// <summary>
    /// Interaction logic for USASpendingloader.xaml
    /// </summary>
    public partial class GovWinloader : UserControl
    {
        public GovWinloader()
        {
            if (!WebCore.IsInitialized)
                WebCore.Initialize(WebConfig.Default);
            InitializeComponent();
        }
        bool finishedLoading = false;
        bool viewready = false;
        private void logmsg(String msg)
        {


            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    textBox1.Text = textBox1.Text + "\n" + msg;
                }));

            }
            else
            {
                textBox1.Text = textBox1.Text + "\n" + msg;
            }

        }
        private void webcontrolJS(String script, String xpath)
        {


            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    webControl1.ExecuteJavascript(script, xpath);
                }));

            }
            else
            {
                webControl1.ExecuteJavascript(script, xpath);
            }

        }
        private void webcontrolJS(String script)
        {


            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    webControl1.ExecuteJavascript(script);
                }));

            }
            else
            {
                webControl1.ExecuteJavascript(script);
            }

        }
        private String webcontrolJSresult(String script, String xpath)
        {

            String fileurl = String.Empty;
            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    fileurl = webControl1.ExecuteJavascriptWithResult(script, xpath);
                }));

            }
            else
            {
                fileurl = webControl1.ExecuteJavascriptWithResult(script, xpath);
            }
            return fileurl;
        }
        private JSValue webcontrolJSresultobject(String script, String xpath)
        {

            JSValue fileurl = String.Empty;
            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    fileurl = webControl1.ExecuteJavascriptWithResult(script, xpath);
                }));

            }
            else
            {
                fileurl = webControl1.ExecuteJavascriptWithResult(script, xpath);
            }
            return fileurl;
        }
         private JSValue webcontrolJSresultobject(String script)
        {

            JSValue fileurl = String.Empty;
            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    fileurl = webControl1.ExecuteJavascriptWithResult(script);
                }));

            }
            else
            {
                fileurl = webControl1.ExecuteJavascriptWithResult(script);
            }
            return fileurl;
        }
        private String getagency()
        {

            String agency = String.Empty;
            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    agency = comboBox2.SelectedValue.ToString();
                }));

            }
            else
            {
                agency = comboBox2.SelectedValue.ToString();
            }
            return agency;
        }
        private String getyear()
        {

            String year = String.Empty;
            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    year = comboBox1.SelectedValue.ToString();
                }));

            }
            else
            {
                year = comboBox1.SelectedValue.ToString();
            }
            return year;
        }
        //private DateTime getstartdate()
        //{

        //    DateTime dt = new DateTime();
        //    if (!Dispatcher.CheckAccess())
        //    {
        //        this.Dispatcher.Invoke((Action)(() =>
        //        {
        //            dt = datePicker1.SelectedDate.Value ;
        //        }));

        //    }
        //    else
        //    {
        //        dt = datePicker1.SelectedDate.Value;
        //    }
        //    return dt;
        //}
        private void enablebut()
        {


            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    button1.IsEnabled = true;
                }));

            }
            else
            {
                button1.IsEnabled = true;
            }

        }
        private void cursorarrow()
        {


            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    this.Cursor = Cursors.Arrow;
                }));

            }
            else
            {
                this.Cursor = Cursors.Arrow;
            }

        }
        private void cursorwait()
        {


            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    this.Cursor = Cursors.Wait;
                }));

            }
            else
            {
                this.Cursor = Cursors.Wait;
            }

        }


        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = false;
            Thread t = new Thread(new ThreadStart(this.loaddata));
            t.Start();
            

        }

        private void loaddatabackground()
        {
            ObservableCollection<govwinmodel> display;

            String[] piids = new String[2]
                {
                     "TIRNO11D00007",
                     "TIRNO11D00005"
                };



            display = govwinservice.getgovwin(piids);

            showdia(display);

        }

        private void loaddata()
        {
            char[] tok = { '/' };
            // String Page = "https://apps.usaspending.gov/DownloadCenter/DataDownload?SenderId=25043576&SPHostUrl=https%3a%2f%2fwww.usaspending.gov%2fDownloadCenter";
            String Page = "https://iq.govwin.com/login/loginpage.cfm?newformaction=http%3A%2F%2Fiq%2Egovwin%2Ecom%2Findex%2Ecfm%3Ffractal%3DmyInput%2Edsp%2EmyPortal";
            cursorwait();
            using (USAspendEF ef = new USAspendEF())
            {
                String fileurl = OpenPage(Page);

                if (String.IsNullOrEmpty(fileurl))
                {
                    logmsg("USASpend failed to generate a file.");
                    cursorarrow();
                    enablebut();
                    return;
                }

                if (getthefile(fileurl))
                {
                    logmsg("File download completed");
                }
                else
                {
                    logmsg("Error occurred during file download");
                    cursorarrow();
                    enablebut();
                    return;
                }
                String[] nameparts = fileurl.Split(tok);
                String filename = @"c:\usaspend\" +nameparts.Last();
                int count;
                int loadcount;
                int ooscount;
                int deletecount;
                int zerocount;
                int deletezerocount;
                int fixcount;
                int setcount;
                logmsg("Loading file to database table");
                try
                {

                    // first stage

                    var sqlloadtruncate = new CsvBulkCopyDataTruncateIntoSqlServer();
                    count = sqlloadtruncate.LoadTruncateCsvDataIntoSqlServer(filename);
                    logmsg("Downloaded " + count.ToString() + " records.");
                    // load only new records to the table from staging.

                    StagetoCurrenttable stage = new StagetoCurrenttable();
                    loadcount = stage.SeparateandLoad();
                    logmsg("Found " + loadcount.ToString() + " new records.");
                    // remove all out of scope records to OOS table.

                    var removeoutofscope = new RemoveOutofScope();

                    zerocount = removeoutofscope.MoveZeroRecords();
                    logmsg("Found and moved " + zerocount.ToString() + " zero records.");
                    deletezerocount = removeoutofscope.RemoveZeroRecords();
                    logmsg("Deleted " + deletezerocount.ToString() + " zero records.");

                    ooscount = removeoutofscope.MoveOutOfScopeRecords();
                    logmsg("Found and moved " + ooscount.ToString() + " out of scope records.");
                    deletecount = removeoutofscope.RemoveOutOfScopeRecords();
                    logmsg("Deleted " + deletecount.ToString() + " out of scope records.");

                    ooscount += zerocount;
                    deletecount += deletezerocount;
                    // fix piids on new records

                    fixidvpiid fixit = new fixidvpiid();
                    fixcount = fixit.fixidvpiidRecords();
                    logmsg("Fixed PIID on " + fixcount.ToString() + " records.");
                    // Assign Contract vehicle, work, completion date and year to new records.

                    setcontractvehicle cv = new setcontractvehicle();
                    setcount = cv.setCVRecords();
                    logmsg("Set Contract Vehicle on " + setcount.ToString() + " records.");
                }
                catch (Exception ex)
                {
                    logmsg("A database loading error occurred. Close program and check the database.");
                    cursorarrow();
                    return;


                }
                logmsg("Loading file to database table");





                Loadtracking audit = new Loadtracking();
                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                //audit.id = DBNull.Value;

                //var dates = from c in ef.Audit
                //            select c;

                //foreach (var c in dates)
                //{
                //    c.ToString();
                //}


                audit.loaddate = DateTime.Now;
                audit.loaduser = userName;
                audit.recordcount = (long)(loadcount - deletecount);
                logmsg("Loaded " + (loadcount - deletecount).ToString() + " new records.");
                ef.Audit.Add(audit);
                ef.SaveChanges();


                logmsg("Loading database complete");
                cursorarrow();
                enablebut();
            }
        }
        private bool getthefile(String fileurl)
        {
            char[] tok = { '/' };
            bool goodbad = true;
            using (WebClient client = new WebClient())
            {
                try
                {
                    String[] nameparts = fileurl.Split(tok);
                    String filename = nameparts.Last();
                    logmsg("Starting to download file " + filename);
                    client.DownloadFile(fileurl,
                                        @"c:\usaspend\" + filename);
                    logmsg("Download complete");
                }
                catch (Exception e)
                {

                    goodbad = false;

                }
            }

            return goodbad;

        }
        private void webcontrolSetup(Uri url)
        {


            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    webControl1.Source = url;
                    webControl1.LoadingFrameComplete += (s, ev) =>
                    {
                        logmsg(String.Format("Frame Loaded: {0}", ev.FrameId));

                        // The main frame usually finishes loading last for a given page load.
                        if (ev.IsMainFrame)
                            finishedLoading = true;
                    };
                }));

            }
            else
            {
                webControl1.Source = url;
                webControl1.LoadingFrameComplete += (s, ev) =>
                {
                    logmsg(String.Format("Frame Loaded: {0}", ev.FrameId));

                    // The main frame usually finishes loading last for a given page load.
                    if (ev.IsMainFrame)
                        finishedLoading = true;
                };
            }

        }
        private void webcontroltoblank()
        {

            Uri url = new Uri("About:blank");
            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {

                    webControl1.Source = url;

                }));

            }
            else
            {
                webControl1.Source = url;

            }

        }
        private String OpenPage(String strurl)
        {
            //while (!viewready)
            //{
            //    Thread.Sleep(100);
            //    // A Console application does not have a synchronization
            //    // context, thus auto-update won't be enabled on WebCore.
            //    // We need to manually call Update here.

            //}
            string fileurl = String.Empty;
            using (USAspendEF ef = new USAspendEF())
            {
                Uri url = new Uri(strurl);
                int waitloops = 20;
                int loops = 0;
                webcontrolSetup(url);

                while (!finishedLoading)
                {
                    Thread.Sleep(100);

                }
                finishedLoading = false;
              
                // login

                webcontrolJS("document.frmLoginForm.username.value = 'jrock@citizant.com'");

                webcontrolJS("document.frmLoginForm.password.value = '1!Roadkill'");

                webcontrolJS("document.frmLoginForm.submit()");

                // pass browser warning

                while (!finishedLoading)
                {
                    Thread.Sleep(100);

                }
                finishedLoading = false;
                
                webcontrolJS("jQuery.fn.colorbox.close()");
                

                webcontrolJS("window.location = '/index.cfm?fractal=coveo.dsp.search&sk=DISContractsListView'");
                while (!finishedLoading)
                {
                    Thread.Sleep(100);

                }
                finishedLoading = false;
                Thread.Sleep(10000);

                // Now query the contract PIID's

                webcontrolJS("document.getElementById('h_DISContractsListView_ctl00_mup_as_qry').value = 'TIRNO11D00007 OR TIRNO11D00005'");
                webcontrolJS("document.getElementById('h_DISContractsListView_ctl00_mup_as_sbt').click()");

               
                while (!finishedLoading && loops <= waitloops)
                {
                    Thread.Sleep(100);
                    loops++;
                }
                finishedLoading = false;
                loops = 0;
                // make sure results display in a grid.

                webcontrolJS("document.getElementById('h_DISContractsListView_ctl00_mup_ctl01_disResultPanel_ctl01_ctl01_BtnGridView').click()");
                while (!finishedLoading && loops <= waitloops)
                {
                    Thread.Sleep(100);
                    loops++;
                }
                finishedLoading = false;
                loops = 0;

                // Now lets get the results.
                // Headers

//                String headerfunc = @"(function () {
//                              var table = document.getElementById('gridViewTableWithPricing'),
//                                  records = [];
//
//                              if (table == null) return null;
//
//                              table = table.getElementsByTagName('thead');
//
//                              if (table == null || table.length === 0) return null;
//
//                              // there should only be one tbody element in a table
//                              table = table[0];
//
//                              // getElementsByTagName returns a NodeList instead of an Array
//                              // but we can still use Array#forEach on it
//                              Array.prototype.forEach.call(table.getElementsByTagName('tr'),
//
//                              function (row) {
//                                 var record = [];
//                                  Array.prototype.forEach.call(row.getElementsByTagName('th'),
//                                  function (cell) {
//                                            Array.prototype.forEach.call(cell.querySelectorAll('a, span'),
//                                            function (a) {
//                                            record.push(a.innerText);
//                                            });
//                                    
//                                  });
//                                  records.push(record);
//                              });
//
//                              return records;
//                            })();";

//                JSValue headerresult = webcontrolJSresultobject(headerfunc);
//                JSValue[] headerrecords;
//                JSValue[] headerrecord;

//                if (!headerresult.IsNull && headerresult.IsArray)
//                {
//                    headerrecords = (JSValue[])headerresult;

//                    foreach (JSValue row in headerrecords)
//                    {
//                        if (row == null || row.IsNull || !row.IsArray)
//                            continue;

//                        headerrecord = (JSValue[])row;

//                        foreach (JSValue cell in headerrecord)
//                        {
//                            if (cell.IsNull || !cell.IsString)
//                                continue;
//                            System.Diagnostics.Debug.WriteLine((string)cell);
//                        }

//                    }
//                }


                // Data records
              
                  ObservableCollection<govwinmodel> display = new ObservableCollection<govwinmodel>();
                const string JAVASCRIPT = @"(function () {
                              var table = document.getElementById('gridViewTableWithPricing'),
                                  records = [];

                              if (table == null) return;

                              table = table.getElementsByTagName('tbody');

                              if (table == null || table.length === 0) return;

                              // there should only be one tbody element in a table
                              table = table[0];

                              // getElementsByTagName returns a NodeList instead of an Array
                              // but we can still use Array#forEach on it
                              Array.prototype.forEach.call(table.getElementsByTagName('tr'),

                              function (row) {
                                 var record = [];
                                  Array.prototype.forEach.call(row.getElementsByTagName('td'),
                                  function (cell) {
                                    record.push(cell.innerText);
                                  });
                                  records.push(record);
                              });

                              return records;
                            })();";

                    JSValue result = webcontrolJSresultobject(JAVASCRIPT);
                    JSValue[] records;
                    JSValue[] record;

                    if (!result.IsNull && result.IsArray)
                    {
                        records = (JSValue[])result;

                        foreach (JSValue row in records)
                        {
                            if (row == null || row.IsNull || !row.IsArray)
                                continue;

                            record = (JSValue[])row;
                            govwinmodel newrec = new govwinmodel();
                            int fieldcount = 0;
                            foreach (JSValue cell in record)
                            {
                                if (cell.IsNull || !cell.IsString)
                                {
                                    fieldcount++;
                                    continue;
                                }
                                switch(fieldcount)
                                {
                                    case 0 :
                                        newrec.Contract_name = (string)cell;
                                        break;
                                    case 1:
                                        newrec.Priority = (string)cell;
                                        break;
                                    case 2:
                                        newrec.Contract_number = (string)cell;
                                        break;
                                    case 3:
                                        newrec.Vendor = (string)cell;
                                        break;
                                    case 4:
                                        newrec.Start_date = (string)cell;
                                        break;
                                    case 5:
                                        newrec.Ultimate_expiration_date = (string)cell;
                                        break;
                                    case 6:
                                        newrec.Primary_requirement = (string)cell;
                                        break;
                                    case 7:
                                        newrec.Contract_type = (string)cell;
                                        break;
                                    case 8:
                                        newrec.Contract_vehicle = (string)cell;
                                        break;
                                    case 9:
                                        newrec.PSC = (string)cell;
                                        break;
                                    case 10:
                                        newrec.NAICS = (string)cell;
                                        break;
                                
                            }
                                fieldcount++;
                            }
                            display.Add(newrec);
                        }
                    }
               // display results for now.
                   


                showdia(display);

            }
            return fileurl;
        }
        private void showdia(ObservableCollection<govwinmodel> list)
        {


            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    DialogService service = new DialogService();
                    govwindetails dia = new govwindetails();
                    govwindetailsviewmodel vm = new govwindetailsviewmodel();
                    dia.DataContext = vm;
                    vm.logitems = list;
                    service.ShowDialog(dia);
                }));

            }
            else
            {
                DialogService service = new DialogService();
                govwindetails dia = new govwindetails();
                govwindetailsviewmodel vm = new govwindetailsviewmodel();
                dia.DataContext = vm;
                vm.logitems = list;
                service.ShowDialog(dia);
            }

        }
        private void Window_Closed(object sender, EventArgs e)
        {
            //base.OnClosed(e);
            webControl1.Dispose();
            WebCore.Shutdown();

        }

        private void webControl1_ShowCreatedWebView(object sender, ShowCreatedWebViewEventArgs e)
        {
            if (!webControl1.IsLive)
                return;
            e.Cancel = true;
            viewready = true;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            using (USAspendEF ef = new USAspendEF())
            {
                comboBox2.DisplayMemberPath = "Key";
                comboBox2.SelectedValuePath = "Value";
                var agencycb = from a in ef.GUIconfig
                               where a.combobox == 0
                               select a;
                foreach (var cb in agencycb)
                {

                    comboBox2.Items.Add(new KeyValuePair<string, string>(cb.display, cb.value));
                    //comboBox2.Items.Add(new KeyValuePair<string, string>("Deus", "Why"));
                    //comboBox2.Items.Add(new KeyValuePair<string, string>("Flirptidee", "Stuff"));
                    //comboBox2.Items.Add(new KeyValuePair<string, string>("Fernum", "Blictor"));
                }
                comboBox2.SelectedIndex = 0;


                comboBox1.DisplayMemberPath = "Key";
                comboBox1.SelectedValuePath = "Value";
                //add next year on top here.
                var yearcb = from a in ef.GUIconfig
                             where a.combobox == 1
                             select a;
                foreach (var yr in yearcb)
                {
                    comboBox1.Items.Add(new KeyValuePair<string, string>(yr.display, yr.value));
                    //comboBox1.Items.Add(new KeyValuePair<string, string>("2015", "2015"));
                    //comboBox1.Items.Add(new KeyValuePair<string, string>("2014", "2014"));
                    //comboBox1.Items.Add(new KeyValuePair<string, string>("2013", "2013"));
                }
                comboBox1.SelectedIndex = 0;


            }
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            webControl1.Dispose();
            WebCore.Shutdown();
            App.Current.Shutdown();

        }


    }
}
