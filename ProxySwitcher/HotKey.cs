using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace mitto.Util
{
	/// <summary>
	/// ホットキーで使うキーの列挙体
	/// </summary>
	[Flags()]
	public enum ModKeys : uint
	{
		None,
		Alt = 0x0001,
		Control = 0x0002,
		Shift = 0x0004,
		Win = 0x0008
	}

	/// <summary>
	/// ホットキーの登録で使うクラス
	/// </summary>
	public class HotKey : IDisposable
	{
		public const int WM_HOTKEY = 0x312;

		#region "コンストラクター"

		/// <summary>
		/// コンストラクター
		/// </summary>
		/// <param name="hash">ハッシュ文字列</param>
		/// <param name="handle">ホットキーを登録するウインドウハンドル</param>
		public HotKey(string hash, IntPtr handle)
		{
			Hash = hash;
			Handle = handle;
			ModKey = ModKeys.None;
			Key = Keys.None;

			SuccessRegisterHotKey = false;
		}

		/// <summary>
		/// コンストラクター
		/// </summary>
		/// <param name="hash">ハッシュ文字列</param>
		/// <param name="handle">ホットキーを登録するウインドウハンドル</param>
		/// <param name="modkey">登録するModKey列挙体の組み合わせ</param>
		/// <param name="key">登録するKeys列挙体</param>
		public HotKey(string hash, IntPtr handle, ModKeys modkey, Keys key)
		{
			Hash = hash;
			Handle = handle;
			ModKey = modkey;
			Key = key;

			SuccessRegisterHotKey = false;
		}

		#endregion

		#region "メソッド"

		/// <summary>
		/// ホットキーの登録メソッド
		/// </summary>
		/// <returns>登録に成功すればTrue、失敗すればFalse</returns>
		public bool RegisterHotKey()
		{
			//Debug.Print("Handle:{0}\nhash:{1}\nModKey:{2}\nKey:{3}", Handle, Hash, ModKey, Key);

			//必要なキーが設定されているかの確認
			if ((ModKey == ModKeys.None) || (Key == Keys.None))
			{
				//throw new ArgumentException("必要なプロパティが設定されていません");
			}

			//Atomの取得
			HotKeyId = GlobalAddAtom(HotKeyMessage + Hash);

			
			if (HotKeyId == 0) return false;
#if DEBUG
			//Debug.Print("ATOM登録成功：{0}:{1}", HotKeyMessage, HotKeyId);
#endif

			if (RegisterHotKey(Handle, HotKeyId, (uint)ModKey, (uint)Key) == 0) return false;

#if DEBUG
			Debug.Print("ホットキーの登録に成功:{0}", HotKeyMessage);
#endif

			SuccessRegisterHotKey = true;

			return true;
		}

		public bool RegisterHotKey(string hash, IntPtr handle, ModKeys modkey, Keys key)
		{
			this.Handle = handle;
			this.Hash = hash;
			this.ModKey = modkey;
			this.Key = key;

			return RegisterHotKey();
		}

		/// <summary>
		/// ホットキーを削除するメソッド
		/// </summary>
		/// <returns>削除に成功すればtrue、失敗すればfalse</returns>
		public bool ReleaseHotKey()
		{
			//登録が成功していなければそのままfalseを返す
			//if (SuccessRegisterHotKey) return false;

			if (UnregisterHotKey(Handle, HotKeyId) == 0) return false;

			if (GlobalDeleteAtom(HotKeyId) != 0) return false;

			return true;
		}

		public static string GenerateHotKeyMeassage(ModKeys modkey, Keys key)
		{
			string mes = "";

			//if ((modkey & ModKeys.None) == ModKeys.None) return mes;

			if ((modkey & ModKeys.Alt) == ModKeys.Alt)
			{
				mes += "Alt + ";
			}

			if ((modkey & ModKeys.Control) == ModKeys.Control)
			{
				mes += "Control + ";
			}

			if ((modkey & ModKeys.Shift) == ModKeys.Shift)
			{
				mes += "Shift + ";
			}

			if ((modkey & ModKeys.Win) == ModKeys.Win)
			{
				mes += "Win + ";
			}

			mes += key.ToString();

			return mes;

		}

		#endregion

		#region "プロパティ"

		/// <summary>
		/// ホットキーの登録の際に使う一意な文字列のためのハッシュを入れておくプロパティ
		/// </summary>
		public string Hash { get; set; }

		/// <summary>
		/// 登録元のウインドウハンドルを登録しておくためのプロパティ
		/// </summary>
		public IntPtr Handle { get; set; }

		/// <summary>
		/// ModKeys列挙体を入れておくプロパティ
		/// </summary>
		public ModKeys ModKey { get; set; }

		/// <summary>
		/// Keys列挙体を入れておくプロパティ
		/// </summary>
		public Keys Key { get; set; }

		/// <summary>
		/// ホットキーの識別ID
		/// </summary>
		public short HotKeyId { get; private set; }

		/// <summary>
		/// ホットキーを表す文字列のプロパティ
		/// </summary>
		public string HotKeyMessage
		{
			get
			{
				return GenerateHotKeyMeassage(ModKey, Key);
			}
		}

		/// <summary>
		/// ホットキーの登録が成功しているかのプロパティ
		/// </summary>
		public bool SuccessRegisterHotKey { get; private set; }

		#endregion

		#region "Windows APIラッパー"

		[DllImport("user32.dll")]
		private extern static int RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

		[DllImport("user32.dll")]
		private extern static int UnregisterHotKey(IntPtr hWnd, int id);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		private extern static short GlobalAddAtom(string lpString);

		[DllImport("kernel32.dll")]
		private extern static short GlobalDeleteAtom(short nAtom);

		#endregion

		#region "IDispossable"

		private bool disposed = false;

		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this);
		}


		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					//マネージリソースはここでDispose
				}

				ReleaseHotKey();

				this.Handle = IntPtr.Zero;

			}
			disposed = true;
		}

		~HotKey()
		{
			Dispose(false);
		}

		#endregion

	}
}
