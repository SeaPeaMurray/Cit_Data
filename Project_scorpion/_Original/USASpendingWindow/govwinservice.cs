using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Awesomium.Core;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Net;
using System.IO;

namespace USAspendingWindow
{
    public class govwinservice
    {

        // JavaScript that will get a reliable value 
        // for the full height of the document loaded.
        const string PAGE_HEIGHT_FUNC = "(function() { " +
            "var bodyElmnt = document.body; var html = document.documentElement; " +
            "var height = Math.max( bodyElmnt.scrollHeight, bodyElmnt.offsetHeight, html.clientHeight, html.scrollHeight, html.offsetHeight ); " +
            "return height; })();";



        public static ObservableCollection<govwinmodel> getgovwin(string[] args)
        {
            ObservableCollection<govwinmodel> result = null;
            // Initialize the WebCore with some configuration settings.
            if (!WebCore.IsInitialized)
            {
                WebCore.Initialize(new WebConfig()
                {
                    LogPath = Environment.CurrentDirectory + "/awesomium.log",
                    LogLevel = LogLevel.Verbose,
                });
            }

            // Attempt get the URL from the command line,
            // or use the default for demonstration.
            Uri url = new Uri("https://iq.govwin.com/login/loginpage.cfm?newformaction=http%3A%2F%2Fiq%2Egovwin%2Ecom%2Findex%2Ecfm%3Ffractal%3DmyInput%2Edsp%2EmyPortal");
            finishedLoading = false;
            logmsg("************************************Starting load***********************************");

            // Take snapshots of the site.
            result = NavigateAndTakeSnapshots(url, args);

            logmsg("************************************Ending load*************************************");
            if (logfile != null)
                logfile.Close();
            return result;
        }
        public static StreamWriter logfile = null;
        public static StringBuilder message;
         public static bool finishedLoading;
         public static void logmsg(String msg)
        {
#if DEBUG
            Console.WriteLine(msg);
#endif
            // write to file stream here.
            if (logfile == null)
                logfile = new StreamWriter(Environment.CurrentDirectory + "/usaspendload.log", true);
            String logentry = String.Format(" [{0}]:{1} ...", DateTime.Now.ToString(), msg);
            logfile.WriteLine(logentry);
            if (message == null)
                message = new StringBuilder();
            message.AppendLine(logentry);
        }

        public static ObservableCollection<govwinmodel> NavigateAndTakeSnapshots(Uri url, String[] piids)
        {
            finishedLoading = false;
            ObservableCollection<govwinmodel> result = null;
            // We demonstrate an easy way to hide the scrollbars by providing
            // custom CSS. Read more about how to style the scrollbars here:
            // http://www.webkit.org/blog/363/styling-scrollbars/.
            // Just consider that this setting is WebSession-wide. If you want to apply
            // a similar effect for single pages, you can use ExecuteJavascript
            // and pass: document.documentElement.style.overflow = 'hidden';
            // (Unfortunately WebKit's scrollbar does not have a DOM equivalent yet)
            using (WebSession session = WebCore.CreateWebSession(new WebPreferences() { CustomCSS = "::-webkit-scrollbar { visibility: hidden; }" }))
            {
                // WebView implements IDisposable. Here we demonstrate
                // wrapping it in a using statement.
                using (WebView view = WebCore.CreateWebView(1100, 1000, session))
                {
                    logmsg(String.Format("Loading: {0} ...", url));

                    // Load a URL.
                    view.Source = url;

                    // This event is fired when a frame in the
                    // page finishes loading.
                    view.LoadingFrameComplete += (s, e) =>
                    {
                        logmsg(String.Format("Frame Loaded: {0}", e.FrameId));

                        // The main frame usually finishes loading last for a given page load.
                        if (!e.IsMainFrame)
                            return;

                        // Print some more information.
                        logmsg(String.Format("Page Title: {0}", view.Title));
                        logmsg(String.Format("Loaded URL: {0}", view.Source));
                         finishedLoading = true;
                        // Take snapshots of the page.
                        //
                        // result = TakeSnapshots((WebView)view, piids);
                    };

                    result = TakeSnapshots((WebView)view, piids);
                    // Check if the WebCore is already automatically updating.
                    // This check is only here for demonstration. Console applications
                    // are not UI applications and have no synchronization context.
                    // Without a valid synchronization context, we need to call Run.
                    // This will tell the WebCore to create an Awesomium-specific
                    // synchronization context and start an update loop.
                    // The current thread will be blocked until WebCore.Shutdown
                    // is called. You can use the same model by creating a dedicated
                    // thread for Awesomium. For details about the new auto-updating
                    // and synchronization model of Awesomium.NET, read the documentation
                    // of WebCore.Run.
                      if (WebCore.UpdateState == WebCoreUpdateState.NotUpdating)
                        // The point of no return. This will only exit
                        // when we call Shutdown.
                        WebCore.Run();

                }
            }
            return result;
        }

        public static ObservableCollection<govwinmodel> TakeSnapshots(WebView view, String[] piids)
        {
            int waitloops = 20;
            int loops = 0;
            Error lastError = view.GetLastError();

            // Report errors.
            if (lastError != Error.None)
            {
                logmsg(String.Format("Error: {0} occurred while getting the page's height.", lastError));
                logfile.Close();
                return null;
            }
            // Exit if the operation failed or the height is 0.
            // if (docHeight == 0)
            //   return;


            // do stuff to page



            while (!finishedLoading)
            {
                Thread.Sleep(100);

            }
            finishedLoading = false;
                //while(view.IsLoading)
                //    Thread.Sleep(100);
                // login

                view.ExecuteJavascript("document.frmLoginForm.username.value = 'jrock@citizant.com'");

                view.ExecuteJavascript("document.frmLoginForm.password.value = '1!Roadkill'");

                view.ExecuteJavascript("document.frmLoginForm.submit()");

                // pass browser warning

                while (!finishedLoading)
                {
                    Thread.Sleep(100);

                }
                finishedLoading = false;

                view.ExecuteJavascript("jQuery.fn.colorbox.close()");


                view.ExecuteJavascript("window.location = '/index.cfm?fractal=coveo.dsp.search&sk=DISContractsListView'");
                while (!finishedLoading)
                {
                    Thread.Sleep(100);

                }
                finishedLoading = false;
                Thread.Sleep(10000);

                // Now query the contract PIID's
                bool first = true;
                StringBuilder psb = new StringBuilder();
                foreach (String s in piids)
                {
                    if (first)
                        psb.Append(" '" + s);
                    else
                        psb.Append(" OR " + s);

                }
                psb.Append("'");

                view.ExecuteJavascript("document.getElementById('h_DISContractsListView_ctl00_mup_as_qry').value = " + psb.ToString());
                view.ExecuteJavascript("document.getElementById('h_DISContractsListView_ctl00_mup_as_sbt').click()");

               
                while (!finishedLoading && loops <= waitloops)
                {
                    Thread.Sleep(100);
                    loops++;
                }
                finishedLoading = false;
                loops = 0;
                // make sure results display in a grid.

                view.ExecuteJavascript("document.getElementById('h_DISContractsListView_ctl00_mup_ctl01_disResultPanel_ctl01_ctl01_BtnGridView').click()");
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

                //                JSValue headerresult = view.ExecuteJavascript(headerfunc);
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

                    JSValue result = view.ExecuteJavascriptWithResult(JAVASCRIPT);
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
                   

       
                
            WebCore.Shutdown();
            return display;
        }

       
    }
}
