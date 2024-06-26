using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.API.Context;
using GTUGraphicsModule.Core.DataAccess;
using GTUGraphicsModule.Core.EntityFramework;
using GTUGraphicsModule.Models.Models;
using GTUGraphicsModule.Models.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace GTUGraphicsModule.API.Business.Concrete
{
    public class Kalite_PerformansGostergeVeriKategorisiIliskiBusiness : EntityRepository<Kalite_PerformansGostergeVeriKategorisiIliski>, IKalite_PerformansGostergeVeriKategorisiIliskiBusiness
    {
        private readonly GTUGraphicsModuleDbContext _context;
        public Kalite_PerformansGostergeVeriKategorisiIliskiBusiness(GTUGraphicsModuleDbContext context) : base(context)
        {
            _context = context;
        }

        /*
        public async Task<List<PerformansGostergeVM>> GetAllPerformansGosterge()
        {
            var performans_res = (from gostergeveri in _context.Kalite_PerformansGostergeVeriKategorisiIliski
                                  join performansgosterge in _context.Kalite_PerformansGostergeTanim_Revizyon on gostergeveri.performans_gosterge_id equals performansgosterge.performans_gosterge_tanim_id
                                  join hedeflenendeger in _context.Kalite_PerformansGostergeHedeflenenDeger on gostergeveri.performans_gosterge_id equals hedeflenendeger.performans_gosterge_id
                                  join gerceklesendeger in _context.Kalite_PerformansGostergeGerceklesenDeger on gostergeveri.performans_gosterge_id equals gerceklesendeger.performans_gosterge_id
                                  select new PerformansGostergeVM
                                  {

                                      PerformansGosterge = performansgosterge,
                                      HedeflenenDeger = hedeflenendeger,
                                      GerceklesenDeger = gerceklesendeger,

                                  }).ToList();

            return performans_res;

        }

        public async Task<List<VeriKategorisiVM>> GetAllVeriKategorisi()
        {



            var veri_res = (from gostergeveri in _context.Kalite_PerformansGostergeVeriKategorisiIliski
                                  join verikategorisi in _context.VeriKategorileri_Revizyon on gostergeveri.veri_kategorisi_id equals verikategorisi.veri_kategorisi_id
                                  select new VeriKategorisiVM
                                  {
                                      VeriKategorisi = verikategorisi
                                  }).ToList();

            return veri_res;

        }

        */

       
        public Task<List<PerformansGostergeVeriKategorisiVM>> GetPerformansVeri()
        {


            var result = (from gostergeveri in _context.Kalite_PerformansGostergeVeriKategorisiIliski
                          join veriKategorisi in _context.VeriKategorileri_Revizyon on gostergeveri.veri_kategorisi_id equals veriKategorisi.veri_kategorisi_id
                          join performansTanim in _context.Kalite_PerformansGostergeTanim on gostergeveri.performans_gosterge_id equals performansTanim.id
                          join performansRevizyon in _context.Kalite_PerformansGostergeTanim_Revizyon.Include(pr => pr.Kalite_PerformansGostergeHedeflenenDeger).ThenInclude(p => p.Kalite_PerformansGostergeGerceklesenDeger) on performansTanim.id equals performansRevizyon.performans_gosterge_tanim_id into revizyonList

                          select new PerformansGostergeVeriKategorisiVM
                          {
                              VeriKategorisi = veriKategorisi,
                              PerformansGostergeTanim = performansTanim,
                              PerformansGostergeleri = revizyonList.ToList()
                          }).ToListAsync();
            /*
            var res = from gostergeveri in _context.Kalite_PerformansGostergeVeriKategorisiIliski
                      join performansgosterge in _context.Kalite_PerformansGostergeTanim_Revizyon on gostergeveri.performans_gosterge_id equals performansgosterge.performans_gosterge_tanim_id
                      join verikategorisi in _context.VeriKategorileri_Revizyon on gostergeveri.veri_kategorisi_id equals verikategorisi.veri_kategorisi_id
                      join hedeflenendeger in _context.Kalite_PerformansGostergeHedeflenenDeger on gostergeveri.performans_gosterge_id equals hedeflenendeger.performans_gosterge_id
                      join gerceklesendeger in _context.Kalite_PerformansGostergeGerceklesenDeger on gostergeveri.performans_gosterge_id equals gerceklesendeger.performans_gosterge_id
                      select new PerformansGostergeVeriKategorisiVM
                      {

                          PerformansGosterge = performansgosterge,
                          VeriKategorisi = verikategorisi,
                          HedeflenenDeger = hedeflenendeger,
                          GerceklesenDeger= gerceklesendeger,

                      };
            */

            return result;
        }

        public async Task<List<PerformansGostergeBirimVM>> GetBirimVeri(int BirimId)
        {

            var result = (from gostergeveri in _context.Kalite_PerformansGostergeVeriKategorisiIliski
                          join veriKategorisi in _context.VeriKategorileri_Revizyon on gostergeveri.veri_kategorisi_id equals veriKategorisi.veri_kategorisi_id
                          join performansTanim in _context.Kalite_PerformansGostergeTanim on gostergeveri.performans_gosterge_id equals performansTanim.id
                          join performansRevizyon in _context.Kalite_PerformansGostergeTanim_Revizyon.Include(pr => pr.Kalite_PerformansGostergeHedeflenenDeger).ThenInclude(p => p.Kalite_PerformansGostergeGerceklesenDeger) on performansTanim.id equals performansRevizyon.performans_gosterge_tanim_id into revizyonList
                          join birimIliski in _context.Kalite_PerformansGostergeBirimIliski on gostergeveri.performans_gosterge_id equals birimIliski.performans_gosterge_id
                          join birim in _context.Kalite_Birim on birimIliski.birim_id equals birim.Id
                          where birimIliski.birim_id == BirimId
                          select new PerformansGostergeBirimVM
                          {
                              VeriKategorisi = veriKategorisi,
                              PerformansGostergeTanim = performansTanim,
                              PerformansGostergeleri = revizyonList.ToList(),
                              Birim = birim // Assuming you have a property named 'Birim' in your ViewModel
                          }).ToList();

            return result;

        }


        public async Task<List<PerformansGostergeKonuVM>> GetKonuVeri(int KonuId)
        {

            var result = (from gostergeveri in _context.Kalite_PerformansGostergeVeriKategorisiIliski
                          join veriKategorisi in _context.VeriKategorileri_Revizyon on gostergeveri.veri_kategorisi_id equals veriKategorisi.veri_kategorisi_id
                          join performansTanim in _context.Kalite_PerformansGostergeTanim on gostergeveri.performans_gosterge_id equals performansTanim.id
                          join performansRevizyon in _context.Kalite_PerformansGostergeTanim_Revizyon.Include(pr => pr.Kalite_PerformansGostergeHedeflenenDeger).ThenInclude(p => p.Kalite_PerformansGostergeGerceklesenDeger) on performansTanim.id equals performansRevizyon.performans_gosterge_tanim_id into revizyonList
                          join konuIliski in _context.Kalite_PerformansGostergeKonuIliski on gostergeveri.performans_gosterge_id equals konuIliski.performans_gosterge_id
                          join konu in _context.Kalite_Konu on konuIliski.konu_id equals konu.Id
                          where konuIliski.konu_id == KonuId
                          select new PerformansGostergeKonuVM
                          {
                              VeriKategorisi = veriKategorisi,
                              PerformansGostergeTanim = performansTanim,
                              PerformansGostergeleri = revizyonList.ToList(),
                              Konu = konu // Assuming you have a property named 'Birim' in your ViewModel
                          }).ToList();

            return result;

        }


    }
}
