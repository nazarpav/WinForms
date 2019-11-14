using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11._11._2019
{
    public abstract class baseF
    {
        public readonly DrawableType drawableType;
        public Point point { get; set; }
        public int thickness { get; set; }
        public Color colorF { get; set; }
        public Color colorThickness { get; set; }
        public virtual void Draw(Graphics g)
        {
        }
    }
    class PointF: baseF
    {
        public PointF(Point point,int thickness)
        {
            this.point = point;
            this.thickness = thickness;
            this.colorF = Color.Black;
        }
        public PointF(Point point, int thickness,Color colorF)
        {
            this.point = point;
            this.colorF = colorF;
            this.colorThickness = Color.Transparent;
           this.thickness = thickness;
        }
        public PointF(Point point, int thickness, Color colorF,Color colorThickness)
        {
            this.colorThickness = colorThickness;
            this.point = point;
            this.colorF = colorF;
            this.thickness = thickness;
        }
        public PointF(Point point,Color colorThickness, int thickness)
        {
            this.colorThickness = colorThickness;
            this.point = point;
            this.colorF = Color.Transparent;
            this.thickness = thickness;
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Black, point.X, point.Y, thickness, thickness);
        }
    }
    class RectangleF : baseF
    {
        Rectangle rect;
        public RectangleF(Rectangle rect, int thickness)
        {
            this.rect = rect;
            this.thickness = thickness;
            this.colorF = Color.Black;
            this.colorThickness = Color.Transparent;
        }
        public RectangleF(Rectangle rect, int thickness,Color colorF,Color colorThickness)
        {
            this.rect = rect;
            this.colorF = colorF;
            this.colorThickness = colorThickness;
            this.thickness = thickness;
        }
        public RectangleF(Rectangle rect, int thickness, Color colorF)
        {
            this.rect = rect;
            this.colorF = colorF;
            this.colorThickness = Color.Transparent;
            this.thickness = thickness;
        }
        public RectangleF(Rectangle rect, Color colorThickness, int thickness)
        {
            this.rect = rect;
            this.colorF = Color.Transparent;
            this.colorThickness = colorThickness;
            this.thickness = thickness;
        }
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(colorThickness, thickness), rect);
            g.FillRectangle(new SolidBrush(colorF), rect);
        }
    }
    class EllipseF : baseF
    {
        Rectangle rect;
        public EllipseF(Rectangle rect, int thickness)
        {
            this.rect = rect;
            this.thickness = thickness;
            this.colorF = Color.Black;
            this.colorThickness = Color.Transparent;
        }
        public EllipseF(Rectangle rect, int thickness, Color colorF, Color colorThickness)
        {
            this.rect = rect;
            this.colorF = colorF;
            this.colorThickness = colorThickness;
            this.thickness = thickness;
        }
        public EllipseF(Rectangle rect, int thickness, Color colorF)
        {
            this.rect = rect;
            this.colorF = colorF;
            this.colorThickness = Color.Transparent;
            this.thickness = thickness;
        }
        public EllipseF(Rectangle rect, Color colorThickness, int thickness)
        {
            this.rect = rect;
            this.colorF = Color.Transparent;
            this.colorThickness = colorThickness;
            this.thickness = thickness;
        }
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(colorThickness, thickness), rect);
            g.FillEllipse(new SolidBrush(colorF), rect);
        }
    }
}
