using System;
using System.Collections.Generic;
using System.Linq;
using TrainTicketMachine.Model.Entity;


namespace TrainTicketMachine.Data.Database
{
    /// <summary>
    /// Simulates the database context
    /// </summary>
    public class DbContext : IDbContext
    {
        /// <summary>
        /// Station Dictionary Property.
        /// </summary>
        private Dictionary<string, Dictionary<string, HashSet<string>>> Stations = new Dictionary<string, Dictionary<string, HashSet<string>>>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Method to simulate database result search (mock)
        /// </summary>
        public void Init()
        {
            List<Station> stationsList = new List<Station> {
                new Station {Id = 1,Name = "DARTFORD" },
                new Station {Id = 2,Name = "DARTMOUTH" },
                new Station {Id = 3,Name = "TOWER HILL" },
                new Station {Id = 4,Name = "DERBY" },
                new Station {Id = 5,Name = "LIVERPOOL" },
                new Station {Id = 6,Name = "LIVERPOOL LIME STREET" },
                new Station {Id = 7,Name = "PADDINGTON" },
                new Station {Id = 8,Name = "EUSTON" },
                new Station {Id = 9,Name = "LONDON BRIDGE" },
                new Station {Id = 10,Name = "VICTORIA" }
            };

            BuildStationsDictionary(stationsList);
        }

        /// <summary>
        /// Method to get stations dictionary
        /// </summary>
        /// <returns>Return stations dictionary, else return null</returns>
        public Dictionary<string, Dictionary<string, HashSet<string>>> GetStations()
        {
            Init();
            return Stations.Count > 0 ? Stations : null;
        }

        /// <summary>
        /// Method to build a dictionary 
        /// </summary>
        public void BuildStationsDictionary(List<Station> stationsList)
        {
            if (stationsList != null && stationsList.Count > 0)
                foreach (var s in stationsList.OrderBy(c => c.Name))
                {
                    try
                    {
                        for (int i = 1; i <= s.Name.Length; i++)
                        {
                            string termSlice = string.Empty;

                            if (i < s.Name.Length)
                                termSlice = s.Name.Substring(0, i);
                            else
                                termSlice = s.Name;

                            Dictionary<string, HashSet<string>> list;

                            if (!Stations.TryGetValue(termSlice, out list))
                            {
                                list = new Dictionary<string, HashSet<string>>();
                                list.Add("stations", new HashSet<string>());
                                list.Add("nextCharacters", new HashSet<string>());

                                Stations.Add(termSlice, list);
                            }

                            HashSet<string> words;
                            list.TryGetValue("stations", out words);
                            words.Add(s.Name);

                            if (i < s.Name.Length)
                            {
                                var nextLetter = s.Name.Substring(i, 1);
                                HashSet<string> letters;
                                list.TryGetValue("nextCharacters", out letters);
                                letters.Add(nextLetter);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
        }
    }
}

