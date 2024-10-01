using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public abstract class PixelFilter : IFilter
    {
        public abstract ParameterInfo[] GetParametersInfo();

        public Photo Process(Photo original, double[] parameters)
        {
            var newPhoto = new Photo(original.Width, original.Height);

            for (var x = 0; x < original.Width; x++)
                for (var y = 0; y < original.Height; y++)
                    newPhoto[x, y] = ProcessPixel(original[x, y], parameters);

            return newPhoto;
        }

        public abstract Pixel ProcessPixel(Pixel pixel, double[] parameters);
    }
}
