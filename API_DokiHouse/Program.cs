using Tools_DokiHouse.Services.Authentication;
using Tools_DokiHouse.Services.DependencyInjection;
using Tools_DokiHouse.Services.SwaggerConfiguration;
using Tools_DokiHouse.Filters.AuthorizationFilter;
using API_DokiHouse.Tools;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//**************************** DEPENDENCY INJECTION ******************************************
DependencyInjectionService
    .ConfigureDependencyInjection(builder.Services, builder.Configuration);
//HTTPContext Service
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<GetInfosHTTPContext>();
//Domain Service
builder.Services.AddSingleton<GetDomainService>();
//********************************************************************************************




//**************************** AUTHENTICATION CONFIG ******************
AuthenticationService.ConfigureAuthentication(builder.Services);
//*********************************************************************


//**************************** ADD FILTER ****************************************
AuthorizationFilterService.AddFilterControllersAuthorize(builder.Services);
//********************************************************************************


//****************** SWAGGER CONFIG *********************
SwaggerService.ConfigureSwagger(builder.Services);
//*******************************************************


//**************************** BIND FILE APPSETTINGS.JSON **********************************
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//******************************************************************************************


//************ SERILOG *******************
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host.UseSerilog();
//****************************************




//************ CORS *******************
string allowLocalHost4200 = "angular";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowLocalHost4200,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
//*************************************




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



//**********************
app.UseCors(allowLocalHost4200);
app.UseAuthentication();
//**********************



app.UseAuthorization();

app.MapControllers();

app.Run();
