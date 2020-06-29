using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using mindmapdraw.Controllers;
using mindmapdraw.Models;

namespace mindmapdraw.Views
{
    public class Shape : Box
    {
        public Pen pen;
        public Color color;
        public int shape;
        public TopicClass topic;
        public List<TopicClass> cT;
        public Shape()
        {
            
        }
        public Shape(Point cor, int width, int height, Color color, int shape)
        {
            topic = new TopicClass();
            this.Location = cor;
            this.shape = shape;
            this.Width = width;
            this.Height = height;
            this.color = color;
            this.textBox1.Text = "Nhap noi dung";
            this.BackgroundImage = new Bitmap(this.Width, this.Height);
            this.textBox1.BackColor = color;
            using (Graphics g = Graphics.FromImage(this.BackgroundImage))
            {
                Rectangle r = new Rectangle(1, 1, this.Width - 5, this.Height - 5);
                g.SmoothingMode = SmoothingMode.HighQuality;
                switch (shape)
                {
                    case 1:
                        g.DrawRectangle(new Pen(Color.Black, 3), r);
                        g.FillRectangle(new SolidBrush(this.color), r);
                        break;
                    case 2:
                        g.DrawEllipse(new Pen(Color.Black, 3), r);
                        g.FillEllipse(new SolidBrush(this.color), r);
                        int lr = (this.Width - (int)(this.Width / Math.Sqrt(2))) / 2 + 5;
                        int tb = (this.Height - (int)(this.Height / Math.Sqrt(2))) / 2 + 5;
                        this.Padding = new Padding(lr, tb, lr, tb);
                        break;
                    case 3:
                        g.DrawRoundedRectangle(new Pen(Color.Black, 3), r, r.Width / 5);
                        g.FillRoundedRectangle(new SolidBrush(this.color), r, r.Height / 5);
                        this.Padding = new Padding(r.Height / 5);
                        break;
                    default:
                        break;
                }
            }
            this.Refresh();

            topic.Color = ColorTranslator.ToHtml(this.color);
            topic.ID = TopicControllers.GetIDfromDB();
            topic.X = this.Location.X;
            topic.Y = this.Location.Y;
            topic.Height = this.Height;
            topic.Width = this.Width;
            topic.Text = this.textBox1.Text;
            topic.shape = this.shape;
            TopicControllers.AddTopic(this.topic);
            this.textBox1.TextChanged += textchanged;
        }
        private void textchanged(object sender, EventArgs e)
        {
            topic.Text = this.textBox1.Text.Trim();
            TopicControllers.UpdateTopic(topic);
        }
        public Shape(TopicClass t)
        {
            this.Location = new Point(t.X, t.Y);
            this.color = ColorTranslator.FromHtml(t.Color);
            this.Size = new Size(t.Width, t.Height);
            this.textBox1.Text = t.Text;
            this.shape = t.shape;
            this.BackgroundImage = new Bitmap(this.Width, this.Height);
            this.textBox1.BackColor = color;
            this.cT = t.listTopics.ToList();
            this.topic = TopicControllers.GetTopic(t.ID);
            this.textBox1.TextChanged += textchanged;
            using (Graphics g = Graphics.FromImage(this.BackgroundImage))
            {
                Rectangle r = new Rectangle(1, 1, this.Width - 6, this.Height - 6);
                g.SmoothingMode = SmoothingMode.HighQuality;
                switch (shape)
                {
                    case 1:
                        g.DrawRectangle(new Pen(Color.Black, 3), r);
                        g.FillRectangle(new SolidBrush(this.color), r);
                        break;
                    case 2:
                        g.DrawEllipse(new Pen(Color.Black, 3), r);
                        g.FillEllipse(new SolidBrush(this.color), r);
                        int lr = (this.Width - (int)(this.Width / Math.Sqrt(2))) / 2 + 5;
                        int tb = (this.Height - (int)(this.Height / Math.Sqrt(2))) / 2 + 5;
                        this.Padding = new Padding(lr, tb, lr, tb);
                        break;
                    case 3:
                        g.DrawRoundedRectangle(new Pen(Color.Black, 3), r, r.Width / 5);
                        g.FillRoundedRectangle(new SolidBrush(this.color), r, r.Height / 5);
                        break;
                    default:
                        break;
                }
            }
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (((Draw)this.Parent).mode == 2)
            {
                ((Draw)this.Parent).current = this.topic;
                if (((Draw)this.Parent).first is null ||
                    ((Draw)this.Parent).first == this.topic)
                    ((Draw)this.Parent).first = this.topic;
                else
                {
                    ((Draw)this.Parent).second = this.topic;
                    ((Draw)this.Parent).fish(((Draw)this.Parent).first, this.topic);

                    this.topic.listTopics.Add(((Draw)this.Parent).first);
                    TopicControllers.UpdateTopic(this.topic);

                    ((Draw)this.Parent).second = null;
                    ((Draw)this.Parent).first = null;
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Delete)
            {
                this.Dispose();
                TopicControllers.RemoveTask(this.topic.ID);
            }
        }

        public Bitmap save()
        {

            Bitmap save = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(save, this.ClientRectangle);
            Rectangle r = new Rectangle(textBox1.Location.X + 1, textBox1.Location.Y + 1, textBox1.Width - 3, textBox1.Height - 3);
            textBox1.DrawToBitmap(save, r);
            this.Invalidate();
            return save;
        }
    }
}
