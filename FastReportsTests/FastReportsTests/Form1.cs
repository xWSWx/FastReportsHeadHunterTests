using FastReportsTests.Shapes;
using FastReportsTests.WinFormComponents;
using System.Runtime.CompilerServices;

namespace FastReportsTests
{
    public partial class Form1 : Form
    {
        public enum eDrawingPanelMode { select, connect, drawCicle, drawTriangle, drawRectangle }
        private eDrawingPanelMode _currentDrawingMode;
        public eDrawingPanelMode CurrentDrawingMode
        {
            get { return _currentDrawingMode; }
            private set
            {
                var wasConnectMode = _currentDrawingMode == eDrawingPanelMode.connect;
                if (value != eDrawingPanelMode.connect)
                {
                    DrawingPanelWSW.StopConnectionLinePrimitive();
                }
                switch (value)
                {
                    case eDrawingPanelMode.drawCicle:
                        DrawingPanelWSW.SetFuturePrimitive(new Shapes.CirclePrimitive() { Radius = 10, FillColor = Color.Yellow });
                        break;
                    case eDrawingPanelMode.drawTriangle:
                        DrawingPanelWSW.SetFuturePrimitive(new Shapes.TrianglePrimitive() { FillColor = Color.Yellow });
                        break;
                    case eDrawingPanelMode.drawRectangle:
                        DrawingPanelWSW.SetFuturePrimitive(new Shapes.RectanglePrimitive() { Width = 50, Height = 30, FillColor = Color.Yellow });
                        break;
                    case eDrawingPanelMode.connect:
                        DrawingPanelWSW.StartConnectionLinePrimitive();
                        break;
                }
                _currentDrawingMode = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
            DrawingPanelWSW.OnAddPrimitiveByClick += (x, y) => listBox1.SelectedIndex = -1;
            DrawingPanelWSW.OnConnected += (x, y) => listBox1.SelectedIndex = 0;
            DrawingPanelWSW.OnSelectedChanged += DrawingPanelWSW_OnSelectChanged;
            DrawingPanelWSW.OnTimerSelected += (x, y) => 
            {
                FillLabel.ForeColor = DrawingPanelWSW.SelectedPrimitive == null ? Color.Black : DrawingPanelWSW.SelectedPrimitive.FillColor;
                StrokeLable.ForeColor = DrawingPanelWSW.SelectedPrimitive == null ? Color.Black : DrawingPanelWSW.SelectedPrimitive.StrokeColor;
            };
        }
        private void DrawingPanelWSW_OnSelectChanged(object? sender, GraphicPrimitive? shape)
        {
            FillLabel.ForeColor = shape == null? Color.Black : shape.FillColor;
            StrokeLable.ForeColor = shape == null ? Color.Black : shape.StrokeColor;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrentDrawingMode = (eDrawingPanelMode)listBox1.SelectedIndex;
            }
            catch { }
        }

    }
}
