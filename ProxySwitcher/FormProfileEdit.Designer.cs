namespace ProxySwitcher
{
	partial class FormProfileEdit
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
			this.groupBoxProxyServer = new System.Windows.Forms.GroupBox();
			this.checkBoxLocalProxyAddress = new System.Windows.Forms.CheckBox();
			this.checkBoxAllEqualProxy = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxHttpProxyAddress = new System.Windows.Forms.TextBox();
			this.textBoxHttpProxyPort = new System.Windows.Forms.TextBox();
			this.textBoxHttpsProxyAddress = new System.Windows.Forms.TextBox();
			this.textBoxHttpsProxyPort = new System.Windows.Forms.TextBox();
			this.textBoxFtpProxyAddress = new System.Windows.Forms.TextBox();
			this.textBoxFtpProxyPort = new System.Windows.Forms.TextBox();
			this.textBoxSocksProxyAddress = new System.Windows.Forms.TextBox();
			this.textBoxSocksProxyPort = new System.Windows.Forms.TextBox();
			this.groupBoxNotProxyAddress = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBoxNotProxyAddress = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.textBoxProfileName = new System.Windows.Forms.TextBox();
			this.buttonProfileNameEdit = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.textBoxHotKey = new System.Windows.Forms.TextBox();
			this.groupBoxHotKey = new System.Windows.Forms.GroupBox();
			this.groupBoxProxyServer.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBoxNotProxyAddress.SuspendLayout();
			this.groupBoxHotKey.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxProxyServer
			// 
			this.groupBoxProxyServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxProxyServer.Controls.Add(this.checkBoxLocalProxyAddress);
			this.groupBoxProxyServer.Controls.Add(this.checkBoxAllEqualProxy);
			this.groupBoxProxyServer.Controls.Add(this.tableLayoutPanel1);
			this.groupBoxProxyServer.Location = new System.Drawing.Point(12, 42);
			this.groupBoxProxyServer.Name = "groupBoxProxyServer";
			this.groupBoxProxyServer.Size = new System.Drawing.Size(397, 220);
			this.groupBoxProxyServer.TabIndex = 0;
			this.groupBoxProxyServer.TabStop = false;
			this.groupBoxProxyServer.Text = "プロキシサーバー";
			// 
			// checkBoxLocalProxyAddress
			// 
			this.checkBoxLocalProxyAddress.AutoSize = true;
			this.checkBoxLocalProxyAddress.Location = new System.Drawing.Point(62, 185);
			this.checkBoxLocalProxyAddress.Name = "checkBoxLocalProxyAddress";
			this.checkBoxLocalProxyAddress.Size = new System.Drawing.Size(257, 16);
			this.checkBoxLocalProxyAddress.TabIndex = 2;
			this.checkBoxLocalProxyAddress.Text = "ローカルアドレスにはプロキシサーバーを使用しない";
			this.checkBoxLocalProxyAddress.UseVisualStyleBackColor = true;
			this.checkBoxLocalProxyAddress.CheckedChanged += new System.EventHandler(this.checkBoxLocalProxyAddress_CheckedChanged);
			// 
			// checkBoxAllEqualProxy
			// 
			this.checkBoxAllEqualProxy.AutoSize = true;
			this.checkBoxAllEqualProxy.Location = new System.Drawing.Point(62, 163);
			this.checkBoxAllEqualProxy.Name = "checkBoxAllEqualProxy";
			this.checkBoxAllEqualProxy.Size = new System.Drawing.Size(267, 16);
			this.checkBoxAllEqualProxy.TabIndex = 1;
			this.checkBoxAllEqualProxy.Text = "すべてのプロトコルに同じプロキシサーバーを使用する";
			this.checkBoxAllEqualProxy.UseVisualStyleBackColor = true;
			this.checkBoxAllEqualProxy.CheckedChanged += new System.EventHandler(this.checkBoxAllEqualProxy_CheckedChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanel1.Controls.Add(this.label12, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.label11, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label10, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label8, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBoxHttpProxyAddress, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBoxHttpProxyPort, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBoxHttpsProxyAddress, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBoxHttpsProxyPort, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBoxFtpProxyAddress, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.textBoxFtpProxyPort, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.textBoxSocksProxyAddress, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.textBoxSocksProxyPort, 3, 4);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(22, 30);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 127);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label12
			// 
			this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label12.Location = new System.Drawing.Point(263, 100);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(14, 27);
			this.label12.TabIndex = 18;
			this.label12.Text = "：";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label11.Location = new System.Drawing.Point(3, 100);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(54, 27);
			this.label11.TabIndex = 16;
			this.label11.Text = "Socks";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label10.Location = new System.Drawing.Point(263, 75);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(14, 25);
			this.label10.TabIndex = 14;
			this.label10.Text = "：";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label9.Location = new System.Drawing.Point(3, 75);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(54, 25);
			this.label9.TabIndex = 12;
			this.label9.Text = "FTP";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label8.Location = new System.Drawing.Point(263, 50);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(14, 25);
			this.label8.TabIndex = 10;
			this.label8.Text = "：";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label7.Location = new System.Drawing.Point(3, 50);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 25);
			this.label7.TabIndex = 8;
			this.label7.Text = "HTTPS";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label6.Location = new System.Drawing.Point(263, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(14, 25);
			this.label6.TabIndex = 6;
			this.label6.Text = "：";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Location = new System.Drawing.Point(3, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 25);
			this.label5.TabIndex = 4;
			this.label5.Text = "HTTP";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Location = new System.Drawing.Point(283, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 25);
			this.label4.TabIndex = 3;
			this.label4.Text = "ポート";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point(263, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 25);
			this.label3.TabIndex = 2;
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(63, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(194, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "使用するプロキシのアドレス";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "種類";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxHttpProxyAddress
			// 
			this.textBoxHttpProxyAddress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxHttpProxyAddress.Location = new System.Drawing.Point(63, 28);
			this.textBoxHttpProxyAddress.Name = "textBoxHttpProxyAddress";
			this.textBoxHttpProxyAddress.Size = new System.Drawing.Size(194, 19);
			this.textBoxHttpProxyAddress.TabIndex = 5;
			// 
			// textBoxHttpProxyPort
			// 
			this.textBoxHttpProxyPort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxHttpProxyPort.Location = new System.Drawing.Point(283, 28);
			this.textBoxHttpProxyPort.Name = "textBoxHttpProxyPort";
			this.textBoxHttpProxyPort.Size = new System.Drawing.Size(64, 19);
			this.textBoxHttpProxyPort.TabIndex = 7;
			// 
			// textBoxHttpsProxyAddress
			// 
			this.textBoxHttpsProxyAddress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxHttpsProxyAddress.Location = new System.Drawing.Point(63, 53);
			this.textBoxHttpsProxyAddress.Name = "textBoxHttpsProxyAddress";
			this.textBoxHttpsProxyAddress.Size = new System.Drawing.Size(194, 19);
			this.textBoxHttpsProxyAddress.TabIndex = 9;
			// 
			// textBoxHttpsProxyPort
			// 
			this.textBoxHttpsProxyPort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxHttpsProxyPort.Location = new System.Drawing.Point(283, 53);
			this.textBoxHttpsProxyPort.Name = "textBoxHttpsProxyPort";
			this.textBoxHttpsProxyPort.Size = new System.Drawing.Size(64, 19);
			this.textBoxHttpsProxyPort.TabIndex = 11;
			// 
			// textBoxFtpProxyAddress
			// 
			this.textBoxFtpProxyAddress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxFtpProxyAddress.Location = new System.Drawing.Point(63, 78);
			this.textBoxFtpProxyAddress.Name = "textBoxFtpProxyAddress";
			this.textBoxFtpProxyAddress.Size = new System.Drawing.Size(194, 19);
			this.textBoxFtpProxyAddress.TabIndex = 13;
			// 
			// textBoxFtpProxyPort
			// 
			this.textBoxFtpProxyPort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxFtpProxyPort.Location = new System.Drawing.Point(283, 78);
			this.textBoxFtpProxyPort.Name = "textBoxFtpProxyPort";
			this.textBoxFtpProxyPort.Size = new System.Drawing.Size(64, 19);
			this.textBoxFtpProxyPort.TabIndex = 15;
			// 
			// textBoxSocksProxyAddress
			// 
			this.textBoxSocksProxyAddress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxSocksProxyAddress.Location = new System.Drawing.Point(63, 103);
			this.textBoxSocksProxyAddress.Name = "textBoxSocksProxyAddress";
			this.textBoxSocksProxyAddress.Size = new System.Drawing.Size(194, 19);
			this.textBoxSocksProxyAddress.TabIndex = 17;
			// 
			// textBoxSocksProxyPort
			// 
			this.textBoxSocksProxyPort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxSocksProxyPort.Location = new System.Drawing.Point(283, 103);
			this.textBoxSocksProxyPort.Name = "textBoxSocksProxyPort";
			this.textBoxSocksProxyPort.Size = new System.Drawing.Size(64, 19);
			this.textBoxSocksProxyPort.TabIndex = 19;
			// 
			// groupBoxNotProxyAddress
			// 
			this.groupBoxNotProxyAddress.Controls.Add(this.label14);
			this.groupBoxNotProxyAddress.Controls.Add(this.textBoxNotProxyAddress);
			this.groupBoxNotProxyAddress.Controls.Add(this.label13);
			this.groupBoxNotProxyAddress.Location = new System.Drawing.Point(12, 268);
			this.groupBoxNotProxyAddress.Name = "groupBoxNotProxyAddress";
			this.groupBoxNotProxyAddress.Size = new System.Drawing.Size(397, 124);
			this.groupBoxNotProxyAddress.TabIndex = 1;
			this.groupBoxNotProxyAddress.TabStop = false;
			this.groupBoxNotProxyAddress.Text = "除外アドレス";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(25, 99);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(215, 12);
			this.label14.TabIndex = 2;
			this.label14.Text = "セミコロン(;)を使用してエントリを分けてください";
			// 
			// textBoxNotProxyAddress
			// 
			this.textBoxNotProxyAddress.Location = new System.Drawing.Point(27, 48);
			this.textBoxNotProxyAddress.Multiline = true;
			this.textBoxNotProxyAddress.Name = "textBoxNotProxyAddress";
			this.textBoxNotProxyAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxNotProxyAddress.Size = new System.Drawing.Size(345, 40);
			this.textBoxNotProxyAddress.TabIndex = 1;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(25, 28);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(212, 12);
			this.label13.TabIndex = 0;
			this.label13.Text = "次で始まるアドレスにはプロキシを使用しない";
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(253, 432);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(334, 432);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "キャンセル";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(22, 18);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(69, 12);
			this.label15.TabIndex = 4;
			this.label15.Text = "プロファイル名";
			// 
			// textBoxProfileName
			// 
			this.textBoxProfileName.Location = new System.Drawing.Point(99, 15);
			this.textBoxProfileName.Name = "textBoxProfileName";
			this.textBoxProfileName.ReadOnly = true;
			this.textBoxProfileName.Size = new System.Drawing.Size(229, 19);
			this.textBoxProfileName.TabIndex = 5;
			// 
			// buttonProfileNameEdit
			// 
			this.buttonProfileNameEdit.Location = new System.Drawing.Point(334, 13);
			this.buttonProfileNameEdit.Name = "buttonProfileNameEdit";
			this.buttonProfileNameEdit.Size = new System.Drawing.Size(75, 23);
			this.buttonProfileNameEdit.TabIndex = 6;
			this.buttonProfileNameEdit.Text = "変更";
			this.buttonProfileNameEdit.UseVisualStyleBackColor = true;
			this.buttonProfileNameEdit.Click += new System.EventHandler(this.buttonProfileNameEdit_Click);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(25, 18);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(154, 12);
			this.label16.TabIndex = 0;
			this.label16.Text = "このプロファイルのホットキー設定";
			// 
			// textBoxHotKey
			// 
			this.textBoxHotKey.BackColor = System.Drawing.Color.White;
			this.textBoxHotKey.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxHotKey.Location = new System.Drawing.Point(27, 33);
			this.textBoxHotKey.Name = "textBoxHotKey";
			this.textBoxHotKey.ReadOnly = true;
			this.textBoxHotKey.Size = new System.Drawing.Size(152, 19);
			this.textBoxHotKey.TabIndex = 1;
			this.textBoxHotKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBoxHotKey.Click += new System.EventHandler(this.textBoxHotKey_Click);
			// 
			// groupBoxHotKey
			// 
			this.groupBoxHotKey.Controls.Add(this.label16);
			this.groupBoxHotKey.Controls.Add(this.textBoxHotKey);
			this.groupBoxHotKey.Location = new System.Drawing.Point(12, 401);
			this.groupBoxHotKey.Name = "groupBoxHotKey";
			this.groupBoxHotKey.Size = new System.Drawing.Size(205, 67);
			this.groupBoxHotKey.TabIndex = 7;
			this.groupBoxHotKey.TabStop = false;
			// 
			// FormProfileEdit
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(421, 476);
			this.ControlBox = false;
			this.Controls.Add(this.groupBoxHotKey);
			this.Controls.Add(this.buttonProfileNameEdit);
			this.Controls.Add(this.textBoxProfileName);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupBoxNotProxyAddress);
			this.Controls.Add(this.groupBoxProxyServer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormProfileEdit";
			this.Text = "FormProfileEdit";
			this.Load += new System.EventHandler(this.FormProfileEdit_Load);
			this.groupBoxProxyServer.ResumeLayout(false);
			this.groupBoxProxyServer.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.groupBoxNotProxyAddress.ResumeLayout(false);
			this.groupBoxNotProxyAddress.PerformLayout();
			this.groupBoxHotKey.ResumeLayout(false);
			this.groupBoxHotKey.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxProxyServer;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxHttpProxyAddress;
		private System.Windows.Forms.TextBox textBoxHttpsProxyAddress;
		private System.Windows.Forms.TextBox textBoxFtpProxyAddress;
		private System.Windows.Forms.TextBox textBoxSocksProxyAddress;
		private System.Windows.Forms.CheckBox checkBoxAllEqualProxy;
		private System.Windows.Forms.GroupBox groupBoxNotProxyAddress;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBoxNotProxyAddress;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBoxProfileName;
		private System.Windows.Forms.Button buttonProfileNameEdit;
		private System.Windows.Forms.CheckBox checkBoxLocalProxyAddress;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox textBoxHotKey;
		private System.Windows.Forms.GroupBox groupBoxHotKey;
		private System.Windows.Forms.TextBox textBoxHttpProxyPort;
		private System.Windows.Forms.TextBox textBoxHttpsProxyPort;
		private System.Windows.Forms.TextBox textBoxFtpProxyPort;
		private System.Windows.Forms.TextBox textBoxSocksProxyPort;
	}
}