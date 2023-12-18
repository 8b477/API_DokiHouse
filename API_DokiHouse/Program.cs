#region USING

#region using Project
    using Tools_DokiHouse.Services;
#endregion

#region using Package
    using Serilog;
#endregion

#endregion


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//**************************** DEPENDENCY INJECTION ******************************************
DependencyInjectionService
    .ConfigureDependencyInjection(builder.Services, builder.Configuration);
//********************************************************************************************


//**************************** BIND FIELD APPSETTINGS.JSON *********************************
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//******************************************************************************************


//************ SERILOG *******************
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host.UseSerilog();
//****************************************


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
