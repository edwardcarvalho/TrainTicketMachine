using System.Collections.Generic;

namespace TrainTicketMachine.Data.Repositories.StationModelRepository
{
    public interface ICacheStation
    {
        Dictionary<string, Dictionary<string, HashSet<string>>> Get();
    }
}