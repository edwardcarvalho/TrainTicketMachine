using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using TrainTicketMachine.Model.Entity;
using TrainTicketMachine.Service.Database;

namespace TrainTicketMachine.Data.Repositories.StationModelRepository
{
    /// <summary>
    /// Station Cache Manager
    /// </summary>
    internal static class CacheStation
    {
        private static readonly object lockObj = new object();
        private static string cacheKey = "CacheStation";
        private static int cachePolicy = 1;
        private static readonly MemoryCache cache = new MemoryCache(cacheKey);

        /// <summary>
        /// Return the station object
        /// </summary>
        /// <returns>If exists return a collection of stations</returns>
        internal static Dictionary<string, ICollection<string>> Get()
        {
            Dictionary<string, ICollection<string>> stations = cache.Get(cacheKey) as Dictionary<string, ICollection<string>>;

            if (stations == null)
            {
                lock (cacheKey)
                {
                    stations = new DbContext().Stations;
                    cache.Set(cacheKey, stations, new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddHours(cachePolicy) });
                }
            }

            return stations;
        }
    }
}
