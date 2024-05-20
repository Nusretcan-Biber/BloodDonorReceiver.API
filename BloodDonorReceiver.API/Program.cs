using BloodDonorReceiver.DataAccess.Context;
using BloodDonorReceiver.Utils.InitialHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MasterContext>(x => x.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRESQL_URI")));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "BloodDonorReceiver.API", Version = "v1" });

    options.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        Description = "Input your username and password to access this API"
    });

    var basicSecurityScheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "basic"
        }
    };

    var securityRequirement = new OpenApiSecurityRequirement
    {
        { basicSecurityScheme, new List<string>() }
    };

    options.AddSecurityRequirement(securityRequirement);
});




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


//burayý bir kez çalýþtýrdýktan sonra yorum satýrýna alabilirsiniz.
//bu sayede sistem daha hýzlý baþlayacaktýr
using (new Init()) ;
app.UseAuthorization();

app.MapControllers();

app.Run();
