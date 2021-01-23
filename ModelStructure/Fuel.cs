using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ModelStructure
{
    public class Fuel : Base
    {
        public string Name { get; set; }
        public int EconomyTier { get; set; }
        [JsonIgnore]
        public ICollection<Car> Cars { get; set; }

    }
}