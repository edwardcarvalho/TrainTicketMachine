using System;
using System.Collections.Generic;
using TrainTicketMachine.Model.Entity.Response;

namespace TrainTicketMachine.Repository.Repositories.StationModelRepository
{
    /// <summary>
    /// Interface that determines contracts to be implemented for Station Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStationRepository
    {

        /// <summary>
        /// Return the all the stations that starts with the parameter
        /// </summary>
        /// <param name="param">Searched Name</param>
        /// <returns>Result of search</returns>
        Dictionary<string, HashSet<string>> GetAllStationsByParam(string param);
    }
}