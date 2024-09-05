using System.Reflection;


namespace UpdateIP
{
    public class LogFile
    {
        private static string _logPathAndFile;

        public LogFile() => LogFile._logPathAndFile = this.AssemblyDirectory + "\\logs.txt";

        public void WriteNewIP(string ip)
        {
            string str = "Updated " + DateTime.Now.ToString() + " | " + ip;
            if (!File.Exists(LogFile._logPathAndFile))
            {
                File.Create(LogFile._logPathAndFile);
                TextWriter textWriter = (TextWriter)new StreamWriter(LogFile._logPathAndFile);
                textWriter.WriteLine(str);
                textWriter.Close();
            }
            else
            {
                if (!File.Exists(LogFile._logPathAndFile))
                    return;
                TextWriter textWriter = (TextWriter)new StreamWriter(LogFile._logPathAndFile, true);
                textWriter.WriteLine(str);
                textWriter.Close();
            }
        }

        public string ReadLastIP()
        {
            try
            {
                if (File.Exists(LogFile._logPathAndFile))
                {
                    string str = File.ReadLines(LogFile._logPathAndFile).Last<string>();
                    if (string.IsNullOrEmpty(str))
                        return str;
                    return str.Split('|')[1].Trim();
                }
            }
            catch
            {
                return (string)null;
            }
            return (string)null;
        }

        private string AssemblyDirectory => Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));        
    }
}