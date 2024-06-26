using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.Models.Models;
using GTUGraphicsModule.Models.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTUGraphicsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kalite_PerformansGostergeVeriKategorisiIliskiController : ControllerBase
    {
        private readonly IKalite_PerformansGostergeVeriKategorisiIliskiBusiness _kalite_PerformansGostergeVeriKategorisiIliski;

        public Kalite_PerformansGostergeVeriKategorisiIliskiController(IKalite_PerformansGostergeVeriKategorisiIliskiBusiness kalite_PerformansGostergeVeriKategorisiIliski)
        {
            _kalite_PerformansGostergeVeriKategorisiIliski = kalite_PerformansGostergeVeriKategorisiIliski;
        }


        [HttpGet("{id}")]
        public async Task<Kalite_PerformansGostergeVeriKategorisiIliski> Get(int id)
        {
            return await _kalite_PerformansGostergeVeriKategorisiIliski.Get(o => o.ef_gereksinimi_icin_id.Equals(id));
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Kalite_PerformansGostergeVeriKategorisiIliski>> GetAll()
        {
            return await _kalite_PerformansGostergeVeriKategorisiIliski.GetAll();
        }

        [HttpPost]
        public async Task<Kalite_PerformansGostergeVeriKategorisiIliski> Add(Kalite_PerformansGostergeVeriKategorisiIliski kalite_PerformansGostergeVeriKategorisiIliski)
        {
            return await _kalite_PerformansGostergeVeriKategorisiIliski.Add(kalite_PerformansGostergeVeriKategorisiIliski);
        }

        [HttpDelete]
        public async Task<Kalite_PerformansGostergeVeriKategorisiIliski> Delete(int id)
        {
            var result = await _kalite_PerformansGostergeVeriKategorisiIliski.Get(o => o.ef_gereksinimi_icin_id.Equals(id));
            return await _kalite_PerformansGostergeVeriKategorisiIliski.Update(result);
        }

        [HttpPut]
        public async Task<Kalite_PerformansGostergeVeriKategorisiIliski> Update(Kalite_PerformansGostergeVeriKategorisiIliski kalite_PerformansGostergeVeriKategorisiIliski)
        {

            return await _kalite_PerformansGostergeVeriKategorisiIliski.Update(kalite_PerformansGostergeVeriKategorisiIliski);
        }

        [HttpGet]
        [Route("GetPerformansVeri")]
        public async Task<List<PerformansGostergeVeriKategorisiVM>> GetPerformansVeri()
        {

            return await _kalite_PerformansGostergeVeriKategorisiIliski.GetPerformansVeri();

        }

        [HttpGet("GetBirimVeri/{BirimId}")]
        //[Route("GetBirimVeri")]
        public async Task<List<PerformansGostergeBirimVM>> GetBirimVeri(int BirimId)
        {

            return await _kalite_PerformansGostergeVeriKategorisiIliski.GetBirimVeri(BirimId);

        }

        [HttpGet("GetKonuVeri/{KonuId}")]
        //[Route("GetBirimVeri")]
        public async Task<List<PerformansGostergeKonuVM>> GetPerformansKonu(int KonuId)
        {

            return await _kalite_PerformansGostergeVeriKategorisiIliski.GetKonuVeri(KonuId);

        }


    }
}
