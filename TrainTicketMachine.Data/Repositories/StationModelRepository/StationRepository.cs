using System;
using System.Collections.Generic;
using System.Linq;
using TrainTicketMachine.Data.Repositories.StationModelRepository;
using TrainTicketMachine.Model.Entity;
using TrainTicketMachine.Model.Entity.Response;
using TrainTicketMachine.Service.Repository;

namespace TrainTicketMachine.Service.Repositories.StationModelRepository
{
    /// <summary>
    /// Repository Class of Station
    /// </summary>
    public class StationRepository : IBaseRepository<Station>, IStationRepository
    {
        /// <summary>
        /// Return de result of de search
        /// </summary>
        /// <param name="param">search parameter</param>
        /// <returns>If exists return list of stations, else return null</returns>
        public ICollection<Station> Get(string param)
        {
            try
            {
                var stations = CacheStation.Get();

                return stations.Where(c => c.Name.ToLower().StartsWith(param.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                //TODO: Log Event
                return null;
            }

        }

        /// <summary>
        /// Return the possible characters list of search result
        /// </summary>
        /// <param name="stations">list of stations</param>
        /// <param name="param">search parameter</param>
        /// <returns>If exists return list of characteres, else return null</returns>
        private ICollection<Char> GetNextCharacter(ICollection<Station> stations, string param)
        {

            var characteres = new List<Char>();

            try
            {
                foreach (var station in stations)
                {
                    if (station.Name != param && station.Name.Length > param.Length)
                        characteres.Add(station.Name.Substring(param.Length).ToCharArray().FirstOrDefault());
                }

                return characteres;
            }
            catch (Exception ex)
            {
                //TODO: Log 
                throw ex;
            }
        }

        /// <summary>
        /// Return the final result of search
        /// </summary>
        /// <param name="param">search parameter</param>
        /// <returns>If exists return StationReponse object, else return null</returns>
        public StationResponse GetResponse(string param)
        {
            try
            {
                var stations = Get(param);
                var charsList = GetNextCharacter(stations, param);

                return new StationResponse { Stations = stations, NextCharacters = charsList };

            }
            catch (Exception ex)
            {
                //TODO: Log Event
                return null;
            }
        }
    }
}
