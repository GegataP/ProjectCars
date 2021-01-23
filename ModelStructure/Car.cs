using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ModelStructure
{
    public class Car : Base
    {
        public string Model { get; set; }
        public int Year { get; set; }

        public int BrandId { get; set; }
        [JsonIgnore]
        public virtual Brand Brand { get; set; }
        public int EngineId { get; set; }
        [JsonIgnore]
        public virtual Engine Engine { get; set; }
        public int FuelId { get; set; }
        [JsonIgnore]
        public virtual Fuel Fuel { get; set; }

    }
}
