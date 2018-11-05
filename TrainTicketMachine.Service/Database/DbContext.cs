using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketMachine.Model.Entity;

namespace TrainTicketMachine.Service.Database
{
    /// <summary>
    /// Simulates the database context
    /// </summary>
    public class DbContext
    {
        /// <summary>
        /// class constructor
        /// </summary>
        public DbContext()
        {
            Init();
        }

        /// <summary>
        /// Station List Property.
        /// </summary>
        public ICollection<Station> Stations { get; private set; }

        /// <summary>
        /// Method to simulate database result search (mock)
        /// </summary>
        void Init()
        {
            Stations = new List<Station>
            {
                new Station
                {
                    StationId = 1,
                    Name = "DARTFORD"
                },
                new Station
                {
                    StationId = 2,
                    Name = "DARTMOUTH"
                },
                new Station
                {
                    StationId = 3,
                    Name = "TOWER HILL"
                },
                new Station
                {
                    StationId = 4,
                    Name = "DERBY"
                },
                new Station
                {
                    StationId = 5,
                    Name = "LIVERPOOL"
                },
                new Station
                {
                    StationId = 6,
                    Name = "LIVERPOOL LIME STREET"
                }
            };
        }
    }
}
