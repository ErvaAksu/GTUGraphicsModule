using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.API.Context;
using GTUGraphicsModule.Core.DataAccess;
using GTUGraphicsModule.Core.EntityFramework;
using GTUGraphicsModule.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GTUGraphicsModule.API.Business.Concrete
{
    public class Kalite_PerformansGostergeKonuIliskiBusiness : EntityRepository<Kalite_PerformansGostergeKonuIliski>, IKalite_PerformansGostergeKonuIliskiBusiness
    {
        private readonly GTUGraphicsModuleDbContext _context;
        public Kalite_PerformansGostergeKonuIliskiBusiness(GTUGraphicsModuleDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
