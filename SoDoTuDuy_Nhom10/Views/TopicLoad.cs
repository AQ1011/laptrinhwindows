using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mindmapdraw.Controllers;
using mindmapdraw.Models;
using System.Drawing;
using System.IO;

namespace mindmapdraw.Views
{
    public partial class TopicLoad : UserControl
    {
        public string ID;
        public TopicLoad(MindMapClass mm)
        {
            InitializeComponent();
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            try
            {
                this.pictureBox1.Image = Image.FromFile(mm.name);
            }
            catch 
            {
                this.pictureBox1.Image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(this.pictureBox1.Image))
                {
                    g.DrawString("Khong tim duoc hinh", new Font("Arial", 14), new SolidBrush(Color.Black), 10, 10);
                }
            }
            this.ID = mm.ID.ToString();
            this.label1.Text = Path.GetFileName(mm.name);
            this.pictureBox1.Click += picturebox_Click;
        }
        private void picturebox_Click(object sender, EventArgs e)
        {
            ((FormLoad)(this.Parent.Parent)).ID = this.ID;
        }
    }
}
