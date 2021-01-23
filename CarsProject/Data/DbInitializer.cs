using ModelStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsProject.Data
{
    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Engines.Any())
            {
                context.Engines.AddRange(Engines.Select(c => c.Value));
            }
            context.SaveChanges();

            if (!context.Fuels.Any())
            {
                context.Fuels.AddRange(Fuels.Select(c => c.Value));
            }
            context.SaveChanges();

            if (!context.Brands.Any())
            {
                context.Brands.AddRange(Brands.Select(c => c.Value));
            }
            context.SaveChanges();

            if (!context.Cars.Any())
            {
                context.Cars.AddRange(Cars.Select(c => c.Value));
            }
            context.SaveChanges();
        }

        private static Dictionary<string, Car> cars;
        public static Dictionary<string, Car> Cars
        {
            get
            {
                if (cars == null)
                {
                    var carList = new Car[]
                    {
                        new Car { Model = "A3" , Year = 1998, Brand = Brands["Audi"],  Engine = Engines["1.8"], Fuel = Fuels["Gasoline"] },
                        new Car { Model = "Ibiza" , Year = 2004, Brand = Brands["Seat"],  Engine = Engines["1.9"], Fuel = Fuels["Petrol"] },

                    };

                    cars = new Dictionary<string, Car>();

                    foreach (Car car in carList)
                    {
                        cars.Add(car.Model, car);
                    }
                }
                return cars;
            }
        }


        private static Dictionary<string, Engine> engines;
        public static Dictionary<string, Engine> Engines
        {
            get
            {
                if (engines == null)
                {
                    var engineList = new Engine[]
                    {
                        new Engine { Name = "1.8", Cylinder = 8 },
                        new Engine { Name = "1.9", Cylinder = 9 }
                    };

                    engines = new Dictionary<string, Engine>();

                    foreach (Engine engine in engineList)
                    {
                        engines.Add(engine.Name, engine);
                    }
                }
                return engines;
            }
        }
        private static Dictionary<string, Fuel> fuels;
        public static Dictionary<string, Fuel> Fuels
        {
            get
            {
                if (fuels == null)
                {
                    var fuelList = new Fuel[]
                    {
                        new Fuel { Name = "Gasoline", EconomyTier = 3 },
                        new Fuel { Name = "Petrol", EconomyTier = 4 }
                    };

                    fuels = new Dictionary<string, Fuel>();

                    foreach (Fuel fuel in fuelList)
                    {
                        fuels.Add(fuel.Name, fuel);
                    }
                }
                return fuels;
            }
        }
        private static Dictionary<string, Brand> brands;
        public static Dictionary<string, Brand> Brands
        {
            get
            {
                if (brands == null)
                {
                    var facilityList = new Brand[]
                    {
                        new Brand { Name = "Audi", Information = "Fastest cars in the world" },
                        new Brand { Name = "Seat", Information = "Good for racing on the 40's" },
                    };

                    brands = new Dictionary<string, Brand>();

                    foreach (Brand facility in facilityList)
                    {
                        brands.Add(facility.Name, facility);
                    }
                }
                return brands;
            }
        }
    }
}
