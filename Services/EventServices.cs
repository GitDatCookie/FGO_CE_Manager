using FGO_CE_Manager.Data;
using FGO_CE_Manager.Data.CEModels;
using FGO_CE_Manager.Data.EventModels;
using Newtonsoft.Json;
using System.IO;

namespace FGO_CE_Manager.Services
{
    public class EventServices
    {
        const string apiLink = @"https://api.atlasacademy.io/export/NA/nice_event.json";
        private ApplicationDbContext _context { get; set; }
        public EventServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task FillEventDatabase()
        {

            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStreamAsync(apiLink);
                DeserializeJson(jsonString);
            }

        }

        public void DeserializeJson(Stream stream )
        {

            using (StreamReader r = new StreamReader(stream))
            {
                string json = r.ReadToEnd();
                {
                    var eves = JsonConvert.DeserializeObject<List<FGOEvent>>(json);
                    foreach (var e in eves)
                    {
                        int eventCheck = e.id;
                        if(eventCheck > 80000)
                        {
                            AddEvent(e);
                        }
                        
                    }
                }
            }
        }

        //public Event GetEvent(int eventID)
        //{
        //    Event even = _context.Event.Where(w => w.EventID == eventID).FirstOrDefault();
        //    return even;
        //}

        public void AddEvent(FGOEvent even)
        {
            _context.Add(even);
            _context.SaveChanges();
        }

        public List<FGOEvent> GetEventList()
        {
            var result = _context.Event.ToList();
            return result;
        }
    }
}
