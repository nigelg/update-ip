using System.Net;

#nullable disable
namespace UpdateIP
{
    internal class DuckDNS
    {
        private static string _token;
        private static string _domains;

        public static bool UpdateIP(string ip)
        {
            var settings = new Settings().LoadFromJsonFile();

            _token = settings.Token;
            _domains = settings.Domains;


            return new StreamReader(WebRequest.Create("https://www.duckdns.org/update?domains=" + DuckDNS._domains + "&token=" + DuckDNS._token + "&ip=" + ip)
                .GetResponse()
                .GetResponseStream()
            ).ReadToEnd().Trim() == "OK";
        }
    }
}