using Lucene.Net.Util;
using Lucene.Net.Util.Fst;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrainTicketMachine.Data.Repositories;
using TrainTicketMachine.Model.Entity;
using TrainTicketMachine.Service.Database;
using TrainTicketMachine.Service.Repositories.StationModelRepository;

namespace TrainTicketMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = new StationRepository().Find("DA");

            //var dic = new Dictionary<string, string>();
            //dic.Add("b", "bla");
            //dic.Add("bl", "bla");
            //dic.Add("bla", "bla");
            //dic.Add("boneca", "boneca");
            //dic.Add("bo", "boneca");
            //dic.Add("c", "caca");
            //dic.Add("ca", "caca");
            //dic.Add("cac", "caca");
            //dic.Add("cacu", "caca");

            //var list = new List<string>();
            //list.Add("bla");
            //list.Add("boneca");
            //list.Add("barata");
            //list.Add("blabla");
            //list.Add("blastoise");
            //list.Add("caca");

            var fst = CharSequenceOutputs.Singleton;
            var builder = new Builder<CharsRef>(FST.INPUT_TYPE.BYTE1, fst);
            var irb = new IntsRef(); // ?

            ////foreach (var d in dic)
            ////{
            ////    var key = Util.ToIntsRef(new BytesRef(d.Key), irb);
            ////    var value = new CharsRef(d.Value);
            ////    builder.Add(key, value);
            ////}



            Dictionary<string, Dictionary<string, HashSet<string>>> Stations = new Dictionary<string, Dictionary<string, HashSet<string>>>();

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
                    for (int i = 1; i <= s.Name.Length; i++)
                    {
                        string termSlice = s.Name.Substring(0, i);

                        Dictionary<string, HashSet<string>> list2;

                        if (!Stations.TryGetValue(termSlice, out list2))
                        {
                            list2 = new Dictionary<string, HashSet<string>>();
                            list2.Add("words", new HashSet<string>());
                            list2.Add("nextCharacters", new HashSet<string>());

                            Stations.Add(termSlice, list2);
                        }

                        HashSet<string> words;
                        list2.TryGetValue("words", out words);
                        words.Add(s.Name);

                        if (i-1 < s.Name.Length)
                        {
                            var nextLetter = s.Name.Substring(i, 1);
                            HashSet<string> letters;
                            list2.TryGetValue("letters", out letters);
                            letters.Add(nextLetter);
                        }

                        //list2.Add(s.Name);
                    }
                }


            foreach (var st in Stations)
            {
                HashSet<string> wordlist;
                st.Value.TryGetValue("words", out wordlist);

                HashSet<string> letterslist;
                st.Value.TryGetValue("letters", out letterslist);

                var value = new CharsRef(String.Join(",", letterslist) + "|" + String.Join(",", wordlist));
                var key = Util.ToIntsRef(new BytesRef(st.Key), irb);
                builder.Add(key, value);
            }

            var database = builder.Finish();

            var retorno = Util.Get(database, new BytesRef("DART"));


            Console.WriteLine(retorno);
            Console.ReadKey();
        }
    }
}
