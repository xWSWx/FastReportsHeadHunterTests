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
            g.FillEllipse(fillBrush, X-Radius, Y - Radius, 2 * Radius, 2 * Radius);                              
            g.DrawEllipse(strokePen, X- Radius, Y- Radius, 2 * Radius, 2 * Radius);         
        }

        public override bool IsPointInside(Point p)
        {
            int dx = X - p.X;
            int dy = Y - p.Y;
            return (dx * dx + dy * dy <= Radius * Radius);
        }

        public override void Resize(int width, int height)
        {
            Radius = width / 2;  
        }
    }

}
