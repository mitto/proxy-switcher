using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxySwitcher
{
	/// <summary>
	/// プロファイルのインターフェイス
	/// </summary>
	public interface IProfile
	{
		void Save();
		void Load();
		void Apply();
		//void Release();
	}
}
