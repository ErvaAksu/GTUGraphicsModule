using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTUGraphicsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kalite_KonuController : ControllerBase
    {

        private readonly IKalite_KonuBusiness _kalite_KonuBusiness;

        public Kalite_KonuController(IKalite_KonuBusiness kalite_KonuBusiness)
        {
            _kalite_KonuBusiness = kalite_KonuBusiness;
        }


        [HttpGet("{id}")]
        public async Task<Kalite_Konu> Get(int id)
        {
            return await _kalite_KonuBusiness.Get(o => o.Id.Equals(id));
        }


        [Route("GetAll")]
        [HttpGet]

        public async Task<IEnumerable<Kalite_Konu>> GetAll()
        {
            return await _kalite_KonuBusiness.GetAll();
        }

        [HttpPost]
        public async Task<Kalite_Konu> Add(Kalite_Konu kalite_Konu)
        {
            return await _kalite_KonuBusiness.Add(kalite_Konu);
        }

        [HttpDelete]
        public async Task<Kalite_Konu> Delete(int id)
        {
            var result = await _kalite_KonuBusiness.Get(o => o.Id.Equals(id));
            return await _kalite_KonuBusiness.Update(result);
        }

        [HttpPut]
        public async Task<Kalite_Konu> Update(Kalite_Konu kalite_Konu)
        {

            return await _kalite_KonuBusiness.Update(kalite_Konu);
        }

    }
}
