using System;
using System.Runtime.Serialization;
using xBrainLab.Security.Cryptography;

namespace XamarinSA.Locator.Data.Models
{
    
	public class Ambassador
	{
		private string gravitar;
		public string Gravitar {
			get { 
				if (string.IsNullOrEmpty (gravitar)) {
					gravitar = GenerateGravitarLink (ContactEmail, 75);
				}
				return gravitar;
			}
		}

		private string gravitarLarge;
		public string GravitarLarge {
			get {
				if (String.IsNullOrEmpty (gravitarLarge)) {
                    gravitarLarge = GenerateGravitarLink(ContactEmail, 150);
				}
				return gravitarLarge;
			}
		}

        [IgnoreDataMember]
#if ASPNET
        [ScaffoldColumn(false)]
#endif
        public int Id { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name="First Name"), Required]
#endif
        public String FirstName { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Middle Name")]
#endif
        public String MiddleName { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Last Name"), Required]
#endif
        public String LastName { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Country"), Required]
#endif
        public String Country { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Email"), Required, DataType(DataType.EmailAddress)]
#endif
        public String ContactEmail { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Twitter handle"), Required]
#endif
        public String TwitterHandle { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Facebook ID"), Required]
#endif
        public Int64 FacebookName { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "LinkedIn ID")]
#endif
        public Int64 LinkedInName { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Blog"), DataType(DataType.Url)]
#endif
        public String Blog { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Is Certified")]
#endif
        public Boolean IsCertified { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Picture"), DataType(DataType.Upload)]
#endif
        public String PhotoUri { get; set; }

#if ASPNET
        [DataMember]
        [Display(Name = "Promotion page"), Required, DataType(DataType.Url)]
#endif
        public String EventPage { get; set; }

#if ASPNET
        [DataMember]
        [Display(Name = "Bio"), Required, DataType(DataType.MultilineText)]
#endif
        public String Biography { get; set; }

#if ASPNET
        [DataMember]
        [Display(Name = "GPS Coordinates")]
#endif
        public String GpsCoordinates { get; set; }

        [IgnoreDataMember]
#if ASPNET
        [Display(Name = "University"), Required]
#endif
        public Int32? UniversityId { get; set; }

        [DataMember]
#if ASPNET
        [ScaffoldColumn(false), Display(Name="University name")]
#endif
        public virtual University University { get; set; }

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

