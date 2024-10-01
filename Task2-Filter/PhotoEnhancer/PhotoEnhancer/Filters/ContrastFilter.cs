using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class ContrastFilter : PixelFilter
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
            double k = parameters[0];
            return new Pixel(
                AdjustContrast(pixel.R, k),
                AdjustContrast(pixel.G, k),
                AdjustContrast(pixel.B, k));
        }

        private double AdjustContrast(double intensity, double k)
        {
            double newIntensity = k * (intensity - 0.5) + 0.5;

            if (newIntensity < 0) 
                newIntensity = 0;

            if (newIntensity > 1) 
                newIntensity = 1;

            return newIntensity;
        }

        public override string ToString()
        {
            return "Контраст";
        }
    }
}
