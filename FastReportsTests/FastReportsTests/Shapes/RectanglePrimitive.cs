using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReportsTests.Shapes
{
    public class RectanglePrimitive : GraphicPrimitive
    {
        public RectanglePrimitive() { }

        public override void Draw(Graphics g)
        {            
            g.FillRectangle(fillBrush, X-Width/2, Y-Height/2, Width, Height);
            g.DrawRectangle(strokePen, X-Width/2, Y-Height/2, Width, Height);
        }

        public override bool IsPointInside(Point p)
        {
            return
                p.X >= X - Width/2 && p.X <= X + Width/2
                && 
                p.Y >= Y - Height/2 && p.Y <= Y+ Height/2;
        }

        public override void Resize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
