using System;
using XamarinSA.Locator.Models;
using System.Threading.Tasks;

namespace XamarinSA.Locator.Interfaces
{
	public interface ILocationProvider
	{
		Task<Location> GetCurrentLocation();
	}
}

