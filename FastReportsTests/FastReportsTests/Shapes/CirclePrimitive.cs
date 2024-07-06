using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReportsTests.Shapes
{
    public class CirclePrimitive : GraphicPrimitive
    {
        public int Radius { get; set; }
        public override void Draw(Graphics g)
        {
            //using (Brush brush = new SolidBrush(FillColor))
            {
                g.FillEllipse(fillBrush, X, Y, 2 * Radius, 2 * Radius);
            }
            using (Pen pen = new Pen(StrokeColor))
            {
                g.DrawEllipse(pen, X, Y, 2 * Radius, 2 * Radius);
            }
        }

        public override bool IsPointInside(Point p)
        {
            int dx = p.X - Radius;
            int dy = p.Y - Radius;
            return (dx * dx + dy * dy <= Radius * Radius);
        }

        public override void Resize(int width, int height)
        {
            Radius = width / 2;  // Assuming width = height for a circle
        }
    }

}
