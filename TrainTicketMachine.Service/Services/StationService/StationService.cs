using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketMachine.Model.Entity.Response;
using TrainTicketMachine.Repository.Repositories.StationModelRepository;

namespace TrainTicketMachine.Service.Services.StationService
{
    /// <summary>
    /// Station Bussines Class
    /// </summary>
    public class StationService : IStationService
    {
        /// <summary>
        /// StationRepository Class
        /// </summary>
        private readonly IStationRepository _stationRepository;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="stationRepository">StationRespository injection</param>
        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        /// <summary>
        /// Method to search term
        /// </summary>
        /// <param name="term">search param</param>
        /// <returns>Result of search</returns>
        public StationResponse FindTerm(string term)
        {
            return _stationRepository.Find(term);
        }
    }
}
