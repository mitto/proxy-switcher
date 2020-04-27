using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using mitto.Util;

namespace mitto.Util
{
	public partial class FormHotKey : Form
	{
		///使用するキーのリスト
		private List<Keys> keyslist = new List<Keys>();
		private HotKey hotkey;

		/// <summary>
		/// デフォルトコンストラクター
		/// </summary>
		public FormHotKey(HotKey hk)
		{
			InitializeComponent();

			hotkey = hk;
			Initialize();

		}

		/// <summary>
		/// フォームの初期化用メソッド
		/// </summary>
		private void Initialize()
		{

			this.ShowInTaskbar = false;
			this.ControlBox = false;

			this.AcceptButton = btnOK;
			this.CancelButton = btnCancel;

			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximumSize = this.Size;

			//コンボボックスの設定
			cmbKeys.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbKeys.Enabled = false;
			cmbKeys.BackColor = Color.White;
			
			//ボタンの設定
			//btnOK.Enabled = false;


			//キーリストの作成
			KeysConverter kc = new KeysConverter();
			Keys key;


			//AからZまでのキー追加
			for (char c = 'A'; c <= 'Z'; c++)
			{
				key = (Keys)kc.ConvertFrom(c.ToString());
				keyslist.Add(key);
			}

			//Functionキーの追加
			for (int i = 1; i <= 12; i++)
			{
				key = (Keys)kc.ConvertFrom("F" + i);
				keyslist.Add(key);
			}

			//数字キーの追加
			for (int i = 0; i <= 9; i++)
			{
				key = (Keys)kc.ConvertFrom(i.ToString());
				keyslist.Add(key);
			}

			/*	追加で使えそうなキーのリスト
			keyslist.Add(Keys.Tab);
			keyslist.Add(Keys.CapsLock);
			keyslist.Add(Keys.Enter);
			keyslist.Add(Keys.Back);
			keyslist.Add(Keys.Insert);
			keyslist.Add(Keys.Delete);
			keyslist.Add(Keys.Home);
			keyslist.Add(Keys.End);
			keyslist.Add(Keys.PageUp);
			keyslist.Add(Keys.PageDown);
			keyslist.Add(Keys.PrintScreen);
			keyslist.Add(Keys.Scroll);

			keyslist.Sort();
			*/

			if (hotkey.ModKey != ModKeys.None) ReverseConfig();

			//イベントハンドラの登録
			chkAlt.Click += new EventHandler(checkBox_Click);
			chkCtrl.Click += new EventHandler(checkBox_Click);
			chkShift.Click += new EventHandler(checkBox_Click);
			chkWin.Click += new EventHandler(checkBox_Click);
			
			btnOK.Click += new EventHandler(btnOK_Click);
			btnCancel.Click +=new EventHandler(btnCancel_Click);
		}

		/// <summary>
		/// コンボボックスの初期化メソッド
		/// </summary>
		private void InitializeComboBox()
		{
			cmbKeys.Enabled = false;
			cmbKeys.Items.Clear();
			cmbKeys.SelectedItem = null;

			using (HotKey hk = new HotKey(this.GetHashCode().ToString(), this.Handle))
			{
				hk.ModKey = GetModKey();
				
				//現在の設定できるキーを検索
				foreach (Keys key in keyslist)
				{
					hk.Key = key;

					//オーナーは自分でよさげなので変更
					if (hk.RegisterHotKey())
					{
						hk.ReleaseHotKey();
						cmbKeys.Items.Add(key.ToString());
					}
				}
			}


			cmbKeys.SelectedIndex = 0;

			//cmbKeys.Enabled = true;
		}
	 
		private ModKeys GetModKey()
		{
			ModKeys modkey = ModKeys.None;

			if (chkAlt.Checked)
			{
				modkey = modkey | ModKeys.Alt;
			}

			if (chkCtrl.Checked)
			{
				modkey = modkey | ModKeys.Control;
			}

			if (chkShift.Checked)
			{
				modkey = modkey | ModKeys.Shift;
			}

			if (chkWin.Checked)
			{
				modkey = modkey | ModKeys.Win;
			}

			return modkey;
		}

		private void ReverseConfig()
		{
			if ((hotkey.ModKey & ModKeys.Alt) == ModKeys.Alt)
			{
				chkAlt.Checked = true;
			}

			if ((hotkey.ModKey & ModKeys.Control) == ModKeys.Control)
			{
				chkCtrl.Checked = true;
			}

			if ((hotkey.ModKey & ModKeys.Shift) == ModKeys.Shift)
			{
				chkShift.Checked = true;
			}

			if ((hotkey.ModKey & ModKeys.Win) == ModKeys.Win)
			{
				chkWin.Checked = true;
			}

			InitializeComboBox();

			cmbKeys.Text = hotkey.Key.ToString();

			btnOK.Enabled = true;
			cmbKeys.Enabled = true;
		}


		private void checkBox_Click(object sender, EventArgs e)
		{
			if (chkAlt.Checked || chkCtrl.Checked || chkShift.Checked || chkWin.Checked)
			{
				InitializeComboBox();
				//btnOK.Enabled = true;
				cmbKeys.Enabled = cmbKeys.Items.Count > 0 ? true : false;

			}
			else
			{
				//btnOK.Enabled = false;
				cmbKeys.SelectedItem = null;
				cmbKeys.Enabled = false;
			}

		}

		private void FormHotKey_Load(object sender, EventArgs e)
		{
			//this.Top = (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Height / 2);
			//this.Left = (Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (cmbKeys.SelectedItem != null)
			{
				EnumConverter ec = new EnumConverter(typeof(Keys));
				hotkey.ModKey = GetModKey();
				hotkey.Key = (Keys)ec.ConvertFrom(cmbKeys.SelectedItem);
				//hotkey.Key = (Keys)cmbKeys.SelectedItem;
			}
			else
			{
				hotkey.ModKey = ModKeys.None;
				hotkey.Key = Keys.None;
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

	}
}
