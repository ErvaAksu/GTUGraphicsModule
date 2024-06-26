using GTUGraphicsModule.API.Business.Abstract;
using GTUGraphicsModule.API.Business.Concrete;
using GTUGraphicsModule.API.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GTUGraphicsModuleDbContext>(o => o.UseSqlServer(@"Server=.;Database=gtudb;User Id=sa;Password=Sakarya54;Trust Server Certificate=True;"));

builder.Services.AddScoped<IKalite_PerformansGostergeBirimIliskiBusiness, Kalite_PerformansGostergeBirimIliskiBusiness>();
//builder.Services.AddScoped<IEntityRepository<Kalite_PerformansGostergeBirimIliski>, EntityRepository<Kalite_PerformansGostergeBirimIliski>>();

builder.Services.AddScoped<IKalite_PerformansGostergeGerceklesenDegerBusiness, Kalite_PerformansGostergeGerceklesenDegerBusiness>();
//builder.Services.AddScoped<IEntityRepository<Kalite_PerformansGostergeGerceklesenDeger>, EntityRepository<Kalite_PerformansGostergeGerceklesenDeger>>();

builder.Services.AddScoped<IKalite_PerformansGostergeHedeflenenDegerBusiness, Kalite_PerformansGostergeHedeflenenDegerBusiness>();
//builder.Services.AddScoped<IEntityRepository<Kalite_PerformansGostergeHedeflenenDeger>, EntityRepository<Kalite_PerformansGostergeHedeflenenDeger>>();

builder.Services.AddScoped<IKalite_PerformansGostergeTanim_RevizyonBusiness, Kalite_PerformansGostergeTanim_RevizyonBusiness>();
//builder.Services.AddScoped<IEntityRepository<Kalite_PerformansGostergeTanim_Revizyon>, EntityRepository<Kalite_PerformansGostergeTanim_Revizyon>>();

builder.Services.AddScoped<IKalite_PerformansGostergeTanimBusiness, Kalite_PerformansGostergeTanimBusiness>();
//builder.Services.AddScoped<IEntityRepository<Kalite_PerformansGostergeTanim>, EntityRepository<Kalite_PerformansGostergeTanim>>();

builder.Services.AddScoped<IKalite_PerformansGostergeVeriKategorisiIliskiBusiness, Kalite_PerformansGostergeVeriKategorisiIliskiBusiness>();
//builder.Services.AddScoped<IEntityRepository<Kalite_PerformansGostergeVeriKategorisiIliski>, EntityRepository<Kalite_PerformansGostergeVeriKategorisiIliski>>();

builder.Services.AddScoped<IKalite_VeriKategorileriBusiness, Kalite_VeriKategorileriBusiness>();
//builder.Services.AddScoped<IEntityRepository<Kalite_VeriKategorileri>, EntityRepository<Kalite_VeriKategorileri>>();

builder.Services.AddScoped<IKalite_VeriKategorileri_RevizyonBusiness, Kalite_VeriKategorileri_RevizyonBusiness>();
//builder.Services.AddScoped<IEntityRepository<Kalite_VeriKategorileri_Revizyon>, EntityRepository<Kalite_VeriKategorileri_Revizyon>>();

builder.Services.AddScoped<IKalite_BirimBusiness, Kalite_BirimBusiness>();

builder.Services.AddScoped<IKalite_KonuBusiness, Kalite_KonuBusiness>();

builder.Services.AddScoped<IKalite_PerformansGostergeKonuIliskiBusiness, Kalite_PerformansGostergeKonuIliskiBusiness>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



