using System;
using System.Collections.Generic;

public class Car
{
    public string Number { get; set; }
    public int TimesMoved { get; set; } // Число разів, коли автомобіль віддалявся для виїзду
}

public class Garage
{
    private List<Car> cars = new List<Car>();

    public List<Car> Cars { get { return cars; } }


    public void AddCar(string number)
    {
        Car newCar = new Car { Number = number };
        cars.Add(newCar);
        Console.WriteLine($"Автомобіль з номером {number} доданий на стоянку.");
    }

    public void RemoveCar(string number)
    {
        Car carToRemove = cars.Find(car => car.Number == number);
        if (carToRemove != null)
        {
            int index = cars.IndexOf(carToRemove);
            cars.RemoveAt(index);
            Console.WriteLine($"Автомобіль з номером {number} виїхав із стоянки.");
            foreach (Car car in cars.GetRange(index, cars.Count - index))
            {
                car.TimesMoved++;
            }
        }
        else
        {
            Console.WriteLine($"Автомобіль з номером {number} не знайдений на стоянці.");
        }
    }

    public void DisplayCars()
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("На стоянці немає жодного автомобіля.");
        }
        else
        {
            Console.WriteLine("Автомобілі на стоянці:");
            foreach (Car car in cars)
            {
                Console.WriteLine($"Номер: {car.Number}, Віддалення для виїзду: {car.TimesMoved} разів");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Garage garage = new Garage();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати автомобіль");
            Console.WriteLine("2. Видалити автомобіль");
            Console.WriteLine("3. Показати автомобілі на стоянці");
            Console.WriteLine("4. Вийти");

            Console.Write("Оберіть опцію: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть номер автомобіля: ");
                    string numberToAdd = Console.ReadLine();
                    garage.AddCar(numberToAdd);
                    break;
                case "2":
                    Console.Write("Введіть номер автомобіля для видалення: ");
                    string numberToRemove = Console.ReadLine();
                    garage.RemoveCar(numberToRemove);
                    break;
                case "3":
                    garage.DisplayCars();
                    break;
                case "4":
                    Console.WriteLine("Програма завершена.");
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}
