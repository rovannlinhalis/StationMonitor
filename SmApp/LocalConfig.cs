using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmApp
{
    public class LocalConfig
    {
        public static readonly string pathConfig = Application.StartupPath;//Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\StationMonitor";
        public static readonly string pathFileConfig =  pathConfig + "\\LocalConfig.json";
        //static readonly string url = "https://localhost";
        static readonly string url = "https://localhost:44394";

        public static string Url { get => url.EndsWith("/") ? url : url + "/"; }

        public string Nome { get; set; }
        
        private string token;

        public string Token { get => token; set { token = value; id = Guid.Empty;   } }

        private Guid id;
        public Guid Id
        {
            get {
                if (id == Guid.Empty && !String.IsNullOrEmpty(Token))
                    id = Guid.Parse(Token);
                return id;
            }
        }


    }
}
