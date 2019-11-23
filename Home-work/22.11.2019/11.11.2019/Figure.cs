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
        public int thicknessLine { get; set; }
        public Color colorF { get; set; }
        public Color colorThickness { get; set; }
        public virtual void Draw(Graphics g)
        {
        }
    }
    class PointF: baseF
    {
        int thicknessWrap;
        public PointF(Point point,int thickness, int thicknessWrap)
        {
            this.point = point;
            this.thicknessWrap = thicknessWrap;
            this.thicknessLine = thickness;
            this.colorF = Color.Black;
        }
        public PointF(Point point, int thickness, int thicknessWrap, Color colorF)
        {
            this.point = point;
            this.colorF = colorF;
            this.colorThickness = Color.Transparent;
           this.thicknessLine = thickness;
            this.thicknessWrap = thicknessWrap;
        }
        public PointF(Point point, int thickness, int thicknessWrap, Color colorF,Color colorThickness)
        {
            this.colorThickness = colorThickness;
            this.point = point;
            this.colorF = colorF;
            this.thicknessLine = thickness;
            this.thicknessWrap = thicknessWrap;
        }
        public PointF(Point point,Color colorThickness, int thickness, int thicknessWrap)
        {
            this.colorThickness = colorThickness;
            this.point = point;
            this.colorF = Color.Transparent;
            this.thicknessLine = thickness;
            this.thicknessWrap = thicknessWrap;
        }
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(colorThickness, thicknessWrap), point.X, point.Y, thicknessLine, thicknessLine);
            g.FillEllipse(new SolidBrush(colorF), point.X-1, point.Y-1, thicknessLine+2, thicknessLine+2);
        }
    }
    class RectangleF : baseF
    {
        public Rectangle rect { get; set; }
        public RectangleF(Rectangle rect, int thickness)
        {
            this.rect = rect;
            this.thicknessLine = thickness;
            this.colorF = Color.Black;
            this.colorThickness = Color.Transparent;
        }
        public RectangleF(Rectangle rect, int thickness,Color colorF,Color colorThickness)
        {
            this.rect = rect;
            this.colorF = colorF;
            this.colorThickness = colorThickness;
            this.thicknessLine = thickness;
        }
        public RectangleF(Rectangle rect, int thickness, Color colorF)
        {
            this.rect = rect;
            this.colorF = colorF;
            this.colorThickness = Color.Transparent;
            this.thicknessLine = thickness;
        }
        public RectangleF(Rectangle rect, Color colorThickness, int thickness)
        {
            this.rect = rect;
            this.colorF = Color.Transparent;
            this.colorThickness = colorThickness;
            this.thicknessLine = thickness;
        }
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(colorThickness, thicknessLine), rect);
            g.FillRectangle(new SolidBrush(colorF), rect);
        }
    }
    class ImageRect : baseF
    {
        public Rectangle rect { get; set; }

        Image image;
        public ImageRect(Rectangle rect, Image image)
        {
            this.rect = rect;
            this.image = image;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(image, rect);
        }
    }
    class Line : baseF
    {
        Point p1;
        Point p2;
        int thicknessWrap;
        public Line(Point p1,Point p2, int thickness,int thicknessWrap)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.thicknessLine = thickness;
            this.thicknessWrap = thicknessWrap;
            this.colorF = Color.Black;
            this.colorThickness = Color.Transparent;
        }
        public Line(Point p1, Point p2, int thickness, int thicknessWrap, Color colorF, Color colorThickness)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.colorF = colorF;
            this.colorThickness = colorThickness;
            this.thicknessLine = thickness;
            this.thicknessWrap = thicknessWrap;
        }
        public Line(Point p1, Point p2, int thickness, int thicknessWrap, Color colorF)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.colorF = colorF;
            this.colorThickness = Color.Transparent;
            this.thicknessLine = thickness;
            this.thicknessWrap = thicknessWrap;
        }
        public Line(Point p1, Point p2, Color colorThickness, int thickness, int thicknessWrap)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.colorF = Color.Transparent;
            this.colorThickness = colorThickness;
            this.thicknessLine = thickness;
            this.thicknessWrap = thicknessWrap;
        }
        public override void Draw(Graphics g)
        {
            if(thicknessWrap>0)
            g.DrawLine(new Pen(colorThickness, thicknessWrap + thicknessLine),p1,p2);
            g.DrawLine(new Pen(colorF, thicknessLine),p1,p2);
        }
    }
    class EllipseF : baseF
    {
        public Rectangle rect { get; set; }

        public EllipseF(Rectangle rect, int thickness)
        {
            this.rect = rect;
            this.thicknessLine = thickness;
            this.colorF = Color.Black;
            this.colorThickness = Color.Transparent;
        }
        public EllipseF(Rectangle rect, int thickness, Color colorF, Color colorThickness)
        {
            this.rect = rect;
            this.colorF = colorF;
            this.colorThickness = colorThickness;
            this.thicknessLine = thickness;
        }
        public EllipseF(Rectangle rect, int thickness, Color colorF)
        {
            this.rect = rect;
            this.colorF = colorF;
            this.colorThickness = Color.Transparent;
            this.thicknessLine = thickness;
        }
        public EllipseF(Rectangle rect, Color colorThickness, int thickness)
        {
            this.rect = rect;
            this.colorF = Color.Transparent;
            this.colorThickness = colorThickness;
            this.thicknessLine = thickness;
        }
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(colorThickness, thicknessLine), rect);
            g.FillEllipse(new SolidBrush(colorF), rect);
        }
    }
}
