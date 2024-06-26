using GTUGraphicsModule.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTUGraphicsModule.API.Context
{
    public class GTUGraphicsModuleDbContext : DbContext
    {

        public GTUGraphicsModuleDbContext(DbContextOptions<GTUGraphicsModuleDbContext> option) : base(option)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
           

        }

        public virtual DbSet<Kalite_PerformansGostergeTanim> Kalite_PerformansGostergeTanim { get; set; }
        public virtual DbSet<Kalite_PerformansGostergeTanim_Revizyon> Kalite_PerformansGostergeTanim_Revizyon { get; set; }
        public virtual DbSet<Kalite_VeriKategorileri> VeriKategorileri { get; set; }
        public virtual DbSet<Kalite_VeriKategorileri_Revizyon> VeriKategorileri_Revizyon { get; set; }
        public virtual DbSet<Kalite_PerformansGostergeBirimIliski> Kalite_PerformansGostergeBirimIliski { get; set; }
        public virtual DbSet<Kalite_PerformansGostergeVeriKategorisiIliski> Kalite_PerformansGostergeVeriKategorisiIliski { get; set; }
        public virtual DbSet<Kalite_PerformansGostergeGerceklesenDeger> Kalite_PerformansGostergeGerceklesenDeger { get; set; }
        public virtual DbSet<Kalite_PerformansGostergeHedeflenenDeger> Kalite_PerformansGostergeHedeflenenDeger { get; set; }
        public virtual DbSet<Kalite_Birim> Kalite_Birim { get; set; }
        public virtual DbSet<Kalite_PerformansGostergeKonuIliski> Kalite_PerformansGostergeKonuIliski { get; set; }
        public virtual DbSet<Kalite_Konu> Kalite_Konu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Kalite_PerformansGostergeHedeflenenDeger>().HasKey(p => new { p.performans_gosterge_id, p.faaliyet_donem_id, p.surec_id });

            modelBuilder.Entity<Kalite_PerformansGostergeGerceklesenDeger>().HasKey(c => new { c.performans_gosterge_id, c.faaliyet_donem_id, c.surec_id, c.periyod });

            modelBuilder.Entity<Kalite_PerformansGostergeGerceklesenDeger>().
                                                                            HasOne(c => c.Kalite_PerformansGostergeHedeflenenDeger).
                                                                            WithMany(d => d.Kalite_PerformansGostergeGerceklesenDeger).
                                                                            HasForeignKey(c => new { c.performans_gosterge_id, c.faaliyet_donem_id, c.surec_id });

           
            
            /*
            modelBuilder.HasSequence<int>("EntitySequence")
           .StartsAt(2023)
           .IncrementsBy(1)
           .HasMin(2023)
           .HasMax(2027);

            modelBuilder.Entity<Kalite_PerformansGostergeGerceklesenDeger>()
                .Property(e => e.periyod)
                .HasDefaultValueSql("NEXT VALUE FOR EntitySequence");

            modelBuilder.Entity<Kalite_PerformansGostergeGerceklesenDeger>()
                .HasCheckConstraint("CK_Kalite_PerformansGostergeGerceklesenDeger_periyod_Range", "[periyod] >= 2023 AND [periyod] <= 2027");*/

            // modelBuilder.Entity<Kalite_PerformansGostergeGerceklesenDeger>().HasKey(p => new { p.performans_gosterge_id, p.faaliyet_donem_id, p.surec_id, p.periyod});


            //modelBuilder.Entity<Kalite_PerformansGostergeBirimIliski>().HasOne(b => b.Kalite_PerformansGostergeTanim).WithOne().HasForeignKey<Kalite_PerformansGostergeBirimIliski>(b => b.performans_gosterge_id);

            //modelBuilder.Entity<Kalite_PerformansGostergeTanim_Revizyon>().HasOne(b => b.Kalite_PerformansGostergeTanim).WithOne().HasForeignKey<Kalite_PerformansGostergeTanim_Revizyon>(b => b.performans_gosterge_tanim_id);

            //modelBuilder.Entity<Kalite_VeriKategorileri_Revizyon>().HasOne(b => b.Kalite_VeriKategorileri).WithOne().HasForeignKey<Kalite_VeriKategorileri_Revizyon>(b => b.ust_veri_kategorisi_id);

            //modelBuilder.Entity<Kalite_PerformansGostergeVeriKategorisiIliski>().HasOne(b => b.Kalite_PerformansGostergeTanim).WithOne().HasForeignKey<Kalite_PerformansGostergeVeriKategorisiIliski>(b => b.performans_gosterge_id);
            //modelBuilder.Entity<Kalite_PerformansGostergeVeriKategorisiIliski>().HasOne(b => b.Kalite_VeriKategorileri).WithOne().HasForeignKey<Kalite_PerformansGostergeVeriKategorisiIliski>(b => b.veri_kategorisi_id);

            //modelBuilder.Entity<Kalite_PerformansGostergeGerceklesenDeger>().HasOne(b => b.Kalite_PerformansGostergeTanim).WithOne().HasForeignKey<Kalite_PerformansGostergeGerceklesenDeger>(b => b.performans_gosterge_id);
            //modelBuilder.Entity<Kalite_PerformansGostergeHedeflenenDeger>().HasOne(b => b.Kalite_PerformansGostergeTanim).WithOne().HasForeignKey<Kalite_PerformansGostergeHedeflenenDeger>(b => b.performans_gosterge_id);

        }

    }

    


}