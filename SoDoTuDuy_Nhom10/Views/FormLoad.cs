using mindmapdraw.Controllers;
using mindmapdraw.Models;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace mindmapdraw.Views
{
    public partial class FormLoad : Form
    {
        public string ID;
        public FormLoad()
        {
            int temp = 0;
            InitializeComponent();
            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();
            foreach (MindMapClass mm in MindMapControllers.LoadAllMindMap())
            {
                if (mm.listTopics.Count == 0)
                    continue;
                TopicLoad b = new TopicLoad(mm);
                b.Click += piclick;
                this.tableLayoutPanel1.Controls.Add(b,0,temp++);
            }
        }
        private void piclick(object sender, EventArgs e)
        {
            TopicLoad p = sender as TopicLoad;
            this.ID = p.ID;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
