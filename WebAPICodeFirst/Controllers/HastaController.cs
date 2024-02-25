using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICodeFirst.Context;
using WebAPICodeFirst.DTO;
using WebAPICodeFirst.Model;




namespace WebAPICodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaController : ControllerBase
    {
        private readonly HastaneDbContext dbContext;
        private readonly IMapper mapper;

        public HastaController(HastaneDbContext dbContext,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("GetAllPatients")]
        public IActionResult GetAllPatients()
        {
            ListPatientsDTO listPatientsDTO = new ListPatientsDTO()
            {
                Hastalar = dbContext.Hastalar.ToList()
            };
            return Ok(listPatientsDTO);
        }

        [HttpGet]
        [Route("GetPatientById")]
        public IActionResult GetPatientById(int id)
        {
           Hasta hasta= dbContext.Hastalar.FirstOrDefault(h => h.Id == id);
           if(hasta!=null)
                return Ok(hasta);

           return NotFound();
        }
        //[HttpPost]
        //[Route("AddPatient")]
        //public ActionResult Add(HastaDTO hastadto)
        //{
        //    Hasta hasta=mapper.Map<Hasta>(hastadto);

        //}
    }
}
