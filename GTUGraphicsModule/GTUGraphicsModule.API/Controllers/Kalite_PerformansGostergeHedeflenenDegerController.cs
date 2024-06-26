using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTUGraphicsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kalite_PerformansGostergeHedeflenenDegerController : ControllerBase
    {
        private readonly IKalite_PerformansGostergeHedeflenenDegerBusiness _kalite_PerformansGostergeHedeflenenDegerBusiness;

        public Kalite_PerformansGostergeHedeflenenDegerController(IKalite_PerformansGostergeHedeflenenDegerBusiness kalite_PerformansGostergeHedeflenenDegerBusiness)
        {
            _kalite_PerformansGostergeHedeflenenDegerBusiness = kalite_PerformansGostergeHedeflenenDegerBusiness;
        }


        [HttpGet("{id}")]
        public async Task<Kalite_PerformansGostergeHedeflenenDeger> Get(int id)
        {
            return await _kalite_PerformansGostergeHedeflenenDegerBusiness.Get(o => o.performans_gosterge_id.Equals(id), o => o.Kalite_PerformansGostergeGerceklesenDeger);
        }

        [HttpGet]

        public async Task<IEnumerable<Kalite_PerformansGostergeHedeflenenDeger>> GetAll()
        {
            return await _kalite_PerformansGostergeHedeflenenDegerBusiness.GetAll();
        }

        [HttpPost]
        public async Task<Kalite_PerformansGostergeHedeflenenDeger> Add(Kalite_PerformansGostergeHedeflenenDeger kalite_PerformansGostergeHedeflenenDeger)
        {
            return await _kalite_PerformansGostergeHedeflenenDegerBusiness.Add(kalite_PerformansGostergeHedeflenenDeger);
        }

        [HttpDelete]
        public async Task<Kalite_PerformansGostergeHedeflenenDeger> Delete(int id)
        {
            var result = await _kalite_PerformansGostergeHedeflenenDegerBusiness.Get(o => o.performans_gosterge_id.Equals(id));
            return await _kalite_PerformansGostergeHedeflenenDegerBusiness.Update(result);
        }

        [HttpPut]
        public async Task<Kalite_PerformansGostergeHedeflenenDeger> Update(Kalite_PerformansGostergeHedeflenenDeger kalite_PerformansGostergeHedeflenenDeger)
        {

            return await _kalite_PerformansGostergeHedeflenenDegerBusiness.Update(kalite_PerformansGostergeHedeflenenDeger);
        }
    }
}
