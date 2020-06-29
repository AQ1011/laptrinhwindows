using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace mindmapdraw
{
    public class Drawbox : PictureBox
    {
        bool isDrawing;
        public bool canDraw;
        public Pen pen;
        public Color color;
        int x1, x2, y1, y2;
        public float tbx, tby;
        Point lastPoint;
        //Point begin;
        int mouseX;
        int mouseY;
        public string text;
        Bitmap bmp;
        GraphicsPath gra = new GraphicsPath();
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            if(canDraw)
            {
                this.Cursor = Cursors.Cross;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (canDraw)
            {
                this.isDrawing = true;
                lastPoint = e.Location;
                //begin = lastPoint;
                x1 = e.X;
                y1 = e.Y;
                x2 = e.Y;
                y2 = e.Y;
            }
            else
            {
                this.isDrawing = true;
                mouseX = e.X;
                mouseY = e.Y;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.isDrawing = false;
            if (this.Image == null)
            {
                this.Dispose();
                return;
            }
            if (canDraw)
            {
                Random rnd = new Random();
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                this.BackColor = randomColor;
                this.color = randomColor;
                bmp = new Bitmap(this.Width,this.Height);
                this.Width = x2 - x1;
                this.Height = y2 - y1;
                this.Image = bmp;
                Matrix ma = new Matrix();
                ma.Translate(-x1,-y1);
                gra.Transform(ma);
                this.Region = new Region(gra);
                GraphicsPath temp = gra;
                temp.Widen(new Pen(Color.Black, 1));
                using (Graphics g = Graphics.FromImage(this.Image))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawPath(new Pen(Color.Black, 3), temp);
                }
                this.Location = new Point(x1,y1);
                this.text = "HELLO";
                if (this.Width < 10 && this.Height < 10)
                    this.Dispose();
                this.Cursor = Cursors.Hand;
            }
            this.canDraw = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (x1 > e.X)
                x1 = e.X;
            if (y1 > e.Y)
                y1 = e.Y;
            if (x2 < e.X)
                x2 = e.X;
            if (y2 < e.Y)
                y2 = e.Y;
            if (canDraw && isDrawing)
            {
                if (lastPoint != null)
                {
                    if (this.Image == null)
                    {
                        bmp = new Bitmap(this.Width, this.Height);
                        this.Image = bmp;
                        this.BackColor = color;
                    }
                    using (Graphics g = Graphics.FromImage(this.Image))
                    {
                        g.DrawLine(new Pen(Color.Black, 3), lastPoint, e.Location);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        gra.AddLine(lastPoint, e.Location);
                    }
                    this.Invalidate();
                    lastPoint = e.Location;
                }
            }
            else if(!canDraw && isDrawing && ((Draw)this.Parent).mode == 4)
            {
                this.Left += e.X - mouseX;
                this.Top += e.Y - mouseY;
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            SizeF textSize = pe.Graphics.MeasureString(text, new Font("Arial", 14));
            PointF locationToDraw = new PointF();
            locationToDraw.X = (this.Width / 2) - (textSize.Width / 2);
            locationToDraw.Y = (this.Height / 2) - (textSize.Height / 2);
            tbx = locationToDraw.X;
            tby = locationToDraw.Y;
            pe.Graphics.DrawString(text, new Font("Arial", 14), Brushes.Black, locationToDraw);

        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!canDraw)
            {
                if (e.Button == MouseButtons.Left)
                {
                    mouseX = e.X;
                    mouseY = e.Y;
                }
                if (this.Parent is Draw)
                {
                    //if (((Draw)this.Parent).mode == 2)
                    //{
                    //    if (((Draw)this.Parent).first is null ||
                    //        ((Draw)this.Parent).first == this)
                    //        ((Draw)this.Parent).first = this;
                    //    else
                    //    {
                    //        ((Draw)this.Parent).second = this;
                    //        ((Draw)this.Parent).fish(((Draw)this.Parent).first,
                    //        ((Draw)this.Parent).second);
                    //        ((Draw)this.Parent).second = null;
                    //        ((Draw)this.Parent).first = null;
                    //    }
                    //}
                }
                if(color == null)
                {
                    color = Color.White;
                }
                this.BackColor = color;
            }
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            //((Draw)this.Parent).current = this;
            ((Draw)this.Parent).tb.BackColor = SystemColors.Control;
            ((Draw)this.Parent).tb.Text = this.text;
            ((Draw)this.Parent).tb.MinimumSize = new Size(100, 30);
            ((Draw)this.Parent).tb.Visible = true;
            ((Draw)this.Parent).tb.MaximumSize = new Size(this.Width - 10, 9999);
            ((Draw)this.Parent).tb.Location = new Point((int)tbx + this.Location.X, (int)tby + this.Location.Y);
            this.text = "";
            this.Refresh();
            ((Draw)this.Parent).tb.Font = new Font("Arial", 14);
            ((Draw)this.Parent).tb.BringToFront();
        }
        public Bitmap save()
        {
            Bitmap bmp = new Bitmap(this.ClientSize.Width,
                               this.ClientSize.Height);
            gra.FillMode = FillMode.Winding;
            //this.DrawToBitmap(bmp, this.ClientRectangle);
            using (Graphics g = this.CreateGraphics())
            {
                Brush b = new SolidBrush(this.BackColor);
                g.FillPath(b, gra);
            }
                return bmp;
        }
    }
}
