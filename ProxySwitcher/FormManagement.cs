using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace ProxySwitcher
{
	public partial class FormManagement : Form
	{
		private ProfileManager manager;
		private int index;

		public FormManagement(ProfileManager manager)
		{
			InitializeComponent();
			this.manager = manager;
		}

		private void FormManagement_Load(object sender, EventArgs e)
		{
			textBoxProfileSavePath.Text = manager.SavePath;

			UpdateListBox();

			MinimumSize = new Size(200, 250);
		}

		private void buttonChangeSaveDirectory_Click(object sender, EventArgs e)
		{
			using (var dlg = new FolderBrowserDialog())
			{
				dlg.SelectedPath = Properties.Settings.Default.ProfileSavePath;

				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					manager.SavePath = dlg.SelectedPath;
				}
			}
		}

		private void UpdateSaveProfileDirectory()
		{
			textBoxProfileSavePath.Text = manager.SavePath;
		}

		private void buttonProfileDelete_Click(object sender, EventArgs e)
		{
			string item = (string)listBoxProfile.Items[index];
			string msg = string.Format("プロファイル「{0}」を削除しますか？", item);
			if (MessageBox.Show(msg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) ==
				 DialogResult.Yes)
			{
				manager.Remove(item);
				UpdateListBox();
			}
		}

		private void buttonProfileEdit_Click(object sender, EventArgs e)
		{
			Profile profile = manager.Search((string)listBoxProfile.Items[index]);

			using(var dlg = new FormProfileEdit(manager, profile))
			{
				dlg.ShowDialog(this);
			}

			UpdateListBox();

			UpdateButtons(false);

		}

		private void buttonProfileAdd_Click(object sender, EventArgs e)
		{
			string name = "";

			using (var dlg = new FormInput("プロファイル名を入力してください"))
			{
				bool flag = true;
				while(flag)
				{
					switch (dlg.ShowDialog(this))
					{
						case DialogResult.OK:
							name = dlg.InputText;
							break;
						case DialogResult.Cancel:
							return;
					}

					if (string.IsNullOrEmpty(name))
					{
						MessageBox.Show("プロファイル名を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						if(manager.ContainsKey(name))
						{
							MessageBox.Show("このプロファイル名はすでに登録されています\n別の名前を指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						else
						{
							flag = false;
						}
					}
				}
			}


			using (var dlg = new FormProfileEdit(manager, name))
			{

				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					UpdateListBox();
				}
			}
		}

		private void listBoxProfile_SelectedIndexChanged(object sender, EventArgs e)
		{
			index = listBoxProfile.SelectedIndex;

			if (index == -1)
			{
				UpdateButtons(false);
			}
			else
			{
				UpdateButtons(true);
			}
		}

		private void UpdateButtons(bool enable)
		{
			buttonProfileDelete.Enabled = enable;
			buttonProfileEdit.Enabled = enable;
		}

		private void UpdateListBox()
		{
			listBoxProfile.Items.Clear();
			listBoxProfile.Items.AddRange(manager.Keys);
		}
	}
}
