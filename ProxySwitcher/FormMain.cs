using System;
using System.Windows.Forms;

using Microsoft.Win32;

using mitto.Util;
using System.Drawing;

namespace ProxySwitcher
{
	/// <summary>
	/// メインフォームクラス
	/// </summary>
	public partial class FormMain : Form
	{
		#region "フィールド"

		private ProfileManager manager = new ProfileManager();

		#endregion

		#region "定数"

		private const string BALLOON_TITLE_PROFILE_CHANGE = "プロファイル変更";

		#endregion

		#region "コンストラクター"

		/// <summary>
		/// コンストラクター
		/// </summary>
		public FormMain()
		{
			InitializeComponent();
		}

		#endregion

		#region "メソッド"
		
		/// <summary>
		/// 現在プロキシ設定が有効になっているかを取得するメソッド
		/// </summary>
		/// <returns>有効ならtrue、無効ならfalseを返す</returns>
		private bool GetProxyEnable()
		{
			var reg = Registry.CurrentUser.OpenSubKey(Profile.INTERNET_SETTINGS, false);

			if (reg == null) return false;

			return ((int)reg.GetValue(Profile.REGISTRY_PROXY_ENABLE) != 0) ? true : false;

		}
	
		/// <summary>
		/// プロキシ設定の有効、無効を設定するメソッド
		/// </summary>
		/// <param name="enable">プロキシ設定を有効にするならtrue、無効化するならfalse</param>
		private void SetProxyEnable(bool enable)
		{
			var reg = Registry.CurrentUser.OpenSubKey(Profile.INTERNET_SETTINGS, true);

			if (reg == null) return;

			reg.SetValue(Profile.REGISTRY_PROXY_ENABLE, enable ? 1 : 0);
		}

		/// <summary>
		/// プロファイル一覧のコンボボックスのitemをリフレッシュするメソッド
		/// </summary>
		private void RefreshComboBox()
		{
			comboBoxProfile.Items.Clear();
			comboBoxProfile.Items.AddRange(manager.KeysMessage);

			if (manager.ActivateProfile != null)
			{
				comboBoxProfile.SelectedItem = manager.ActivateProfile.Name + ":" + manager.ActivateProfile.HotKey.HotKeyMessage;
			}
		}

		/// <summary>
		/// 有効か無効かのラジオボタンの表示をリフレッシュするメソッド
		/// </summary>
		private void RefreshRadioButtons()
		{
			if (GetProxyEnable())
			{
				radioButtonProxyEnable.Checked = true;
			}
			else
			{
				radioButtonProxyDisable.Checked = true;
			}
		}

		/// <summary>
		/// タスクトレイから通知バルーンを表示させるメソッド（5秒固定版）
		/// </summary>
		/// <param name="title">通知バルーンのタイトル</param>
		/// <param name="message">通知バルーンの本文</param>
		public void ShowBalloon(string title, string message)
		{
			notifyIconMain.BalloonTipIcon = ToolTipIcon.Info;
			notifyIconMain.BalloonTipTitle = title;
			notifyIconMain.BalloonTipText = message;
			notifyIconMain.ShowBalloonTip(5000);
		}

		/// <summary>
		/// タスクトレイから通知バルーンを表示させるメソッド(フル指定版)
		/// </summary>
		/// <param name="icon">通知に使うアイコン</param>
		/// <param name="title">通知バルーンのタイトル</param>
		/// <param name="message">通知バルーンの本文</param>
		/// <param name="time">タイムアウトまでの時間</param>
		public void ShowBalloon(ToolTipIcon icon, string title, string message, int time)
		{
			notifyIconMain.BalloonTipIcon = icon;
			notifyIconMain.BalloonTipTitle = title;
			notifyIconMain.BalloonTipText = message;
			notifyIconMain.ShowBalloonTip(time);
		}

		/// <summary>
		/// 現在のVisibleプロパティを反転させるメソッド
		/// </summary>
		private void ChangeFormVisible()
		{
			this.Visible = !this.Visible;
		}

		#endregion

		#region "イベントハンドラ"

		/// <summary>
		/// メインフォームのLoadイベントハンドラ
		/// </summary>
		private void FormMain_Load(object sender, EventArgs e)
		{
			//初期化
			this.Text = Application.ProductName;

			this.Icon = Properties.Resources.settings_64;

			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.MaximizeBox = false;

			notifyIconMain.Icon = this.Icon;

			manager.Initialize(this.Handle, this.GetHashCode().ToString());

			RefreshComboBox();
			RefreshRadioButtons();

			if (!string.IsNullOrEmpty(manager.EnableHotKey))
			{
				ShowBalloon("ホットキー登録完了", manager.EnableHotKey);
			}
			//イベントハンドラ登録
			radioButtonProxyEnable.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
			radioButtonProxyDisable.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

			ToolStripMenuItemTaskbarSettingRelease.Click += new EventHandler(ClearControl_Click);
			buttonClear.Click += new EventHandler(ClearControl_Click);
		}

		/// <summary>
		/// メインフォームのFormClosingイベントハンドラ
		/// </summary>
		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
				
		}

		/// <summary>
		/// メインフォームのラジオボタン共通のCheckedChangedイベントハンドラ
		/// </summary>
		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			var radioButton = sender as RadioButton;

			if (radioButton == null) return;

			switch (radioButton.Name)
			{
				case "radioButtonProxyEnable":
					SetProxyEnable(true);
					break;
				case "radioButtonProxyDisable":
					SetProxyEnable(false);
					break;
			}
		}

		private void buttonManagement_Click(object sender, EventArgs e)
		{
			notifyIconMain.Text = "";

			using (var f = new FormManagement(manager))
			{
				f.ShowDialog(this);

				RefreshComboBox();

				manager.HotKeyEnable(false);
				manager.HotKeyEnable(true);
				string mes = manager.EnableHotKey;
				if (!string.IsNullOrEmpty(mes))
				{
					ShowBalloon("ホットキー登録完了", mes);
				}
			}
		}

		private void buttonSetting_Click(object sender, EventArgs e)
		{
			if (comboBoxProfile.SelectedIndex != -1)
			{
				string item = (string)comboBoxProfile.SelectedItem;

				item = item.Split(':')[0];
				manager.Search(item).Apply();
				RefreshRadioButtons();
			}
		}


		private void ToolStripMenuItemTaskbarVisible_Click(object sender, EventArgs e)
		{
			ChangeFormVisible();
		}

		private void ToolStripMenuItemTaskbarExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}


		private void notifyIconMain_MouseClick(object sender, MouseEventArgs e)
		{
			switch (e.Button)
			{
 				case MouseButtons.Left:
					ChangeFormVisible();
					break;
				//右クリックしたときなんかするかも？
				case MouseButtons.Right:
					break;
			}
		}

		private void ToolStripMenuItemTaskbarSettingApply_Click(object sender, EventArgs e)
		{
			radioButtonProxyEnable.PerformClick();
		}

		/// <summary>
		/// 設定解除用に配置したコントロール用のClickイベントハンドラー
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClearControl_Click(object sender, EventArgs e)
		{
			radioButtonProxyDisable.PerformClick();
		}
	
		/// <summary>
		/// レジストリの変更を監視するタイマーTickイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timerCheck_Tick(object sender, EventArgs e)
		{
			bool check = radioButtonProxyEnable.Checked;

			if (check != GetProxyEnable())
			{
				string msg = string.Format("システム側でプロキシ設定が変更されました\n【{0}】", check ? "有効→無効" : "無効→有効");
				ShowBalloon("設定変更", msg);
				//変更があった際は何があるかわからないのでnullっとく
				comboBoxProfile.SelectedItem = null;
				RefreshRadioButtons();
			}
		}


		private void ToolStripMenuItemTaskbarSetting_Click(object sender, EventArgs e)
		{

		}

		#endregion


		#region "オーバーライドメソッド"

		/// <summary>
		/// ウインドウのメッセージ処理用のオーバーライドメソッド
		/// </summary>
		/// <param name="m"></param>
		[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			//規定のウインドウメッセージを処理
			base.WndProc(ref m);

			if (m.Msg == HotKey.WM_HOTKEY)
			{
				foreach (var item in manager.Profiles)
				{
					if (item.HotKey.HotKeyId == (short)m.WParam)
					{
						//登録されているホットキーのIDが見つかったらプロキシの設定を適用
						manager.Apply(item);
						//現在設定されているプロファイルに指定
						comboBoxProfile.SelectedItem = manager.ActivateProfile.Name + ":" + manager.ActivateProfile.HotKey.HotKeyMessage;
						//設定変更完了なので通知
						ShowBalloon(BALLOON_TITLE_PROFILE_CHANGE, item.ToString());
						//ラジオボタンリフレッシュ
						RefreshRadioButtons();
					}
				}
			}
		}

		#endregion




	}
}
