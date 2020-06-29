using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mindmapdraw.Views
{
    public partial class Box : UserControl
    {
        protected RichTextBox textBox1;
        bool mouseDown;
        Point begin;
        public Box()
        {
            InitializeComponent();
            this.textBox1 = new RichTextBox();
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            textBox1.Font = new Font("Arial", 14);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Multiline = true;
            textBox1.SelectAll();
            textBox1.SelectionAlignment= HorizontalAlignment.Center;
            textBox1.DeselectAll();
            textBox1.Dock = DockStyle.Fill;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            textBox1.KeyDown += tb_OnKeyDown;
            textBox1.MouseDown += tb_OnMouseDown;
            textBox1.MouseMove += tb_OnMouseMove;
            textBox1.MouseUp += tb_OnMouseUp;
            textBox1.DoubleClick += tb_doubleClick;
            textBox1.BackColor = Color.White;
            this.Controls.Add(textBox1);
            mouseDown = false;
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            textBox1.Enabled = true;
            textBox1.ReadOnly = false;
        }
        private void tb_doubleClick(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
        }
        private void tb_OnKeyDown(object sender, KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if(e.KeyCode == Keys.Enter)
            {
                textBox1.ReadOnly = true;
                textBox1.BackColor = this.BackColor;
                textBox1.Enabled = false;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mouseDown = true;
            begin = e.Location;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.mouseDown = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (mouseDown && textBox1.ReadOnly == true)
            {
                this.Left += e.X - begin.X;
                this.Top += e.Y - begin.Y;
                this.Invalidate();
            }
        }
        private void tb_OnMouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mouseDown = true;
            begin = e.Location;
        }
        private void tb_OnMouseUp(object sender, MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.mouseDown = false;
        }
        private void tb_OnMouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (mouseDown && textBox1.ReadOnly == true)
            {
                this.Left += e.X - begin.X;
                this.Top += e.Y - begin.Y;
                this.Invalidate();
            }
        }
    }
}
