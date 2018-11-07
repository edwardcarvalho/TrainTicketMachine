using System;
using System.Collections.Generic;
using System.Linq;
using TrainTicketMachine.Data.Repositories.StationModelRepository;
using TrainTicketMachine.Model.Entity.Response;

namespace TrainTicketMachine.Service.Repositories.StationModelRepository
{
    /// <summary>
    /// Repository Class of Station
    /// </summary>
    public class StationRepository : IStationRepository
    {
        private readonly ICacheStation _cacheStation;

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
                //TODO: Log Event
                return null;
            }

        }

        /// <summary>
        /// Return the final result of search
        /// </summary>
        /// <param name="param">search parameter</param>
        /// <returns>If exists return StationReponse object, else return null</returns>
        public StationResponse Find(string param)
        {
            try
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
                    return new StationResponse { Message = "Station Not Found."};
                }
            }
            catch (Exception ex)
            {
                //TODO: Log Event
                return new StationResponse { Message = "Server Error." };
            }
        }

        /// <summary>
        /// Return the possible characters list of search result
        /// </summary>
        /// <param name="stations">list of stations</param>
        /// <param name="param">search parameter</param>
        /// <returns>If exists return list of characteres, else return null</returns>
        public ICollection<Char> GetNextCharacter(ICollection<string> stations, string param)
        {

            var characteres = new List<Char>();

            try
            {
                foreach (var station in stations)
                {
                    var charac = station.Substring(param.Length).ToCharArray().FirstOrDefault();

                    if (!characteres.Exists(c => c.Equals(charac)))
                        characteres.Add(charac);
                }

                return characteres;
            }
            catch (Exception ex)
            {
                //TODO: Log 
                throw ex;
            }
        }
    }
}
