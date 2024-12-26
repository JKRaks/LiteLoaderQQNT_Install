namespace Liteloader
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            txtInstall = new TextBox();
            label1 = new Label();
            btnSetLocation = new Button();
            btnFrameUpdate = new Button();
            btnInjet = new Button();
            btnImport = new Button();
            ckbUseProxy = new CheckBox();
            txtQVersion = new TextBox();
            btnReset = new Button();
            SuspendLayout();
            // 
            // txtInstall
            // 
            txtInstall.Location = new Point(50, 12);
            txtInstall.Name = "txtInstall";
            txtInstall.Size = new Size(279, 23);
            txtInstall.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 0;
            label1.Text = "目录";
            // 
            // btnSetLocation
            // 
            btnSetLocation.Location = new Point(335, 12);
            btnSetLocation.Name = "btnSetLocation";
            btnSetLocation.Size = new Size(25, 23);
            btnSetLocation.TabIndex = 2;
            btnSetLocation.Text = "...";
            btnSetLocation.UseVisualStyleBackColor = true;
            btnSetLocation.Click += btnSetLocation_Click;
            // 
            // btnFrameUpdate
            // 
            btnFrameUpdate.Location = new Point(12, 41);
            btnFrameUpdate.Name = "btnFrameUpdate";
            btnFrameUpdate.Size = new Size(75, 23);
            btnFrameUpdate.TabIndex = 4;
            btnFrameUpdate.Text = "框架更新";
            btnFrameUpdate.UseVisualStyleBackColor = true;
            btnFrameUpdate.Click += btnFrameUpdate_Click;
            // 
            // btnInjet
            // 
            btnInjet.Location = new Point(93, 41);
            btnInjet.Name = "btnInjet";
            btnInjet.Size = new Size(75, 23);
            btnInjet.TabIndex = 5;
            btnInjet.Text = "注入框架";
            btnInjet.UseVisualStyleBackColor = true;
            btnInjet.Click += btnInjet_Click;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(335, 41);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(75, 23);
            btnImport.TabIndex = 8;
            btnImport.Text = "导入插件";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // ckbUseProxy
            // 
            ckbUseProxy.AutoSize = true;
            ckbUseProxy.Checked = true;
            ckbUseProxy.CheckState = CheckState.Checked;
            ckbUseProxy.Location = new Point(174, 43);
            ckbUseProxy.Name = "ckbUseProxy";
            ckbUseProxy.Size = new Size(59, 21);
            ckbUseProxy.TabIndex = 6;
            ckbUseProxy.Text = "Proxy";
            ckbUseProxy.UseVisualStyleBackColor = true;
            // 
            // txtQVersion
            // 
            txtQVersion.Location = new Point(239, 41);
            txtQVersion.Name = "txtQVersion";
            txtQVersion.Size = new Size(90, 23);
            txtQVersion.TabIndex = 7;
            // 
            // btnReset
            // 
            btnReset.ForeColor = Color.Red;
            btnReset.Location = new Point(366, 12);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(44, 23);
            btnReset.TabIndex = 3;
            btnReset.Text = "清理";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(422, 75);
            Controls.Add(btnReset);
            Controls.Add(txtQVersion);
            Controls.Add(ckbUseProxy);
            Controls.Add(btnImport);
            Controls.Add(btnInjet);
            Controls.Add(btnFrameUpdate);
            Controls.Add(btnSetLocation);
            Controls.Add(label1);
            Controls.Add(txtInstall);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            Text = "狠狠的安装喵";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInstall;
        private Label label1;
        private Button btnSetLocation;
        private Button btnFrameUpdate;
        private Button btnInjet;
        private Button btnImport;
        private CheckBox ckbUseProxy;
        private TextBox txtQVersion;
        private Button btnReset;
    }
}
