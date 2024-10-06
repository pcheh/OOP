using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    public class MedianCalculator : IStatisticsCalculator
    {
        public string Caption
        {
            get
            {
                return "Median";
            }
        }

        public object MakeStatistics(IEnumerable<double> data)
        {
            var list = data.OrderBy(z => z).ToList();
            if (list.Count % 2 == 0)
                return (list[list.Count / 2] + list[list.Count / 2 - 1]) / 2;

            return list[list.Count / 2];
        }
    }
}
