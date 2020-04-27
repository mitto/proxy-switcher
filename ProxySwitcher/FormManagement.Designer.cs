namespace ProxySwitcher
{
	partial class FormManagement
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
			this.listBoxProfile = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxProfileSavePath = new System.Windows.Forms.TextBox();
			this.buttonChangeSaveDirectory = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonProfileAdd = new System.Windows.Forms.Button();
			this.buttonProfileEdit = new System.Windows.Forms.Button();
			this.buttonProfileDelete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBoxProfile
			// 
			this.listBoxProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxProfile.FormattingEnabled = true;
			this.listBoxProfile.ItemHeight = 12;
			this.listBoxProfile.Location = new System.Drawing.Point(14, 74);
			this.listBoxProfile.Name = "listBoxProfile";
			this.listBoxProfile.ScrollAlwaysVisible = true;
			this.listBoxProfile.Size = new System.Drawing.Size(150, 196);
			this.listBoxProfile.TabIndex = 0;
			this.listBoxProfile.SelectedIndexChanged += new System.EventHandler(this.listBoxProfile_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "プロファイルの保存場所";
			// 
			// textBoxProfileSavePath
			// 
			this.textBoxProfileSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxProfileSavePath.Location = new System.Drawing.Point(12, 24);
			this.textBoxProfileSavePath.Name = "textBoxProfileSavePath";
			this.textBoxProfileSavePath.ReadOnly = true;
			this.textBoxProfileSavePath.Size = new System.Drawing.Size(152, 19);
			this.textBoxProfileSavePath.TabIndex = 2;
			// 
			// buttonChangeSaveDirectory
			// 
			this.buttonChangeSaveDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonChangeSaveDirectory.Location = new System.Drawing.Point(171, 22);
			this.buttonChangeSaveDirectory.Name = "buttonChangeSaveDirectory";
			this.buttonChangeSaveDirectory.Size = new System.Drawing.Size(75, 23);
			this.buttonChangeSaveDirectory.TabIndex = 3;
			this.buttonChangeSaveDirectory.Text = "変更";
			this.buttonChangeSaveDirectory.UseVisualStyleBackColor = true;
			this.buttonChangeSaveDirectory.Click += new System.EventHandler(this.buttonChangeSaveDirectory_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "プロファイル一覧";
			// 
			// buttonProfileAdd
			// 
			this.buttonProfileAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonProfileAdd.Location = new System.Drawing.Point(171, 74);
			this.buttonProfileAdd.Name = "buttonProfileAdd";
			this.buttonProfileAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonProfileAdd.TabIndex = 5;
			this.buttonProfileAdd.Text = "追加(&A)";
			this.buttonProfileAdd.UseVisualStyleBackColor = true;
			this.buttonProfileAdd.Click += new System.EventHandler(this.buttonProfileAdd_Click);
			// 
			// buttonProfileEdit
			// 
			this.buttonProfileEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonProfileEdit.Enabled = false;
			this.buttonProfileEdit.Location = new System.Drawing.Point(171, 103);
			this.buttonProfileEdit.Name = "buttonProfileEdit";
			this.buttonProfileEdit.Size = new System.Drawing.Size(75, 23);
			this.buttonProfileEdit.TabIndex = 6;
			this.buttonProfileEdit.Text = "編集(&E)";
			this.buttonProfileEdit.UseVisualStyleBackColor = true;
			this.buttonProfileEdit.Click += new System.EventHandler(this.buttonProfileEdit_Click);
			// 
			// buttonProfileDelete
			// 
			this.buttonProfileDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonProfileDelete.Enabled = false;
			this.buttonProfileDelete.Location = new System.Drawing.Point(170, 132);
			this.buttonProfileDelete.Name = "buttonProfileDelete";
			this.buttonProfileDelete.Size = new System.Drawing.Size(75, 23);
			this.buttonProfileDelete.TabIndex = 7;
			this.buttonProfileDelete.Text = "削除(&D)";
			this.buttonProfileDelete.UseVisualStyleBackColor = true;
			this.buttonProfileDelete.Click += new System.EventHandler(this.buttonProfileDelete_Click);
			// 
			// FormManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(258, 287);
			this.Controls.Add(this.buttonProfileDelete);
			this.Controls.Add(this.buttonProfileEdit);
			this.Controls.Add(this.buttonProfileAdd);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonChangeSaveDirectory);
			this.Controls.Add(this.textBoxProfileSavePath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBoxProfile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormManagement";
			this.Text = "FormManagement";
			this.Load += new System.EventHandler(this.FormManagement_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxProfile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxProfileSavePath;
		private System.Windows.Forms.Button buttonChangeSaveDirectory;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonProfileAdd;
		private System.Windows.Forms.Button buttonProfileEdit;
		private System.Windows.Forms.Button buttonProfileDelete;
	}
}