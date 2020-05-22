namespace HHGestureUnlocking
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlPassWord = new System.Windows.Forms.Panel();
            this.lblBack = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlPassWord
            // 
            this.pnlPassWord.BackColor = System.Drawing.Color.White;
            this.pnlPassWord.Location = new System.Drawing.Point(1, 128);
            this.pnlPassWord.Name = "pnlPassWord";
            this.pnlPassWord.Size = new System.Drawing.Size(333, 339);
            this.pnlPassWord.TabIndex = 26;
            this.pnlPassWord.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawMouseDown);
            this.pnlPassWord.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawMouseMove);
            this.pnlPassWord.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawMouseUp);
            // 
            // lblBack
            // 
            this.lblBack.BackColor = System.Drawing.Color.Transparent;
            this.lblBack.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBack.Image = global::HHGestureUnlocking.Properties.Resources.btnBack;
            this.lblBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBack.Location = new System.Drawing.Point(-1, 9);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(73, 31);
            this.lblBack.TabIndex = 29;
            this.lblBack.Text = "   返回";
            this.lblBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBack.Click += new System.EventHandler(this.lblBack_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.Image = global::HHGestureUnlocking.Properties.Resources.lockIcon;
            this.lblMsg.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMsg.Location = new System.Drawing.Point(12, 50);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(311, 61);
            this.lblMsg.TabIndex = 27;
            this.lblMsg.Text = "请输入解锁密码";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(335, 465);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.pnlPassWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HHLockForm";
            this.Load += new System.EventHandler(this.HHLockForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlPassWord;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblBack;
    }
}