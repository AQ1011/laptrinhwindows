using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using mindmapdraw.Models;
using mindmapdraw.Controllers;

namespace mindmapdraw.Views
{
    public class Draw : PictureBox
    {
        public int mode;
        public TopicClass first;
        public TopicClass second;
        public TopicClass current;
        public Bitmap temp;
        public TextBox tb;
        public Stack<Shape> undo;
        public Stack<Shape> redo;
        public int shape;
        public MindMapClass mindmap;
        bool isMouseDown;
        Point begin;
        public Color color;
        public void fish(TopicClass first, TopicClass second)
        {
            if (second is null || first is null)
                return;
            Connect c = new Connect();
            this.Controls.Add(c);
            c.connect(first, second);
        }
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e); if (mode == 1)
            {
                Cursor = Cursors.Cross;
            }

        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.isMouseDown = true;
            begin = e.Location;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.isMouseDown = false;
            if (mode == 1)
            {
                int x, y, width, height;
                x = Math.Min(begin.X, e.X);
                y = Math.Min(begin.Y, e.Y);
                width = Math.Max(x, Math.Max(begin.X, e.X)) - x;
                height = Math.Max(y, Math.Max(begin.Y, e.Y)) - y;
                if (width < 20 || height < 20)
                    return;
                Shape s = new Shape(new Point(x, y), width, height, color, shape);
                this.Controls.Add(s);
                s.topic.mindMap = this.mindmap;
                TopicControllers.UpdateTopic(s.topic);
                using (Graphics g = Graphics.FromImage(this.Image))
                {
                    g.FillRectangle(Brushes.White, this.ClientRectangle);
                }
                this.Invalidate();
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(this.Image.Width < this.Width && this.Image.Height < this.Height)
                this.Image = new Bitmap(this.Width, this.Height);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isMouseDown && mode == 1)
            {
                if(this.Image == null)
                { 
                    this.Image = new Bitmap(this.Width, this.Height);
                }
                using (Graphics g = Graphics.FromImage(this.Image))
                {
                    Rectangle r;
                    int x, y, width, height;
                    x = Math.Min(begin.X, e.X);
                    y = Math.Min(begin.Y, e.Y);
                    width = Math.Max(x, Math.Max(begin.X, e.X)) - x;
                    height = Math.Max(y, Math.Max(begin.Y, e.Y)) - y;
                    r = new Rectangle(x,y,width,height);
                    g.FillRectangle(new SolidBrush(Color.White), this.ClientRectangle);
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    switch (shape)
                    {
                        case 1:
                            g.DrawRectangle(new Pen(Color.Black, 3), r);
                            break;
                        case 2:
                            RectangleF rf = r;
                            g.DrawEllipse(new Pen(Color.Black, 3), rf);
                            break;
                        case 3:
                            g.DrawRoundedRectangle(new Pen(Color.Black,3),r,height/5);
                            break;
                        default:
                            break;
                    }
                    this.Invalidate();
                }
            }
        }

        public void save()
        {
            if(mindmap == null)
            {
                mindmap = new MindMapClass();
                mindmap.ID = MindMapControllers.GetIDfromDB();
            }
            mindmap.listTopics.Clear();
            if(this.Image == null)
            { 
                this.Image = new Bitmap(this.Width, this.Height);
                this.BackColor = Color.White;
            }
            try
            {
                using (Graphics g = Graphics.FromImage(this.Image))
                {
                    g.FillRectangle(Brushes.White, this.ClientRectangle);
                    this.BackColor = Color.White;
                    foreach (Control c in this.Controls)
                    {
                        if (c == this.tb)
                            continue;
                        if (c is Connect)
                        {
                            g.DrawBezier(((Connect)c).p, ((Connect)c).p1, ((Connect)c).p2, ((Connect)c).p3, ((Connect)c).p4);
                            continue;
                        }
                    }
                    foreach (Control c in this.Controls)
                    {
                        if (c is Shape)
                        {
                            g.DrawImage(((Shape)c).save(), c.Location);
                            mindmap.listTopics.Add(((Shape)c).topic);
                        }
                    }
                }
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.FileName = "Images|*.png; *.bmp";
                    ImageFormat format = ImageFormat.Png;
                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string ext = System.IO.Path.GetExtension(sfd.FileName);
                        switch (ext)
                        {
                            case ".jpg":
                                format = ImageFormat.Jpeg;
                                break;
                            case ".bmp":
                                format = ImageFormat.Bmp;
                                break;
                        }
                    }
                    this.Image.Save(sfd.FileName, format);
                    mindmap.name = sfd.FileName;
                    MindMapControllers.UpdateMindMap(mindmap);
                    using (Graphics g = Graphics.FromImage(this.Image))
                    {
                        g.FillRectangle(Brushes.White, this.ClientRectangle);
                    }
                }
            }
            catch { }
        }
        public void load(string ID)
        {
            this.Controls.Clear();
            {
                using (var _context = new DBTopicContext())
                {
                    if (ID == null)
                        return;
                    int idd = Int32.Parse(ID);
                    this.mindmap = MindMapControllers.LoadMindMap(idd);
                    foreach(var t in mindmap.listTopics)
                    {
                        var first = TopicControllers.GetTopic(t.ID);
                        foreach(var second in first.listTopics)
                        {
                            this.fish(first, second);
                        }
                    }
                    foreach (var t in mindmap.listTopics)
                    {
                        Shape s = new Shape(t);
                        this.Controls.Add(s);
                        s.BringToFront();
                    }
                }
            }
        }
        public void redrawConnection()
        {
            foreach (Control t in this.Controls)
            {
                if (t is Shape)
                {
                    var first = ((Shape)t).topic;
                    foreach (var second in first.listTopics)
                    {
                        this.fish(first, second);
                    }
                }
                else
                {
                    t.Dispose();
                }
            }
        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
        }
    }
}
