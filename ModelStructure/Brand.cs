using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ModelStructure
{
    public class Brand : Base
    {
        public string Name { get; set; }
        public string Information { get; set; }
        [JsonIgnore]
        public ICollection<Car> Cars { get; set; }
    }
}
