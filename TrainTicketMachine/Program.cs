using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketMachine.Data.Repositories;
using TrainTicketMachine.Service.Database;
using TrainTicketMachine.Service.Repositories.StationModelRepository;

namespace TrainTicketMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new StationRepository().Find("Hodge ");
            var result2 = new StationRepository().Find("Hodge");
        }
    }
}
