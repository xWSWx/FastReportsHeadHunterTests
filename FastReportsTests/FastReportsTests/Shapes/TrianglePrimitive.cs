using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReportsTests.Shapes
{
    public class TrianglePrimitive : GraphicPrimitive
    {        
        public int Angle { get; set; }

        public override void Draw(Graphics g)
        {
            Point[] points = {
            new Point(Width / 2, 0),
            new Point(0, Height),
            new Point(Width, Height)
        };
            using (Brush brush = new SolidBrush(FillColor))
            {
                g.FillPolygon(brush, points);
            }
            using (Pen pen = new Pen(StrokeColor))
            {
                g.DrawPolygon(pen, points);
            }
        }

        public override bool IsPointInside(Point p)
        {
            // Implement point-in-triangle check (complex logic)
            return false;
        }

        public override void Resize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

}
