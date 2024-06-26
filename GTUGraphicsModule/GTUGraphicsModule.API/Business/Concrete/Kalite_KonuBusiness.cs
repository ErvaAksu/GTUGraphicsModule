using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.API.Context;
using GTUGraphicsModule.Core.EntityFramework;
using GTUGraphicsModule.Models.Models;

namespace GTUGraphicsModule.API.Business.Concrete
{
    public class Kalite_KonuBusiness : EntityRepository<Kalite_Konu>, IKalite_KonuBusiness
    {

        private readonly GTUGraphicsModuleDbContext _context;
        public Kalite_KonuBusiness(GTUGraphicsModuleDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
