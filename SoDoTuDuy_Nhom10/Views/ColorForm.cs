using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mindmapdraw
{
    public partial class ColorPick : UserControl
    {
        public Color Color { get; set; }
        public static ColorPick _instance;
        Bitmap Frame;
        public static ColorPick Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ColorPick();
                return _instance;
            }
        }
        public ColorPick()
        {
            InitializeComponent();

            //pictureBox1.MouseHover += mouseHover;
            //pictureBox2.MouseHover += mouseHover;
            //pictureBox3.MouseHover += mouseHover;
            //pictureBox4.MouseHover += mouseHover;
            pictureBox1.MouseEnter += mouseHover;
            pictureBox2.MouseEnter += mouseHover;
            pictureBox3.MouseEnter += mouseHover;
            pictureBox4.MouseEnter += mouseHover;
            pictureBox5.MouseEnter += mouseHover;
            pictureBox6.MouseEnter += mouseHover;
            pictureBox7.MouseEnter += mouseHover;
            pictureBox8.MouseEnter += mouseHover;
            pictureBox1.MouseLeave += mouseLeave;
            pictureBox2.MouseLeave += mouseLeave;
            pictureBox3.MouseLeave += mouseLeave;
            pictureBox4.MouseLeave += mouseLeave;
            pictureBox5.MouseLeave += mouseLeave;
            pictureBox6.MouseLeave += mouseLeave;
            pictureBox7.MouseLeave += mouseLeave;
            pictureBox8.MouseLeave += mouseLeave;
            Frame = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(Frame))
            {
                using (Pen p = new Pen(Color.Black, 3))
                {
                    g.DrawRectangle(p, 1, 1, 32, 32);
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            //ColorDialog cd = new ColorDialog();
            //if (cd.ShowDialog() == DialogResult.OK)
            //{
            //    button9.BackColor = cd.Color;
            //    this.Color = cd.Color;
            //}
            //this.Visible = false;
        }
        private void mouseHover(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                pb.Image = Frame;
            }
        }
        private void mouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
                pb.Image = null;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Color = pictureBox1.BackColor;
            this.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Color = pictureBox2.BackColor;
            this.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Color = pictureBox4.BackColor;
            this.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Color = pictureBox3.BackColor;
            this.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Color = pictureBox6.BackColor;
            this.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Color = pictureBox5.BackColor;
            this.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Color = pictureBox8.BackColor;
            this.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Color = pictureBox7.BackColor;
            this.Visible = false;
        }
    }
}
