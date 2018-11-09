namespace PlattSampleApp.Services
{
    public class SwapiService
    {
        private readonly SwapiClient _swapiClient;

        public SwapiService()
        {
            _swapiClient = new SwapiClient();
        }
    }
}
