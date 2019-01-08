using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace USAspendingWindow
{
    public class govwinmodel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        private String contract_name;
        private String priority;
        private String contract_number;
        private String vendor;
        private String start_date;
        private String ultimate_expiration_date;
        private String primary_requirement;
        private String contract_type;
        private String contract_vehicle;
        private String psc;
        private String naics;



        public String NAICS
        {
            get
            {

                return naics;
            }
            set
            {
                naics = value;
                NotifyPropertyChanged("NAICS");

            }

        }


        public String PSC
        {
            get
            {

                return psc;
            }
            set
            {
                psc = value;
                NotifyPropertyChanged("PSC");

            }

        }


        public String Contract_vehicle
        {
            get
            {

                return contract_vehicle;
            }
            set
            {
                contract_vehicle = value;
                NotifyPropertyChanged("Contract_vehicle");

            }

        }


        public String Contract_type
        {
            get
            {

                return contract_type;
            }
            set
            {
                contract_type = value;
                NotifyPropertyChanged("Contract_type");

            }

        }


        public String Primary_requirement
        {
            get
            {

                return primary_requirement;
            }
            set
            {
                primary_requirement = value;
                NotifyPropertyChanged("Primary_requirement");

            }

        }


        public String Ultimate_expiration_date
        {
            get
            {

                return ultimate_expiration_date;
            }
            set
            {
                ultimate_expiration_date = value;
                NotifyPropertyChanged("Ultimate_expiration_date");

            }

        }



        public String Start_date
        {
            get
            {

                return start_date;
            }
            set
            {
                start_date = value;
                NotifyPropertyChanged("Start_date");

            }

        }


        public String Vendor
        {
            get
            {

                return vendor;
            }
            set
            {
                vendor = value;
                NotifyPropertyChanged("Vendor");

            }

        }


        public String Contract_number
        {
            get
            {

                return contract_number;
            }
            set
            {
                contract_number = value;
                NotifyPropertyChanged("Contract_number");

            }

        }


        public String Priority
        {
            get
            {

                return priority;
            }
            set
            {
                priority = value;
                NotifyPropertyChanged("Priority");

            }

        }


        public String Contract_name
        {
            get
            {

                return contract_name;
            }
            set
            {
                contract_name = value;
                NotifyPropertyChanged("Contract_name");

            }

        }

       

    }
}
