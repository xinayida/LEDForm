namespace LEDForm
{
    partial class ScreenShooter
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.StartBtn = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.StopBtn = new System.Windows.Forms.Button();
            this.OneShot = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxW = new System.Windows.Forms.TextBox();
            this.textBoxH = new System.Windows.Forms.TextBox();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.textBoxIPFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxColumn = new System.Windows.Forms.TextBox();
            this.textBoxRow = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxGamma = new System.Windows.Forms.CheckBox();
            this.textBoxGamma = new System.Windows.Forms.TextBox();
            this.textBoxFPS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(612, 588);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(196, 48);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(832, 588);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(176, 48);
            this.StopBtn.TabIndex = 2;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // OneShot
            // 
            this.OneShot.Location = new System.Drawing.Point(372, 588);
            this.OneShot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OneShot.Name = "OneShot";
            this.OneShot.Size = new System.Drawing.Size(202, 48);
            this.OneShot.TabIndex = 3;
            this.OneShot.Text = "One shot";
            this.OneShot.UseVisualStyleBackColor = true;
            this.OneShot.Click += new System.EventHandler(this.OneShot_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(568, 80);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 400);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "更新屏幕街区范围：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "w:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "h:";
            // 
            // textBoxW
            // 
            this.textBoxW.Location = new System.Drawing.Point(116, 132);
            this.textBoxW.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxW.Name = "textBoxW";
            this.textBoxW.Size = new System.Drawing.Size(92, 35);
            this.textBoxW.TabIndex = 9;
            this.textBoxW.Text = "128";
            // 
            // textBoxH
            // 
            this.textBoxH.Location = new System.Drawing.Point(316, 132);
            this.textBoxH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxH.Name = "textBoxH";
            this.textBoxH.Size = new System.Drawing.Size(92, 35);
            this.textBoxH.TabIndex = 10;
            this.textBoxH.Text = "64";
            // 
            // textBoxIPFrom
            // 
            this.textBoxIPFrom.Location = new System.Drawing.Point(188, 244);
            this.textBoxIPFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxIPFrom.Name = "textBoxIPFrom";
            this.textBoxIPFrom.Size = new System.Drawing.Size(160, 35);
            this.textBoxIPFrom.TabIndex = 11;
            this.textBoxIPFrom.Text = "192.168.90.2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 248);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "IP   from:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 190);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "row:";
            // 
            // textBoxColumn
            // 
            this.textBoxColumn.Location = new System.Drawing.Point(316, 190);
            this.textBoxColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxColumn.Name = "textBoxColumn";
            this.textBoxColumn.Size = new System.Drawing.Size(92, 35);
            this.textBoxColumn.TabIndex = 16;
            this.textBoxColumn.Text = "1";
            // 
            // textBoxRow
            // 
            this.textBoxRow.Location = new System.Drawing.Point(116, 190);
            this.textBoxRow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRow.Name = "textBoxRow";
            this.textBoxRow.Size = new System.Drawing.Size(92, 35);
            this.textBoxRow.TabIndex = 17;
            this.textBoxRow.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 192);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 24);
            this.label7.TabIndex = 18;
            this.label7.Text = "column:";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(116, 468);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(216, 56);
            this.buttonUpdate.TabIndex = 19;
            this.buttonUpdate.Text = "Update Params";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(188, 298);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(76, 35);
            this.textBoxPort.TabIndex = 20;
            this.textBoxPort.Text = "7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(96, 300);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 24);
            this.label8.TabIndex = 21;
            this.label8.Text = "port:";
            // 
            // checkBoxGamma
            // 
            this.checkBoxGamma.AutoSize = true;
            this.checkBoxGamma.Checked = true;
            this.checkBoxGamma.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGamma.Location = new System.Drawing.Point(56, 356);
            this.checkBoxGamma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxGamma.Name = "checkBoxGamma";
            this.checkBoxGamma.Size = new System.Drawing.Size(114, 28);
            this.checkBoxGamma.TabIndex = 22;
            this.checkBoxGamma.Text = "gamma:";
            this.checkBoxGamma.UseVisualStyleBackColor = true;
            this.checkBoxGamma.CheckedChanged += new System.EventHandler(this.checkBoxGamma_CheckedChanged);
            // 
            // textBoxGamma
            // 
            this.textBoxGamma.Location = new System.Drawing.Point(188, 348);
            this.textBoxGamma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGamma.Name = "textBoxGamma";
            this.textBoxGamma.Size = new System.Drawing.Size(76, 35);
            this.textBoxGamma.TabIndex = 23;
            this.textBoxGamma.Text = "2.5";
            // 
            // textBoxFPS
            // 
            this.textBoxFPS.Location = new System.Drawing.Point(188, 404);
            this.textBoxFPS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFPS.Name = "textBoxFPS";
            this.textBoxFPS.Size = new System.Drawing.Size(76, 35);
            this.textBoxFPS.TabIndex = 24;
            this.textBoxFPS.Text = "30";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 408);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 24);
            this.label5.TabIndex = 25;
            this.label5.Text = "FPS:";
            // 
            // ScreenShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 666);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxFPS);
            this.Controls.Add(this.textBoxGamma);
            this.Controls.Add(this.checkBoxGamma);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxRow);
            this.Controls.Add(this.textBoxColumn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxIPFrom);
            this.Controls.Add(this.textBoxH);
            this.Controls.Add(this.textBoxW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.OneShot);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ScreenShooter";
            this.Text = "LED Screen Shooter";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button OneShot;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox textBoxH;
        private System.Windows.Forms.TextBox textBoxW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxRow;
        private System.Windows.Forms.TextBox textBoxColumn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxIPFrom;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxGamma;
        private System.Windows.Forms.CheckBox checkBoxGamma;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFPS;
    }
}

