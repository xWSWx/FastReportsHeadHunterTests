using FastReportsTests.WinFormComponents;

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
                switch (value)
                {
                    case eDrawingPanelMode.drawCicle:
                        DrawingPanelWSW.SetFuturePrimitive(new Shapes.CirclePrimitive() { Radius = 10, FillColor = Color.Yellow });
                        break;
                    case eDrawingPanelMode.drawTriangle:
                        DrawingPanelWSW.SetFuturePrimitive(new Shapes.TrianglePrimitive() { FillColor = Color.Yellow });
                        break;
                    case eDrawingPanelMode.drawRectangle:

                        break;
                }
                _currentDrawingMode = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrentDrawingMode = (eDrawingPanelMode)listBox1.SelectedIndex;
            }
            catch { }
        }

        private void DrawingPanelWSW_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
