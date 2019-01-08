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
    public class loaddetailsviewmodel : INotifyPropertyChanged
    {


          # region properties

       
        private ObservableCollection<Loadtracking> _logitems;
        
        public ObservableCollection<Loadtracking> logitems
        {
            get
            {

                return _logitems;
            }
            set
            {
                _logitems = value;
                NotifyPropertyChanged("logitems");

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

        public loaddetailsviewmodel()
        {
            ViewSwitchCommand = new RelayCommand(new Action<object>(SwitchViews));

            using (USAspendEF ef = new USAspendEF())
            {
                var getlog = from l in ef.Audit
                             orderby l.loaddate descending
                             select l;

                logitems = new ObservableCollection<Loadtracking>(getlog.ToList<Loadtracking>());


            }
           
        }

     
        public void SwitchViews(object obj)
        {

            string par = obj.ToString();

            switch (par)
            {
               
                case "close":
                    CloseAction();
                    break;
                
            }

        }
    }
}
