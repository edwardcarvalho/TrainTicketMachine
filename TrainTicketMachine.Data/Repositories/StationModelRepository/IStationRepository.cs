using System;
using System.Collections.Generic;
using TrainTicketMachine.Model.Entity.Response;

namespace TrainTicketMachine.Service.Repositories.StationModelRepository
{
    /// <summary>
    /// Interface that determines contracts to be implemented for Station Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStationRepository
    {
        /// <summary>
        /// Return the result of station search
        /// </summary>
        /// <param name="param">Searched Name</param>
        /// <returns>Result of search</returns>
        StationResponse Find(string param);

        /// <summary>
        /// Return the all the stations that starts with the parameter
        /// </summary>
        /// <param name="param">Searched Name</param>
        /// <returns>Result of search</returns>
        Dictionary<string, HashSet<string>> GetAll(string param);

        /// <summary>
        /// Return the possible characters list of search result
        /// </summary>
        /// <param name="stations">list of stations</param>
        /// <param name="param">search parameter</param>
        /// <returns>If exists return list of characteres, else return null</returns>
        ICollection<Char> GetNextCharacter(ICollection<string> stations, string param);
    }
}