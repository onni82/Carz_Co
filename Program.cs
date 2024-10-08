using Microsoft.VisualBasic.FileIO;

namespace Carz_Co
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Vehicle> vehicles = new List<Vehicle>
			{
				new Car("Volvo", "V60", 5, "Diesel", 200, 5),
				new Motorcycle("Harley-Davidson", "Street 750", false, "Bensin", 180, 1),
				new Truck("Scania", "R500", 3, "Diesel", 160, 2),
				new Bus("Mercedes", "Citaro", 40, "Hybrid", 100, 100),
				new Boat("Yamaha", "242X", 8, "Bensin", 45, 4)
			};

			Console.WriteLine("Alla fordon:");
			PrintVehicles(vehicles);

			Console.WriteLine("\nFordon som går på diesel och har en maxhastighet över 150 km/h:");
			var filteredVehicles = FilterVehicles(vehicles, v => v.FuelType == "Diesel" && v.MaxSpeed > 150);
			PrintVehicles(filteredVehicles);

			Console.WriteLine("\nFordon sorterade efter maxhastighet (fallande):");
			var sortedVehicles = vehicles.OrderByDescending(v => v.MaxSpeed).ToList();
			PrintVehicles(sortedVehicles);
		}
		// Metod för att lägga till ett fordon
		static void AddVehicle(List<Vehicle> vehicles, Vehicle vehicle)
		{
			vehicles.Add(vehicle);
			Console.WriteLine($"{vehicle.Brand} {vehicle.Model} har lagts till i listan.");
		}

		// Metod för att ta bort ett fordon (baserat på index)
		static void RemoveVehicle(List<Vehicle> vehicles, int index)
		{
			if (index >= 0 && index < vehicles.Count)
			{
				Vehicle vehicle = vehicles[index];
				vehicles.RemoveAt(index);
				Console.WriteLine($"{vehicle.Brand} {vehicle.Model} har tagits bort från listan.");
			}
			else
			{
				Console.WriteLine("Felaktigt index. Inget fordon togs bort.");
			}
		}
		static List<Vehicle> FilterVehicles(List<Vehicle> vehicles, Func<Vehicle, bool> criteria)
		{
			return vehicles.Where(criteria).ToList();
		}

		static void PrintVehicles(List<Vehicle> vehicles)
		{
			foreach (var vehicle in vehicles)
			{
				Console.WriteLine($"{vehicle.Brand} {vehicle.Model} - Bränsle: {vehicle.FuelType}, Max hastighet: {vehicle.MaxSpeed} km/h");
			}
		}
		static void SellVehicle(List<Vehicle> vehicles, Vehicle vehicle)
		{
			Console.WriteLine($"\nSäljer fordon: {vehicle}");
			vehicles.Remove(vehicle);
		}
	}
	public interface IDriveable
	{
		void Drive();
	}
	public abstract class Vehicle : IDriveable
	{
		public string Brand { get; set; }
		public string Model { get; set; }
		public string FuelType { get; set; }
		public int MaxSpeed { get; set; }
		public int PassengerCapacity { get; set; }

		protected Vehicle(string brand, string model, string fuelType, int maxSpeed, int passengerCapacity)
        {
			Brand = brand;
			Model = model;
			FuelType = fuelType;
			MaxSpeed = maxSpeed;
			PassengerCapacity = passengerCapacity;
        }

		public abstract void Drive();
		public override string ToString()
		{
			return $"Brand: {Brand}, Model: {Model}";
		}
	}
	public class Car : Vehicle
	{
		public int AmountOfDoors { get; set; }
		public Car(string brand, string model, int amountOfDoors, string fuelType, int maxSpeed, int passengerCapacity)
			:base(brand, model, fuelType, maxSpeed, passengerCapacity)
        {
			AmountOfDoors = amountOfDoors;
        }
		public override void Drive()
		{
			Console.WriteLine($"{Brand} {Model} is driving. It has {AmountOfDoors} amount of doors.");
		}
		public override string ToString()
		{
			return $"Brand: {Brand}. Model: {Model}. Amount of doors: {AmountOfDoors}";
		}
	}
	public class Motorcycle : Vehicle
	{
		public bool HasSidecar;
		public Motorcycle(string brand, string model, bool hasSidecar, string fuelType, int maxSpeed, int passengerCapacity)
			: base(brand, model, fuelType, maxSpeed, passengerCapacity)
		{
			HasSidecar = hasSidecar;
		}
		public override void Drive()
		{
			Console.WriteLine($"{Brand} {Model} is driving. Does is have a sidecar? {HasSidecar}.");
		}
		public override string ToString()
		{
			return $"Brand: {Brand}. Model: {Model}. Does it have a sidecar? {HasSidecar}";
		}
	}
	public class Truck : Vehicle
	{
		public int AmountOfDoors { get; set; }
		public Truck(string brand, string model, int amountOfDoors, string fuelType, int maxSpeed, int passengerCapacity)
			: base(brand, model, fuelType, maxSpeed, passengerCapacity)
		{
			AmountOfDoors = amountOfDoors;
		}
		public override void Drive()
		{
			Console.WriteLine($"{Brand} {Model} is driving. It has {AmountOfDoors} amount of doors.");
		}
		public override string ToString()
		{
			return $"Brand: {Brand}. Model: {Model}. Amount of doors: {AmountOfDoors}";
		}
	}
	public class Bus : Vehicle
	{
		public int AmountOfDoors { get; set; }
		public Bus(string brand, string model, int amountOfDoors, string fuelType, int maxSpeed, int passengerCapacity)
			: base(brand, model, fuelType, maxSpeed, passengerCapacity)
		{
			AmountOfDoors = amountOfDoors;
		}
		public override void Drive()
		{
			Console.WriteLine($"{Brand} {Model} is driving. It has {AmountOfDoors} amount of doors.");
		}
		public override string ToString()
		{
			return $"Brand: {Brand}. Model: {Model}. Amount of doors: {AmountOfDoors}";
		}
	}
	public class Boat : Vehicle
	{
		public int AmountOfDoors { get; set; }
		public Boat(string brand, string model, int amountOfDoors, string fuelType, int maxSpeed, int passengerCapacity)
			: base(brand, model, fuelType, maxSpeed, passengerCapacity)
		{
			AmountOfDoors = amountOfDoors;
		}
		public override void Drive()
		{
			Console.WriteLine($"{Brand} {Model} is driving. It has {AmountOfDoors} amount of doors.");
		}
		public override string ToString()
		{
			return $"Brand: {Brand}. Model: {Model}. Amount of doors: {AmountOfDoors}";
		}
	}
}
