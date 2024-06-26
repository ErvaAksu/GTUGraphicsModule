using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.API.Context;
using GTUGraphicsModule.Core.DataAccess;
using GTUGraphicsModule.Models.Models;
using System.Linq.Expressions;
using GTUGraphicsModule.Core.EntityFramework;

namespace GTUGraphicsModule.API.Business.Concrete
{
    public class Kalite_PerformansGostergeGerceklesenDegerBusiness : EntityRepository<Kalite_PerformansGostergeGerceklesenDeger> ,IKalite_PerformansGostergeGerceklesenDegerBusiness
    {
        private readonly GTUGraphicsModuleDbContext _context;
        public Kalite_PerformansGostergeGerceklesenDegerBusiness(GTUGraphicsModuleDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
