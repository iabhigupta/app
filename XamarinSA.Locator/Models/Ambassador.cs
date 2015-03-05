using System;
using xBrainLab.Security.Cryptography;

namespace XamarinSA.Locator.Models
{
	public class Ambassador
	{
		public string Name {get;set;}
		public string TwitterUsername {get; set;}
		public string Blog { get;set; }
		public string Bio { get; set; }
		public string Email { get; set; }

		private string twitter;
		public string TwitterHandle {
			get {
				if (string.IsNullOrEmpty (twitter)) {
					twitter = string.Format ("@{0}", TwitterUsername);
				}
				return twitter;
			}
		}

		private string gravitar;
		public string Gravitar {
			get { 
				if (string.IsNullOrEmpty (gravitar)) {
					gravitar = GenerateGravitarLink (Email, 75);
				}
				return gravitar;
			}
		}

		private string gravitarLarge;
		public string GravitarLarge {
			get {
				if (String.IsNullOrEmpty (gravitarLarge)) {
					gravitarLarge = GenerateGravitarLink (Email, 150);
				}
				return gravitarLarge;
			}
		}

		public Location Location { get; set; } 

		public Ambassador ()
		{
		}

		private static string GenerateGravitarLink(string email, int size = -1){
			email = email.Trim ().ToLower ();
			var hash = MD5.GetHashString (email);
			var gravitar = string.Empty;

			if (size > 0) {
				//show to size
				gravitar = string.Format ("{0}{1}?s={2}",
					"http://www.gravatar.com/avatar/",
					hash.ToLower (), size);
			} else {
				gravitar = string.Format ("{0}{1}",
					"http://www.gravatar.com/avatar/",
					hash.ToLower ());
			}

			return gravitar;
		}
	}
}

