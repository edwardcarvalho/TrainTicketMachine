using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// Return de result of search
        /// </summary>
        /// <param name="param">search parameter</param>
        /// <returns>If exists return list of stations, else return null</returns>
        public ICollection<string> GetAll(string param)
        {
            try
            {
                var stations = CacheStation.Get();

                ICollection<string> list;
                stations.TryGetValue(param.Substring(0, 1), out list);

                return list.Where(c => c.Contains(param)).ToList();

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
                var stations = GetAll(param);
                var charList = GetNextCharacter(stations, param);

                return new StationResponse { Stations = stations, NextCharacters = charList };
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
        private ICollection<Char> GetNextCharacter(ICollection<string> stations, string param)
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
