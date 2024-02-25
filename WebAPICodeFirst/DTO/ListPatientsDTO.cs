using WebAPICodeFirst.Model;

namespace WebAPICodeFirst.DTO
{
    public class ListPatientsDTO
    {
        public ListPatientsDTO()
        {
            Hastalar = new List<Hasta>();
        }
        public List<Hasta>Hastalar {  get; set; }

        
    }
}
