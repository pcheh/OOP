using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Report
{
    public class MeanAndStd
    {
        public double Mean { get; set; }
        public double Std { get; set; }
        public override string ToString()
        {
            return Mean.ToString(CultureInfo.InvariantCulture) + "±" + Std.ToString(CultureInfo.InvariantCulture);
        }
    }
}
