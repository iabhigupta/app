using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using XamarinSA.Locator.Data.Models;

namespace XamarinSA.Locator.Data.Models
{
    public class University
    {
        public University()
        {
            Ambassadors = new HashSet<Ambassador>();
        }

        [DataMember]
#if ASPNET
        [Display(Name="University name"), ScaffoldColumn(false)]
#endif
        public int Id { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Name"), Required]
#endif
        public String Name { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Website"), Required, DataType(DataType.Url)]
#endif
        public String WebSite { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Email"), DataType(DataType.EmailAddress)]
#endif
        public String ContactEmail { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Logo"), DataType(DataType.Upload)]
#endif
        public String Logo { get; set; }

        [IgnoreDataMember]
#if ASPNET
        [ScaffoldColumn(false)]
#endif
        public virtual ICollection<Ambassador> Ambassadors { get; set; }
    }
}
