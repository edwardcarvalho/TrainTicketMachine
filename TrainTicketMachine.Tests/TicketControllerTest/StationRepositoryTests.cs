using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TrainTicketMachine.Service.Repositories.StationModelRepository;
using TrainTicketMachine.Api.Controllers;
using TrainTicketMachine.Repositories.StationModelRepository;
using TrainTicketMachine.Data.Database;
using TrainTicketMachine.Model.Entity;
using TrainTicketMachine.Model.Entity.Response;
using System.Web.Http.Results;

namespace TrainTicketMachine.Tests.TicketControllerTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class StationRepositoryTests
    {

        [TestMethod]
        public void SearchTestWithIncompleteTerm()
        {
            //Arrange
            var controller = new TicketController(new StationRepository(new CacheStation(new DbContext())));

            var expected = new StationResponse
            {
                Stations = new List<string>
                {
                    "DARTFORD",
                    "DARTMOUTH"
                },
                NextCharacters = new List<string>
                {
                    "F",
                    "M"
                }
            };

            //Act
            var result = controller.GetStation("DART") as OkNegotiatedContentResult<StationResponse>;

            //Assert
            Assert.IsNotNull(result.Content);
            CollectionAssert.AreEqual(expected.Stations, result.Content.Stations);
            CollectionAssert.AreEqual(expected.NextCharacters, result.Content.NextCharacters);
        }

        [TestMethod]
        public void SearchTestWithCompleteAndIncompleteTerms()
        {
            //Arrange
            var controller = new TicketController(new StationRepository(new CacheStation(new DbContext())));

            var expected = new StationResponse
            {
                Stations = new List<string>
                {
                    "LIVERPOOL",
                    "LIVERPOOL LIME STREET"
                },
                NextCharacters = new List<string>
                {
                    " "
                }
            };

            //Act
            var result = controller.GetStation("LIVERPOOL") as OkNegotiatedContentResult<StationResponse>;

            //Assert
            Assert.IsNotNull(result.Content);
            CollectionAssert.AreEqual(expected.Stations, result.Content.Stations);
            CollectionAssert.AreEqual(expected.NextCharacters, result.Content.NextCharacters);
        }

        [TestMethod]
        public void SearchTestWithUnexistentTerm()
        {
            //Arrange
            var controller = new TicketController(new StationRepository(new CacheStation(new DbContext())));

            var expected = new StationResponse
            {
                Message = "Station Not Found."
            };

            //Act
            var result = controller.GetStation("KING CROSS") as OkNegotiatedContentResult<StationResponse>;

            //Assert
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(expected.Message, result.Content.Message);
        }

        [TestMethod]
        public void SearchTestWithCompleteTerm()
        {
            //Arrange
            var controller = new TicketController(new StationRepository(new CacheStation(new DbContext())));

            var expected = new StationResponse
            {
                Stations = new List<string>
                {
                    "PADDINGTON",
                },
                NextCharacters = new List<string>()
            };

            //Act
            var result = controller.GetStation("PADDINGTON") as OkNegotiatedContentResult<StationResponse>;

            //Assert
            Assert.IsNotNull(result.Content);
            CollectionAssert.AreEqual(expected.Stations, result.Content.Stations);
            CollectionAssert.AreEqual(expected.NextCharacters, result.Content.NextCharacters);
        }
    }
}
