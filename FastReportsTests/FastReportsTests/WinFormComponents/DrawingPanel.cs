using FastReportsTests.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReportsTests.WinFormComponents
{
    public class DrawingPanel : Panel
    {
        private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();
        private GraphicPrimitive? futurePrimitive;
        public DrawingPanel() 
        {
            this.MouseMove += DrawingPanel_MouseMove;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var primitive in primitives)
            {
                primitive.Draw(e.Graphics);
            }
            futurePrimitive?.Draw(e.Graphics);
        }

        public void AddPrimitive(GraphicPrimitive primitive)
        {
            primitives.Add(primitive);
            Invalidate();
        }

        public void SetFuturePrimitive(GraphicPrimitive primitive)
        {
            futurePrimitive = primitive;
        }

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (futurePrimitive != null) 
            {
                futurePrimitive.X = e.X;
                futurePrimitive.Y = e.Y;
                Invalidate();
                //futurePrimitive.Draw(this.gr);
            }

            //if (selectedPrimitive == null) return;

            //if (isMoving)
            //{
            //    int dx = e.X - initialMousePos.X;
            //    int dy = e.Y - initialMousePos.Y;
            //    // Assuming the primitive has properties `X` and `Y` for its position
            //    selectedPrimitive.X += dx;
            //    selectedPrimitive.Y += dy;
            //    initialMousePos = e.Location;
            //    Invalidate();
            //}
            //else if (isResizing)
            //{
            //    int dx = e.X - initialMousePos.X;
            //    int dy = e.Y - initialMousePos.Y;
            //    selectedPrimitive.Resize(initialWidth + dx, initialHeight + dy);
            //    Invalidate();
            //}
        }
        // Handle mouse events for moving and resizing primitives
        // Connect primitives with lines
    }
}
