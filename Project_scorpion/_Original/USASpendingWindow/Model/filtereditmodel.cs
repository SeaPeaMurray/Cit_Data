using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace USAspendingWindow
{
    public class filtereditmodel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        private outofscopefilter filter;
        private bool selected;


        public bool Selected
        {
            get
            {

                return selected;
            }
            set
            {
                selected = value;
                NotifyPropertyChanged("Selected");

            }

        }

        public outofscopefilter Filter
        {
            get
            {

                return filter;
            }
            set
            {
                filter = value;
                NotifyPropertyChanged("Filter");

            }

        }

    }
}
