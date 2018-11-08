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
            try
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
            catch (Exception ex)
            {
                throw new Exception("Server Error: Could not load cache");
            }

        }

        /// <summary>
        /// Return the final result of search
        /// </summary>
        /// <param name="param">search parameter</param>
        /// <returns>If exists return StationReponse object, else return null</returns>
        public StationResponse Find(string param)
        {
            var stations = GetAllStationsByParam(param);

            if (stations != null)
            {
                HashSet<string> words;
                stations.TryGetValue("stations", out words);

                HashSet<string> nextCharacters;
                stations.TryGetValue("nextCharacters", out nextCharacters);

                return new StationResponse { Stations = words.ToList(), NextCharacters = nextCharacters.ToList() };
            }
            else
            {
                return new StationResponse { Message = "Station Not Found." };
            }
        }
    }
}
