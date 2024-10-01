using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LighteningFilter : PixelFilter
    {
        public override ParameterInfo[] GetParametersInfo()
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

        public override Pixel ProcessPixel(Pixel pixel, double[] parameters)
        {
            return pixel * parameters[0];
        }

        public override string ToString()
        {
            return "Осветление/затемнение";
        }
    }
}
