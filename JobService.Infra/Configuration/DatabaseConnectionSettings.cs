using System;
using System.Collections.Generic;
using System.Text;

namespace JobService.Infra.Configuration
{
    public class DatabaseConnectionSettings
    {
        public string DeviceConnection { get; set; }
        public string ClientConnection { get; set; }
        public string JobTagsConnection { get; set; }
    }
}
