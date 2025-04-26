using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.Control
{
    internal class EllipsePictureBox : PictureBox
    {
        private int bordersize = 2;
        private Color bordercolor = Color.RoyalBlue;
        private Color bordercolor2 = Color.HotPink;
        private DashStyle borderlinestyle = DashStyle.Solid;
        private DashCap bordercapstyle = DashCap.Flat;
        private float gradientangle = 50F;
        public EllipsePictureBox()
        {
            this.Size = new Size(100, 100);
            this.SizeMode= PictureBoxSizeMode.StretchImage;
        }
        public int BorderSize
        {
            get { return bordersize; }
            set
            {
                bordersize = value;
                this.Invalidate();
            }
        }
        public Color Bordercolor
        {
            get { return bordercolor; }
            set
            {
                bordercolor = value;
                this.Invalidate();
            }
        }
        public Color Bordercolor2
        {
            get { return bordercolor2; }
            set
            {
                bordercolor2 = value;
                this.Invalidate();
            }
        }
        public DashStyle borderlineStyle
        {
            get { return borderlinestyle; }
            set
            {
                borderlinestyle = value;
                this.Invalidate();
            }
        }
        public DashCap borderCapStyle
        {
            get { return bordercapstyle; }
            set
            {
                bordercapstyle = value;
                this.Invalidate();
            }
        }
        public float GradientAngle
        {
            get { return gradientangle; }
            set
            {
                gradientangle = value;
                this.Invalidate();
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(this.Width,this.Height);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var graph = pe.Graphics;
            var rectcontoursmoouth=Rectangle.Inflate(this.ClientRectangle, -1, -1);
            var rectcontours = Rectangle.Inflate(rectcontoursmoouth, -bordersize, -bordersize);
            var smoothsize=bordersize>0?bordersize*3:1;
            using (var borderGcolor=new LinearGradientBrush(rectcontours,bordercolor,bordercolor2,gradientangle))
            using (var pathregion=new GraphicsPath())
            using (var pensmooth=new Pen(this.Parent.BackColor,smoothsize))
            using (var penBorder=new Pen(borderGcolor,bordersize))
            {
                penBorder.DashStyle = borderlinestyle;
                penBorder.DashCap = bordercapstyle;
                pathregion.AddEllipse(rectcontoursmoouth);
                this.Region = new Region(pathregion);
                graph.SmoothingMode=SmoothingMode.AntiAlias;
                graph.DrawEllipse(pensmooth, rectcontoursmoouth);
                if (bordersize>0)
                {
                    graph.DrawEllipse(penBorder, rectcontours);
                }
            }

        }
    }
}
