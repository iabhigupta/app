using System;
using System.Threading.Tasks;
using XamarinSA.Locator.Data.Models;

namespace XamarinSA.Locator.Interfaces
{
	public interface ILocationProvider
	{
        Task<GpsCooridinate> GetCurrentLocation();
	}
}

