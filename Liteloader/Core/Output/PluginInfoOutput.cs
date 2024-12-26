using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liteloader.Core.Output
{
    public class PluginInfoOutput
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Repo { get; set; }
        public string? Description { get; set; }
        public string? Branch { get; set; }
        [JsonIgnore]
        public string? About { get; set; }
    }
}
