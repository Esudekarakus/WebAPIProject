namespace WebAPICodeFirst.Model
{
    public class Hastane:BaseEntity
    {
        public Hastane()
        {
            Hastalar = new List<Hasta>();
        }
        public string HastaneAd { get; set; }
        public string Adres { get; set; }

        public List<Hasta> Hastalar { get; set; }
    }
}
