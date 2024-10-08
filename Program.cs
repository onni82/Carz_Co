namespace Carz_Co
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Skapa en lista för att lagra fordon
			List<Vehicle> vehicles = new List<Vehicle>();

			// Lägg till några fordon
			vehicles.Add(new Car("Volvo", "V60", 5));
			vehicles.Add(new Motorcycle("Harley-Davidson", "Street 750", false));
			vehicles.Add(new Truck("Scania", "R500", 3));
			vehicles.Add(new Car("Toyota", "Corolla", 4));

			// Skriv ut alla fordon
			Console.WriteLine("Alla fordon:");
			foreach (var vehicle in vehicles)
			{
				Console.WriteLine(vehicle);
			}

			// Filtrera och skriv ut bara bilar
			Console.WriteLine("\nBara bilar:");
			var cars = FilterVehicles<Car>(vehicles);
			foreach (var car in cars)
			{
				Console.WriteLine(car);
			}

			// Sälj ett fordon
			var vehicleToSell = vehicles.Find(v => v.Brand == "Toyota");
			if (vehicleToSell != null)
			{
				SellVehicle(vehicles, vehicleToSell);
			}

			// Skriv ut uppdaterad lista
			Console.WriteLine("\nUppdaterad lista efter försäljning:");
			foreach (var vehicle in vehicles)
			{
				Console.WriteLine(vehicle);
			}
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
		static List<T> FilterVehicles<T>(List<Vehicle> vehicles) where T : Vehicle
		{
			return vehicles.OfType<T>().ToList();
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

        protected Vehicle(string brand, string model)
        {
			Brand = brand;
			Model = model;
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
		public Car(string brand, string model, int amountOfDoors)
			:base(brand, model)
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
		public bool HasDoors;
		public Motorcycle(string brand, string model, bool hasDoors)
			: base(brand, model)
		{
			HasDoors = hasDoors;
		}
		public override void Drive()
		{
			Console.WriteLine($"{Brand} {Model} is driving. Does is have doors? {HasDoors}.");
		}
		public override string ToString()
		{
			return $"Brand: {Brand}. Model: {Model}. Does it have doors? {HasDoors}";
		}
	}
	public class Truck : Vehicle
	{
		public int AmountOfDoors { get; set; }
		public Truck(string brand, string model, int amountOfDoors)
			: base(brand, model)
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
