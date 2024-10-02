using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class ContrastParameters : IParameters
    {
        public double Coefficient { get; set; }
        public ParameterInfo[] GetDecription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Коэффициент",
                    MinValue = 0,
                    MaxValue = 10,
                    DefaultValue = 1,
                    Increment = 0.05
                }
            };
        }

        public void SetValues(double[] values)
        {
            Coefficient = values[0];
        }

        public double AdjustContrast(double intensity)
        {
            double newIntensity = Coefficient * (intensity - 0.5) + 0.5;

            if (newIntensity < 0)
                newIntensity = 0;

            if (newIntensity > 1)
                newIntensity = 1;

            return newIntensity;
        }
    }
}
