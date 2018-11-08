using TrainTicketMachine.Model.Entity.Response;

namespace TrainTicketMachine.Service.Services.StationService
{
    public  interface IStationService
    {
        StationResponse FindTerm(string term);
    }
}