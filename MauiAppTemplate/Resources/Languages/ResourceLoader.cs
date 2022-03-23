using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTemplate.Resources.Languages
{
	public class ResourceLoader : INotifyPropertyChanged
	{
		public static string ResourceId = "MauiAppTemplate.Resources.Languages.AppRessources"; // The namespace and name of your Resources file
		public static ResourceLoader Instance { get; private set; }

		private ResourceManager _manager;
		public CultureInfo _cultureInfo;

		public event PropertyChangedEventHandler PropertyChanged;
		public string this[string key] => GetString(key);

		public ResourceLoader(ResourceManager resourceManager)
		{
			_manager = resourceManager;
			Instance = this;
			_cultureInfo = CultureInfo.CurrentUICulture;
		}

		public string GetString(string resourceName)
		{
			string stringRes = _manager.GetString(resourceName, _cultureInfo);
			return stringRes;
		}


		public void SetCultureInfo(CultureInfo cultureInfo)
		{
			_cultureInfo = cultureInfo;
			CultureInfo.CurrentCulture = _cultureInfo;
			CultureInfo.CurrentUICulture = _cultureInfo;
			//PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
		}
	}
}
