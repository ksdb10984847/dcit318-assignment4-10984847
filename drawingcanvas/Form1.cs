using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace drawingcanvas
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;
        private Point lastPoint;
        private Bitmap drawingBitmap;
        private Graphics drawingGraphics;

        public Form1()
        {
            InitializeComponent();
            InitializeDrawingSurface();
        }

        private void InitializeDrawingSurface()
        {
            drawingBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);
            drawingGraphics = Graphics.FromImage(drawingBitmap);
            drawingGraphics.Clear(Color.White); // Initialize the drawing surface with white background
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(drawingBitmap, Point.Empty);
        }

        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = e.Location;
            }
        }

        private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(drawingBitmap))
                {
                    g.DrawLine(Pens.Black, lastPoint, e.Location);
                }
                lastPoint = e.Location;
                drawingPanel.Invalidate(); // Redraw the panel to reflect the new drawing
            }
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }
    }
}
