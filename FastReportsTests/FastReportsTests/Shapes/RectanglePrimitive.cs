using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReportsTests.Shapes
{
    public class RectanglePrimitive : GraphicPrimitive
    {
        public override void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(FillColor))
            {
                g.FillRectangle(brush, X, Y, Width, Height);
            }
            using (Pen pen = new Pen(StrokeColor))
            {
                g.DrawRectangle(pen, X, Y, Width, Height);
            }
        }

        public override bool IsPointInside(Point p)
        {
            return (p.X >= X && p.X <= Width && p.Y >= X && p.Y <= Height);
        }

        public override void Resize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
