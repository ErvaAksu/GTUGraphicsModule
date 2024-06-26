using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTUGraphicsModule.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kalite_Birim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalite_Birim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kalite_Konu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonuAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalite_Konu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kalite_PerformansGostergeTanim",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalite_PerformansGostergeTanim", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VeriKategorileri",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeriKategorileri", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Kalite_PerformansGostergeBirimIliski",
                columns: table => new
                {
                    efgereksinimiicinid = table.Column<int>(name: "ef_gereksinimi_icin_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    performansgostergeid = table.Column<int>(name: "performans_gosterge_id", type: "int", nullable: false),
                    birimid = table.Column<int>(name: "birim_id", type: "int", nullable: false),
                    baslangicticks = table.Column<int>(name: "baslangic_ticks", type: "int", nullable: false),
                    bitisticks = table.Column<int>(name: "bitis_ticks", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalite_PerformansGostergeBirimIliski", x => x.efgereksinimiicinid);
                    table.ForeignKey(
                        name: "FK_Kalite_PerformansGostergeBirimIliski_Kalite_Birim_birim_id",
                        column: x => x.birimid,
                        principalTable: "Kalite_Birim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kalite_PerformansGostergeBirimIliski_Kalite_PerformansGostergeTanim_performans_gosterge_id",
                        column: x => x.performansgostergeid,
                        principalTable: "Kalite_PerformansGostergeTanim",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kalite_PerformansGostergeKonuIliski",
                columns: table => new
                {
                    efgereksinimiicinid = table.Column<int>(name: "ef_gereksinimi_icin_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    performansgostergeid = table.Column<int>(name: "performans_gosterge_id", type: "int", nullable: false),
                    konuid = table.Column<int>(name: "konu_id", type: "int", nullable: false),
                    baslangicticks = table.Column<int>(name: "baslangic_ticks", type: "int", nullable: false),
                    bitisticks = table.Column<int>(name: "bitis_ticks", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalite_PerformansGostergeKonuIliski", x => x.efgereksinimiicinid);
                    table.ForeignKey(
                        name: "FK_Kalite_PerformansGostergeKonuIliski_Kalite_Konu_konu_id",
                        column: x => x.konuid,
                        principalTable: "Kalite_Konu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kalite_PerformansGostergeKonuIliski_Kalite_PerformansGostergeTanim_performans_gosterge_id",
                        column: x => x.performansgostergeid,
                        principalTable: "Kalite_PerformansGostergeTanim",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kalite_PerformansGostergeTanim_Revizyon",
                columns: table => new
                {
                    efgereksinimiicinid = table.Column<int>(name: "_ef_gereksinimi_icin_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    performansgostergetanimid = table.Column<int>(name: "performans_gosterge_tanim_id", type: "int", nullable: false),
                    kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eskikod = table.Column<string>(name: "eski_kod", type: "nvarchar(max)", nullable: false),
                    revizyonnumarasi = table.Column<int>(name: "revizyon_numarasi", type: "int", nullable: false),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adingilizce = table.Column<string>(name: "ad_ingilizce", type: "nvarchar(max)", nullable: false),
                    tanim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    olcubirimcesit = table.Column<int>(name: "olcu_birim_cesit", type: "int", nullable: false),
                    formulcesit = table.Column<int>(name: "formul_cesit", type: "int", nullable: false),
                    izlemeperiyotcesit = table.Column<int>(name: "izleme_periyot_cesit", type: "int", nullable: false),
                    genelgostergeformulcesit = table.Column<int>(name: "genel_gosterge_formul_cesit", type: "int", nullable: false),
                    aktif = table.Column<bool>(type: "bit", nullable: false),
                    stratejiid = table.Column<int>(name: "strateji_id", type: "int", nullable: false),
                    baslangicticks = table.Column<int>(name: "baslangic_ticks", type: "int", nullable: false),
                    bitisticks = table.Column<int>(name: "bitis_ticks", type: "int", nullable: false),
                    silinecekgostergecesit = table.Column<int>(name: "_silinecek_gosterge_cesit", type: "int", nullable: false),
                    silineceksonuckritercesit = table.Column<int>(name: "_silinecek_sonuc_kriter_cesit", type: "int", nullable: false),
                    silinecekformulcesit = table.Column<int>(name: "_silinecek_formul_cesit", type: "int", nullable: false),
                    silinecekgenelgostergeformulcesit = table.Column<int>(name: "_silinecek_genel_gosterge_formul_cesit", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalite_PerformansGostergeTanim_Revizyon", x => x.efgereksinimiicinid);
                    table.ForeignKey(
                        name: "FK_Kalite_PerformansGostergeTanim_Revizyon_Kalite_PerformansGostergeTanim_performans_gosterge_tanim_id",
                        column: x => x.performansgostergetanimid,
                        principalTable: "Kalite_PerformansGostergeTanim",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kalite_PerformansGostergeVeriKategorisiIliski",
                columns: table => new
                {
                    efgereksinimiicinid = table.Column<int>(name: "ef_gereksinimi_icin_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    performansgostergeid = table.Column<int>(name: "performans_gosterge_id", type: "int", nullable: false),
                    verikategorisiid = table.Column<int>(name: "veri_kategorisi_id", type: "int", nullable: false),
                    baslangicticks = table.Column<int>(name: "baslangic_ticks", type: "int", nullable: false),
                    bitisticks = table.Column<int>(name: "bitis_ticks", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalite_PerformansGostergeVeriKategorisiIliski", x => x.efgereksinimiicinid);
                    table.ForeignKey(
                        name: "FK_Kalite_PerformansGostergeVeriKategorisiIliski_Kalite_PerformansGostergeTanim_performans_gosterge_id",
                        column: x => x.performansgostergeid,
                        principalTable: "Kalite_PerformansGostergeTanim",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kalite_PerformansGostergeVeriKategorisiIliski_VeriKategorileri_veri_kategorisi_id",
                        column: x => x.verikategorisiid,
                        principalTable: "VeriKategorileri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VeriKategorileri_Revizyon",
                columns: table => new
                {
                    efgereksininmiicinid = table.Column<int>(name: "ef_gereksininmi_icin_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    verikategorisiid = table.Column<int>(name: "veri_kategorisi_id", type: "int", nullable: false),
                    ustverikategorisiid = table.Column<int>(name: "ust_veri_kategorisi_id", type: "int", nullable: false),
                    kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    baslangicticks = table.Column<int>(name: "baslangic_ticks", type: "int", nullable: false),
                    bitisticks = table.Column<int>(name: "bitis_ticks", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeriKategorileri_Revizyon", x => x.efgereksininmiicinid);
                    table.ForeignKey(
                        name: "FK_VeriKategorileri_Revizyon_VeriKategorileri_ust_veri_kategorisi_id",
                        column: x => x.ustverikategorisiid,
                        principalTable: "VeriKategorileri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kalite_PerformansGostergeHedeflenenDeger",
                columns: table => new
                {
                    performansgostergeid = table.Column<int>(name: "performans_gosterge_id", type: "int", nullable: false),
                    surecid = table.Column<int>(name: "surec_id", type: "int", nullable: false),
                    faaliyetdonemid = table.Column<int>(name: "faaliyet_donem_id", type: "int", nullable: false),
                    hedeflenendeger = table.Column<int>(name: "hedeflenen_deger", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalite_PerformansGostergeHedeflenenDeger", x => new { x.performansgostergeid, x.faaliyetdonemid, x.surecid });
                    table.ForeignKey(
                        name: "FK_Kalite_PerformansGostergeHedeflenenDeger_Kalite_PerformansGostergeTanim_Revizyon_performans_gosterge_id",
                        column: x => x.performansgostergeid,
                        principalTable: "Kalite_PerformansGostergeTanim_Revizyon",
                        principalColumn: "_ef_gereksinimi_icin_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kalite_PerformansGostergeGerceklesenDeger",
                columns: table => new
                {
                    performansgostergeid = table.Column<int>(name: "performans_gosterge_id", type: "int", nullable: false),
                    surecid = table.Column<int>(name: "surec_id", type: "int", nullable: false),
                    faaliyetdonemid = table.Column<int>(name: "faaliyet_donem_id", type: "int", nullable: false),
                    periyod = table.Column<int>(type: "int", nullable: false),
                    gerceklesendeger = table.Column<int>(name: "gerceklesen_deger", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalite_PerformansGostergeGerceklesenDeger", x => new { x.performansgostergeid, x.faaliyetdonemid, x.surecid, x.periyod });
                    table.ForeignKey(
                        name: "FK_Kalite_PerformansGostergeGerceklesenDeger_Kalite_PerformansGostergeHedeflenenDeger_performans_gosterge_id_faaliyet_donem_id_~",
                        columns: x => new { x.performansgostergeid, x.faaliyetdonemid, x.surecid },
                        principalTable: "Kalite_PerformansGostergeHedeflenenDeger",
                        principalColumns: new[] { "performans_gosterge_id", "faaliyet_donem_id", "surec_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kalite_PerformansGostergeBirimIliski_birim_id",
                table: "Kalite_PerformansGostergeBirimIliski",
                column: "birim_id");

            migrationBuilder.CreateIndex(
                name: "IX_Kalite_PerformansGostergeBirimIliski_performans_gosterge_id",
                table: "Kalite_PerformansGostergeBirimIliski",
                column: "performans_gosterge_id");

            migrationBuilder.CreateIndex(
                name: "IX_Kalite_PerformansGostergeHedeflenenDeger_performans_gosterge_id",
                table: "Kalite_PerformansGostergeHedeflenenDeger",
                column: "performans_gosterge_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kalite_PerformansGostergeKonuIliski_konu_id",
                table: "Kalite_PerformansGostergeKonuIliski",
                column: "konu_id");

            migrationBuilder.CreateIndex(
                name: "IX_Kalite_PerformansGostergeKonuIliski_performans_gosterge_id",
                table: "Kalite_PerformansGostergeKonuIliski",
                column: "performans_gosterge_id");

            migrationBuilder.CreateIndex(
                name: "IX_Kalite_PerformansGostergeTanim_Revizyon_performans_gosterge_tanim_id",
                table: "Kalite_PerformansGostergeTanim_Revizyon",
                column: "performans_gosterge_tanim_id");

            migrationBuilder.CreateIndex(
                name: "IX_Kalite_PerformansGostergeVeriKategorisiIliski_performans_gosterge_id",
                table: "Kalite_PerformansGostergeVeriKategorisiIliski",
                column: "performans_gosterge_id");

            migrationBuilder.CreateIndex(
                name: "IX_Kalite_PerformansGostergeVeriKategorisiIliski_veri_kategorisi_id",
                table: "Kalite_PerformansGostergeVeriKategorisiIliski",
                column: "veri_kategorisi_id");

            migrationBuilder.CreateIndex(
                name: "IX_VeriKategorileri_Revizyon_ust_veri_kategorisi_id",
                table: "VeriKategorileri_Revizyon",
                column: "ust_veri_kategorisi_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kalite_PerformansGostergeBirimIliski");

            migrationBuilder.DropTable(
                name: "Kalite_PerformansGostergeGerceklesenDeger");

            migrationBuilder.DropTable(
                name: "Kalite_PerformansGostergeKonuIliski");

            migrationBuilder.DropTable(
                name: "Kalite_PerformansGostergeVeriKategorisiIliski");

            migrationBuilder.DropTable(
                name: "VeriKategorileri_Revizyon");

            migrationBuilder.DropTable(
                name: "Kalite_Birim");

            migrationBuilder.DropTable(
                name: "Kalite_PerformansGostergeHedeflenenDeger");

            migrationBuilder.DropTable(
                name: "Kalite_Konu");

            migrationBuilder.DropTable(
                name: "VeriKategorileri");

            migrationBuilder.DropTable(
                name: "Kalite_PerformansGostergeTanim_Revizyon");

            migrationBuilder.DropTable(
                name: "Kalite_PerformansGostergeTanim");
        }
    }
}
