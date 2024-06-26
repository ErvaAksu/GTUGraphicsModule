using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTUGraphicsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kalite_PerformansGostergeKonuIliskiController : ControllerBase
    {
        private readonly IKalite_PerformansGostergeKonuIliskiBusiness _kalite_PerformansGostergeKonuIliskiBusiness;

        public Kalite_PerformansGostergeKonuIliskiController(IKalite_PerformansGostergeKonuIliskiBusiness kalite_PerformansGostergeKonuIliskiBusiness)
        {
            _kalite_PerformansGostergeKonuIliskiBusiness = kalite_PerformansGostergeKonuIliskiBusiness;
        }


        [HttpGet("{id}")]
        public async Task<Kalite_PerformansGostergeKonuIliski> Get(int id)
        {
            return await _kalite_PerformansGostergeKonuIliskiBusiness.Get(o => o.ef_gereksinimi_icin_id.Equals(id));
        }

        [HttpGet]

        public async Task<IEnumerable<Kalite_PerformansGostergeKonuIliski>> GetAll()
        {
            return await _kalite_PerformansGostergeKonuIliskiBusiness.GetAll();
        }

        [HttpPost]
        public async Task<Kalite_PerformansGostergeKonuIliski> Add(Kalite_PerformansGostergeKonuIliski kalite_PerformansGostergeKonuIliski)
        {
            return await _kalite_PerformansGostergeKonuIliskiBusiness.Add(kalite_PerformansGostergeKonuIliski);
        }

        [HttpDelete]
        public async Task<Kalite_PerformansGostergeKonuIliski> Delete(int id)
        {
            var result = await _kalite_PerformansGostergeKonuIliskiBusiness.Get(o => o.ef_gereksinimi_icin_id.Equals(id));
            return await _kalite_PerformansGostergeKonuIliskiBusiness.Update(result);
        }

        [HttpPut]
        public async Task<Kalite_PerformansGostergeKonuIliski> Update(Kalite_PerformansGostergeKonuIliski kalite_PerformansGostergeKonuIliski)
        {

            return await _kalite_PerformansGostergeKonuIliskiBusiness.Update(kalite_PerformansGostergeKonuIliski);
        }
    }
}
