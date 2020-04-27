using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Windows.Forms;

using mitto.Util;

namespace ProxySwitcher
{
	public class ProfileManager
	{
		private Dictionary<string, Profile> profileList = new Dictionary<string, Profile>();

		/// <summary>
		/// マネージャーの初期化
		/// </summary>
		public void Initialize(IntPtr ptr, string hash)
		{
			Handle = ptr;
			Hash = hash;

			ActivateProfile = null;

			//保存先がなかったらアプリケーションのスタートアップパスを設定する
			if (string.IsNullOrEmpty(SavePath))
			{
				SavePath = Application.StartupPath;
			}


			//初期化終わりだからフォルダ内のプロファイルファイル取得してくる
			foreach (var item in Directory.GetFiles(SavePath))
			{

				if (item.EndsWith(Profile.PROFILE_EXTENTION))
				{
					var info = new FileInfo(item);
					var profile = new Profile();

					profile.HotKey = new HotKey(Hash, Handle);

					profile.Load(info.FullName);

					profileList.Add(profile.Name, profile);
				}
			}

			HotKeyEnable(true);
		}

		public void Add(Profile profile)
		{
			profileList.Add(profile.Name ,profile);
		}

		public void Update(Profile profile)
		{
			profileList[profile.Name] = profile;
		}

		public bool ContainsKey(string key)
		{
			return profileList.ContainsKey(key);
		}

		public Profile Search(string key)
		{
			return profileList[key];
		}

		public void Remove(string name)
		{
			foreach (var item in profileList.Keys)
			{
				if (item == name)
				{
					File.Delete(profileList[item].GetPath(true));
					profileList.Remove(item);
					break;
				}
			}
		}

		public void Remove(Profile profile)
		{
			profileList.Remove(profile.Name);
		}

		public void Save()
		{
			foreach (var item in profileList.Values)
			{
				item.Save();
			}
		}

		public void Apply(Profile pro)
		{
			profileList[pro.Name].Apply();
			ActivateProfile = pro;
		}

		public void Clear()
		{
			if (ActivateProfile != null)
			{
				Profile.Clear();
				ActivateProfile = null;
			}
		}

		public void HotKeyEnable(bool enable)
		{
			EnableHotKey = "";

			if (enable)
			{
				foreach (Profile item in profileList.Values)
				{
					if (item.HotKey == null) return;

					if (!string.IsNullOrEmpty(item.HotKey.HotKeyMessage))
					{
						item.HotKey.RegisterHotKey();
						EnableHotKey += string.Format("{0}:{1}\n", item.Name, item.HotKey.HotKeyMessage);
					}
				}
			}
			else
			{
				foreach (Profile item in profileList.Values)
				{
					if (item.HotKey == null) return;

					if (!string.IsNullOrEmpty(item.HotKey.HotKeyMessage))
					{
						item.HotKey.ReleaseHotKey();
					}
				}
			}
		}

		/// <summary>
		/// プロファイルファイルの保存先パスを取得したり設定するプロパティ
		/// </summary>
		public string SavePath
		{
			get
			{
				return Properties.Settings.Default.ProfileSavePath;
			}
			set
			{
				if (!Directory.Exists(value))
				{
					throw new ArgumentException("ディレクトリが存在していません");
				}

				Properties.Settings.Default.ProfileSavePath = value;
				Properties.Settings.Default.Save();
			}
		}

		public string[] Keys
		{
			get
			{
				return profileList.Keys.ToArray<string>();
			}
		}

		public Profile[] Profiles
		{
			get
			{
				return profileList.Values.ToArray<Profile>();
			}
		}

		public int KeyCount
		{
			get
			{
				return profileList.Keys.Count;
			}
		}

		public string[] KeysMessage
		{
			get
			{
				string[] key = Keys;

				for (int i = 0; i < key.Length; i++)
				{
					key[i] = string.Format("{0}:{1}", key[i], profileList[key[i]].HotKey.HotKeyMessage);
				}
	
				return key;
			}
		}

		public IntPtr Handle { get; private set; }
		public string Hash { get; private set; }

		public string EnableHotKey { get; private set; }

		public Profile ActivateProfile { get; private set; }
	}
}
