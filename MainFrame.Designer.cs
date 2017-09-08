namespace WFH
{
    partial class MainFrame
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkBlockAllInbound = new System.Windows.Forms.CheckBox();
            this.chkBlockOutbound = new System.Windows.Forms.CheckBox();
            this.btnHarden = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.chkExclude = new System.Windows.Forms.CheckBox();
            this.lvExclude = new System.Windows.Forms.ListView();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnDir = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.chkWhiteList = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkBlockAllInbound
            // 
            this.chkBlockAllInbound.AutoSize = true;
            this.chkBlockAllInbound.Checked = true;
            this.chkBlockAllInbound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBlockAllInbound.Location = new System.Drawing.Point(12, 201);
            this.chkBlockAllInbound.Name = "chkBlockAllInbound";
            this.chkBlockAllInbound.Size = new System.Drawing.Size(161, 16);
            this.chkBlockAllInbound.TabIndex = 0;
            this.chkBlockAllInbound.Text = "Block All Inbound Traffic";
            this.chkBlockAllInbound.UseVisualStyleBackColor = true;
            // 
            // chkBlockOutbound
            // 
            this.chkBlockOutbound.AutoSize = true;
            this.chkBlockOutbound.Checked = true;
            this.chkBlockOutbound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBlockOutbound.Location = new System.Drawing.Point(179, 201);
            this.chkBlockOutbound.Name = "chkBlockOutbound";
            this.chkBlockOutbound.Size = new System.Drawing.Size(152, 16);
            this.chkBlockOutbound.TabIndex = 1;
            this.chkBlockOutbound.Text = "Block Outbound Traffic";
            this.chkBlockOutbound.UseVisualStyleBackColor = true;
            // 
            // btnHarden
            // 
            this.btnHarden.Location = new System.Drawing.Point(12, 252);
            this.btnHarden.Name = "btnHarden";
            this.btnHarden.Size = new System.Drawing.Size(636, 23);
            this.btnHarden.TabIndex = 2;
            this.btnHarden.Text = "Harden";
            this.btnHarden.UseVisualStyleBackColor = true;
            this.btnHarden.Click += new System.EventHandler(this.btnHarden_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 223);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(636, 23);
            this.progressBar.TabIndex = 3;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 281);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(636, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(636, 183);
            this.txtLog.TabIndex = 5;
            // 
            // chkExclude
            // 
            this.chkExclude.AutoSize = true;
            this.chkExclude.Location = new System.Drawing.Point(337, 201);
            this.chkExclude.Name = "chkExclude";
            this.chkExclude.Size = new System.Drawing.Size(120, 16);
            this.chkExclude.TabIndex = 6;
            this.chkExclude.Text = "Use Exclude List";
            this.chkExclude.UseVisualStyleBackColor = true;
            this.chkExclude.CheckedChanged += new System.EventHandler(this.chkExclude_CheckedChanged);
            // 
            // lvExclude
            // 
            this.lvExclude.Location = new System.Drawing.Point(12, 310);
            this.lvExclude.Name = "lvExclude";
            this.lvExclude.Size = new System.Drawing.Size(636, 191);
            this.lvExclude.TabIndex = 7;
            this.lvExclude.UseCompatibleStateImageBehavior = false;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(12, 507);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(210, 23);
            this.btnFile.TabIndex = 8;
            this.btnFile.Text = "Add File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnDir
            // 
            this.btnDir.Location = new System.Drawing.Point(228, 507);
            this.btnDir.Name = "btnDir";
            this.btnDir.Size = new System.Drawing.Size(210, 23);
            this.btnDir.TabIndex = 9;
            this.btnDir.Text = "Add Directory";
            this.btnDir.UseVisualStyleBackColor = true;
            this.btnDir.Click += new System.EventHandler(this.btnDir_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(444, 507);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(204, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chkWhiteList
            // 
            this.chkWhiteList.AutoSize = true;
            this.chkWhiteList.Location = new System.Drawing.Point(463, 201);
            this.chkWhiteList.Name = "chkWhiteList";
            this.chkWhiteList.Size = new System.Drawing.Size(193, 16);
            this.chkWhiteList.TabIndex = 11;
            this.chkWhiteList.Text = "Use White List (Only exclude)";
            this.chkWhiteList.UseVisualStyleBackColor = true;
            this.chkWhiteList.CheckedChanged += new System.EventHandler(this.chkWhiteList_CheckedChanged);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 537);
            this.Controls.Add(this.chkWhiteList);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnDir);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.lvExclude);
            this.Controls.Add(this.chkExclude);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnHarden);
            this.Controls.Add(this.chkBlockOutbound);
            this.Controls.Add(this.chkBlockAllInbound);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainFrame";
            this.Text = "Windows Firewall Harden";
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBlockAllInbound;
        private System.Windows.Forms.CheckBox chkBlockOutbound;
        private System.Windows.Forms.Button btnHarden;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.CheckBox chkExclude;
        private System.Windows.Forms.ListView lvExclude;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnDir;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox chkWhiteList;
    }
}

