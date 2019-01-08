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
    class filtertestviewmodel: INotifyPropertyChanged
    {
              # region properties

       
        
        private ObservableCollection<Current_usaspend> _logitems;


        public ObservableCollection<Current_usaspend> logitems
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

        public filtertestviewmodel()
        {
            ViewSwitchCommand = new RelayCommand(new Action<object>(SwitchViews));
           
        }

      

        public void SwitchViews(object obj)
        {

            string par = obj.ToString();

            switch (par)
            {
                case "close":
                    //do something..
                    
                  
                    break;
                
                
            }

        }
    }
}
