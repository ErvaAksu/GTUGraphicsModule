using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTUGraphicsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kalite_BirimController : ControllerBase
    {

        private readonly IKalite_BirimBusiness _kalite_BirimBusiness;

        public Kalite_BirimController(IKalite_BirimBusiness kalite_BirimBusiness)
        {
            _kalite_BirimBusiness = kalite_BirimBusiness;
        }


        [HttpGet("{id}")]
        public async Task<Kalite_Birim> Get(int id)
        {
            return await _kalite_BirimBusiness.Get(o => o.Id.Equals(id));
        }


        [Route("GetAll")]
        [HttpGet]

        public async Task<IEnumerable<Kalite_Birim>> GetAll()
        {
            return await _kalite_BirimBusiness.GetAll();
        }

        [HttpPost]
        public async Task<Kalite_Birim> Add(Kalite_Birim kalite_VeriKategorileri)
        {
            return await _kalite_BirimBusiness.Add(kalite_VeriKategorileri);
        }

        [HttpDelete]
        public async Task<Kalite_Birim> Delete(int id)
        {
            var result = await _kalite_BirimBusiness.Get(o => o.Id.Equals(id));
            return await _kalite_BirimBusiness.Update(result);
        }

        [HttpPut]
        public async Task<Kalite_Birim> Update(Kalite_Birim kalite_Birim)
        {

            return await _kalite_BirimBusiness.Update(kalite_Birim);
        }

    }
}
