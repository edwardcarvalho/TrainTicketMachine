using System.Collections.Generic;

namespace TrainTicketMachine.Service.Database
{
    public interface IDbContext
    {
        void Init();

        Dictionary<string, Dictionary<string, HashSet<string>>> GetStations();

    }
}