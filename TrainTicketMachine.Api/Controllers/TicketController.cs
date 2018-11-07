﻿using System;
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
    /// <summary>
    /// Controller to Search Term
    /// </summary>
    public class TicketController : ApiController
    {
        /// <summary>
        /// StationRepository Class
        /// </summary>
        private readonly IStationRepository _stationRepository;

        /// <summary>
        /// Default Constructor 
        /// </summary>
        /// <param name="stationRepository"></param>
        public TicketController(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
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
