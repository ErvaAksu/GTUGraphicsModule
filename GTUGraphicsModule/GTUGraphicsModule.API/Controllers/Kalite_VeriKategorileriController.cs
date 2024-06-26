using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.Models.Models;

namespace GTUGraphicsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kalite_VeriKategorileriController : ControllerBase
    {
        private readonly IKalite_VeriKategorileriBusiness _kalite_VeriKategorileriBusiness;

        public Kalite_VeriKategorileriController(IKalite_VeriKategorileriBusiness kalite_VeriKategorileriBusiness)
        {
            _kalite_VeriKategorileriBusiness = kalite_VeriKategorileriBusiness;
        }


        [HttpGet("{id}")]
        public async Task<Kalite_VeriKategorileri> Get(int id)
        {
            return await _kalite_VeriKategorileriBusiness.Get(o => o.id.Equals(id));
        }

        [HttpGet]

        public async Task<IEnumerable<Kalite_VeriKategorileri>> GetAll()
        {
            return await _kalite_VeriKategorileriBusiness.GetAll();
        }

        [HttpPost]
        public async Task<Kalite_VeriKategorileri> Add(Kalite_VeriKategorileri kalite_VeriKategorileri)
        {
            return await _kalite_VeriKategorileriBusiness.Add(kalite_VeriKategorileri);
        }

        [HttpDelete]
        public async Task<Kalite_VeriKategorileri> Delete(int id)
        {
            var result = await _kalite_VeriKategorileriBusiness.Get(o => o.id.Equals(id));
            return await _kalite_VeriKategorileriBusiness.Update(result);
        }

        [HttpPut]
        public async Task<Kalite_VeriKategorileri> Update(Kalite_VeriKategorileri kalite_VeriKategorileri)
        {

            return await _kalite_VeriKategorileriBusiness.Update(kalite_VeriKategorileri);
        }

    }
}
