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
    class outofscopefilterviewmodel : INotifyPropertyChanged
    {
        # region properties



        private ObservableCollection<filtereditmodel> _filteritems;

        private ObservableCollection<ComboBoxDisplayValue> _fielditems;
        private ObservableCollection<ComboBoxDisplayValue> _opitems;
        private ObservableCollection<ComboBoxDisplayValue> _stringopitems;
        private ObservableCollection<ComboBoxDisplayValue> _agencyitems;
        private int _fieldindex;



        private String _filtertext;
        private String _selectfield;
        private String _selectop;
        private String _selectstringop;
        private DateTime _selectdate;
        private String _numstrtext;
        private String _selecttestagency;
        private String _selectfilteragency;
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

        public String selecttestagency
        {
            get
            {

                return _selecttestagency;
            }
            set
            {
                _selecttestagency = value;
                NotifyPropertyChanged("selecttestagency");

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

        public String numstrtext
        {
            get
            {

                return _numstrtext;
            }
            set
            {
                _numstrtext = value;
                NotifyPropertyChanged("numstrtext");

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


        public ObservableCollection<ComboBoxDisplayValue> stringopitems
        {
            get
            {

                return _stringopitems;
            }
            set
            {
                _stringopitems = value;
                NotifyPropertyChanged("stringopitems");

            }

        }

        public ObservableCollection<ComboBoxDisplayValue> opitems
        {
            get
            {

                return _opitems;
            }
            set
            {
                _opitems = value;
                NotifyPropertyChanged("opitems");

            }

        }

        public String selectstringop
        {
            get
            {

                return _selectstringop;
            }
            set
            {
                _selectstringop = value;
                NotifyPropertyChanged("selectstringop");

            }

        }
        public DateTime selectdate
        {
            get
            {

                return _selectdate;
            }
            set
            {
                _selectdate = value;
                NotifyPropertyChanged("selectdate");

            }

        }
        public String selectop
        {
            get
            {

                return _selectop;
            }
            set
            {
                _selectop = value;
                NotifyPropertyChanged("selectop");

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

        public String filtertext
        {
            get
            {

                return _filtertext;
            }
            set
            {
                _filtertext = value;
                NotifyPropertyChanged("filtertext");

            }

        }

        public ObservableCollection<filtereditmodel> filteritems
        {
            get
            {

                return _filteritems;
            }
            set
            {
                _filteritems = value;
                NotifyPropertyChanged("filteritems");

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

        public Action CloseAction { get; set; }

        # endregion

        public outofscopefilterviewmodel()
        {
            ViewSwitchCommand = new RelayCommand(new Action<object>(SwitchViews));
            setupcombo();
            fieldindex = -1;
            //selectdate = DateTime.Now;
        }

        void setupcombo()
        {

            using (USAspendEF ef = new USAspendEF())
            {
                fielditems = new ObservableCollection<ComboBoxDisplayValue>(new List<ComboBoxDisplayValue>() 
            {
                new ComboBoxDisplayValue("dollarsobligated","decimal"),
                new ComboBoxDisplayValue("productorservicecode","String"),
                new ComboBoxDisplayValue("principalnaicscode","String"),
               // new ComboBoxDisplayValue("principalnaicscode","String"),
                new ComboBoxDisplayValue("completion_date", "DateTime"),
                new ComboBoxDisplayValue("contract_vehicle", "String")
            });




                stringopitems = new ObservableCollection<ComboBoxDisplayValue>(new List<ComboBoxDisplayValue>() 
            {
               new ComboBoxDisplayValue("STARTS WITH","start like"),
                new ComboBoxDisplayValue("DOES NOT START WITH","start not like"),
                new ComboBoxDisplayValue("CONTAINS","like"),
                new ComboBoxDisplayValue("DOES NOT CONTAINS","not like"),
                new ComboBoxDisplayValue("EXACT MATCH","="),
                new ComboBoxDisplayValue("DOES NOT MATCH","<>"),
                new ComboBoxDisplayValue("IS NULL/NOTHING","is null")
            });

                opitems = new ObservableCollection<ComboBoxDisplayValue>(new List<ComboBoxDisplayValue>() 
            {
                new ComboBoxDisplayValue("equals","="),
                new ComboBoxDisplayValue("greater than",">"),
                                    new ComboBoxDisplayValue("less than","<"),
                                    new ComboBoxDisplayValue("greater than or equal",">="),
                                    new ComboBoxDisplayValue("less than or equal", "<="),
                                    new ComboBoxDisplayValue("not equal to", "<>"),
                                    new ComboBoxDisplayValue("is null/nothing", "is null")
            });

                var agency = from a in ef.GUIconfig
                             where a.combobox == 0
                             select a;
                agencyitems = new ObservableCollection<ComboBoxDisplayValue>();
                foreach (var agencycb in agency)
                {
                    agencyitems.Add(new ComboBoxDisplayValue(agencycb.display, agencycb.value));

                }

                setfilterdatagrid();
            }
        }
        private void setfilterdatagrid()
        {
            using (USAspendEF ef = new USAspendEF())
            {

                var ooss = from s in ef.Outofscopefilters
                           select s;
                List<filtereditmodel> display = new List<filtereditmodel>();

                foreach (var s in ooss)
                {
                    var rec = new filtereditmodel();
                    rec.Filter = s;
                    display.Add(rec);

                }

                filteritems = new ObservableCollection<filtereditmodel>(display);


            }

        }
        private void getfilter()
        {
            // may need to validate that all controls are set before adding filter.
            //make a fitler 
            if (String.IsNullOrEmpty(selectfilteragency))
            {
                DialogService dialog = new DialogService();
                dialog.ShowMessageBox("Please select an agency.", "Input Error", System.Windows.MessageBoxButton.OK);
                return;

            }


            if (String.IsNullOrEmpty(selectfield))
            {
                DialogService dialog = new DialogService();
                dialog.ShowMessageBox("Please select a field.", "Input Error", System.Windows.MessageBoxButton.OK);
                return;

            }

            StringBuilder sb = new StringBuilder();

            String selectfieldname = fielditems[fieldindex].Display;


            switch (selectfield)
            {
                case "DateTime":// date only operators where time is always 00:00:00
                    //validate

                    if (String.IsNullOrEmpty(selectop)) //||
                    {
                        DialogService dialog = new DialogService();
                        dialog.ShowMessageBox("Please select an operator.", "Input Error", System.Windows.MessageBoxButton.OK);
                        return;

                    }

                    // setup
                    sb.Append(selectfieldname);
                    String op = selectop;
                    sb.Append(" " + op + " ");
                    String seldt = selectdate.ToString("MM-dd-yyyy");
                    sb.Append("'" + seldt + "'");
                    break;
                case "String":
                    String strop = selectstringop;
                    if (String.IsNullOrEmpty(selectstringop) ||
                        String.IsNullOrEmpty(numstrtext))
                    {
                        DialogService dialog = new DialogService();
                        dialog.ShowMessageBox("Please select an operator and text to compare.", "Input Error", System.Windows.MessageBoxButton.OK);
                        return;

                    }
                    if (strop == "like")
                    {
                        sb.Append(selectfieldname);
                        sb.Append(" " + strop + " ");
                        sb.Append(" '%" + numstrtext + "%' ");
                    }
                    if (strop == "not like")
                    {
                        sb.Append("(ISNULL(" + selectfieldname + ",'ZZZZZZZZZZZZZZZZZZZZZ')) ");

                        sb.Append(" " + strop + " ");
                        sb.Append(" '%" + numstrtext + "%' ");
                    }
                    else if (strop == "start like")
                    {
                        sb.Append(selectfieldname);
                        sb.Append(" " + "like" + " ");
                        sb.Append(" '" + numstrtext + "%' ");
                    }
                    if (strop == "start not like")
                    {
                        sb.Append("(ISNULL(" + selectfieldname + ",'ZZZZZZZZZZZZZZZZZZZZZ')) ");

                        sb.Append(" " + "not like" + " ");
                        sb.Append(" '" + numstrtext + "%' ");
                    }
                    else if (strop == "<>")
                    {
                        sb.Append("(ISNULL(" + selectfieldname + ",'ZZZZZZZZZZZZZZZZZZZZZ')) ");

                        sb.Append(" " + strop + " ");
                        sb.Append(" '" + numstrtext + "' ");
                    }
                    else if (strop == "=")
                    {
                        sb.Append(selectfieldname);
                        sb.Append(" " + strop + " ");
                        sb.Append(" '" + numstrtext + "' ");
                    }
                    else if (strop == "is null")
                    {
                        sb.Append(selectfieldname);
                        sb.Append(" " + strop);

                    }
                    break;
                case "decimal":
                    if (String.IsNullOrEmpty(selectop) ||
                       String.IsNullOrEmpty(numstrtext))
                    {
                        DialogService dialog = new DialogService();
                        dialog.ShowMessageBox("Please select an operator and text to compare.", "Input Error", System.Windows.MessageBoxButton.OK);
                        return;

                    }
                    int test;

                     if (selectop != "is null")
                    {
                        if (!Int32.TryParse(numstrtext, out test))
                        {
                            DialogService dialog = new DialogService();
                            dialog.ShowMessageBox("Value must be a number.", "Input Error", System.Windows.MessageBoxButton.OK);
                            return;


                        }
                    }
                    sb.Append(selectfieldname);
                    String decop = selectop;
                    if (decop == "is null")
                    {
                        sb.Append(" " + decop);
                    }
                    else
                    {
                        sb.Append(" " + decop + " ");
                        sb.Append(numstrtext);
                    }
                    break;
            }
            //now reset screen


            if (!String.IsNullOrEmpty(filtertext))
                filtertext = filtertext + " and " + sb.ToString();
            else
            {
                // set agency 
                // sb.Append(String.Format("{0}:", selectfilteragency));
                filtertext = String.Format("{0}:", selectfilteragency) + sb.ToString();
            }
        }

        public void SwitchViews(object obj)
        {

            string par = obj.ToString();

            switch (par)
            {
                case "clear":
                    //do something..

                    filtertext = String.Empty;
                    break;
                case "save":
                    //do something..
                    if (!String.IsNullOrEmpty(filtertext))
                    {
                        using (USAspendEF ef = new USAspendEF())
                        {
                            String[] tok = new String[1] { ":" };
                            String[] filterparts = filtertext.Split(tok, StringSplitOptions.None);

                            outofscopefilter oosrec = new outofscopefilter();
                            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                            oosrec.insertdate = DateTime.Now;
                            oosrec.insertuser = userName;
                            oosrec.agency = filterparts[0];
                            oosrec.filter = filterparts[1];
                            ef.Outofscopefilters.Add(oosrec);
                            ef.SaveChanges();


                        }
                    }
                    setfilterdatagrid();

                    break;
                case "try":
                    //do something..
                    if (!String.IsNullOrEmpty(filtertext))
                    {

                        using (USAspendEF ef = new USAspendEF())
                        {
                            String[] tok = new String[1] { ":" };
                            String[] filterparts = filtertext.Split(tok, StringSplitOptions.None);



                            var results = ef.Contracts.SqlQuery("select * from Current_usaspend where " + filterparts[1] + "  and maj_agency_cat like '" + filterparts[0] + "%'").ToList<Current_usaspend>();
                            DialogService dialog = new DialogService();

                            filtertestviewmodel vm = new filtertestviewmodel();
                            filtertest thelog = new filtertest();
                            thelog.DataContext = vm;
                            vm.logitems = new System.Collections.ObjectModel.ObservableCollection<Current_usaspend>(results.ToList<Current_usaspend>());
                            dialog.ShowDialog(thelog);

                        }

                    }

                    break;
                case "add":
                    //do something..
                    getfilter();
                    CloseAction();
                    break;

                case "testallfilters":
                    //do something..
                    //do something..

                    using (USAspendEF ef = new USAspendEF())
                    {
                        // first get all the filters in the table
                        if (String.IsNullOrEmpty(selecttestagency))
                        {
                            DialogService errdialog = new DialogService();
                            errdialog.ShowMessageBox("Please select an agency.", "Input Error", System.Windows.MessageBoxButton.OK);
                            break;

                        }
                        StringBuilder sb = new StringBuilder();


                        var filters = from f in ef.Outofscopefilters
                                      where f.agency == selecttestagency
                                      select f;

                        if (filters.Count() < 1)
                        {
                            DialogService errdialog = new DialogService();
                            errdialog.ShowMessageBox("No filter records.", "Warning", System.Windows.MessageBoxButton.OK);
                            break;
                        }

                        int loop = 0;
                        foreach (var s in filters)
                        {
                            if (loop == 0)
                                sb.Append(" ((" + s.filter + ") ");
                            else
                                sb.Append(" or (" + s.filter + ") ");
                            loop++;

                        }

                        sb.Append(") and maj_agency_cat like '" + selecttestagency + "%' ");

                        var results = ef.Contracts.SqlQuery("select * from Current_usaspend where " + sb.ToString()).ToList<Current_usaspend>();
                        DialogService dialog = new DialogService();

                        filtertestviewmodel vm = new filtertestviewmodel();
                        filtertest thelog = new filtertest();
                        thelog.DataContext = vm;
                        vm.logitems = new System.Collections.ObjectModel.ObservableCollection<Current_usaspend>(results.ToList<Current_usaspend>());
                        dialog.ShowDialog(thelog);

                    }



                    break;
                case "deletefilter":
                    //do something..


                    using (USAspendEF ef = new USAspendEF())
                    {
                        // first get all the filters in the table
                        DialogService dialog = new DialogService();

                        if (filteritems.Count() < 1)
                        {

                            dialog.ShowMessageBox("No filter records.", "Warning", System.Windows.MessageBoxButton.OK);
                            break;
                        }



                        //delete record

                        List<filtereditmodel> selected = new List<filtereditmodel>();

                        foreach (var r in filteritems)
                        {

                            if (r.Selected)
                                selected.Add(r);

                        }

                        if (selected.Count() < 1)
                        {
                            dialog.ShowMessageBox("No records were selected.", "Delete filter", System.Windows.MessageBoxButton.OK);
                            break;

                        }
                        //multiple selection is in the new list

                        // warning to bail if you want to.




                        System.Windows.MessageBoxResult result = dialog.ShowMessageBox("Are you sure you want to delete these filters?", "Delete filter", System.Windows.MessageBoxButton.YesNo);

                        if (result == System.Windows.MessageBoxResult.No)
                            break;



                        foreach (var s in selected)
                        {

                            if (s.Selected)
                            {
                                ef.Outofscopefilters.Remove(ef.Outofscopefilters.Where(x => x.id == s.Filter.id).SingleOrDefault());
                            }

                        }
                        ef.SaveChanges();
                        setfilterdatagrid();

                    }
                    break;
            }

        }
    }
}
