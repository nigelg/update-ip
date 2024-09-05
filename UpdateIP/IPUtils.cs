using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

#nullable disable
namespace UpdateIP
{
    internal class IPUtils
    {
        public static string GetLocalIPAddress()
        {
            foreach (IPAddress address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    return address.ToString();
            }
            throw new Exception("Local IP Address Not Found!");
        }

        public static IPAddress GetDefaultGateway()
        {
            NetworkInterface networkInterface = ((IEnumerable<NetworkInterface>)NetworkInterface.GetAllNetworkInterfaces()).FirstOrDefault<NetworkInterface>();
            return networkInterface == null ? (IPAddress)null : networkInterface.GetIPProperties().GatewayAddresses.FirstOrDefault<GatewayIPAddressInformation>().Address;
        }

        public static string GetPublicIP()
        {
            return new StreamReader(WebRequest.Create("http://checkip.dyndns.org").GetResponse().GetResponseStream()).ReadToEnd().Trim().Split(':')[1].Substring(1).Split('<')[0];
        }
    }
}
