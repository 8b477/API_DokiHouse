using Tools_DokiHouse.Services.Authentication;
using Tools_DokiHouse.Services.DependencyInjection;
using Tools_DokiHouse.Services.SwaggerConfiguration;

using Serilog;
using Tools_DokiHouse.Filters.AuthorizationFilter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//**************************** DEPENDENCY INJECTION ******************************************
DependencyInjectionService
    .ConfigureDependencyInjection(builder.Services, builder.Configuration);
//********************************************************************************************




//**************************** BIND FILE APPSETTINGS.JSON **********************************
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//******************************************************************************************




//**************************** AUTHENTICATION CONFIG **** *************
AuthenticationService.AddAuthenticationAuth0(builder.Services);
//*********************************************************************




//**************************** ADD FILTER ****************************************
AuthorizationFilterService.AddFilterControllersAuthorize(builder.Services);
//********************************************************************************




//****************** SWAGGER CONFIG *********************
SwaggerService.ConfigureSwagger(builder.Services);
//*******************************************************




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



//**********************
app.UseAuthentication();
//**********************



app.UseAuthorization();

app.MapControllers();

app.Run();
