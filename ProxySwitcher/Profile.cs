using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Windows.Forms;

using Microsoft.Win32;


using mitto.Util;
using System.Diagnostics;

namespace ProxySwitcher
{
	/// <summary>
	/// プロキシ設定のプロファイルを管理するクラス
	/// </summary>
	public class Profile //: IProfile
	{
		#region "メモ"

		//2011/05/16
		//基本的にレジストリいじったりなどはプロファイルごとで行うように変更
		//ApplyとRelease
		//あと、プロキシ設定の有効かと無効かはメインフォームで管理するように変更
		//とりあえずホットキーもこちらで管理するように変更

		//どうやらSecureはHTTPSサーバーだったらしい

		//なんか設定項目増えてきたら独自ファイルよりXMLで記述しちゃった方が楽な気がしてきた

		//settings
		//+setting
		//++各プロパティ達

		//あれ、でも上のプランで行くとパースとか入出力変えないとだめじゃね･･･？ｗ
		//でも、変更とか楽なのかなぁ･･･ｗ

		#endregion

		#region "定数"

		//主にいじるレジストリキークラス内で統一なのでstatic化
		public const string INTERNET_SETTINGS = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings";

		public const string REGISTRY_PROXY_ENABLE = "ProxyEnable"; //プロキシの有効化(1)と無効化(0)
		public const string REGISTRY_PROXY_SERVER = "ProxyServer"; //ポート番号を含めたサーバーアドレス
		public const string REGISTRY_PROXY_OVERRIDE = "ProxyOverride"; //プロキシを経由しないアドレスを指定

		private const string PROXY_OVERRIDE_DEFAULT = "*.local;"; //デフォルト値
		private const string PROXY_OVERRIDE_LOCAL = "*.local;<local>;"; //ローカルアドレスを含んだ場合の規定値

		private const string PROXY_SERVER = "{0}:{1}";
		private const string PROXY_SERVER_HTTP = "http={0}:{1};";
		private const string PROXY_SERVER_HTTPS = "https={0}:{1};";
		private const string PROXY_SERVER_FTP = "ftp={0}:{1};";
		private const string PROXY_SERVER_SOCKS = "socks={0}:{1}";

		public const string PROFILE_EXTENTION = ".profile"; //プロファイルファイルの拡張子

		#endregion

		#region "フィールド"


		#endregion

		#region "コンストラクター"

		/// <summary>
		/// デフォルトコンストラクター
		/// </summary>
		public Profile()
		{
		}

		/// <summary>
		/// 新しくプロファイルを作る場合のコンストラクター
		/// </summary>
		/// <param name="name">プロファイル名</param>
		public Profile(string name)
		{
			Name = name;
		}

		#endregion

		#region "メソッド"

		/// <summary>
		/// プロファイルの設定を適用するメソッド
		/// </summary>
		public void Apply()
		{
			using(var reg = Registry.CurrentUser.OpenSubKey(INTERNET_SETTINGS, true))
			{
				if (reg == null) return;

				reg.SetValue(REGISTRY_PROXY_ENABLE, 1);

				string address = "";

				if (this.UseSameProxyServerAddress)
				{
					address = string.Format(PROXY_SERVER, HttpProxyServerAddress, HttpProxyServerPort);
				}
				else
				{
					address += string.IsNullOrEmpty(HttpProxyServerAddress) ? "" :
						string.Format(PROXY_SERVER_HTTP, HttpProxyServerAddress, HttpProxyServerPort);
					address += string.IsNullOrEmpty(HttpsProxyServerAddress) ? "" :
						string.Format(PROXY_SERVER_HTTPS, HttpsProxyServerAddress, HttpsProxyServerPort);
					address += string.IsNullOrEmpty(HttpProxyServerAddress) ? "" :
						string.Format(PROXY_SERVER_FTP, FtpProxyServerAddress, FtpProxyServerPort);
					address += string.IsNullOrEmpty(HttpProxyServerAddress) ? "" :
						string.Format(PROXY_SERVER_SOCKS, SocksProxyServerAddress, SocksProxyServerPort);
				}
				
				reg.SetValue(REGISTRY_PROXY_SERVER, address);
				
				string localAddress = UseLocalAddressProxyEnable ? PROXY_OVERRIDE_LOCAL : PROXY_OVERRIDE_DEFAULT;

				localAddress += ExcludingProxyAddress;

				reg.SetValue(REGISTRY_PROXY_OVERRIDE, localAddress);
			}
		}

		/// <summary>
		/// プロファイルの設定を解除するスタティックメソッド
		/// </summary>
		public static void Clear()
		{
			using(var reg = Registry.CurrentUser.OpenSubKey(INTERNET_SETTINGS, true))
			{
				if (reg == null) return;

				reg.SetValue(REGISTRY_PROXY_ENABLE, 0);

				//念のため中身を空に設定してから削除
				reg.SetValue(REGISTRY_PROXY_SERVER, "");
				reg.DeleteValue(REGISTRY_PROXY_SERVER);

				reg.SetValue(REGISTRY_PROXY_OVERRIDE, PROXY_OVERRIDE_DEFAULT);
			}
		}

		/// <summary>
		/// ファイルへ現在のプロファイル設定を書き出すメソッド
		/// </summary>
		public void Save()
		{
			using(var writer = new StreamWriter(GetPath(true)))
			{
				writer.Write(GetSettingString());
			}
		}

		/// <summary>
		/// 指定したパスから直接設定を読み込むメソッド
		/// </summary>
		/// <param name="path"></param>
		public void Load(string path)
		{
			if (File.Exists(path))
			{
				string[] config;
				string file;
				using (var reader = new StreamReader(path))
				{
					file = reader.ReadToEnd();
				}

				config = file.Split('\n');

				foreach (var item in config)
				{
					string[] parseItem = item.Split(':');

					switch (parseItem[0])
					{
						case "Name":
							this.Name = parseItem[1];
							break;
						case "HttpProxyServerAddress":
							this.HttpProxyServerAddress = parseItem[1];
							break;
						case "HttpProxyServerPort":
							this.HttpProxyServerPort = int.Parse(parseItem[1]);
							break;
						case "HttpsProxyServerAddress":
							this.HttpsProxyServerAddress = parseItem[1];
							break;
						case "HttpsProxyServerPort":
							this.HttpsProxyServerPort = int.Parse(parseItem[1]);
							break;
						case "FtpProxyServerAddress":
							this.FtpProxyServerAddress = parseItem[1];
							break;
						case "FtpProxyServerPort":
							this.FtpProxyServerPort = int.Parse(parseItem[1]);
							break;
						case "SocksProxyServerAddress":
							this.SocksProxyServerAddress = parseItem[1];
							break;
						case "SocksProxyServerPort":
							this.SocksProxyServerPort = int.Parse(parseItem[1]);
							break;
						case "UseSameProxyServerAddress":
							this.UseSameProxyServerAddress = bool.Parse(parseItem[1]);
							break;
						case "UseLocalAddressProxyEnable":
							this.UseLocalAddressProxyEnable = bool.Parse(parseItem[1]);
							break;
						case "ExcludingProxyAddress":
							this.ExcludingProxyAddress = parseItem[1];
							break;
						case "ModKey":
							//this.HotKey.ModKey = (ModKeys)Enum.Parse(typeof(ModKeys), parseItem[1]);
							this.HotKey.ModKey = (ModKeys)uint.Parse(parseItem[1]);
							break;
						case "Key":
							//2011/05/13 何も設定してないとエラー出るようになったので、uintで読み込んでからKeysに変換するようにした
							//KeysConverter keysCV = new KeysConverter();
							//this.HotKey.Key = (Keys)keysCV.ConvertFromString(parseItem[1]);
							this.HotKey.Key = (Keys)uint.Parse(parseItem[1]);
							break;
					}
#if DEBUG
					Debug.WriteLine(item);
#endif
				}

			}

		}

		/// <summary>
		/// プロファイルのパスを返すメソッド
		/// </summary>
		/// <param name="file">
		///		拡張子まで含めたファイル名を取得する場合はtrue
		///		フォルダ名までの場合はfalse
		/// </param>
		/// <returns>フォルダ名または拡張子を含んだファイル名</returns>
		public string GetPath(bool file)
		{
			string path = Properties.Settings.Default.ProfileSavePath;

			if(!file)
			{
				return path;
			}

			if (!path.EndsWith(@"\"))
			{
				path += @"\";
			}

			//Nameプロパティが空白なら例外投げてもいいかも？
			//→とりあえず投げるようにしておこう
			if (string.IsNullOrEmpty(Name)) throw new NullReferenceException("Nameプロパティが設定されていません");

			return path + Name + PROFILE_EXTENTION;
		}

		/// <summary>
		/// 現在のプロファイル設定を保存するための文字列を返すメソッド
		/// </summary>
		/// <returns>ファイル記述用の文字列</returns>
		private string GetSettingString()
		{
			//何かめんどくさいからXMLで書き出したり読み出した方が楽かも
			var sb = new StringBuilder();

			sb.AppendFormat("Name:{0}\n", Name);

			sb.AppendFormat("HttpProxyServerAddress:{0}\n", HttpProxyServerAddress);
			sb.AppendFormat("HttpProxyServerPort:{0}\n", HttpProxyServerPort);
			
			sb.AppendFormat("HttpsProxyServerAddress:{0}\n", HttpsProxyServerAddress);
			sb.AppendFormat("HttpsProxyServerPort:{0}\n", HttpsProxyServerPort);

			sb.AppendFormat("FtpProxyServerAddress:{0}\n", FtpProxyServerAddress);
			sb.AppendFormat("FtpProxyServerPort:{0}\n", FtpProxyServerPort);

			sb.AppendFormat("SocksProxyServerAddress:{0}\n", SocksProxyServerAddress);
			sb.AppendFormat("SocksProxyServerPort:{0}\n", SocksProxyServerPort);

			sb.AppendFormat("UseSameProxyServerAddress:{0}\n", UseSameProxyServerAddress);
			sb.AppendFormat("UseLocalAddressProxyEnable:{0}\n", UseLocalAddressProxyEnable);

			sb.AppendFormat("ExcludingProxyAddress:{0}\n", ExcludingProxyAddress);

			sb.AppendFormat("ModKey:{0}\n", (uint)HotKey.ModKey);
			sb.AppendFormat("Key:{0}", (uint)HotKey.Key);
			
			return sb.ToString();
		}

#endregion

		#region "オーバーライドメソッド"

		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.AppendFormat("【プロファイル名】：{0}\n", Name);

			if (UseSameProxyServerAddress)
			{
				sb.AppendFormat("【サーバー】：{0}:{1}\n", HttpProxyServerAddress, HttpProxyServerPort);
			}
			else
			{
				if (!string.IsNullOrEmpty(HttpProxyServerAddress))
				{
					sb.AppendFormat("【HTTPプロキシサーバー】：{0}:{1}\n", HttpProxyServerAddress, HttpProxyServerPort);
				}
				if (!string.IsNullOrEmpty(HttpsProxyServerAddress))
				{
					sb.AppendFormat("【HTTPSプロキシサーバー】：{0}:{1}\n", HttpsProxyServerAddress, HttpsProxyServerPort);
				}
				if (!string.IsNullOrEmpty(FtpProxyServerAddress))
				{
					sb.AppendFormat("【FTPプロキシサーバー】：{0}:{1}\n", FtpProxyServerAddress, FtpProxyServerPort);
				}
				if (!string.IsNullOrEmpty(PROXY_SERVER_SOCKS))
				{
					sb.AppendFormat("【Socksプロキシサーバー】：{0}:{1}\n", SocksProxyServerAddress, SocksProxyServerPort);
				}
			}

			return sb.ToString();
		}
		
		#endregion

		#region "プロパティ"

		/// <summary>
		/// プロファイル名兼ファイル名
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// HTTPプロキシアドレス
		/// </summary>
		public string HttpProxyServerAddress { get; set; }

		/// <summary>
		/// HTTPプロキシポート番号
		/// </summary>
		public int HttpProxyServerPort { get; set; }

		/// <summary>
		/// HTTPSプロキシアドレス
		/// </summary>
		public string HttpsProxyServerAddress { get; set; }

		/// <summary>
		/// HTTPSプロキシポート番号
		/// </summary>
		public int HttpsProxyServerPort { get; set; }

		/// <summary>
		/// FTPプロキシアドレス
		/// </summary>
		public string FtpProxyServerAddress { get; set; }
		
		/// <summary>
		/// FTPプロキシポート番号
		/// </summary>
		public int FtpProxyServerPort { get; set; }

		/// <summary>
		/// Socksプロキシアドレス
		/// </summary>
		public string SocksProxyServerAddress { get; set; }

		/// <summary>
		/// Socksプロキシポート番号
		/// </summary>
		public int SocksProxyServerPort { get; set; }

		/// <summary>
		/// プロキシを使用しないアドレス
		/// </summary>
		public string ExcludingProxyAddress { get; set; }

		/// <summary>
		/// すべてのプロトコルで同じプロキシを利用するかのプロパティ
		/// </summary>
		public bool UseSameProxyServerAddress { get; set; }

		/// <summary>
		/// ローカルアドレスにプロキシを利用するかのプロパティ
		/// </summary>
		public bool UseLocalAddressProxyEnable { get; set; }


		private HotKey _HotKey = null;
		/// <summary>
		/// このプロファイルのホットキー
		/// </summary>
		public HotKey HotKey { get { return _HotKey; } set { _HotKey = value; } }

	#endregion

	}

}
