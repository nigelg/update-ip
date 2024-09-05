using System.Reflection;
using Newtonsoft.Json;

#nullable disable
namespace UpdateIP
{
    public class Settings
    {
        public string Token;
        public string Domains;

        public Settings LoadFromJsonFile()
        {
            using (StreamReader r = new StreamReader(this.AssemblyDirectory + "\\settings.json"))
            {
                string json = r.ReadToEnd();
                var settigns = JsonConvert.DeserializeObject<Settings>(json);
                return settigns;
            }
        }

        private string AssemblyDirectory => Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
    }
}