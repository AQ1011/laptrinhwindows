using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using mindmapdraw.Models;
using mindmapdraw.Controllers;

namespace mindmapdraw.Views
{
    class Connect : PictureBox
    {
        public Point p1, p2, p3, p4;
        bool movp2, movp3;
        bool show;
        bool mouseDown;
        GraphicsPath gra;
        TopicClass first;
        TopicClass second;
        public Pen p;
        public Connect()
        {

        }
        public void connect(TopicClass First, TopicClass Second)
        {
            first = First;
            second = Second;
            this.Image = new Bitmap(this.Parent.Width, this.Parent.Height);
            //Random rnd = new Random();
            //Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            p = new Pen(Color.Black, 5);
            this.Dock = DockStyle.Fill;
            gra = new GraphicsPath();
            if(this.Image == null)
            {
                this.Image = new Bitmap(this.Width, this.Height);

            }
            p1 = new Point(first.X + first.Width / 2,
                    first.Y + first.Height / 2);
            p4 = new Point(second.X + second.Width / 2,
                    second.Y + second.Height / 2);
            p2 = new Point((p1.X + p4.X) / 2, (p1.Y + p4.Y) / 2);
            p3 = new Point((p1.X + p4.X) / 2, (p1.Y + p4.Y) / 2);
            if (p1 == p4)
            {
                this.Dispose();
                return;
            }
            using (Graphics g = Graphics.FromImage(this.Image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawBezier(p, p1, p2, p3, p4);
            }
            first.listTopics.Add(second);
            second.listTopics.Add(first);
            TopicControllers.UpdateTopic(first);
            TopicControllers.UpdateTopic(second);
            gra.AddBezier(p1, p2, p3, p4);
            gra.Widen(p);
            this.Region = new Region(gra);
            this.show = false;
        }
        public void updateP(TopicClass t)
        {
            if (first == t)
            {
                p1 = new Point(t.X + t.Width / 2,
                    t.Y + t.Height / 2);
            }
            if (second == t)
            {
                p1 = new Point(t.X + t.Width / 2,
                    t.Y + t.Height / 2);
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if(e.KeyCode == Keys.Delete)
            {
                TopicControllers.DeleteTopicConnection(first, second);
                this.Dispose();
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mouseDown = false;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Location.X > p2.X - 10 && e.Location.X < p2.X + 10 && e.Location.Y > p2.Y - 10 && e.Location.Y < p2.Y + 10))
            {
                if (movp2)
                    movp2 = false;
                else
                {
                    movp2 = true;
                    this.mouseDown = true;
                }
                return;
            }
            else if ((e.Location.X > p3.X - 10 && e.Location.X < p3.X + 10 && e.Location.Y > p3.Y - 10 && e.Location.Y < p3.Y + 10))
            {
                if (movp3)
                    movp3 = false;
                else
                {
                    movp3 = true;
                    this.mouseDown = true;
                }
                return;
            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(this.Image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            base.OnClick(e);
            this.SendToBack();
            if (!show)
            {
                Rectangle r = new Rectangle(this.Location, this.Size);
                this.Region = new Region(r);
                g.DrawLine(p, p1, p2);
                g.DrawLine(p, p3, p4);
                g.DrawEllipse(p, p2.X - 5, p2.Y - 5, 10, 10);
                g.DrawEllipse(p, p3.X - 5, p3.Y - 5, 10, 10);
                g.Dispose();
                this.show = true;
            }
            else
            {
                if(!(e.Location.X > p2.X - 10 && e.Location.X < p2.X + 10 && e.Location.Y > p2.Y - 10 && e.Location.Y < p2.Y + 10) &&
                    !(e.Location.X > p3.X - 10 && e.Location.X < p3.X + 10 && e.Location.Y > p3.Y - 10 && e.Location.Y < p3.Y + 10))
                {
                    this.Region = new Region(gra);
                    movp2 = false;
                    movp3 = false;
                    this.show = false;
                    return;
                }
                else if((e.Location.X > p2.X - 10 && e.Location.X < p2.X + 10 && e.Location.Y > p2.Y - 10 && e.Location.Y < p2.Y + 10))
                {
                    if (movp2)
                        movp2 = false;
                    else
                    {
                        movp2 = true;
                        this.mouseDown = true;
                    }
                    return;
                }
                else if((e.Location.X > p3.X - 10 && e.Location.X < p3.X + 10 && e.Location.Y > p3.Y - 10 && e.Location.Y < p3.Y + 10))
                {
                    if (movp3)
                        movp3 = false;
                    else
                    {
                        movp3 = true;
                        this.mouseDown = true;
                    }
                    return;
                }
                if (!movp2 && !movp3)
                {
                    this.Region = new Region(gra);
                    this.show = false;
                }
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            try
            {
                using (Graphics g = Graphics.FromImage(this.Image))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawBezier(p, p1, p2, p3, p4);
                    this.show = false;
                    try
                    {
                        this.Region = new Region(gra);
                    }
                    catch { }
                }
            }
            catch { }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if ((e.Location.X > p2.X - 10 && e.Location.X < p2.X + 10 && e.Location.Y > p2.Y - 10 && e.Location.Y < p2.Y + 10))
            {
                this.Cursor = Cursors.Hand;
            }
            else if ((e.Location.X > p3.X - 10 && e.Location.X < p3.X + 10 && e.Location.Y > p3.Y - 10 && e.Location.Y < p3.Y + 10))
            {
                this.Cursor = Cursors.Hand;
            }
            if (mouseDown && movp2 || movp3)
            {
                if (movp2)
                    p2 = e.Location;
                if (movp3)
                    p3 = e.Location;
                using (Graphics g = Graphics.FromImage(this.Image))
                {
                    Rectangle ImageSize = new Rectangle(0, 0, this.Width, this.Height);
                    g.FillRectangle(Brushes.White, ImageSize);
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawBezier(p, p1, p2, p3, p4);
                    g.DrawLine(p, p1, p2);
                    g.DrawLine(p, p3, p4);
                    g.DrawEllipse(p, p2.X - 5, p2.Y - 5, 10, 10);
                    g.DrawEllipse(p, p3.X - 5, p3.Y - 5, 10, 10);
                    gra = new GraphicsPath();
                    gra.Reset();
                    gra.AddBezier(p1, p2, p3, p4);
                    gra.Widen(p);
                }
            }
            this.Invalidate();
        }
    }
}
