using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketMachine.Model.Entity.Response
{
    /// <summary>
    /// Result of stations search
    /// </summary>
    public class StationResponse
    {
        /// <summary>
        /// Station Collection Property.
        /// </summary>
        public ICollection<Station> Stations { get; set; }

        /// <summary>
        /// NextCharacters Collection Property.
        /// </summary>
        public ICollection<Char> NextCharacters { get; set; }
    }
}
