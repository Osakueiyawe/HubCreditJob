﻿namespace SalaryAdvanceNew
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Interval to check the database";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(179, 13);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    this.label1 = new System.Windows.Forms.Label();
        //    this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        //    this.label2 = new System.Windows.Forms.Label();
        //    this.btnCancel = new System.Windows.Forms.Button();
        //    this.tTimer = new System.Windows.Forms.Timer(this.components);
        //    this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
        //    this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        //    this.mStart = new System.Windows.Forms.ToolStripMenuItem();
        //    this.mEnd = new System.Windows.Forms.ToolStripMenuItem();
        //    this.mProperties = new System.Windows.Forms.ToolStripMenuItem();
        //    this.mExit = new System.Windows.Forms.ToolStripMenuItem();
        //    ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
        //    this.contextMenuStrip1.SuspendLayout();
        //    this.SuspendLayout();
        //    // 
        //    // label1
        //    // 
        //    this.label1.AutoSize = true;
        //    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //    this.label1.Location = new System.Drawing.Point(12, 29);
        //    this.label1.Name = "label1";
        //    this.label1.Size = new System.Drawing.Size(182, 13);
        //    this.label1.TabIndex = 2;
        //    this.label1.Text = "Interval to check the database";
        //    // 
        //    // numericUpDown1
        //    // 
        //    this.numericUpDown1.Location = new System.Drawing.Point(209, 29);
        //    this.numericUpDown1.Name = "numericUpDown1";
        //    this.numericUpDown1.Size = new System.Drawing.Size(53, 20);
        //    this.numericUpDown1.TabIndex = 12;
        //    this.numericUpDown1.Value = new decimal(new int[] {
        //    10,
        //    0,
        //    0,
        //    0});
        //    // 
        //    // label2
        //    // 
        //    this.label2.AutoSize = true;
        //    this.label2.Location = new System.Drawing.Point(268, 36);
        //    this.label2.Name = "label2";
        //    this.label2.Size = new System.Drawing.Size(34, 13);
        //    this.label2.TabIndex = 13;
        //    this.label2.Text = "(mins)";
        //    // 
        //    // btnCancel
        //    // 
        //    this.btnCancel.Location = new System.Drawing.Point(227, 108);
        //    this.btnCancel.Name = "btnCancel";
        //    this.btnCancel.Size = new System.Drawing.Size(75, 23);
        //    this.btnCancel.TabIndex = 14;
        //    this.btnCancel.Text = "Close";
        //    this.btnCancel.UseVisualStyleBackColor = true;
        //    this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        //    // 
        //    // tTimer
        //    // 
        //    this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        //    // 
        //    // notifyIcon1
        //    // 
        //    this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
        //    this.notifyIcon1.Text = "GTCollection Payment Engine";
        //    this.notifyIcon1.Visible = true;
        //    this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
        //    // 
        //    // contextMenuStrip1
        //    // 
        //    this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        //    this.mStart,
        //    this.mEnd,
        //    this.mProperties,
        //    this.mExit});
        //    this.contextMenuStrip1.Name = "contextMenuStrip1";
        //    this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
        //    this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
        //    // 
        //    // mStart
        //    // 
        //    this.mStart.Name = "mStart";
        //    this.mStart.Size = new System.Drawing.Size(127, 22);
        //    this.mStart.Text = "Start";
        //    this.mStart.Click += new System.EventHandler(this.mStart_Click);
        //    // 
        //    // mEnd
        //    // 
        //    this.mEnd.Name = "mEnd";
        //    this.mEnd.Size = new System.Drawing.Size(127, 22);
        //    this.mEnd.Text = "Stop";
        //    this.mEnd.Click += new System.EventHandler(this.mEnd_Click);
        //    // 
        //    // mProperties
        //    // 
        //    this.mProperties.Name = "mProperties";
        //    this.mProperties.Size = new System.Drawing.Size(127, 22);
        //    this.mProperties.Text = "Properties";
        //    this.mProperties.Click += new System.EventHandler(this.mProperties_Click);
        //    // 
        //    // mExit
        //    // 
        //    this.mExit.Name = "mExit";
        //    this.mExit.Size = new System.Drawing.Size(127, 22);
        //    this.mExit.Text = "Exit";
        //    this.mExit.Click += new System.EventHandler(this.mExit_Click);
        //    // 
        //    // frmForm1
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(326, 172);
        //    this.ControlBox = false;
        //    this.Controls.Add(this.btnCancel);
        //    this.Controls.Add(this.label2);
        //    this.Controls.Add(this.numericUpDown1);
        //    this.Controls.Add(this.label1);
        //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        //    this.MaximizeBox = false;
        //    this.MinimizeBox = false;
        //    this.Name = "frmForm1";
        //    this.ShowInTaskbar = false;
        //    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        //    this.Text = "GTCollection Payment Engine";
        //    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        //    this.Load += new System.EventHandler(this.frmForm1_Load);
        //    ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
        //    this.contextMenuStrip1.ResumeLayout(false);
        //    this.ResumeLayout(false);
        //    this.PerformLayout();

        //}




        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
    }
}

