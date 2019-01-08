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
    class OOSreviewsummaryviewmodel : INotifyPropertyChanged
    {
        # region properties




        private ObservableCollection<OutOfScopeaggregate> _sumitems;
        private ObservableCollection<ComboBoxDisplayValue> _fielditems;
        private ObservableCollection<ComboBoxDisplayValue> _agencyitems;
        private ObservableCollection<ComboBoxDisplayValue> _yearitems;
        private int _fieldindex;
        private String _selectfield;
        private String _selectfilteragency;
        private String _fieldname;
        private Cursor _thecursor;
        private String _selectyear;




        public String selectyear
        {
            get
            {

                return _selectyear;
            }
            set
            {
                _selectyear = value;
                NotifyPropertyChanged("selectyear");

            }

        }
        public ObservableCollection<ComboBoxDisplayValue> yearitems
        {
            get
            {

                return _yearitems;
            }
            set
            {
                _yearitems = value;
                NotifyPropertyChanged("yearitems");

            }

        }
        public Cursor cursor
        {
            get
            {

                return _thecursor;
            }
            set
            {
                _thecursor = value;
                NotifyPropertyChanged("cursor");

            }

        }

        public String fieldname
        {
            get
            {

                return _fieldname;
            }
            set
            {
                _fieldname = value;
                NotifyPropertyChanged("fieldname");

            }

        }
        public ObservableCollection<OutOfScopeaggregate> sumitems
        {
            get
            {

                return _sumitems;
            }
            set
            {
                _sumitems = value;
                NotifyPropertyChanged("sumitems");

            }

        }
        public ObservableCollection<ComboBoxDisplayValue> agencyitems
        {
            get
            {

                return _agencyitems;
            }
            set
            {
                _agencyitems = value;
                NotifyPropertyChanged("agencyitems");

            }

        }


        public String selectfilteragency
        {
            get
            {

                return _selectfilteragency;
            }
            set
            {
                _selectfilteragency = value;
                NotifyPropertyChanged("selectfilteragency");

            }

        }


        public int fieldindex
        {
            get
            {

                return _fieldindex;
            }
            set
            {
                _fieldindex = value;
                NotifyPropertyChanged("fieldindex");

            }

        }



        public String selectfield
        {
            get
            {

                return _selectfield;
            }
            set
            {
                _selectfield = value;
                NotifyPropertyChanged("selectfield");

            }

        }


        public ObservableCollection<ComboBoxDisplayValue> fielditems
        {
            get
            {

                return _fielditems;
            }
            set
            {
                _fielditems = value;
                NotifyPropertyChanged("fielditems");

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
        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return clickCommand;
            }
            set
            {
                clickCommand = value;
            }
        }
        public Action CloseAction { get; set; }

        # endregion

        public OOSreviewsummaryviewmodel()
        {
            ViewSwitchCommand = new RelayCommand(new Action<object>(SwitchViews));
            ClickCommand = new RelayCommand(new Action<object>(Selectedrecord));
            setupcombo();
            fieldindex = -1;
            //selectdate = DateTime.Now;

        }

        void setupcombo()
        {

           
                fielditems = new ObservableCollection<ComboBoxDisplayValue>(new List<ComboBoxDisplayValue>() 
            {
                //new ComboBoxDisplayValue("dollarsobligated","decimal"),
                new ComboBoxDisplayValue("productorservicecode","productorservicecode"),
                new ComboBoxDisplayValue("principalnaicscode","principalnaicscode"),
                new ComboBoxDisplayValue("piid","piid"),
                new ComboBoxDisplayValue("idvpiid", "idvpiid")
            });




                agencyitems = Utility.GetagencyCB();
                yearitems = Utility.GetyearCB();

                //sumitems = new ObservableCollection<OutOfScopeaggregate>();
                // sumitems.Add(new OutOfScopeaggregate());
                fieldname = "Field";
            
        }

        public void Selectedrecord(object obj)
        {

            if (obj.ToString() != "Hello World")
            {
                OutOfScopeaggregate par = obj as OutOfScopeaggregate;
                using (USAspendEF ef = new USAspendEF())
                {
                    DialogService dialog = new DialogService();

                    OOSdetailsviewmodel vm = new OOSdetailsviewmodel();
                    OOSdetails win = new OOSdetails();
                    cursor = Cursors.Wait;
                   
                    var details = ef.Outofscopes.Where(x => x.maj_agency_cat.Contains(par.agency)).Where(x=> x.fiscal_year.Contains(par.year)).Where(x => x.dollarsobligated > 0);
                    switch (fieldname)
                    {
                        case "principalnaicscode":
                            if (String.IsNullOrEmpty(par.field))
                                details = details.Where(x => x.principalnaicscode == String.Empty);
                            else
                                details = details.Where(x => x.principalnaicscode == par.field);
                            break;
                        case "productorservicecode":
                            if (String.IsNullOrEmpty(par.field))
                                details = details.Where(x => x.productorservicecode == String.Empty);
                            else
                                details = details.Where(x => x.productorservicecode.Contains(par.field));
                            break;
                        case "piid":
                            if (String.IsNullOrEmpty(par.field))
                                details = details.Where(x => x.piid == String.Empty);
                            else
                                details = details.Where(x => x.piid == par.field);
                            break;
                        case "idvpiid":
                            if (String.IsNullOrEmpty(par.field))
                                details = details.Where(x => x.idvpiid == String.Empty);
                            else
                                details = details.Where(x => x.idvpiid == par.field);
                            break;
                    }
                    ObservableCollection<outofscopereceditmodel> items = new ObservableCollection<outofscopereceditmodel>();
                    foreach (var d in details)
                    {
                        outofscopereceditmodel temprec = new outofscopereceditmodel();
                        temprec.Rec = d;
                        temprec.Selected = false;
                        items.Add(temprec);

                    }
                    vm.logitems = items;
                    win.DataContext = vm;
                    dialog.ShowDialog(win);
                    cursor = Cursors.Arrow;
                }
            }
        }

        public void SwitchViews(object obj)
        {

            string par = obj.ToString();

            switch (par)
            {

                case "query":
                    //do something..

                    if (String.IsNullOrEmpty(selectfilteragency))
                    {
                        DialogService dialog = new DialogService();
                        dialog.ShowMessageBox("Please select an agency.", "Input Error", System.Windows.MessageBoxButton.OK);
                        return;

                    }

                    if (String.IsNullOrEmpty(selectyear))
                    {
                        DialogService dialog = new DialogService();
                        dialog.ShowMessageBox("Please select a fiscal year.", "Input Error", System.Windows.MessageBoxButton.OK);
                        return;

                    }
                    if (String.IsNullOrEmpty(selectfield))
                    {
                        DialogService dialog = new DialogService();
                        dialog.ShowMessageBox("Please select a field.", "Input Error", System.Windows.MessageBoxButton.OK);
                        return;

                    }
                    using (USAspendEF ef = new USAspendEF())
                    {
                        cursor = Cursors.Wait;
                        switch (selectfield)
                        {
                            case "principalnaicscode":
                                var summaryagg = from sum in ef.Outofscopes
                                                 where sum.maj_agency_cat.Contains(selectfilteragency)
                                                 where sum.fiscal_year.Contains(selectyear)
                                                 where sum.dollarsobligated > 0
                                                 group sum by sum.principalnaicscode into sumGrp
                                                 select sumGrp;
                                List<OutOfScopeaggregate> templist = new List<OutOfScopeaggregate>();
                                foreach (var s in summaryagg)
                                {
                                    var sumrec = new OutOfScopeaggregate();
                                    sumrec.agency = selectfilteragency;
                                    sumrec.year = selectyear;
                                    sumrec.field = s.Key;
                                    sumrec.records = s.Count();
                                    templist.Add(sumrec);
                                }
                                sumitems = null;
                                sumitems = new ObservableCollection<OutOfScopeaggregate>(templist);
                                fieldname = selectfield;
                                break;
                            case "productorservicecode":
                                var summarypscagg = from sum in ef.Outofscopes
                                                 where sum.maj_agency_cat.Contains(selectfilteragency)
                                                    where sum.fiscal_year.Contains(selectyear)
                                                 where sum.dollarsobligated > 0
                                                    group sum by sum.productorservicecode.Substring(0, 4) into sumGrp
                                                 select sumGrp;
                                List<OutOfScopeaggregate> temppsclist = new List<OutOfScopeaggregate>();
                                foreach (var s in summarypscagg)
                                {
                                    var sumrec = new OutOfScopeaggregate();
                                    sumrec.agency = selectfilteragency;
                                    sumrec.year = selectyear;
                                    sumrec.field = s.Key;
                                    sumrec.records = s.Count();
                                    temppsclist.Add(sumrec);
                                }
                                sumitems = null;
                                sumitems = new ObservableCollection<OutOfScopeaggregate>(temppsclist);
                                fieldname = selectfield;
                                break;
                            case "piid":
                                var summarypiidagg = from sum in ef.Outofscopes
                                                 where sum.maj_agency_cat.Contains(selectfilteragency)
                                                     where sum.fiscal_year.Contains(selectyear)
                                                 where sum.dollarsobligated > 0
                                                 group sum by sum.piid into sumGrp
                                                 select sumGrp;
                                List<OutOfScopeaggregate> temppiidlist = new List<OutOfScopeaggregate>();
                                foreach (var s in summarypiidagg)
                                {
                                    var sumrec = new OutOfScopeaggregate();
                                    sumrec.agency = selectfilteragency;
                                    sumrec.year = selectyear;
                                    sumrec.field = s.Key;
                                    sumrec.records = s.Count();
                                    temppiidlist.Add(sumrec);
                                }
                                sumitems = null;
                                sumitems = new ObservableCollection<OutOfScopeaggregate>(temppiidlist);
                                fieldname = selectfield;
                                break;
                            case "idvpiid":
                                var summaryidvpiidagg = from sum in ef.Outofscopes
                                                 where sum.maj_agency_cat.Contains(selectfilteragency)
                                                 where sum.fiscal_year.Contains(selectyear)
                                                 where sum.dollarsobligated > 0
                                                 group sum by sum.idvpiid into sumGrp
                                                 select sumGrp;
                                List<OutOfScopeaggregate> tempidvpiidlist = new List<OutOfScopeaggregate>();
                                foreach (var s in summaryidvpiidagg)
                                {
                                    var sumrec = new OutOfScopeaggregate();
                                    sumrec.agency = selectfilteragency;
                                    sumrec.year = selectyear;
                                    sumrec.field = s.Key;
                                    sumrec.records = s.Count();
                                    tempidvpiidlist.Add(sumrec);
                                }
                                sumitems = null;
                                sumitems = new ObservableCollection<OutOfScopeaggregate>(tempidvpiidlist);
                                fieldname = selectfield;
                                break;
                        }
                        cursor = Cursors.Arrow;

                    }
                    break;
            }

        }
    }
}
