using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.API.Context;
using GTUGraphicsModule.Core.DataAccess;
using GTUGraphicsModule.Core.EntityFramework;
using GTUGraphicsModule.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GTUGraphicsModule.API.Business.Concrete
{
    public class Kalite_PerformansGostergeBirimIliskiBusiness : EntityRepository<Kalite_PerformansGostergeBirimIliski>, IKalite_PerformansGostergeBirimIliskiBusiness
    {
        private readonly IKalite_PerformansGostergeTanimBusiness _PerformansGostergeTanimBusiness;
        private readonly GTUGraphicsModuleDbContext _context;
        public Kalite_PerformansGostergeBirimIliskiBusiness(GTUGraphicsModuleDbContext context, IKalite_PerformansGostergeTanimBusiness performansGostergeTanimBusiness) : base(context)
        {
            _PerformansGostergeTanimBusiness = performansGostergeTanimBusiness;
            _context = context;
        }

        
        
    }
}
