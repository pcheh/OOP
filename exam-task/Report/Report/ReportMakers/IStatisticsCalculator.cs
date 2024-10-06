using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    public interface IStatisticsCalculator
    {
        string Caption { get; }

        object MakeStatistics(IEnumerable<double> data);
    }
}
