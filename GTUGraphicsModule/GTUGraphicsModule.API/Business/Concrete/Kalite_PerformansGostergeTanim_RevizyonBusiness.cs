using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.API.Context;
using GTUGraphicsModule.Core.DataAccess;
using GTUGraphicsModule.Core.EntityFramework;
using GTUGraphicsModule.Models.Models;
using System.Linq.Expressions;

namespace GTUGraphicsModule.API.Business.Concrete
{
    public class Kalite_PerformansGostergeTanim_RevizyonBusiness : EntityRepository<Kalite_PerformansGostergeTanim_Revizyon>, IKalite_PerformansGostergeTanim_RevizyonBusiness
    {
        private readonly GTUGraphicsModuleDbContext _context;
        public Kalite_PerformansGostergeTanim_RevizyonBusiness(GTUGraphicsModuleDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
