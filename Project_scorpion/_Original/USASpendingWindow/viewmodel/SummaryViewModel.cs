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

namespace USAspendingWindow
{
    public class SummaryViewModel : INotifyPropertyChanged
    {

        # region properties

       
        private String log;
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

        public SummaryViewModel()
        {
            ViewSwitchCommand = new RelayCommand(new Action<object>(SwitchViews));
           
        }

         private void logmsg(String msg)
        {


           
                Log = Log + "\n" + msg;
         
        }

        public void SwitchViews(object obj)
        {

            string par = obj.ToString();

            switch (par)
            {
                case "refresh":
                    //do something..
                    cursor = Cursors.Wait;
                    using (USAspendEF ef = new USAspendEF())
                    {
                        var loader = from l in ef.Audit
                                     orderby l.loaddate descending
                                     select l;

                        

                        Loadtracking audit = loader.FirstOrDefault<Loadtracking>();
                        Log = String.Empty;
                        logmsg("************THE LAST DATA LOAD EVENT*******************");
                        logmsg(" ");
                        logmsg( String.Format("Last table load occurred on {0} ", audit.loaddate.ToShortDateString()));
                        logmsg(String.Format("the load was performed by {0} ", audit.loaduser));
                        logmsg( String.Format("{0} records were loaded. ", audit.recordcount));



                        //var stats = from db in ef.Contracts
                        //            group db by db.fiscal_year into dbgroup
                        //            select dbgroup;
                        var stats = ef.Database.SqlQuery<string>("select fiscal_year + '\t\t' + str(count(fiscal_year)) "+
                                                                    " from Current_usaspend group by fiscal_year order by fiscal_year desc");

                        // table stats
                        logmsg(" ");
                        logmsg(" ");
                        logmsg("******RECORD STATUS FOR THE MAIN USASpend TABLE*********");
                        logmsg(" ");

                       logmsg( String.Format("Fiscal Year\tCount"));

                        foreach(var g in stats)
                        {
                            //logmsg(String.Format("{0}\t\t{1}", g.Key, g.Count().ToString()));
                            logmsg(g);
                        }

                        // Out of scope
                        //var OOS = from db in ef.Outofscopes
                        //            group db by db.fiscal_year into dbgroup
                        //            select dbgroup;

                        var OOS = ef.Database.SqlQuery<string>("select fiscal_year + '\t\t' + str(count(fiscal_year)) " +
                                                                    " from OutOfScope_usaspend group by fiscal_year order by fiscal_year desc");

                        // table stats
                        logmsg(" ");
                        logmsg(" ");
                        logmsg("***RECORD STATUS FOR THE Out of scope USASpend TABLE****");
                        logmsg(" ");

                        logmsg(String.Format("Fiscal Year\tCount"));

                        foreach (var g in OOS)
                        {
                            //logmsg(String.Format("{0}\t\t{1}", g.Key, g.Count().ToString()));
                            logmsg(g);
                        }
                   }

                    cursor = Cursors.Arrow;
                    break;
                case "log":
                    DialogService dialog = new DialogService();

                    loaddetailsviewmodel vm = new loaddetailsviewmodel();
                    loaddetails thelog = new loaddetails();
                    thelog.DataContext = vm;
                    dialog.ShowDialog(thelog);
                    break;
                
            }

        }

    }
}
