using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mathematics.Classes;
using System.Drawing.Drawing2D;
namespace Mathematics.Formes
{
    public partial class CurvesDrawer : Form
    {
        public bool first = false;
        public bool second = false;
        public bool third = false;
        public bool fourth = false;
        public bool fifth = false;
        public bool sixth = false;
        public int koef1 = 0;
        public int koef2 = 0;
        public int koef3 = 0;
        public int koef4 = 0;
        public CurvesDrawer()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;

            // Dont't resize when the font changes size.
            this.AutoScaleMode = AutoScaleMode.None;

            // Set the initial transformation.
            SetTransformation();
        }

        // The transformation.
        private Matrix transformation;
        private float xmax, ymax;

        // Set up a transformation to draw everything nicely.
        private void Form1_Resize(object sender, EventArgs e)
        {
            SetTransformation();
        }
        private void SetTransformation()
        {
            // Scale.
            xmax = 10;
            ymax = 10;
            float scale = Math.Min(
                this.ClientSize.Width / xmax / 2,
                this.ClientSize.Height / ymax / 2);

            xmax = this.ClientSize.Width / scale;
            ymax = this.ClientSize.Height / scale;

            transformation = new Matrix();
            transformation.Scale(scale, scale, MatrixOrder.Append);
            transformation.Translate(
                this.ClientSize.Width / 2,
                this.ClientSize.Height / 2,
                MatrixOrder.Append);
        }

        // The function.
        private double First(float x)
        {
            return -(Math.Sin(x));
        }
        private double Second(float x, float a)
        {
            return -(Math.Pow(x, a));
        }
        private double Third(float x)
        {
            return -(Math.Cos(x));
        }
        private double Fourth(float x, float a)
        {
            return -(Math.Pow(a, x));
        }
        private double Fifth(float x,float a,float b, float c,float d)
        {
            return -(a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d);
        }
        private double Sixth(float x, float a)
        {
            return -(Math.Cos(x - a));
        }
        // The most recent point clicked.
        private float X0 = 1, Y0 = 0;

        // Find a root starting at the clicked position.
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Convert the mouse's X coordinate into world coordinates.
            Matrix m = transformation.Clone();
            m.Invert();
            PointF[] pts = { new PointF(e.X, e.Y) };
            m.TransformPoints(pts);
            X0 = pts[0].X;
            Y0 = pts[0].Y;

            // Redraw.
            this.Invalidate();
        }

        // Draw the underlying graph.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (transformation == null) return;
            e.Graphics.Transform = transformation;
            DrawGraph(e.Graphics);
        }
        public Font MyFont = new Font("Arial", 0.6f, GraphicsUnit.World);
        public SolidBrush SolidBrush = new SolidBrush(Color.Red);
        private void DrawGraph(Graphics gr)
        {
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            gr.Clear(this.BackColor);

            // Make a font that isn't too huge.
            this.Font = new Font("Arial", 1, GraphicsUnit.World);

            // Draw the axes.
            using (Pen axis_pen = new Pen(Color.Blue, 0))
            {
                for (int x = (int)(-xmax); x <= xmax; x++)
                {
                    gr.DrawLine(axis_pen, x, -0.5f, x, 0.5f);
                    gr.DrawString(x.ToString(), MyFont, SolidBrush, x, 0);
                }
                for (int y = (int)(-ymax); y <= ymax; y++)
                {
                    gr.DrawLine(axis_pen, -0.5f, y, 0.5f, y);
                    gr.DrawString(y.ToString(), MyFont, SolidBrush, 0, y * -1);
                }
                gr.DrawLine(axis_pen, -xmax, 0, xmax, 0);
                gr.DrawLine(axis_pen, 0, -ymax, 0, ymax);
            }

            // Draw the curve.
            using (Pen curve_pen = new Pen(Color.Crimson, 0))
            {
                double y1 = 0;
                double y2 = 0;
                if (first)
                {
                    y1 = First(-10);
                    y2 = First(-10);
                }
                else if (second)
                {
                    y1 = Second(-10, koef1);
                    y2 = Second(-10, koef1);
                }
                else if (third)
                {
                    y1 = Third(-10);
                    y2 = Third(-10);
                }
                else if (fourth)
                {
                    y1 = Fourth(-10, koef1);
                    y2 = Fourth(-10, koef1);
                }
                else if (fifth)
                {
                    y1 = Fifth(-10, koef1,koef2,koef3,koef4);
                    y2 = Fifth(-10, koef1, koef2, koef3, koef4);
                }
                const float step_size = 0.1f;
                for (float x = -xmax/2 + step_size; x <= xmax/2; x += step_size)
                {
                    y1 = y2;
                    if (first)
                    {
                        y2 = First(x);
                    }
                    else if (second)
                    {
                        y2 = Second(x, koef1);
                    }
                    else if (third)
                    {
                        y2 = Third(x);
                    }
                    else if (fourth)
                    {
                        y2 = Fourth(x, koef1);
                    }
                    else if (fifth)
                    {
                        y2 = Fifth(x, koef1, koef2, koef3, koef4);
                    }
                    else if (sixth)
                    {
                        y2 = Sixth(x, koef1);
                    }
                    try
                    {
                        gr.DrawLine(curve_pen, x - step_size, (float)y1, x, (float)y2);
                    }
                    catch (Exception) {  }
                }
            }
        }
 
    }
}

