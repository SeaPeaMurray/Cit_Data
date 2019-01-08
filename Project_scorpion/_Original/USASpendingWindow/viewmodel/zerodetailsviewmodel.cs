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
using System.IO;

namespace USAspendingWindow
{
    class zerodetailsviewmodel : INotifyPropertyChanged
    {
        # region properties



        private ObservableCollection<outofscopereceditmodel> _logitems;
        private bool _canclose;
        private Cursor _thecursor;


        public Cursor thecursor
        {
            get
            {

                return _thecursor;
            }
            set
            {
                _thecursor = value;
                NotifyPropertyChanged("thecursor");

            }

        }
        public bool canclose
        {
            get
            {

                return _canclose;
            }
            set
            {
                _canclose = value;
                NotifyPropertyChanged("canclose");

            }

        }
        public ObservableCollection<outofscopereceditmodel> logitems
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

        public zerodetailsviewmodel()
        {
            ViewSwitchCommand = new RelayCommand(new Action<object>(SwitchViews));
            canclose = true;

        }



        public void SwitchViews(object obj)
        {

            string par = obj.ToString();

            switch (par)
            {
                case "close":
                    //do something..


                    break;
                case "return":
                    //do something..
                    using (USAspendEF ef = new USAspendEF())
                    {
                        DialogService dialog = new DialogService();

                        dialog.ShowMessageBox("The OOS filter must be modified to keep these records from returning to the Out of Scope table.", "Warning", System.Windows.MessageBoxButton.OK);
                        thecursor = Cursors.Wait;
                        int movecount = 0;
                        foreach (var r in logitems)
                        {

                            if (r.Selected)
                            {
                                var oosrec = from o in ef.Outofscopes
                                             where o.unique_transaction_id == r.Rec.unique_transaction_id
                                             select o;

                                OutOfScope_usaspend oos = oosrec.FirstOrDefault();
                                ef.Outofscopes.Remove(oos);
                                ef.Contracts.Add(Utility.ConvertOOStoUSASpend( oos));

                                movecount++;
                            }


                        }
                        ef.SaveChanges();
                        thecursor = Cursors.Arrow;
                        dialog.ShowMessageBox(movecount.ToString() + " OOS records were moved to Current USA Spend Table.", "Warning", System.Windows.MessageBoxButton.OK);

                    }


                    break;
                case "savetofile":

                    
                    if (logitems.Count > 0)
                    {
                        DialogService dialog = new DialogService();
                        String filepath = dialog.ShowFileDialog();

                        if (String.IsNullOrEmpty(filepath))
                            break;


                        if (!File.Exists(filepath))
                        {
                            File.Create(filepath).Close();
                        }
                        else
                        {
                            dialog.ShowMessageBox("File exists, please enter a unique name.", "Error", System.Windows.MessageBoxButton.OK);
                            break;
                        }
                        thecursor = Cursors.Wait;
                        canclose = false;
                        ObservableCollection<OutOfScope_usaspend> records = new ObservableCollection<OutOfScope_usaspend>();
                        foreach (var r in logitems)
                        {
                            records.Add(r.Rec);

                        }
                        String filetext = Utility.USAspendRecordtoCSV(records);
                        File.AppendAllText(filepath, filetext);
                        thecursor = Cursors.Arrow;
                        canclose = true;
                    }

                    break;

            }

        }
    }
}
