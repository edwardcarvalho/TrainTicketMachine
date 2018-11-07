using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainTicketMachine.Data.Repositories.StationModelRepository;
using TrainTicketMachine.Model.Entity;
using TrainTicketMachine.Service.Repositories.StationModelRepository;

namespace TrainTicketMachine.Api.Controllers
{
    public class TicketController : ApiController
    {

        private readonly IStationRepository _stationRepository;

        public TicketController(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        // GET api/Ticket/GetStation?term=param
        public IHttpActionResult GetStation([FromUri] string term)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var searchReturn = _stationRepository.Find(term);
                    return Ok(searchReturn);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
