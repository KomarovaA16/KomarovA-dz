using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class SkewUpTransformer : ITransformer<SkewUpParameters>
    {
        Size oldSize { get; set; }
        double angleInRadians { get; set; }
        public Size ResultSize { get; private set; }
        public void Initialize(Size size, SkewUpParameters parameters)
        {
            oldSize = size;
            angleInRadians = parameters.AngleInDegrees * Math.PI / 180;
            ResultSize = new Size(
                (size.Width),
                (int)(size.Height + size.Height * Math.Abs(Math.Tan(angleInRadians)) 
                    ));
        }

        public Point? MapPoint(Point point)
        {
            var x = (point.X);
            var y = (int)(point.Y * Math.Cos(angleInRadians) - point.X * Math.Sin(angleInRadians));

            if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height)
                return null;

            return new Point(x, y);
        }
    }
}
