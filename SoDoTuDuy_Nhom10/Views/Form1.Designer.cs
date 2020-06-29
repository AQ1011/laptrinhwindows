namespace mindmapdraw.Views
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.draw1 = new mindmapdraw.Views.Draw();
            this.label1 = new System.Windows.Forms.Label();
            this.colorPicker = new System.Windows.Forms.PictureBox();
            this.undo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnNoi = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnViet = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnvuongla = new System.Windows.Forms.Button();
            this.btnvuong = new System.Windows.Forms.Button();
            this.btnHtron = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panelHinh = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.draw1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.draw1);
            this.panel1.Location = new System.Drawing.Point(164, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 520);
            this.panel1.TabIndex = 0;
            // 
            // draw1
            // 
            this.draw1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.draw1.Image = ((System.Drawing.Image)(resources.GetObject("draw1.Image")));
            this.draw1.Location = new System.Drawing.Point(0, 0);
            this.draw1.Name = "draw1";
            this.draw1.Size = new System.Drawing.Size(1019, 520);
            this.draw1.TabIndex = 6;
            this.draw1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Màu";
            // 
            // colorPicker
            // 
            this.colorPicker.BackColor = System.Drawing.Color.White;
            this.colorPicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPicker.Location = new System.Drawing.Point(164, 10);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(67, 44);
            this.colorPicker.TabIndex = 14;
            this.colorPicker.TabStop = false;
            this.colorPicker.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // undo
            // 
            this.undo.BackColor = System.Drawing.Color.White;
            this.undo.Image = ((System.Drawing.Image)(resources.GetObject("undo.Image")));
            this.undo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.undo.Location = new System.Drawing.Point(5, 10);
            this.undo.Name = "undo";
            this.undo.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.undo.Size = new System.Drawing.Size(140, 44);
            this.undo.TabIndex = 8;
            this.undo.Text = "Undo";
            this.undo.UseVisualStyleBackColor = false;
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.panel2.Controls.Add(this.btnHelp);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnOpen);
            this.panel2.Controls.Add(this.panelHinh);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 592);
            this.panel2.TabIndex = 1;
            // 
            // btnHelp
            // 
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(0, 577);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(2);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnHelp.Size = new System.Drawing.Size(164, 43);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.panel4.Controls.Add(this.btnNoi);
            this.panel4.Controls.Add(this.btnClear);
            this.panel4.Controls.Add(this.btnViet);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 448);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(164, 129);
            this.panel4.TabIndex = 5;
            // 
            // btnNoi
            // 
            this.btnNoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnNoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNoi.FlatAppearance.BorderSize = 0;
            this.btnNoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoi.ForeColor = System.Drawing.Color.White;
            this.btnNoi.Image = ((System.Drawing.Image)(resources.GetObject("btnNoi.Image")));
            this.btnNoi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNoi.Location = new System.Drawing.Point(0, 78);
            this.btnNoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnNoi.Name = "btnNoi";
            this.btnNoi.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnNoi.Size = new System.Drawing.Size(164, 39);
            this.btnNoi.TabIndex = 7;
            this.btnNoi.Text = "Connected";
            this.btnNoi.UseVisualStyleBackColor = false;
            this.btnNoi.Click += new System.EventHandler(this.btnNoi_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.Location = new System.Drawing.Point(0, 39);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnClear.Size = new System.Drawing.Size(164, 39);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnViet
            // 
            this.btnViet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnViet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViet.FlatAppearance.BorderSize = 0;
            this.btnViet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViet.ForeColor = System.Drawing.Color.White;
            this.btnViet.Image = ((System.Drawing.Image)(resources.GetObject("btnViet.Image")));
            this.btnViet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViet.Location = new System.Drawing.Point(0, 0);
            this.btnViet.Margin = new System.Windows.Forms.Padding(2);
            this.btnViet.Name = "btnViet";
            this.btnViet.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnViet.Size = new System.Drawing.Size(164, 39);
            this.btnViet.TabIndex = 4;
            this.btnViet.Text = "Viết";
            this.btnViet.UseVisualStyleBackColor = false;
            this.btnViet.Click += new System.EventHandler(this.btnViet_Click);
            // 
            // button11
            // 
            this.button11.Dock = System.Windows.Forms.DockStyle.Top;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Image = ((System.Drawing.Image)(resources.GetObject("button11.Image")));
            this.button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.Location = new System.Drawing.Point(0, 409);
            this.button11.Margin = new System.Windows.Forms.Padding(2);
            this.button11.Name = "button11";
            this.button11.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.button11.Size = new System.Drawing.Size(164, 39);
            this.button11.TabIndex = 4;
            this.button11.Text = "Edit";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.panel3.Controls.Add(this.btnvuongla);
            this.panel3.Controls.Add(this.btnvuong);
            this.panel3.Controls.Add(this.btnHtron);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 290);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(164, 119);
            this.panel3.TabIndex = 3;
            // 
            // btnvuongla
            // 
            this.btnvuongla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnvuongla.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnvuongla.FlatAppearance.BorderSize = 0;
            this.btnvuongla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvuongla.ForeColor = System.Drawing.Color.White;
            this.btnvuongla.Image = ((System.Drawing.Image)(resources.GetObject("btnvuongla.Image")));
            this.btnvuongla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnvuongla.Location = new System.Drawing.Point(0, 78);
            this.btnvuongla.Margin = new System.Windows.Forms.Padding(2);
            this.btnvuongla.Name = "btnvuongla";
            this.btnvuongla.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnvuongla.Size = new System.Drawing.Size(164, 38);
            this.btnvuongla.TabIndex = 5;
            this.btnvuongla.Text = "square";
            this.btnvuongla.UseVisualStyleBackColor = false;
            this.btnvuongla.Click += new System.EventHandler(this.btnvuongla_Click);
            // 
            // btnvuong
            // 
            this.btnvuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnvuong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnvuong.FlatAppearance.BorderSize = 0;
            this.btnvuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvuong.ForeColor = System.Drawing.Color.White;
            this.btnvuong.Image = ((System.Drawing.Image)(resources.GetObject("btnvuong.Image")));
            this.btnvuong.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnvuong.Location = new System.Drawing.Point(0, 39);
            this.btnvuong.Margin = new System.Windows.Forms.Padding(2);
            this.btnvuong.Name = "btnvuong";
            this.btnvuong.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnvuong.Size = new System.Drawing.Size(164, 39);
            this.btnvuong.TabIndex = 4;
            this.btnvuong.Text = "Hình vuông";
            this.btnvuong.UseVisualStyleBackColor = false;
            this.btnvuong.Click += new System.EventHandler(this.btnvuong_Click);
            // 
            // btnHtron
            // 
            this.btnHtron.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnHtron.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHtron.FlatAppearance.BorderSize = 0;
            this.btnHtron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHtron.ForeColor = System.Drawing.Color.White;
            this.btnHtron.Image = ((System.Drawing.Image)(resources.GetObject("btnHtron.Image")));
            this.btnHtron.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHtron.Location = new System.Drawing.Point(0, 0);
            this.btnHtron.Margin = new System.Windows.Forms.Padding(2);
            this.btnHtron.Name = "btnHtron";
            this.btnHtron.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnHtron.Size = new System.Drawing.Size(164, 39);
            this.btnHtron.TabIndex = 3;
            this.btnHtron.Text = "Hình tròn";
            this.btnHtron.UseVisualStyleBackColor = false;
            this.btnHtron.Click += new System.EventHandler(this.btnHtron_Click);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(0, 251);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.button7.Size = new System.Drawing.Size(164, 39);
            this.button7.TabIndex = 2;
            this.button7.Text = "Chọn hình";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(0, 207);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(164, 44);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Location = new System.Drawing.Point(0, 164);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnOpen.Size = new System.Drawing.Size(164, 43);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // panelHinh
            // 
            this.panelHinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelHinh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHinh.Location = new System.Drawing.Point(0, 0);
            this.panelHinh.Margin = new System.Windows.Forms.Padding(2);
            this.panelHinh.Name = "panelHinh";
            this.panelHinh.Size = new System.Drawing.Size(164, 164);
            this.panelHinh.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.panel5.Controls.Add(this.colorPicker);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.undo);
            this.panel5.Location = new System.Drawing.Point(166, 2);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1017, 72);
            this.panel5.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 598);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 599);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.draw1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Draw draw1;
        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.PictureBox colorPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel panelHinh;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnvuongla;
        private System.Windows.Forms.Button btnvuong;
        private System.Windows.Forms.Button btnHtron;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnViet;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnNoi;
    }
}

