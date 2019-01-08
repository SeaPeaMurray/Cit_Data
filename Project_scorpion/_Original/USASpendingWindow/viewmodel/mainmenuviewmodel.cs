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
    class mainmenuviewmodel : INotifyPropertyChanged
    {
               # region properties

       
        private String log;
       
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
        public mainmenuviewmodel()
        {
            ViewSwitchCommand = new RelayCommand(new Action<object>(SwitchViews));
            
        }

      

        public void SwitchViews(object obj)
        {

            string par = obj.ToString();

            switch (par)
            {
                case "querycontract" :
                    //do something..
                    NavView("BlotterRegion", "querycontract");
                    break;
                case "summary":
                    //do something..
                    NavView("BlotterRegion", "summaryview");
                    break;
                case "load":
                    //do something..
                    NavView("BlotterRegion", "USASpendingloader");
                    break;
                case "Print":
                    //do something..
                    CloseAction();
                    break;
                case "loadadvanced":
                    //do something..
                    NavView("BlotterRegion", "USASpendingloaderadvanced");
                    break;

                case "outofscopefilter":
                    //do something..
                    NavView("BlotterRegion", "outofscopefilterview");
                    break;
                case "outofscopesummary":
                    //do something..
                    NavView("BlotterRegion", "OOSreviewsummary");
                    break;
                case "zerosummary":
                    //do something..
                    NavView("BlotterRegion", "zeroreviewsummary");
                    break;
                case "querynewpiid":
                    //do something..
                    NavView("BlotterRegion", "querynewpiid");
                    break;
                case "contracttest":

                    //do something..
                    NavView("BlotterRegion", "Contracttest");
                    break;
                case "govwinload":

                    //do something..
                    NavView("BlotterRegion", "GovWinloader");
                    break;
                case "exit" :
                    App.Current.Shutdown();
                    break;
            }

        }

        public void NavView(string region, string uri, string property, string value)
        {
            Microsoft.Practices.Prism.UriQuery qry = new Microsoft.Practices.Prism.UriQuery();

            qry.Add(property, value);
            //Uri vu = new Uri("CustListViewShort" + qry.ToString(), UriKind.Relative);
            //rgn.RequestNavigate(vu, GetCustomers);

            var regionmanager = ServiceLocator.Current.GetInstance<IRegionManager>();
            Uri testview;
            testview = new Uri(uri + qry.ToString(), UriKind.Relative);
            regionmanager.RequestNavigate(region, testview);
        }

        public void NavView(string region, string uri)
        {
            var regionmanager = ServiceLocator.Current.GetInstance<IRegionManager>();
            Uri testview;
            testview = new Uri(uri, UriKind.Relative);
            regionmanager.RequestNavigate(region, testview);
        }

    }
}
