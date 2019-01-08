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
using Awesomium.Core;
using Awesomium.Windows.Controls;



namespace USAspendingWindow 
{
    class USAspendingWindowViewModel : INotifyPropertyChanged
    {

        # region properties

        private ObservableCollection<ComboBoxDisplayValue> fiscalyear;
        private String selectyear;
        private ObservableCollection<ComboBoxDisplayValue> agency;
        private String selectagency;
        private DateTime loaddate;
        private bool buttonenable;
        private bool viewready;
        private String log;
        private WebControl webcontrol;
        public bool finishedLoading = false;

       

        public WebControl Webcontrol
        {
            get
            {

                return webcontrol;
            }
            set
            {
                webcontrol = value;
                NotifyPropertyChanged("Webcontrol");

            }

        }
        public String Log
        {
            get
            {

                return log;
            }
            set
            {
                log = value;
                NotifyPropertyChanged("Log");

            }

        }

        public bool Viewready
        {
            get
            {

                return viewready;
            }
            set
            {
                viewready = value;
                NotifyPropertyChanged("Viewready");

            }

        }


        public bool Buttonenable
        {
            get
            {

                return buttonenable;
            }
            set
            {
                buttonenable = value;
                NotifyPropertyChanged("Buttonenable");

            }

        }

        public DateTime Loaddate
        {
            get
            {

                return loaddate;
            }
            set
            {
                loaddate = value;
                NotifyPropertyChanged("Loaddate");

            }

        }


        public ObservableCollection<ComboBoxDisplayValue> Agency
        {
            get
            {

                return agency;
            }
            set
            {
                agency = value;
                NotifyPropertyChanged("Agency");

            }

        }

        public String Selectagency
        {
            get
            {

                return selectagency;
            }
            set
            {
                selectagency = value;
                NotifyPropertyChanged("Selectagency");

            }

        }

        public ObservableCollection<ComboBoxDisplayValue> Fiscalyear
        {
            get
            {

                return fiscalyear;
            }
            set
            {
                fiscalyear = value;
                NotifyPropertyChanged("Fiscalyear");

            }

        }

        public String Selectyear
        {
            get
            {

                return selectyear;
            }
            set
            {
                selectyear = value;
                NotifyPropertyChanged("Selectyear");

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

        public Action CloseAction { get; set; }

        # endregion
        public USAspendingWindowViewModel()
        {
            ViewSwitchCommand = new RelayCommand(new Action<object>(SwitchViews));
            setupcontrols();
            Buttonenable = true;
            Loaddate = DateTime.Now;
        }

        private void logmsg(String msg)
        {


                Log = Log + "\n" + msg;
            

        }

        private void webcontrolJS(String script, String xpath)
        {


                Webcontrol.ExecuteJavascript(script, xpath);
      
        }

        private String webcontrolJSresult(String script, String xpath)
        {

            String fileurl = String.Empty;

            fileurl = Webcontrol.ExecuteJavascriptWithResult(script, xpath);
            
            return fileurl;
        }

        private void setupcontrols()
        {

            Fiscalyear = new ObservableCollection<ComboBoxDisplayValue>()
           {
               new ComboBoxDisplayValue("2016","2016"),
                new ComboBoxDisplayValue("2015","2015"),
                 new ComboBoxDisplayValue("2014","2014"),
                  new ComboBoxDisplayValue("2013","2013"),
                   new ComboBoxDisplayValue("2012","2012")
                    

           };

            Agency =  new ObservableCollection<ComboBoxDisplayValue>()
           {
               new ComboBoxDisplayValue("Department of the Treasury","2000")
                    

           };


        }
        /// <summary>
        /// loaddata() is the main call to start the download
        /// </summary>
        private void loaddata()
        {
            char[] tok = { '/' };
            // String Page = "https://apps.usaspending.gov/DownloadCenter/DataDownload?SenderId=25043576&SPHostUrl=https%3a%2f%2fwww.usaspending.gov%2fDownloadCenter";
            String Page = "https://www.usaspending.gov/DownloadCenter/Pages/DataDownload.aspx";

            using (USAspendEF ef = new USAspendEF())
            {
                //String fileurl = OpenPage(Page);
                
                //if (String.IsNullOrEmpty(fileurl))
                //{
                //    logmsg("USASpend failed to generate a file.");
                //    return;
                //}

                //if (getthefile(fileurl))
                //{
                //    logmsg("File download completed");
                //}
                //else
                //{
                //    logmsg("Error occurred during file download");
                //    return;
                //}
                //String[] nameparts = fileurl.Split(tok);
                //String filename = @"c:\usaspend\" + nameparts.Last();
                var sqlload = new CsvBulkCopyDataIntoSqlServer();
                logmsg("Loading file to database table");
                int count = sqlload.LoadCsvDataIntoSqlServer(@"c:\usaspend\Data_Feed.csv");//filename);

                Loadtracking audit = new Loadtracking();
                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                //audit.id = DBNull.Value;

                var dates = from c in ef.Audit
                            select c;

                foreach (var c in dates)
                {
                    c.ToString();
                }


                audit.loaddate = DateTime.Now;
                audit.loaduser = userName;
                audit.recordcount = (long)count;
                ef.Audit.Add(audit);
                ef.SaveChanges();

                

                logmsg("Loading database complete");
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


   
                Webcontrol.Source = url;
                //Webcontrol.LoadingFrameComplete += (s, ev) =>
                //{
                //    logmsg(String.Format("Frame Loaded: {0}", ev.FrameId));

                //    // The main frame usually finishes loading last for a given page load.
                //    if (ev.IsMainFrame)
                //        finishedLoading = true;
                //};
            

        }
        private void webcontroltoblank()
        {

            Uri url = new Uri("About:blank");

            Webcontrol.Source = url;

          

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
            Uri url = new Uri(strurl);

            webcontrolSetup(url);

            while (!finishedLoading)
            {
                Thread.Sleep(100);

            }
            finishedLoading = false;


            logmsg("Selecting Dept of Treasury contracts");
            webcontrolJS("document.getElementById('Agency').value = '2000'", "//iframe[@id='ctl00_ctl42_g_1935225f_fe1a_4c68_abd4_f0ee42249199_ctl00_ctl00']");
            logmsg("Clicking submit");
            webcontrolJS("document.getElementById('btnSubmit').click()", "//iframe[@id='ctl00_ctl42_g_1935225f_fe1a_4c68_abd4_f0ee42249199_ctl00_ctl00']");
            Thread.Sleep(10000);

            logmsg("Clicking the generate file button");
            webcontrolJS("document.getElementById('btnGenerateFile').click()", "//iframe[@id='ctl00_ctl42_g_1935225f_fe1a_4c68_abd4_f0ee42249199_ctl00_ctl00']");
            string fileurl = String.Empty;
            Thread.Sleep(10000);

            while (String.IsNullOrEmpty(fileurl))
            {


                fileurl = webcontrolJSresult("document.getElementById('divDownloadFileUrl').text", "//iframe[@id='ctl00_ctl42_g_1935225f_fe1a_4c68_abd4_f0ee42249199_ctl00_ctl00']");
                Thread.Sleep(10000);

            }
            logmsg("Got the file link " + fileurl);


            //// Print some more information.

            //logmsg(String.Format("Page Title: {0}", webControl1.Title));
            //logmsg(String.Format("Loaded URL: {0}", webControl1.Source));
            webcontroltoblank();
            return fileurl;
        }

        public void SwitchViews(object obj)
        {

            string par = obj.ToString();

            switch (par)
            {
                case "load":
                    //do something..
                    Buttonenable = false;

                    loaddata();
                    Buttonenable = true;
                    break;
                case "exit" :
                    CloseAction();
                    break;
            }

        }

    }
}
