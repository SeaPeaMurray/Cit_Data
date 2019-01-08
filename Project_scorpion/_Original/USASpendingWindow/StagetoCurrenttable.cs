using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USAspendingWindow
{
    public class StagetoCurrenttable
    {
        public int SeparateandLoad()
        {
            int count = 0;

            using (USAspendEF ef = new USAspendEF())
            {

                count = ef.Database.ExecuteSqlCommand("insert into [dbo].[Current_usaspend] "+
                                                        "select * FROM [dbo].[Stage_usaspend] as t1 "+
                                                        "where not exists "+
                                                        "(select * FROM [dbo].[Current_usaspend] as t2 "+
                                                        "where t1.unique_transaction_id = t2.unique_transaction_id)");



            }

            return count;
        }
    }
}
