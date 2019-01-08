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
    public class setcontractvehicle
    {
        public int setCVRecords()
        {
            int fixedrec = 0;
            int fixedoos = 0;

            using (USAspendEF ef = new USAspendEF())
            {

                ef.Configuration.LazyLoadingEnabled = false;
                ObservableCollection<ComboBoxDisplayValue> years = Utility.GetyearCB();

                string currentyear = years[0].Value;


                fixedrec = ef.Database.ExecuteSqlCommand("UPDATE t1 SET t1.contract_vehicle = t2.contract_vehicle, t1.work = t2.work, "+
                               "  t1.completion_date = t2.completion_date, t1.completion_year = t2.completion_year "+
                               " FROM Current_usaspend t1 INNER JOIN Current_usaspend t2 "+
                               " ON t1.piid + t1.idvpiid = t2.piid + t2.idvpiid "+
                               " where t1.fiscal_year = '" + currentyear + "' and t1.contract_vehicle is null and "+
                               " t2.fiscal_year <> '" + currentyear + "' and t2.contract_vehicle is not null");
            }

            return fixedrec;
        }
        public int setCVRecords(String fiscal_year)
        {
            int fixedrec = 0;
            int fixedoos = 0;

            using (USAspendEF ef = new USAspendEF())
            {

                ef.Configuration.LazyLoadingEnabled = false;
                ObservableCollection<ComboBoxDisplayValue> years = Utility.GetyearCB();

                string currentyear = years[0].Value;


                fixedrec = ef.Database.ExecuteSqlCommand("UPDATE t1 SET t1.contract_vehicle = t2.contract_vehicle, t1.work = t2.work, " +
                               "  t1.completion_date = t2.completion_date, t1.completion_year = t2.completion_year " +
                               " FROM Current_usaspend t1 INNER JOIN Current_usaspend t2 " +
                               " ON t1.piid + t1.idvpiid = t2.piid + t2.idvpiid " +
                               " where t1.fiscal_year = '" + fiscal_year + "' and t1.contract_vehicle is null and " +
                               " t2.fiscal_year <> '" + fiscal_year + "' and t2.contract_vehicle is not null");
            }

            return fixedrec;
        }

    }
}
