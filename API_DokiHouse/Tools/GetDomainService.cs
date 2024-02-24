
namespace API_DokiHouse.Tools
{
    public class GetDomainService
    {
        #region INJECTION
        private readonly IConfiguration _config;

        public GetDomainService(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }
        #endregion

        public string GetCurrentDomainName()
        {
            string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? throw new ArgumentNullException(nameof(environment));
            string? domainSetting = _config.GetValue<string>($"DomainSettings:{environment}") ?? throw new ArgumentNullException(nameof(domainSetting));

            return domainSetting;
        }

    }
}
