using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using mitto.Util;

namespace ProxySwitcher
{
	public partial class FormProfileEdit : Form
	{
		Profile profile;
		ProfileManager manager;

		public FormProfileEdit(ProfileManager manager, string name)
		{
			InitializeComponent();
			profile = new Profile(name);
			profile.HotKey = new HotKey(manager.Hash.ToString(), manager.Handle);
			this.manager = manager;
		}

		public FormProfileEdit(ProfileManager manager, Profile pro)
		{
			InitializeComponent();
			profile = pro;
			this.manager = manager;
		}

		private void FormProfileEdit_Load(object sender, EventArgs e)
		{
			textBoxProfileName.Text = profile.Name;

			textBoxHttpProxyAddress.Text = profile.HttpProxyServerAddress;
			textBoxHttpProxyPort.Text = profile.HttpProxyServerPort.ToString();

			textBoxHttpsProxyAddress.Text = profile.HttpsProxyServerAddress;
			textBoxHttpsProxyPort.Text = profile.HttpsProxyServerPort.ToString();
	
			textBoxFtpProxyAddress.Text = profile.FtpProxyServerAddress;
			textBoxFtpProxyPort.Text = profile.FtpProxyServerPort.ToString();

			textBoxSocksProxyAddress.Text = profile.SocksProxyServerAddress;
			textBoxSocksProxyPort.Text = profile.SocksProxyServerPort.ToString();

			textBoxNotProxyAddress.Text = profile.ExcludingProxyAddress;

			checkBoxAllEqualProxy.Checked = profile.UseSameProxyServerAddress;

		    checkBoxLocalProxyAddress.Checked = profile.UseLocalAddressProxyEnable;

			RefreshHotKeyTextBox();

			//TextBoxにイベントハンドラを登録
			foreach (Control item in this.Controls)
			{
				var textbox = item as TextBox;
				if (textbox != null)
				{
					textbox.TextChanged += new EventHandler(textBox_TextChanged);
				}
			}

			foreach (Control item in tableLayoutPanel1.Controls)
			{
				var textbox = item as TextBox;
				if (textbox != null)
				{
					textbox.TextChanged += new EventHandler(textBox_TextChanged);
				}
			
			}

			foreach (Control item in groupBoxNotProxyAddress.Controls)
			{
				var textbox = item as TextBox;
				if (textbox != null)
				{
					textbox.TextChanged += new EventHandler(textBox_TextChanged);
				}
			}
		}


		private void buttonProfileNameEdit_Click(object sender, EventArgs e)
		{
			using (var dlg = new FormInput("プロファイル名を入力してください", "入力", textBoxProfileName.Text))
			{
				bool flag = true;

				while (flag)
				{
					if (dlg.ShowDialog(this) == DialogResult.OK)
					{
						if (string.IsNullOrEmpty(dlg.InputText))
						{
							MessageBox.Show("プロファイル名を入力してください");
						}
						else
						{
							if (manager.ContainsKey(dlg.InputText))
							{
								MessageBox.Show("そのプロファイル名はすでに登録されています\n別の名前を指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							else
							{
								flag = false;
								manager.Remove(profile.Name);
								File.Delete(profile.GetPath(true));
								profile.Name = dlg.InputText;
								profile.Save();
								manager.Add(profile);
								textBoxProfileName.Text = profile.Name;
							}
						}
					}
				}
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			profile.Save();

			if (manager.ContainsKey(profile.Name))
			{
				manager.Update(profile);
			}
			else
			{
				manager.Add(profile);
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void checkBoxAllEqualProxy_CheckedChanged(object sender, EventArgs e)
		{
			ChangeTextBoxEnable(!checkBoxAllEqualProxy.Checked);
			profile.UseSameProxyServerAddress = checkBoxAllEqualProxy.Checked;
		}

		private void ChangeTextBoxEnable(bool enable)
		{
			textBoxHttpsProxyAddress.Enabled = enable;
			textBoxHttpsProxyPort.Enabled = enable;
			textBoxFtpProxyAddress.Enabled = enable;
			textBoxFtpProxyPort.Enabled = enable;
			textBoxSocksProxyAddress.Enabled = enable;
			textBoxSocksProxyPort.Enabled = enable;


			if (!enable)
			{
				string address = textBoxHttpProxyAddress.Text;
				string port = textBoxHttpProxyPort.Text;

				textBoxHttpProxyAddress.Text = address;
				textBoxHttpProxyPort.Text = port;

				textBoxFtpProxyAddress.Text = address;
				textBoxFtpProxyPort.Text = port;
			}
		}

		public string ProfileName
		{
			get
			{
				return textBoxProfileName.Text;
			}
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			TextBox textbox = sender as TextBox;

			if (textbox == null)
			{
				return;
			}

			string address = textbox.Text;
			int port;
			int.TryParse(textbox.Text, out port);

			switch (textbox.Name)
			{
				case "textBoxHttpProxyAddress":
					profile.HttpProxyServerAddress = textbox.Text;
					break;
				case "textBoxHttpProxyPort":
					profile.HttpProxyServerPort = port;
					break;
				case "textBoxHttpsProxyAddress":
					profile.HttpsProxyServerAddress = textbox.Text;
					break;
				case "textBoxHttpsProxyPort":
					profile.HttpsProxyServerPort = port;
					break;
				case "textBoxFtpProxyAddress":
					profile.FtpProxyServerAddress = textbox.Text;
					break;
				case "textBoxFtpProxyPort":
					profile.FtpProxyServerPort = port;
					break;
				case "textBoxSocksProxyAddress":
					profile.SocksProxyServerAddress = textbox.Text;
					break;
				case "textBoxSocksProxyPort":
					profile.SocksProxyServerPort = port;
					break;
				case "textBoxNotProxyAddress":
					profile.ExcludingProxyAddress = textbox.Text;
					break;
			}

			if (checkBoxAllEqualProxy.Checked)
			{
				address = textBoxHttpProxyAddress.Text;
				int.TryParse(textBoxHttpProxyPort.Text, out port);

				textBoxHttpsProxyAddress.Text = address;
				textBoxHttpsProxyPort.Text = port.ToString();

				textBoxFtpProxyAddress.Text = address;
				textBoxFtpProxyPort.Text = port.ToString();
			}
		}

		private void textBoxHotKey_Click(object sender, EventArgs e)
		{
			using (var dlg = new FormHotKey(profile.HotKey))
			{
				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					RefreshHotKeyTextBox();
				}
			}

		}

		private void checkBoxLocalProxyAddress_CheckedChanged(object sender, EventArgs e)
		{
			profile.UseLocalAddressProxyEnable = checkBoxLocalProxyAddress.Checked;
		}

		private void RefreshHotKeyTextBox()
		{
			textBoxHotKey.Text = profile.HotKey.ModKey == ModKeys.None ? "設定がありません" : profile.HotKey.HotKeyMessage;
		}

	}
}
