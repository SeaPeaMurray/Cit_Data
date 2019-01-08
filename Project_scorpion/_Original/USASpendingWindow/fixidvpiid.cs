using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USAspendingWindow
{
    public class fixidvpiid
    {
        public int fixidvpiidRecords()
        {
            int fixedrec = 0;
            int fixedoos = 0;

            using (USAspendEF ef = new USAspendEF())
            {


                fixedrec = ef.Database.ExecuteSqlCommand("update current_usaspend set idvpiid = piid "+
                                                           "where unique_transaction_id "+
                                                           "in (select unique_transaction_id from current_usaspend "+
                                                           " where idvpiid is null and piid is not null)");

                fixedoos = ef.Database.ExecuteSqlCommand("update OutOfScope_usaspend set idvpiid = piid " +
                                                          "where unique_transaction_id " +
                                                          "in (select unique_transaction_id from OutOfScope_usaspend " +
                                                          " where idvpiid is null and piid is not null)");
            }

            return fixedrec;
        }

       
    }
}
