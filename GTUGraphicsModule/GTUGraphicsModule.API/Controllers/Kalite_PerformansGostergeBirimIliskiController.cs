using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTUGraphicsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kalite_PerformansGostergeBirimIliskiController : ControllerBase
    {
        private readonly IKalite_PerformansGostergeBirimIliskiBusiness _kalite_PerformansGostergeBirimIliskiBusiness;

        public Kalite_PerformansGostergeBirimIliskiController(IKalite_PerformansGostergeBirimIliskiBusiness kalite_PerformansGostergeBirimIliskiBusiness)
        {
            _kalite_PerformansGostergeBirimIliskiBusiness = kalite_PerformansGostergeBirimIliskiBusiness;
        }


        [HttpGet("{id}")]
        public async Task<Kalite_PerformansGostergeBirimIliski> Get(int id)
        {
            return await _kalite_PerformansGostergeBirimIliskiBusiness.Get(o => o.ef_gereksinimi_icin_id.Equals(id));
        }

        [HttpGet]

        public async Task<IEnumerable<Kalite_PerformansGostergeBirimIliski>> GetAll()
        {
            return await _kalite_PerformansGostergeBirimIliskiBusiness.GetAll();
        }

        [HttpPost]
        public async Task<Kalite_PerformansGostergeBirimIliski> Add(Kalite_PerformansGostergeBirimIliski kalite_PerformansGostergeBirimIliski)
        {
            return await _kalite_PerformansGostergeBirimIliskiBusiness.Add(kalite_PerformansGostergeBirimIliski);
        }

        [HttpDelete]
        public async Task<Kalite_PerformansGostergeBirimIliski> Delete(int id)
        {
            var result = await _kalite_PerformansGostergeBirimIliskiBusiness.Get(o => o.ef_gereksinimi_icin_id.Equals(id));
            return await _kalite_PerformansGostergeBirimIliskiBusiness.Update(result);
        }

        [HttpPut]
        public async Task<Kalite_PerformansGostergeBirimIliski> Update(Kalite_PerformansGostergeBirimIliski kalite_PerformansGostergeBirimIliski)
        {

            return await _kalite_PerformansGostergeBirimIliskiBusiness.Update(kalite_PerformansGostergeBirimIliski);
        }
    }
}
