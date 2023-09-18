using Azure.Core.GeoJson;
using FGO_CE_Manager.Data;
using FGO_CE_Manager.Data.CEModels;
using FGO_CE_Manager.Data.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


        public async Task FillCEDatabase()
        {
            
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStreamAsync(apiLink);
                DeserializeJson(jsonString);
            }
           
        }
        public void CleanDB()
        {

            _context.Database.ExecuteSqlRaw("Delete From Sval");
            _context.Database.ExecuteSqlRaw("Delete From \"Event\"");
            _context.Database.ExecuteSqlRaw("Delete From \"Function\"");
            _context.Database.ExecuteSqlRaw("Delete From Skill");
            _context.Database.ExecuteSqlRaw("Delete From CharaGraph");
            _context.Database.ExecuteSqlRaw("Delete From Faces");
            _context.Database.ExecuteSqlRaw("Delete From ExtraAssets");
            _context.Database.ExecuteSqlRaw("Delete From CE");
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

                        int? svarCheck = RemoveSkillDuplicates(c);

                        if(svarCheck != null)
                        {
                            AddCE(c);
                        }
                        
                    }
                }
            }
        }
        public int? RemoveSvalsDuplicates(Skills_Function function)
        {
            int? svalEventID = null;
            List<Functions_Sval> duplicateFilterList = new();
            foreach (var sval in function.Svals.ToList())
            {
                //removes empty values
                if (sval.EventID == null)
                {
                    function.Svals.Remove(sval);
                }

                else
                {
                    svalEventID = CheckForSvalDuplicates(sval, duplicateFilterList, function);
                }
            }
            return svalEventID;
        }
        public int? CheckForSvalDuplicates(Functions_Sval sval, List<Functions_Sval> duplicateFilterList, Skills_Function function)
        {
            int? svalEventID = null;
            sval.FGOEvent = _context.Event
                .Where(e => e.id == sval.EventID)
                .FirstOrDefault();
            svalEventID = sval.EventID;
            if (duplicateFilterList.Any(s => s.EventID == svalEventID))
            {
                function.Svals.Remove(sval);
            }
            else
            {
                duplicateFilterList.Add(sval);
            }
            return svalEventID;
        }
        public int? RemoveFunctionDuplicates(CE_Skill skill)
        {
            List<int> duplicateFilterList = new();
            int? svalEventID = null;

            foreach (var function in skill.Functions.ToList())
            {
                svalEventID = RemoveSvalsDuplicates(function);
                //removes empty values
                if (svalEventID == null || duplicateFilterList.Contains((int)svalEventID))
                {
                    skill.Functions.Remove(function);
                }
                else
                {
                    duplicateFilterList.Add((int)svalEventID);
                }
                
            }
            return svalEventID;
        }
        public int? RemoveSkillDuplicates(CE c)
        {

            int? svalEventID= null;
            List<int> duplicateFilterList = new();
            foreach (var skill in c.Skills.ToList())
            {
                svalEventID = RemoveFunctionDuplicates(skill);
                //removes empty values
                if (svalEventID == null || duplicateFilterList.Contains((int)svalEventID))
                {
                    c.Skills.Remove(skill);
                }
                else
                {
                    duplicateFilterList.Add((int)svalEventID);
                }

            }
            return svalEventID;
        }

        public IEnumerable<CEView> GetEventCEList()
        {
            IEnumerable<CE> data = (from ce in _context.CE
                                   from skill in ce.Skills
                                   from function in skill.Functions
                                   from sval in function.Svals
                                   where sval.FGOEvent != null
                                   select ce).Include(i => i.ExtraAssets).ThenInclude(e => e.CharaGraph)
                                   .Include(i => i.ExtraAssets).ThenInclude(e => e.Faces)
                                   .Include(i => i.Skills).ThenInclude(ti => ti.Functions).ThenInclude(ti => ti.Svals).ThenInclude(ti => ti.FGOEvent).Distinct().ToList();

            List<CEView> ceView = new List<CEView>(); 

            foreach(var ce in data)
            {
                CEView view = new();
                view.CEName = ce.Name;
                view.ImageUriGraph = ce.ExtraAssets.CharaGraph.ImageUri;
                view.ImageFace = ce.ExtraAssets.Faces.ImageUri;
                view.CECollectionNo = ce.CollectionNo;
                view.EventNames = (from c in ce.Skills
                                  from s in c.Functions
                                  from f in s.Svals
                                  select f.FGOEvent.Name).ToList();
                ceView.Add(view);
            }
            return ceView;
        }


        //TODO: change to incorporate Event Model
        //public IEnumerable<CE> GetSpecificEventCEList(int eventID)
        //{
        //    IEnumerable<CE> data = (from ce in _context.CE
        //                            from skill in ce.Skills
        //                            from function in skill.Functions
        //                            from sval in function.Svals
        //                            where sval.EventID == eventID
        //                            select ce).Include(i => i.Skills).ThenInclude(ti => ti.Functions).ThenInclude(ti => ti.Svals).Distinct().ToList();

        //    return data;
        //}

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
