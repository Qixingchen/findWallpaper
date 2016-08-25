using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace 获取壁纸
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.getFolder = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.CopyToFolder = new System.Windows.Forms.Button();
            this.Copy = new System.Windows.Forms.Button();
            this.doneCounts = new System.Windows.Forms.TextBox();
            this.AllCounts = new System.Windows.Forms.TextBox();
            this.copyCounts = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(365, 21);
            this.textBox1.TabIndex = 0;
            // 
            // getFolder
            // 
            this.getFolder.Location = new System.Drawing.Point(395, 25);
            this.getFolder.Name = "getFolder";
            this.getFolder.Size = new System.Drawing.Size(92, 23);
            this.getFolder.TabIndex = 1;
            this.getFolder.Text = "获取文件夹";
            this.getFolder.UseVisualStyleBackColor = true;
            this.getFolder.Click += new System.EventHandler(this.getFolder_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(24, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(365, 21);
            this.textBox2.TabIndex = 2;
            // 
            // CopyToFolder
            // 
            this.CopyToFolder.Location = new System.Drawing.Point(395, 100);
            this.CopyToFolder.Name = "CopyToFolder";
            this.CopyToFolder.Size = new System.Drawing.Size(92, 23);
            this.CopyToFolder.TabIndex = 3;
            this.CopyToFolder.Text = "复制到文件夹";
            this.CopyToFolder.UseVisualStyleBackColor = true;
            this.CopyToFolder.Click += new System.EventHandler(this.CopyToFolder_Click);
            // 
            // Copy
            // 
            this.Copy.Location = new System.Drawing.Point(335, 253);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(152, 23);
            this.Copy.TabIndex = 4;
            this.Copy.Text = "复制所有背景";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // doneCounts
            // 
            this.doneCounts.Location = new System.Drawing.Point(82, 186);
            this.doneCounts.Name = "doneCounts";
            this.doneCounts.Size = new System.Drawing.Size(100, 21);
            this.doneCounts.TabIndex = 5;
            // 
            // AllCounts
            // 
            this.AllCounts.Location = new System.Drawing.Point(82, 219);
            this.AllCounts.Name = "AllCounts";
            this.AllCounts.Size = new System.Drawing.Size(100, 21);
            this.AllCounts.TabIndex = 6;
            // 
            // copyCounts
            // 
            this.copyCounts.Location = new System.Drawing.Point(82, 153);
            this.copyCounts.Name = "copyCounts";
            this.copyCounts.Size = new System.Drawing.Size(100, 21);
            this.copyCounts.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "已完成";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "全部";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "已复制";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(499, 288);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.copyCounts);
            this.Controls.Add(this.AllCounts);
            this.Controls.Add(this.doneCounts);
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.CopyToFolder);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.getFolder);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button getFolder;
        private TextBox textBox2;
        private Button CopyToFolder;
        private Button Copy;
        private TextBox doneCounts;
        private TextBox AllCounts;
        private TextBox copyCounts;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}

