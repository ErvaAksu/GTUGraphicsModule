using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.API.Context;
using GTUGraphicsModule.Core.DataAccess;
using GTUGraphicsModule.Core.EntityFramework;
using GTUGraphicsModule.Models.Models;
using System.Linq.Expressions;

namespace GTUGraphicsModule.API.Business.Concrete
{
    public class Kalite_PerformansGostergeHedeflenenDegerBusiness : EntityRepository<Kalite_PerformansGostergeHedeflenenDeger>, IKalite_PerformansGostergeHedeflenenDegerBusiness
    {
        private readonly GTUGraphicsModuleDbContext _context;
        public Kalite_PerformansGostergeHedeflenenDegerBusiness(GTUGraphicsModuleDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
