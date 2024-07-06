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
        public EventHandler? OnAddPrimitiveByClick;
        public EventHandler<GraphicPrimitive?>? OnSelectedChanged;
        private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();
        private GraphicPrimitive? futurePrimitive;
        private GraphicPrimitive? _selectedPrimitive;
        System.Windows.Forms.Timer SelectStrokeTimer = new ();
        public GraphicPrimitive? SelectedPrimitive 
        { 
            get => _selectedPrimitive; 
            private set 
            { 
                var isNew = _selectedPrimitive != value;
                if (!isNew)
                    return;                

                //////////////
                //// Если был, вернуть цвет.
                if (_selectedPrimitive != null)
                {                   
                    _selectedPrimitive.StrokeColor = savedSelectedPen.Color;
                }

                _selectedPrimitive = value;


                if (_selectedPrimitive != null)
                { 
                    savedSelectedPen.Color = _selectedPrimitive.StrokeColor;
                }
                OnSelectedChanged?.Invoke(this, _selectedPrimitive);


                if (_selectedPrimitive == null)
                {
                    SelectStrokeTimer.Stop();
                }
                else
                    SelectStrokeTimer.Start();

                Invalidate();
            } 
        }
        private Point startMousePosition;
        private int startWidth;
        private int startHeight;
        bool isMoving = false;
        bool isResizing = false;

        bool tickTak = false;
        
        Pen selectedPen = new Pen (Color.FromArgb(127, 255, 212));
        Pen savedSelectedPen = new Pen(Color.White);
        public DrawingPanel() 
        {
            DoubleBuffered = true;

            //TODO: сделдать красоту
            SelectStrokeTimer.Tick += delegate {
                if (SelectedPrimitive == null)
                    return;
                tickTak = !tickTak;
                if (tickTak)
                    SelectedPrimitive.StrokeColor = selectedPen.Color;
                else
                    SelectedPrimitive.StrokeColor = savedSelectedPen.Color;

                Invalidate();
            };

            this.MouseMove += DrawingPanel_MouseMove;
            this.MouseDown += DrawingPanel_MouseDown;
            this.MouseUp += DrawingPanel_MouseUp;
            this.MouseClick += DrawingPanel_MouseClick;
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
                return;
            }

            if (isMoving && SelectedPrimitive != null)
            {
                SelectedPrimitive.X = e.X;
                SelectedPrimitive.Y = e.Y; 
                Invalidate();
                return;
            }

        }
        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (futurePrimitive != null)
            {
                primitives.Add(futurePrimitive);
                futurePrimitive = null;
                OnAddPrimitiveByClick?.Invoke(this, EventArgs.Empty);
                return;
            }

            foreach (var primitive in primitives)
            {
                if (primitive.IsPointInside(e.Location))
                {
                    SelectedPrimitive = primitive;
                    startMousePosition = e.Location;
                    startWidth = primitive.Width;
                    startHeight = primitive.Height;

                    if (e.Button == MouseButtons.Left)
                    {
                        isMoving = true;
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        isResizing = true;
                    }
                    break;
                }
            }
        }
        private void DrawingPanel_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMoving = false;
            else if (e.Button == MouseButtons.Right)
                isResizing = false;
            
            //throw new NotImplementedException();
        }
        private void DrawingPanel_MouseClick(object? sender, MouseEventArgs e)
        {
            bool founded = false;
            foreach (var primitive in primitives)
            {
                if (primitive.IsPointInside(e.Location))
                {
                    SelectedPrimitive = primitive;
                    founded = true;
                    break;
                }
            }
            if (!founded) 
            {
                SelectedPrimitive = null;
            }
        }
    }
}
