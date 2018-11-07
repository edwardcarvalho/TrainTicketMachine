﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketMachine.Model.Entity;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using Lucene.Net.Util.Automaton;
using Lucene.Net.Support;

namespace TrainTicketMachine.Service.Database
{
    /// <summary>
    /// Simulates the database context
    /// </summary>
    public class DbContext : IDbContext
    {
        ///// <summary>
        ///// class constructor
        ///// </summary>
        //public DbContext()
        //{
        //    Init();
        //}

        /// <summary>
        /// Station List Property.
        /// </summary>
        //public Dictionary<string, ICollection<string>> Stations = new Dictionary<string, ICollection<string>>();
        Dictionary<string, Dictionary<string, HashSet<string>>> Stations = new Dictionary<string, Dictionary<string, HashSet<string>>>();

        /// <summary>
        /// Method to simulate database result search (mock)
        /// </summary>
        public void Init()
        {
            List<Station> stations = new List<Station> {
                new Station {StationId = 1,Name = "DARTFORD" },
                new Station {StationId = 2,Name = "DARTMOUTH" },
                new Station {StationId = 3,Name = "TOWER HILL" },
                new Station {StationId = 4,Name = "DERBY" },
                new Station {StationId = 5,Name = "LIVERPOOL" },
                new Station {StationId = 6,Name = "LIVERPOOL LIME STREET" },
                new Station {StationId = 7,Name = "PADDINGTON" },
                new Station {StationId = 8,Name = "EUSTON" },
                new Station {StationId = 9,Name = "LONDON BRIDGE" },
                new Station {StationId = 10,Name = "VICTORIA" }
            };

            if (stations != null)
                foreach (var s in stations.OrderBy(c => c.Name))
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

        public Dictionary<string, Dictionary<string, HashSet<string>>> GetStations()
        {
            Init();
            return Stations;
        }
    }
}

