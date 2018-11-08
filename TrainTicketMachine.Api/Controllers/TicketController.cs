using System;
using System.Web.Http;
using TrainTicketMachine.Repository.Repositories.StationModelRepository;
using TrainTicketMachine.Service.Services.StationService;

namespace TrainTicketMachine.Api.Controllers
{
    /// <summary>
    /// Controller to Search Term
    /// </summary>
    public class TicketController : ApiController
    {
        /// <summary>
        /// StationRepository Class
        /// </summary>
        private readonly IStationService _stationService;

        /// <summary>
        /// Default Constructor 
        /// </summary>
        /// <param name="stationRepository"></param>
        public TicketController(IStationService stationService)
        {
            _stationService = stationService;
        }

        /// <summary>
        /// Method to search Term
        /// </summary>
        /// <param name="term">Search Term</param>
        /// <returns>HttpAction</returns>
        // GET api/Ticket/GetStation?term=param
        public IHttpActionResult GetStation([FromUri] string term)
        {
            try
            {
                if (ModelState.IsValid && !String.IsNullOrEmpty(term))
                {
                    var searchReturn = _stationService.FindTerm(term);
                    return Ok(searchReturn);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
