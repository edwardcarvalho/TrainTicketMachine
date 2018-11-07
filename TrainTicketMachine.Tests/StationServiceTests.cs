using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TrainTicketMachine.Service.Repositories.StationModelRepository;
using Rhino.Mocks;
using System.Linq;
using TrainTicketMachine.Service.Database;
using TrainTicketMachine.Data.Repositories.StationModelRepository;
using TrainTicketMachine.Model.Entity;

namespace TrainTicketMachine.Tests
{
    [TestClass]
    public class StationServiceTests
    {
        [TestMethod]
        public void StationSearchWithPartialParameter()
        {
            var mockDB = new List<Station> {
                new Station { Name = "DARTFORD" }, new Station{Name = "DARTMOUTH"}, new Station {Name = "TOWER HILL" }, new Station{Name = "DERBY" } };

        }
    }
}
