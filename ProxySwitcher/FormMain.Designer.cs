namespace ProxySwitcher
{
	partial class FormMain
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.buttonManagement = new System.Windows.Forms.Button();
			this.buttonApply = new System.Windows.Forms.Button();
			this.radioButtonProxyEnable = new System.Windows.Forms.RadioButton();
			this.radioButtonProxyDisable = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxProfile = new System.Windows.Forms.ComboBox();
			this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStripTaskbar = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ToolStripMenuItemTaskbarVisible = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemTaskbarSettingApply = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemTaskbarSettingRelease = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemTaskbarExit = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonClear = new System.Windows.Forms.Button();
			this.timerCheck = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ToolStripMenuItemTaskbarSetting = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStripTaskbar.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonManagement
			// 
			this.buttonManagement.Location = new System.Drawing.Point(235, 9);
			this.buttonManagement.Name = "buttonManagement";
			this.buttonManagement.Size = new System.Drawing.Size(75, 23);
			this.buttonManagement.TabIndex = 0;
			this.buttonManagement.Text = "管理(&M)";
			this.buttonManagement.UseVisualStyleBackColor = true;
			this.buttonManagement.Click += new System.EventHandler(this.buttonManagement_Click);
			// 
			// buttonApply
			// 
			this.buttonApply.Location = new System.Drawing.Point(235, 67);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 23);
			this.buttonApply.TabIndex = 1;
			this.buttonApply.Text = "適用(&S)";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonSetting_Click);
			// 
			// radioButtonProxyEnable
			// 
			this.radioButtonProxyEnable.AutoSize = true;
			this.radioButtonProxyEnable.ForeColor = System.Drawing.Color.Black;
			this.radioButtonProxyEnable.Location = new System.Drawing.Point(6, 15);
			this.radioButtonProxyEnable.Name = "radioButtonProxyEnable";
			this.radioButtonProxyEnable.Size = new System.Drawing.Size(97, 16);
			this.radioButtonProxyEnable.TabIndex = 2;
			this.radioButtonProxyEnable.TabStop = true;
			this.radioButtonProxyEnable.Text = "プロキシ有効化";
			this.radioButtonProxyEnable.UseVisualStyleBackColor = true;
			// 
			// radioButtonProxyDisable
			// 
			this.radioButtonProxyDisable.AutoSize = true;
			this.radioButtonProxyDisable.ForeColor = System.Drawing.Color.Black;
			this.radioButtonProxyDisable.Location = new System.Drawing.Point(109, 15);
			this.radioButtonProxyDisable.Name = "radioButtonProxyDisable";
			this.radioButtonProxyDisable.Size = new System.Drawing.Size(97, 16);
			this.radioButtonProxyDisable.TabIndex = 3;
			this.radioButtonProxyDisable.TabStop = true;
			this.radioButtonProxyDisable.Text = "プロキシ無効化";
			this.radioButtonProxyDisable.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "プロファイル選択";
			// 
			// comboBoxProfile
			// 
			this.comboBoxProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxProfile.FormattingEnabled = true;
			this.comboBoxProfile.Location = new System.Drawing.Point(12, 69);
			this.comboBoxProfile.Name = "comboBoxProfile";
			this.comboBoxProfile.Size = new System.Drawing.Size(217, 20);
			this.comboBoxProfile.TabIndex = 5;
			// 
			// notifyIconMain
			// 
			this.notifyIconMain.ContextMenuStrip = this.contextMenuStripTaskbar;
			this.notifyIconMain.Visible = true;
			this.notifyIconMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseClick);
			// 
			// contextMenuStripTaskbar
			// 
			this.contextMenuStripTaskbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemTaskbarVisible,
            this.toolStripSeparator1,
            this.ToolStripMenuItemTaskbarSettingApply,
            this.ToolStripMenuItemTaskbarSettingRelease,
            this.toolStripSeparator2,
            this.ToolStripMenuItemTaskbarSetting,
            this.ToolStripMenuItemTaskbarExit});
			this.contextMenuStripTaskbar.Name = "contextMenuStripTaskbar";
			this.contextMenuStripTaskbar.Size = new System.Drawing.Size(243, 148);
			// 
			// ToolStripMenuItemTaskbarVisible
			// 
			this.ToolStripMenuItemTaskbarVisible.Name = "ToolStripMenuItemTaskbarVisible";
			this.ToolStripMenuItemTaskbarVisible.Size = new System.Drawing.Size(242, 22);
			this.ToolStripMenuItemTaskbarVisible.Text = "メイン画面の表示切り替え (&V)";
			this.ToolStripMenuItemTaskbarVisible.Click += new System.EventHandler(this.ToolStripMenuItemTaskbarVisible_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(239, 6);
			// 
			// ToolStripMenuItemTaskbarSettingApply
			// 
			this.ToolStripMenuItemTaskbarSettingApply.Name = "ToolStripMenuItemTaskbarSettingApply";
			this.ToolStripMenuItemTaskbarSettingApply.Size = new System.Drawing.Size(242, 22);
			this.ToolStripMenuItemTaskbarSettingApply.Text = "プロキシを有効化 (&E)";
			this.ToolStripMenuItemTaskbarSettingApply.Click += new System.EventHandler(this.ToolStripMenuItemTaskbarSettingApply_Click);
			// 
			// ToolStripMenuItemTaskbarSettingRelease
			// 
			this.ToolStripMenuItemTaskbarSettingRelease.Name = "ToolStripMenuItemTaskbarSettingRelease";
			this.ToolStripMenuItemTaskbarSettingRelease.Size = new System.Drawing.Size(242, 22);
			this.ToolStripMenuItemTaskbarSettingRelease.Text = "プロキシを無効化 (&N)";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(239, 6);
			// 
			// ToolStripMenuItemTaskbarExit
			// 
			this.ToolStripMenuItemTaskbarExit.Name = "ToolStripMenuItemTaskbarExit";
			this.ToolStripMenuItemTaskbarExit.Size = new System.Drawing.Size(242, 22);
			this.ToolStripMenuItemTaskbarExit.Text = "終了 (&X)";
			this.ToolStripMenuItemTaskbarExit.Click += new System.EventHandler(this.ToolStripMenuItemTaskbarExit_Click);
			// 
			// buttonClear
			// 
			this.buttonClear.Location = new System.Drawing.Point(235, 38);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(75, 23);
			this.buttonClear.TabIndex = 6;
			this.buttonClear.Text = "クリア (&C)";
			this.buttonClear.UseVisualStyleBackColor = true;
			// 
			// timerCheck
			// 
			this.timerCheck.Enabled = true;
			this.timerCheck.Interval = 3000;
			this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButtonProxyDisable);
			this.groupBox1.Controls.Add(this.radioButtonProxyEnable);
			this.groupBox1.ForeColor = System.Drawing.Color.Blue;
			this.groupBox1.Location = new System.Drawing.Point(12, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(217, 37);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "現在の設定";
			// 
			// ToolStripMenuItemTaskbarSetting
			// 
			this.ToolStripMenuItemTaskbarSetting.Name = "ToolStripMenuItemTaskbarSetting";
			this.ToolStripMenuItemTaskbarSetting.Size = new System.Drawing.Size(242, 22);
			this.ToolStripMenuItemTaskbarSetting.Text = "設定 (&S)";
			this.ToolStripMenuItemTaskbarSetting.Click += new System.EventHandler(this.ToolStripMenuItemTaskbarSetting_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(322, 100);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonClear);
			this.Controls.Add(this.comboBoxProfile);
			this.Controls.Add(this.buttonManagement);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.label1);
			this.Name = "FormMain";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.contextMenuStripTaskbar.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonManagement;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.RadioButton radioButtonProxyEnable;
		private System.Windows.Forms.RadioButton radioButtonProxyDisable;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxProfile;
		private System.Windows.Forms.NotifyIcon notifyIconMain;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripTaskbar;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTaskbarVisible;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTaskbarSettingApply;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTaskbarSettingRelease;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTaskbarExit;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.Timer timerCheck;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTaskbarSetting;
	}
}

