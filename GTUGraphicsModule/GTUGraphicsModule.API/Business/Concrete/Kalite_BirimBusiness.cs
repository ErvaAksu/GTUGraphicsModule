using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.API.Context;
using GTUGraphicsModule.Core.EntityFramework;
using GTUGraphicsModule.Models.Models;

namespace GTUGraphicsModule.API.Business.Concrete
{
    public class Kalite_BirimBusiness : EntityRepository<Kalite_Birim>, IKalite_BirimBusiness
    {

        private readonly GTUGraphicsModuleDbContext _context;
        public Kalite_BirimBusiness(GTUGraphicsModuleDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
