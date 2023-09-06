using FGO_CE_Manager.Data;
using FGO_CE_Manager.Data.CEModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace FGO_CE_Manager.Services
{
    public class CEServices
    {
        const string apiLink = @"https://api.atlasacademy.io/export/NA/nice_equip.json";

        private ApplicationDbContext _context { get; set; }
        public CEServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async void FillCEDatabase()
        {
            
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStreamAsync(apiLink);
                DeserializeJson(jsonString);
            }
           
        }

        public void DeserializeJson(Stream stream)
        {
            using (StreamReader r = new StreamReader(stream))
            {
                string json = r.ReadToEnd();
                {
                    var ces = JsonConvert.DeserializeObject<List<CE>>(json);
                    foreach (var c in ces)
                    {
                        foreach (var equip in c.ExtraAssets.CharaGraph.Equip)
                        {
                            c.ExtraAssets.CharaGraph.ImageUri = equip.Value.ToString();
                        }
                        foreach (var equip in c.ExtraAssets.Faces.Equip)
                        {
                            c.ExtraAssets.Faces.ImageUri = equip.Value.ToString();
                        }

                        AddCE(c);
                    }
                }
            }
        }

        public IEnumerable<CE> GetEventCEList()
        {
            IEnumerable<CE> data = (from ce in _context.CE
                                   from skill in ce.Skills
                                   from function in skill.Functions
                                   from sval in function.Svals
                                   where sval.EventID != null
                                   select ce).Include(i => i.Skills).ThenInclude(ti => ti.Functions).ThenInclude(ti => ti.Svals).Distinct().ToList();

            return data;
        }

        public IEnumerable<CE> GetSpecificEventCEList(int eventID)
        {
            IEnumerable<CE> data = (from ce in _context.CE
                                    from skill in ce.Skills
                                    from function in skill.Functions
                                    from sval in function.Svals
                                    where sval.EventID == eventID
                                    select ce).Include(i => i.Skills).ThenInclude(ti => ti.Functions).ThenInclude(ti => ti.Svals).Distinct().ToList();

            return data;
        }

        public void AddCE(CE ce)
        {
            _context.Add(ce);
            _context.SaveChanges();
        }

        public CE GetCE(Guid id)
        {
            CE result = _context.CE.Where(w => w.Guid == id).FirstOrDefault();
            return result;
        }
        public CE GetCE(int id)
        {
            CE result = _context.CE.Where(w => w.ID == id).FirstOrDefault();
            return result;
        }

        public async void UpdateDatabase(List<CE> cest)
        {
            using (var httpClient = new HttpClient())
            {
                var jsonStream = await httpClient.GetStreamAsync(apiLink);
                using (StreamReader r = new StreamReader(jsonStream))
                {
                    string json = r.ReadToEnd();
                    {
                        var ces = JsonConvert.DeserializeObject<List<CE>>(json);
                        foreach (var c in ces)
                        {
                            
                            if(_context.CE.FirstOrDefault(f => f.ID == c.ID) == null)
                            {
                                foreach (var equip in c.ExtraAssets.CharaGraph.Equip)
                                {
                                    c.ExtraAssets.CharaGraph.ImageUri = equip.Value.ToString();
                                }
                                foreach (var equip in c.ExtraAssets.Faces.Equip)
                                {
                                    c.ExtraAssets.Faces.ImageUri = equip.Value.ToString();
                                }

                                AddCE(c);
                            }

                        }
                    }
                }
            }
        }
    }
}
