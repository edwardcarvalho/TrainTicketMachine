using System.Collections.Generic;
using TrainTicketMachine.Model.Entity;

namespace TrainTicketMachine.Service.Database
{
    public interface IDbContext
    {
        void Init();

        void BuildStationsDictionary(List<Station> stations);

        Dictionary<string, Dictionary<string, HashSet<string>>> GetStations();

    }
}