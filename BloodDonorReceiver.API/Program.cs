using BloodDonorReceiver.DataAccess.Context;
using BloodDonorReceiver.Utils.InitialHelper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MasterContext>(x => x.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRESQL_URI")));

var app = builder.Build();


using (IServiceScope serviceScope = app.Services.CreateScope())
{
    MasterContext context = serviceScope.ServiceProvider.GetRequiredService<MasterContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (new Init()) ;
app.UseAuthorization();

app.MapControllers();

app.Run();
