using Newtonsoft.Json;
using PlaySel.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySel.Configuration
{
    
    public class Config
    {
        public static Appconfig_DTO loadconfig()
        {
            string config = File.ReadAllText(Directory.GetCurrentDirectory()+ "//Configuration//Appconfig.json");
            Appconfig_DTO appconfig_DTO= JsonConvert.DeserializeObject<Appconfig_DTO>(config)!;
             return appconfig_DTO;
        }
    }
}
