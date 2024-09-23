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
            WriteLineCollection(cars, c => new { A = c.Model, B = c.LicenseNumber });
            WriteLineCollection(cars, c => c);
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

        //private static void PrintCars(MyList<Car> cars)
        //{
        //    foreach (Car car in cars)
        //        Console.WriteLine($"{car.Brand} {car.Model} {car.LicenseNumber} {car.YearOfManufacture}");

        //    Console.WriteLine("-----------------------------------------");
        //}

        private static void WriteLineCollection<T, Y>(IEnumerable<T> collection, Func<T, Y> getDataFrom) // IEnumerable!
        {
            foreach (T item in collection)
                Console.WriteLine(getDataFrom(item));

            Console.WriteLine("-----------------------------------------");
        }
    }
}