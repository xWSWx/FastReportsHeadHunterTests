using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReportsTests.Shapes
{

    public class ConnectedLinePrimitive : GraphicPrimitive
    {
        public GraphicPrimitive First;
        public GraphicPrimitive Second;

        public ConnectedLinePrimitive(GraphicPrimitive first, GraphicPrimitive second) 
        {
            First = first;
            Second = second;
        }
        public override void Draw(Graphics g)
        {
            g.DrawLine(strokePen, First.X, First.Y, Second.X, Second.Y);            
        }
        public override bool IsPointInside(Point p)
        {
            //TODO: добавил формулу выяснения "находится ли точка на отрезке".. допустим, с отклонением в 1 пиксель
            return false;
        }

        public override void Resize(int width, int height)
        {            
        }
    }
}
