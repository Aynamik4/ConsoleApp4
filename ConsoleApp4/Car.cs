using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Car
    {
        public int YearOfManufacture { get; set; }
        public string? LicenseNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public override string ToString() =>
            $"{Brand} {Model} {LicenseNumber} {YearOfManufacture}";
    }
}