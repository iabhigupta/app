using System;
using XamarinSA.Locator.Models;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Base.Extensions;

namespace XamarinSA.Locator.Data
{
	public static class AmbassadorService
	{
		private const string JsonFileName = "XamarinSA.Locator.Data.Ambassadors.json";

		public static void FetchAmbassadorsAsync(Action<IList<Ambassador>> callback){
			//grab the assembly
			var assembly = typeof(Ambassador).GetTypeInfo ().Assembly;
			//get the file
			var stream = assembly.GetManifestResourceStream (JsonFileName);
			//read the file
			using (var reader = new StreamReader (stream)) {
				reader.ReadToEndAsync ().ContinueWith((task) => {
					//if there is something from the file
					if(!String.IsNullOrEmpty(task.Result)){
						//here result will be a json string of ambassadors
						var loc = JsonConvert.DeserializeObject<List<Ambassador>>(task.Result);
						//call the user specified callback function
						callback(loc);
					}
				}, TaskScheduler.FromCurrentSynchronizationContext());
			}
		}

	}
}

