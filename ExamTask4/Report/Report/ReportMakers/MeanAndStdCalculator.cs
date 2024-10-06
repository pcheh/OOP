using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    public class MeanAndStdCalculator : IStatisticsCalculator
    {
        public string Caption
        {
            get
            {
                return "Mean and Std";
            }
        }

        public object MakeStatistics(IEnumerable<double> data)
        {
            var list = data.ToList();
            var mean = list.Average();
            var std = Math.Sqrt(list.Select(z => Math.Pow(z - mean, 2)).Sum() / (list.Count - 1));

            return new MeanAndStd
            {
                Mean = mean,
                Std = std
            };
        }
    }
}
