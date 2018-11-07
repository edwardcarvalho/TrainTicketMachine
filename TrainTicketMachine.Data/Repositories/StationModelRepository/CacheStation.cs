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
        /// <summary>
        /// Lock object property.
        /// </summary>
        private static readonly object lockObj = new object();

        /// <summary>
        /// Cache Key Property.
        /// </summary>
        private static string cacheKey = "CacheStation";

        /// <summary>
        /// Cache Policy Property.
        /// </summary>
        private static int cachePolicy = 1;

        /// <summary>
        /// Memory Cache Instance Property.
        /// </summary>
        private static readonly MemoryCache cache = new MemoryCache(cacheKey);

        /// <summary>
        /// DbContext Class.
        /// </summary>
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="dbContext"></param>
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
                    if (stations != null)
                        cache.Set(cacheKey, stations, new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddHours(cachePolicy) });
                }
            }

            return stations;
        }
    }
}
