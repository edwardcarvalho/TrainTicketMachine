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
    }
}