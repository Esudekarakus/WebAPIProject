using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WebAPICodeFirst.Context;
using WebAPICodeFirst.DTO;
using WebAPICodeFirst.Model;

namespace WebAPICodeFirst.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HastaneController : ControllerBase
    {
        private readonly HastaneDbContext hastaneDbContext;

        public HastaneController(HastaneDbContext hastaneDbContext)
        {
            this.hastaneDbContext = hastaneDbContext;
        }

        [HttpGet]
        public IActionResult GetAllHospitals()
        {
            List<Hastane>hastaneler=hastaneDbContext.Hastaneler.ToList();
            return Ok(hastaneler);
        }


        [HttpGet]
        
        public IActionResult GetHospitalById(int id )
        {
            var hospital=hastaneDbContext.Hastaneler.FirstOrDefault(h=> h.Id == id);
            if(hospital != null)
            {
                return Ok(hospital);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult AddHospital(HastaneAddDto hastaneAdd)
        {
            if(hastaneAdd !=null)
            {
                Hastane hastane = new Hastane()
                {
                    Adres = hastaneAdd.Adres,
                    HastaneAd = hastaneAdd.HastaneAd,
                };
                hastaneDbContext.Hastaneler.Add(hastane);
                hastaneDbContext.SaveChanges();
                return Ok(hastane.HastaneAd);

            }
            return BadRequest("Hastane bilgileri boş");
            
            
        }
        [HttpDelete]
        public IActionResult DeleteHospital(int id)
        {
            Hastane hastaneDelete=hastaneDbContext.Hastaneler.FirstOrDefault(h=>h.Id == id);
            if(hastaneDelete != null)
            {
                hastaneDbContext.Hastaneler.Remove(hastaneDelete);
                hastaneDbContext.SaveChanges();
                return StatusCode(200,hastaneDelete);
            }
            else 
                return NotFound();
     
        }

        [HttpPut]
        public ActionResult<Hastane> UpdateHospital(HastaneUpdateDTO hastaneUpdate)
        {
            
            if(hastaneUpdate !=null)
            {
                Hastane hastane = hastaneDbContext.Hastaneler.FirstOrDefault(h => h.Id == hastaneUpdate.Id);
                hastane.Adres= hastaneUpdate.Adres;
                hastane.HastaneAd= hastaneUpdate.HastaneAd;
                hastaneDbContext.Hastaneler.Update(hastane);
                hastaneDbContext.SaveChanges();


                return hastane;
            }
            else { return NotFound(); }

        }
    }
}
