using System.Collections.Generic;

namespace TrainTicketMachine.Repository.Repositories.StationModelRepository
{
    /// <summary>
    /// Intertace for CacheStation
    /// </summary>
    public interface ICacheStation
    {
        /// <summary>
        /// Return the station object
        /// </summary>
        /// <returns>If exists return a collection of stations</returns>
        Dictionary<string, Dictionary<string, HashSet<string>>> Get();
    }
}