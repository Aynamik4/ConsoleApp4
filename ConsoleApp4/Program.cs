using MySystem.MyCollections;

namespace ConsoleApp4
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            MyList<Car> cars = new()
            {
                new Car { Brand = "Volvo", Model = "XC90", LicenseNumber = "ABC 123", YearOfManufacture = 2024 },
                new Car { Brand = "Audi", Model = "Quatro", LicenseNumber = "XYZ 987", YearOfManufacture = 1998 },
                new Car { Brand = "Toyota", Model = "Aygo Hybrid", LicenseNumber = "TOY 001", YearOfManufacture = 2020 },
                new Car { Brand = "VolksWagen", Model = "Passat", LicenseNumber = "VWW 002", YearOfManufacture = 2010 },
            };

            cars.Sort(SortCondition);
            cars.Sort((a, b) =>
            {
                if (a.YearOfManufacture < b.YearOfManufacture)
                    return -1;
                else
                    if (a.YearOfManufacture > b.YearOfManufacture)
                    return 1;

                return 0;
            });

            WriteLineCollection(cars, c => new { Modell = c.Model, B = c.LicenseNumber });
            WriteLineCollection(cars, c => c);
            WriteLineCollection(cars, c => $"{c.Brand} {c.Model}");
            WriteLineCollection(cars, c => $"{c.Model} Long model name: {c.Model.Length > 6}");
            WriteLineCollection(cars, c => "Hej!");

            cars.WriteLineCollection(c => "Uddevalla");
        }

        static int SortCondition(Car a, Car b)
        {
            if (a.YearOfManufacture < b.YearOfManufacture)
                return -1;
            else
                if (a.YearOfManufacture > b.YearOfManufacture)
                return 1;

            return 0;
        }

        private static void WriteLineCollection<T, Y>(this IEnumerable<T> collection, Func<T, Y> getDataFrom) // IEnumerable!
        {
            foreach (T item in collection)
                Console.WriteLine(getDataFrom(item));

            Console.WriteLine("-----------------------------------------");
        }
    }
}