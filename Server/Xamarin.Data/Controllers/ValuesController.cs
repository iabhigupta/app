using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xamarin.Data.Models;
using XamarinSA.Locator.Data.Models;

namespace Xamarin.Data.Controllers
{
    public class ValuesController : ApiController
    {
        private AmbassadorContext context = new AmbassadorContext();

        // GET api/values
        public IEnumerable<Ambassador> Get()
        {
            context.Configuration.ProxyCreationEnabled = false;
            var ambassadors = context.XamarinAmbassadors.ToList();
            return ambassadors;
        }

        // GET api/values/5
        public Ambassador Get(int id)
        {
            var ambassadors = context.XamarinAmbassadors.Where(x => x.Id == id).SingleOrDefault();
            return ambassadors;
        }
    }
}
