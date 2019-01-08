using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USAspendingWindow
{
    public class RemoveOutofScope
    {
        public int RemoveZeroRecords()
        {
            int count = 0;
            int deleted = 0;

            using (USAspendEF ef = new USAspendEF())
            {

                //count = ef.Database.ExecuteSqlCommand("insert into OutOfScope_usaspend "+
                //                                        "select * from Current_usaspend "+
                //                                        "where dollarsobligated = 0 ");



                deleted = ef.Database.ExecuteSqlCommand("delete Current_usaspend " +
                                                        " where dollarsobligated = 0 ");

            }

            return deleted;
        }

        public int MoveOutOfScopeRecords()
        {
            int count = 0;
            int deleted = 0;

            using (USAspendEF ef = new USAspendEF())
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("insert into OutOfScope_usaspend " +
                            "select * FROM Current_usaspend as t1 " +
                            "where ");

                var filters = from f in ef.Outofscopefilters
                              
                              select f;

                if (filters.Count() < 1)
                {
                    return 0;
                }

                int loop = 0;
                foreach (var s in filters)
                {
                    if (loop == 0)
                        sb.Append(" ((" + s.filter + " and maj_agency_cat like '" + s.agency + "%') ");
                    else
                        sb.Append(" or (" + s.filter + " and maj_agency_cat like '" + s.agency + "%') ");
                    loop++;

                }

                sb.Append(") " +
                    " and not exists " +
                "(select * FROM OutOfScope_usaspend as t2 " +
                "where t1.unique_transaction_id = t2.unique_transaction_id ) ");

                count = ef.Database.ExecuteSqlCommand(sb.ToString());


            }

            return count;
        }
        public int RemoveOutOfScopeRecords()
        {
            int count = 0;
            int deleted = 0;

            using (USAspendEF ef = new USAspendEF())
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("delete Current_usaspend " +
                            " where ");

                var filters = from f in ef.Outofscopefilters

                              select f;

                if (filters.Count() < 1)
                {
                    return 0;
                }

                int loop = 0;
                foreach (var s in filters)
                {
                    if (loop == 0)
                        sb.Append(" ((" + s.filter + " and maj_agency_cat like '" + s.agency + "%') ");
                    else
                        sb.Append(" or (" + s.filter + " and maj_agency_cat like '" + s.agency + "%') ");
                    loop++;

                }

                sb.Append(") ");

                deleted = ef.Database.ExecuteSqlCommand(sb.ToString());
               

            }

            return deleted;
        }

        public int MoveZeroRecords()
        {
            int count = 0;
            int deleted = 0;

            using (USAspendEF ef = new USAspendEF())
            {

                //count = ef.Database.ExecuteSqlCommand("insert into OutOfScope_usaspend "+
                //                                        "select * from Current_usaspend "+
                //                                        "where dollarsobligated = 0 ");

                count = ef.Database.ExecuteSqlCommand("insert into OutOfScope_usaspend " +
                                                        "select * FROM Current_usaspend as t1 " +
                                                        "where dollarsobligated = 0  and not exists " +
                                                        "(select * FROM OutOfScope_usaspend as t2 " +
                                                        "where t1.unique_transaction_id = t2.unique_transaction_id ) ");


            }

            return count;
        }
    }
}
