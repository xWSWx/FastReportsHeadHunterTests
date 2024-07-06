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
        public EventHandler? OnConnected;
        public EventHandler? OnTimerSelected;
        private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();
        private List<GraphicPrimitive> connectionLines = new List<GraphicPrimitive>();
        private GraphicPrimitive? futurePrimitive;
        private GraphicPrimitive? _selectedPrimitive;
        DummyPrimitive dummyPrimitive = new DummyPrimitive();
        private readonly ConnectedLinePrimitive _currentConnectedLinePrimitive; 
        System.Windows.Forms.Timer SelectStrokeTimer = new() { Interval=250 };
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

                if (_selectedPrimitive != null && value != null && isConnectionLineInProgress)
                {
                    _currentConnectedLinePrimitive.Second = value;
                    connectionLines.Add(new ConnectedLinePrimitive(_currentConnectedLinePrimitive.First, _currentConnectedLinePrimitive.Second));
                    isConnectionLineInProgress = false;
                    _currentConnectedLinePrimitive.First = dummyPrimitive;
                    _currentConnectedLinePrimitive.Second = dummyPrimitive;
                    OnConnected?.Invoke(this, EventArgs.Empty);
                }
                if (_selectedPrimitive == null && value != null && isConnectionLineInProgress)
                {
                    _currentConnectedLinePrimitive.First = value;
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
            _currentConnectedLinePrimitive = new ConnectedLinePrimitive(dummyPrimitive, dummyPrimitive);
            //TODO: сделдать красоту
            SelectStrokeTimer.Tick += delegate {
                if (SelectedPrimitive == null)
                    return;
                tickTak = !tickTak;
                if (tickTak)
                    SelectedPrimitive.StrokeColor = selectedPen.Color;
                else
                    SelectedPrimitive.StrokeColor = savedSelectedPen.Color;

                OnTimerSelected?.Invoke(null, EventArgs.Empty);
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
            foreach (var connectLine in connectionLines)
            {
                connectLine.Draw(e.Graphics);
            }
            if (isConnectionLineInProgress)
                _currentConnectedLinePrimitive.Draw(e.Graphics);
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
        bool isConnectionLineInProgress = false;
        public void StartConnectionLinePrimitive()
        {
            if (SelectedPrimitive != null)
            {
                _currentConnectedLinePrimitive.First = SelectedPrimitive;
                _currentConnectedLinePrimitive.Second  = dummyPrimitive;
            }
            isConnectionLineInProgress = true;
        }
        public void StopConnectionLinePrimitive() => isConnectionLineInProgress = false;

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

            if (isConnectionLineInProgress)
            {
                if (SelectedPrimitive == null)
                    return;
                dummyPrimitive.X = e.X;
                dummyPrimitive.Y = e.Y;
                Invalidate();
                return;
            }
            if (isResizing && SelectedPrimitive != null)
            {
                int dx = e.X - startMousePosition.X;
                int dy = e.Y - startMousePosition.Y;
                SelectedPrimitive.Resize(startWidth + dx, startHeight + dy);
                Invalidate();
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
