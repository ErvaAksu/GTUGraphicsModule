using GTUGraphicsModule.API.Business.Concrete;
using GTUGraphicsModule.Core.DataAccess;
using GTUGraphicsModule.Models.Models;
using GTUGraphicsModule.Models.Models.ViewModels;
using System.Linq.Expressions;

namespace GTUGraphicsModule.API.Business.Abstract
{
    public interface IKalite_PerformansGostergeVeriKategorisiIliskiBusiness : IEntityRepository<Kalite_PerformansGostergeVeriKategorisiIliski>
    {

        public Task<List<PerformansGostergeVeriKategorisiVM>> GetPerformansVeri();
        public Task<List<PerformansGostergeBirimVM>> GetBirimVeri(int BirimId);
        public Task<List<PerformansGostergeKonuVM>> GetKonuVeri(int KonuId);

    }
}
