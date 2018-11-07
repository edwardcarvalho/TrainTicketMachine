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
    public class CacheStation : ICacheStation
    {
        private static readonly object lockObj = new object();
        private static string cacheKey = "CacheStation";
        private static int cachePolicy = 1;
        private static readonly MemoryCache cache = new MemoryCache(cacheKey);
        private readonly IDbContext _dbContext;

        public CacheStation(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Return the station object
        /// </summary>
        /// <returns>If exists return a collection of stations</returns>
        public Dictionary<string, Dictionary<string, HashSet<string>>> Get()
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> stations = cache.Get(cacheKey) as Dictionary<string, Dictionary<string, HashSet<string>>>;

            if (stations == null)
            {
                lock (cacheKey)
                {
                    stations = _dbContext.GetStations();
                    cache.Set(cacheKey, stations, new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddHours(cachePolicy) });
                }
            }

            return stations;
        }
    }
}
