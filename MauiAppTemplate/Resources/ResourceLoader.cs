using MauiAppTemplate.Resources.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTemplate.Common
{
	public class ResourceLoader : INotifyPropertyChanged
	{
		const string DEFAULT_LANGUAGE = "fr";
		public static ResourceLoader Instance { get; private set; }

		ResourceManager _resourceManager;
		public CultureInfo _currentCultureInfo;

		public event PropertyChangedEventHandler PropertyChanged;
		public string this[string key] => GetString(key);

		public ResourceLoader(Type resource, CultureInfo cultureInfo)
		{
			_currentCultureInfo = cultureInfo;
			_resourceManager = new ResourceManager(resource);
			Instance = this;	
		}

		public ResourceLoader(Type resource, string language = null)
		  : this(resource, new CultureInfo(language ?? DEFAULT_LANGUAGE))
		{ }

		public string GetString(string resourceName)
		{
			string stringRes = _resourceManager.GetString(resourceName, _currentCultureInfo);
			return stringRes;
		}


		public void SetCultureInfo(CultureInfo cultureInfo)
		{
			_currentCultureInfo = cultureInfo;
			CultureInfo.CurrentCulture = _currentCultureInfo;
			CultureInfo.CurrentUICulture = _currentCultureInfo;

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
		}
	}
}
