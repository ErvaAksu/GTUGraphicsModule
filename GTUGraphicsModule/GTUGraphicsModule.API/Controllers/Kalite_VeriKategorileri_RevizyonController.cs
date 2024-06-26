using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.API.Business.Concrete;
using GTUGraphicsModule.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTUGraphicsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kalite_VeriKategorileri_RevizyonController : ControllerBase
    {
        private readonly IKalite_VeriKategorileri_RevizyonBusiness _kalite_VeriKategorileri_RevizyonBusiness;

        public Kalite_VeriKategorileri_RevizyonController(IKalite_VeriKategorileri_RevizyonBusiness kalite_VeriKategorileri_RevizyonBusiness)
        {
            _kalite_VeriKategorileri_RevizyonBusiness = kalite_VeriKategorileri_RevizyonBusiness;
        }


        [HttpGet("{id}")]
        public async Task<Kalite_VeriKategorileri_Revizyon> Get(int id)
        {
            return await _kalite_VeriKategorileri_RevizyonBusiness.Get(o => o.ef_gereksininmi_icin_id.Equals(id));
        }

        [HttpGet]

        public async Task<IEnumerable<Kalite_VeriKategorileri_Revizyon>> GetAll()
        {
            return await _kalite_VeriKategorileri_RevizyonBusiness.GetAll();
        }

        [HttpPost]
        public async Task<Kalite_VeriKategorileri_Revizyon> Add(Kalite_VeriKategorileri_Revizyon kalite_VeriKategorileri_Revizyon)
        {
            return await _kalite_VeriKategorileri_RevizyonBusiness.Add(kalite_VeriKategorileri_Revizyon);
        }

        [HttpDelete]
        public async Task<Kalite_VeriKategorileri_Revizyon> Delete(int id)
        {
            var result = await _kalite_VeriKategorileri_RevizyonBusiness.Get(o => o.ef_gereksininmi_icin_id.Equals(id));
            return await _kalite_VeriKategorileri_RevizyonBusiness.Update(result);
        }

        [HttpPut]
        public async Task<Kalite_VeriKategorileri_Revizyon> Update(Kalite_VeriKategorileri_Revizyon kalite_VeriKategorileri_Revizyon)
        {

            return await _kalite_VeriKategorileri_RevizyonBusiness.Update(kalite_VeriKategorileri_Revizyon);
        }
    }
}
