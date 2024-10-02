using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LeanParameters : IParameters
    {
        public double AngleInDegrees { get; set; }
        public ParameterInfo[] GetDecription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Угол в °",
                    MinValue = 0,
                    MaxValue = 85,
                    DefaultValue = 0,
                    Increment = 5
                }
            };
        }

        public void SetValues(double[] values)
        {
            AngleInDegrees = values[0];
        }
    }
}
