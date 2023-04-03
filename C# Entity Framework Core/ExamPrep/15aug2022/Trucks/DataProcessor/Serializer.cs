namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.Utilities;

    public class Serializer
    {
        private static XmlHelper? xmlHelper;

        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            xmlHelper = new XmlHelper();

            ExportDespatcherDto[] despatchers = context.Despatchers
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespatcherDto()
                {
                    DespatcherName = d.Name,
                    TrucksCount = d.Trucks.Count,
                    Trucks = d.Trucks
                        .Select(t => new ExportTruckDto()
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            Make = t.MakeType.ToString()
                        })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToArray()
                })
                .OrderByDescending(d => d.Trucks.Length)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            return xmlHelper.Serialize(despatchers, "Despatchers");


        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .ToArray()
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .Select(c => new
                {
                    c.Name,
                    Trucks = c.ClientsTrucks
                   .Where(ct => ct.Truck.TankCapacity >= capacity)
                   .Select(ct => new
                   {
                       TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                       VinNumber = ct.Truck.VinNumber,
                       TankCapacity = ct.Truck.TankCapacity,
                       CargoCapacity = ct.Truck.CargoCapacity,
                       CategoryType = ct.Truck.CategoryType.ToString(),
                       MakeType = ct.Truck.MakeType.ToString()
                   })
                   .OrderBy(t => t.MakeType)
                   .ThenByDescending(t => t.CargoCapacity)
                   .ToList()
                })
                .OrderByDescending(c => c.Trucks.Count)
                .ThenBy(c => c.Name)
                .Take(10);

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
