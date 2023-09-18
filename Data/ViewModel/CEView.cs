
namespace FGO_CE_Manager.Data.ViewModel
{
    public class CEView
    {

        public int CECollectionNo { get; set; }
        public string CEName { get; set; }
        public string ImageUriGraph { get; set; }
        public string ImageFace { get; set; }
        public ICollection<string> EventNames { get; set; }
    }
}
