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
    public class TicketController : ApiController
    {

        private readonly IStationRepository _stationRepository;

        public TicketController(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        // GET api/Station
        public HttpResponseMessage GetStation([FromUri] string term)
        {
            try

            {
                if (ModelState.IsValid)
                {
                    var a = _stationRepository.Find(term);
                    return Request.CreateResponse(HttpStatusCode.OK, a);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
