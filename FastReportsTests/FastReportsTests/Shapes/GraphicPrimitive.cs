﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReportsTests.Shapes
{
    public abstract class GraphicPrimitive
    {
        private static Color _defaultFillColor = Color.Yellow;
        private static Color _defaultStrokeColor = Color.Red;

        ///////////////////
        //// Заливочка
        private Color _fillColor = _defaultFillColor;
        public Color FillColor { get => _fillColor; set { _fillColor = value; fillBrush = new SolidBrush(_fillColor); } }
        protected Brush fillBrush = new SolidBrush(_defaultFillColor);

        ///////////////////
        //// Рамочка
        private Color _strokeColor = _defaultStrokeColor;
        public Color StrokeColor { get => _strokeColor; set { _strokeColor = value; strokePen = new Pen(_strokeColor);  } }
        protected Pen strokePen = new Pen(_defaultStrokeColor);

        public int Width { get; set; }
        public int Height { get; set; }
        /// <summary>
        /// Пока что это центр X
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Пока что это центр Y
        /// </summary>
        public int Y { get; set; }
        public abstract void Draw(Graphics g);
        public abstract bool IsPointInside(Point p);
        public abstract void Resize(int width, int height);
    }
}
