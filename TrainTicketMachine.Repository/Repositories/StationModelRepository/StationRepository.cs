using System;
using System.Collections.Generic;
using System.Linq;
using TrainTicketMachine.Model.Entity.Response;

namespace TrainTicketMachine.Repository.Repositories.StationModelRepository
{
    /// <summary>
    /// Repository Class of Station
    /// </summary>
    public class StationRepository : IStationRepository
    {
        /// <summary>
        /// CacheStation Class
        /// </summary>
        private readonly ICacheStation _cacheStation;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="cacheStation"></param>
        public StationRepository(ICacheStation cacheStation)
        {
            _cacheStation = cacheStation;
        }

        /// <summary>
        /// Return de result of search
        /// </summary>
        /// <param name="param">search parameter</param>
        /// <returns>If exists return list of stations, else return null</returns>
        public Dictionary<string, HashSet<string>> GetAllStationsByParam(string param)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> stations = _cacheStation.Get();

            if (stations != null)
            {
                Dictionary<string, HashSet<string>> list;
                stations.TryGetValue(param, out list);

                return list;
            }
            else
            {
                return null;
            }
        }
    }
}
