using System.Collections.Generic;
using TrainTicketMachine.Model.Entity;

namespace TrainTicketMachine.Service.Database
{
    /// <summary>
    /// Interface for DbContext
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Method to simulate database result search (mock)
        /// </summary>
        void Init();

        /// <summary>
        /// Method to build a dictionary 
        /// </summary>
        void BuildStationsDictionary(List<Station> stations);

        /// <summary>
        /// Method to get stations dictionary
        /// </summary>
        /// <returns>Return stations dictionary, else return null</returns>
        Dictionary<string, Dictionary<string, HashSet<string>>> GetStations();

    }
}