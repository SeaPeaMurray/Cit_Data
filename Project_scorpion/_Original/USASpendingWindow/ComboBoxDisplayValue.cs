using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USAspendingWindow
{
    class ComboBoxDisplayValue
    {
        public ComboBoxDisplayValue(string dis, string val)
        {
            Display = dis;
            Value = val;
           
        }

        public String Display { get; set; }
        public String Value { get; set; }
    }
}
