namespace UpdateIP
{


    class Program
    {
        private static LogFile logfile = new LogFile();

        static void Main(string[] args)
        {            
            string lastIp = logfile.ReadLastIP();
            string currentIp = IPUtils.GetPublicIP();

            if(!(lastIp != currentIp) || !DuckDNS.UpdateIP(currentIp))
                return;

            logfile.WriteNewIP(currentIp);

        }
    }
}