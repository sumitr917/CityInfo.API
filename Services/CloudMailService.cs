namespace CityInfo.API.Services;
public class CloudMailService
{
    private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;
        public CloudMailService(IConfiguration configuration)
        {
            _mailFrom = configuration["mailSettings : mailToAddress"];
            _mailTo = configuration["mailSettings : mailFromAddress"];
        }
        public void Send(string subject, string message)
        {
            //dummy mail - output to console window
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, " +
            $"with {nameof(CloudMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
}