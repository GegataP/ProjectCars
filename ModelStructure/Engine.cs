using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ModelStructure
{
    public class Engine : Base
    {
        public string Name { get; set; }
        public int Cylinder { get; set; }
        [JsonIgnore]
        public ICollection<Car> Cars { get; set; }

    }
}
