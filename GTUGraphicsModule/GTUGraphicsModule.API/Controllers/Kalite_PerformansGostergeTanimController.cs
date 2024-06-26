using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTUGraphicsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kalite_PerformansGostergeTanimController : ControllerBase
    {
        private readonly IKalite_PerformansGostergeTanimBusiness _kalite_PerformansGostergeTanimBusiness;

        public Kalite_PerformansGostergeTanimController(IKalite_PerformansGostergeTanimBusiness kalite_PerformansGostergeTanimBusiness)
        {
            _kalite_PerformansGostergeTanimBusiness = kalite_PerformansGostergeTanimBusiness;
        }


        [HttpGet]
        [Route("GetTanim")]
        public async Task<Kalite_PerformansGostergeTanim> Get(int id)
        {
            return await _kalite_PerformansGostergeTanimBusiness.Get(o => o.id.Equals(id));
        }

        [HttpGet]

        public async Task<IEnumerable<Kalite_PerformansGostergeTanim>> GetAll()
        {
            return await _kalite_PerformansGostergeTanimBusiness.GetAll();
        }

        [HttpPost]
        public async Task<Kalite_PerformansGostergeTanim> Add(Kalite_PerformansGostergeTanim kalite_PerformansGostergeTanim)
        {
            return await _kalite_PerformansGostergeTanimBusiness.Add(kalite_PerformansGostergeTanim);
        }

        [HttpDelete]
        public async Task<Kalite_PerformansGostergeTanim> Delete(int id)
        {
            var result = await _kalite_PerformansGostergeTanimBusiness.Get(o => o.id.Equals(id));
            return await _kalite_PerformansGostergeTanimBusiness.Update(result);
        }

        [HttpPut]
        public async Task<Kalite_PerformansGostergeTanim> Update(Kalite_PerformansGostergeTanim kalite_PerformansGostergeTanim)
        {

            return await _kalite_PerformansGostergeTanimBusiness.Update(kalite_PerformansGostergeTanim);
        }
    }
}
