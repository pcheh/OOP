using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LeanTransformer : ITransformer<LeanParameters>
    {
        Size oldSize { get; set; }
        double tanAlpha { get; set; }

        public Size ResultSize { get; private set; }

        public void Initialize(Size size, LeanParameters parameters)
        {
            oldSize = size;

            double angleInRadians = parameters.AngleInDegrees * Math.PI / 180;
            tanAlpha = Math.Tan(angleInRadians);

            int newWidth = size.Width;
            int newHeight = size.Height + (int)(size.Width * tanAlpha);
            ResultSize = new Size(newWidth, newHeight);
        }

        public Point? MapPoint(Point point)
        {
            int offsetY = (int)(point.X * tanAlpha);

            int oldX = point.X;
            int oldY = point.Y - offsetY;

            if (oldX < 0 || oldX >= oldSize.Width || oldY < 0 || oldY >= oldSize.Height)
                return null;

            return new Point(oldX, oldY);
        }
    }
}
