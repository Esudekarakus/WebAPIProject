namespace WebAPICodeFirst.Model
{
    public class Hasta:BaseEntity
    {
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Klinik { get; set; }
        public DateTime MuayeneTarihi { get; set; }
        public Hastane Hastane { get; set; }
        public int HastaneId { get; set; }
       
    }
}
