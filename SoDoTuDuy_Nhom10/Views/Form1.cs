using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using mindmapdraw.Controllers;

namespace mindmapdraw.Views
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customxizeDesing();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.draw1.tb = new TextBox();
            this.draw1.mindmap = new Models.MindMapClass();
            this.draw1.Controls.Add(this.draw1.tb);
            this.draw1.tb.Multiline = true;
            this.draw1.tb.WordWrap = true;
            this.draw1.tb.Visible = false;
            this.draw1.BackColor = Color.White;
            draw1.tb.TextChanged += tb_TextChanged;
            draw1.mindmap.ID = MindMapControllers.GetIDfromDB();
            MindMapControllers.AddMindMap(draw1.mindmap);

        }
        private void tb_TextChanged(object sender, EventArgs e)
        {
            //Size size = TextRenderer.MeasureText(draw1.tb.Text, draw1.tb.Font);
            //draw1.tb.Width = size.Width;
            //draw1.tb.Height = size.Height;
            //draw1.tb.Location = new Point(draw1.current.Location.X + (int)draw1.current.tbx - draw1.tb.Width / 2,
            //    draw1.current.Location.Y + (int)draw1.current.tby - draw1.tb.Height /2); 
            //Size sz = new Size(this.draw1.tb.ClientSize.Width, int.MaxValue);
            //TextFormatFlags flags = TextFormatFlags.WordBreak;
            //int padding = 3;
            //int borders = this.draw1.tb.Height - this.draw1.tb.ClientSize.Height;
            //sz = TextRenderer.MeasureText(this.draw1.tb.Text, this.draw1.tb.Font, sz, flags);
            //int h = sz.Height + borders + padding;
            //if (this.draw1.tb.Top + h > this.ClientSize.Height - 10)
            //{
            //    h = this.ClientSize.Height - 10 - this.draw1.Top;
            //}
            //this.draw1.tb.Height = h;
        }
        private void tb_MultilineChange(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.draw1.save();
        }
        private void DrawTP_Click(object sender, EventArgs e)
        {
            /*this.draw1.mode = 1;
            this.draw1.shape = 1;*/
        }

        private void StopDraw_Click(object sender, EventArgs e)
        {
            this.draw1.mode = 2;
        }
        private void btn_viet_Click(object sender, EventArgs e)
        {
            this.draw1.mode = 3;
        }

        private void btn_keo_Click(object sender, EventArgs e)
        {
            this.draw1.mode = 4;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.draw1.Controls.Clear();
        }
        private void undo_Click(object sender, EventArgs e)
        {

        }
        private void colorPicker_Click(object sender, EventArgs e)
        {
            if (!this.Controls.Contains(ColorPick.Instance))
            {
                this.Controls.Add(ColorPick.Instance);
                ColorPick.Instance.Location = new Point(colorPicker.Location.X - 3, colorPicker.Location.Y + colorPicker.Height + 3);
                ColorPick.Instance.BringToFront();
                ColorPick.Instance.VisibleChanged += cf_visibleChanged;
            }
            else
            {
                ColorPick.Instance.Location = new Point(colorPicker.Location.X - 3, colorPicker.Location.Y + colorPicker.Height + 3);
                if (ColorPick.Instance.Visible)
                    ColorPick.Instance.Visible = false;
                else
                    ColorPick.Instance.Visible = true;
            }
        }
        private void cf_visibleChanged(object sender, EventArgs e)
        {
            colorPicker.BackColor = ColorPick.Instance.Color;
            draw1.color = ColorPick.Instance.Color;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void customxizeDesing()
        {
            panel3.Visible = false;
            panel4.Visible = false;
            

        }
        private void hideSubMenu()
        {
            if (panel3.Visible == true)
                panel3.Visible = false;
            if (panel4.Visible == true)
                panel4.Visible = false;

        }
        private void showsubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showsubmenu(panel3);
        }
          
       
        private void button11_Click(object sender, EventArgs e)
        {
            showsubmenu(panel4);
        }
       
        private void btnHtron_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            this.draw1.mode = 1;
            this.draw1.shape = 2;
        }

        private void btnvuong_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            this.draw1.mode = 1;
            this.draw1.shape = 1;
        }

        private void btnvuongla_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            this.draw1.mode = 1;
            this.draw1.shape = 3;
        }

        private void btnViet_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            this.draw1.mode = 3;
        }

        private void btnDichuyen_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            this.draw1.mode = 4;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            this.draw1.Controls.Clear();
            using (Graphics g = Graphics.FromImage(this.draw1.Image))
            {
                g.FillRectangle(Brushes.White, this.ClientRectangle);
            }
            this.draw1.mindmap = new Models.MindMapClass();
            this.draw1.mindmap.ID = MindMapControllers.GetIDfromDB();
            MindMapControllers.AddMindMap(draw1.mindmap);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.draw1.save();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //this.draw1.load(textBox1.Text);
            FormLoad fl = new FormLoad();
            if(fl.ShowDialog() == DialogResult.OK)
            {
                this.draw1.load(fl.ID);
            }
        }
        private void btnNoi_Click(object sender, EventArgs e)
        {
            this.draw1.mode = 2;
        }
    }
}

