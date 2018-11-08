using System;
using TrainTicketMachine.Data.Database;
using TrainTicketMachine.Repositories.StationModelRepository;
using TrainTicketMachine.Service.Repositories.StationModelRepository;
using Unity;

namespace TrainTicketMachine.Api.App_Start
{
    public static class Ioc
    {
        public static UnityContainer GetContainer()
        {
            var container = new UnityContainer();

            try
            {
                container.RegisterType<IStationRepository, StationRepository>();
                container.RegisterType<ICacheStation, CacheStation>();
                container.RegisterType<IDbContext, DbContext>();
            }
            catch (Exception)
            {

                throw;
            }

            return container;
        }
    }
}