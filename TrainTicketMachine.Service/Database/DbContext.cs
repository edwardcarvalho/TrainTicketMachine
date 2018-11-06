using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketMachine.Model.Entity;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

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
        public Dictionary<string, ICollection<string>> Stations = new Dictionary<string, ICollection<string>>();

        /// <summary>
        /// Method to simulate database result search (mock)
        /// </summary>
        void Init()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("TrainTicketMachine\\bin\\Debug", @"TrainTicketMachine.Service\StationsData.json");

            var stations = JsonConvert.DeserializeObject<List<Station>>(File.ReadAllText(path));

            if (stations != null)
                foreach (var s in stations.OrderBy(c => c.Name))
                {
                    string letter = s.Name.Substring(0,1);
                    ICollection<string> list;
                    if (!Stations.TryGetValue(letter, out list))
                    {
                        list = new List<string>();
                        Stations.Add(letter, list);
                    }
                    list.Add(s.Name);
                }

        }
    }
}
