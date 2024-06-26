using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.API.Context;
using GTUGraphicsModule.Core.DataAccess;
using GTUGraphicsModule.Core.EntityFramework;
using GTUGraphicsModule.Models.Models;
using System.Linq.Expressions;

namespace GTUGraphicsModule.API.Business.Concrete
{
    public class Kalite_PerformansGostergeTanimBusiness : EntityRepository<Kalite_PerformansGostergeTanim>, IKalite_PerformansGostergeTanimBusiness
    {
        private readonly GTUGraphicsModuleDbContext _context;
        public Kalite_PerformansGostergeTanimBusiness(GTUGraphicsModuleDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
