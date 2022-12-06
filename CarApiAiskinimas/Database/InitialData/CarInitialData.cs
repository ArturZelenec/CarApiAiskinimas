using CarApiAiskinimas.Models;

namespace CarApiAiskinimas.Database.InitialData
{
    public static class CarInitialData
    {
        public static readonly Car[] DataSeed = new Car[]
        {
            new Car
            {
                Id = 1,
                Mark = "VW",
                Model = "Golf",
                Year = new DateTime(2010,1,1),
                PlateNumber = "AAB 111",
                GearBox = ECarGearBox.Manual,
                Fuel = ECarFuel.Petrol
            },
             new Car
            {
                Id = 2,
                Mark = "Toyota",
                Model = "Prius",
                Year = new DateTime(2010,1,1),
                PlateNumber = "AAC 111",
                GearBox = ECarGearBox.Automatic,
                Fuel = ECarFuel.Electric
            },
              new Car
            {
                Id = 3,
                Mark = "Opel",
                Model = "Astra",
                Year = new DateTime(2010,1,1),
                PlateNumber = "AAD 111",
                GearBox = ECarGearBox.Manual,
                Fuel = ECarFuel.Diesel
            },
               new Car
            {
                Id = 4,
                Mark = "Opel",
                Model = "Corsa",
                Year = new DateTime(2010,1,1),
                PlateNumber = "AAC 111",
                GearBox = ECarGearBox.Manual,
                Fuel = ECarFuel.Diesel
            }
        };
    }
}
