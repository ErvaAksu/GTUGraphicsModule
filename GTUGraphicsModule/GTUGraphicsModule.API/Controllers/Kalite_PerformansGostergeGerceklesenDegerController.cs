using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTUGraphicsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kalite_PerformansGostergeGerceklesenDegerController : ControllerBase
    {
        private readonly IKalite_PerformansGostergeGerceklesenDegerBusiness _kalite_PerformansGostergeGerceklesenDegerBusiness;

        public Kalite_PerformansGostergeGerceklesenDegerController(IKalite_PerformansGostergeGerceklesenDegerBusiness kalite_PerformansGostergeGerceklesenDegerBusiness)
        {
            _kalite_PerformansGostergeGerceklesenDegerBusiness = kalite_PerformansGostergeGerceklesenDegerBusiness;
        }


        [HttpGet("{id}")]
        public async Task<Kalite_PerformansGostergeGerceklesenDeger> Get(int id)
        {
            return await _kalite_PerformansGostergeGerceklesenDegerBusiness.Get(o => o.periyod.Equals(id));
        }

        [HttpGet]

        public async Task<IEnumerable<Kalite_PerformansGostergeGerceklesenDeger>> GetAll()
        {
            return await _kalite_PerformansGostergeGerceklesenDegerBusiness.GetAll();
        }

        [HttpPost]
        public async Task<Kalite_PerformansGostergeGerceklesenDeger> Add(Kalite_PerformansGostergeGerceklesenDeger kalite_PerformansGostergeGerceklesenDeger)
        {
            return await _kalite_PerformansGostergeGerceklesenDegerBusiness.Add(kalite_PerformansGostergeGerceklesenDeger);
        }

        [HttpDelete]
        public async Task<Kalite_PerformansGostergeGerceklesenDeger> Delete(int id)
        {
            var result = await _kalite_PerformansGostergeGerceklesenDegerBusiness.Get(o => o.periyod.Equals(id));
            return await _kalite_PerformansGostergeGerceklesenDegerBusiness.Update(result);
        }

        [HttpPut]
        public async Task<Kalite_PerformansGostergeGerceklesenDeger> Update(Kalite_PerformansGostergeGerceklesenDeger kalite_PerformansGostergeGerceklesenDeger)
        {

            return await _kalite_PerformansGostergeGerceklesenDegerBusiness.Update(kalite_PerformansGostergeGerceklesenDeger);
        }
    }
}
