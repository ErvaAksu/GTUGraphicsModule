using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.API.Business.Concrete;
using GTUGraphicsModule.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTUGraphicsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kalite_PerformansGostergeTanim_RevizyonController : ControllerBase
    {
        private readonly IKalite_PerformansGostergeTanim_RevizyonBusiness _kalite_PerformansGostergeTanim_RevizyonBusiness;

        public Kalite_PerformansGostergeTanim_RevizyonController(IKalite_PerformansGostergeTanim_RevizyonBusiness kalite_PerformansGostergeTanim_RevizyonBusiness)
        {
            _kalite_PerformansGostergeTanim_RevizyonBusiness = kalite_PerformansGostergeTanim_RevizyonBusiness;
        }


        [HttpGet("{id}")]
        public async Task<Kalite_PerformansGostergeTanim_Revizyon> Get(int id)
        {
            return await _kalite_PerformansGostergeTanim_RevizyonBusiness.Get(o => o._ef_gereksinimi_icin_id.Equals(id), o => o.Kalite_PerformansGostergeHedeflenenDeger);
        }

        [HttpGet]

        public async Task<IEnumerable<Kalite_PerformansGostergeTanim_Revizyon>> GetAll()
        {
            return await _kalite_PerformansGostergeTanim_RevizyonBusiness.GetAll();
        }

        [HttpPost]
        public async Task<Kalite_PerformansGostergeTanim_Revizyon> Add(Kalite_PerformansGostergeTanim_Revizyon kalite_PerformansGostergeTanim_Revizyon)
        {
            return await _kalite_PerformansGostergeTanim_RevizyonBusiness.Add(kalite_PerformansGostergeTanim_Revizyon);
        }

        [HttpDelete]
        public async Task<Kalite_PerformansGostergeTanim_Revizyon> Delete(int id)
        {
            var result = await _kalite_PerformansGostergeTanim_RevizyonBusiness.Get(o => o._ef_gereksinimi_icin_id.Equals(id));
            return await _kalite_PerformansGostergeTanim_RevizyonBusiness.Update(result);
        }

        [HttpPut]
        public async Task<Kalite_PerformansGostergeTanim_Revizyon> Update(Kalite_PerformansGostergeTanim_Revizyon kalite_PerformansGostergeTanim_Revizyon)
        {

            return await _kalite_PerformansGostergeTanim_RevizyonBusiness.Update(kalite_PerformansGostergeTanim_Revizyon);
        }
    }
}
