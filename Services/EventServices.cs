using FGO_CE_Manager.Data;
using FGO_CE_Manager.Data.CEModels;
using FGO_CE_Manager.Data.EventModels;
using Newtonsoft.Json;

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


        public async void FillEventData()
        {
            using (var httpClient = new HttpClient())
            {
                var jsonStream = await httpClient.GetStreamAsync(apiLink);
                using (StreamReader r = new StreamReader(jsonStream))
                {
                    string json = r.ReadToEnd();
                    {
                        var even = JsonConvert.DeserializeObject<List<Event>>(json);
                        foreach (var ev in even)
                        {                              
                            AddEvent(ev);
                        }
                    }
                }
            }
        }

        public Event GetEvent(int eventID)
        {
            Event even = _context.Event.Where(w => w.EventID == eventID).FirstOrDefault();
            return even;
        }

        public void AddEvent(Event even)
        {
            _context.Add(even);
            _context.SaveChanges();
        }
    }
}
