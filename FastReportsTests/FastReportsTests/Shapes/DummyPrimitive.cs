using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReportsTests.Shapes
{
    public class DummyPrimitive : GraphicPrimitive
    {
        public override void Draw(Graphics g)
        {
        }
        public override bool IsPointInside(Point p)
        {
            return
                false;
        }

        public override void Resize(int width, int height)
        {
            
        }
    }
}
