namespace VehicleFactorySystem
{

  // Базовый интерфейс для всех транспортных средств. Root сущность
  public interface IVehicle
  {
    void Start();
    void Stop();
    string GetInfo();
  }

  // Интерфейс автомобиля. наследует root сущность
  public interface ICar : IVehicle
  {
    // открыть багажник
    void OpenTrunk();
  }

  // Интерфейс мотоцикла. наследует root сущность
  public interface IMotorcycle : IVehicle
  {
    void DoWheelie();
  }

  // ==================== КОНКРЕТНЫЕ ТРАНСПОРТНЫЕ СРЕДСТВА ====================

  // Электрический автомобиль
  public class ElectricCar : ICar
  {
    public void Start()
    {
      Console.WriteLine("Электрический автомобиль запущен.");
    }

    public void Stop()
    {
      Console.WriteLine("Электрический автомобиль остановлен.");
    }

    public string GetInfo()
    {
      return "Электрический автомобиль (ElectricCar)";
    }

    public void OpenTrunk()
    {
      Console.WriteLine("Багажник электрического автомобиля открыт.");
    }
  }

  // Бензиновый автомобиль
  public class GasCar : ICar
  {
    // функции переопределяют функции родителя
    public void Start()
    {
      Console.WriteLine("Бензиновый автомобиль запущен.");
    }

    public void Stop()
    {
      Console.WriteLine("Бензиновый автомобиль остановлен.");
    }

    public string GetInfo()
    {
      return "Бензиновый автомобиль (GasCar)";
    }

    public void OpenTrunk()
    {
      Console.WriteLine("Багажник бензинового автомобиля открыт.");
    }
  }

  // Электрический мотоцикл
  public class ElectricMotorcycle : IMotorcycle
  {
    public void Start()
    {
      Console.WriteLine("Электрический мотоцикл запущен.");
    }

    public void Stop()
    {
      Console.WriteLine("Электрический мотоцикл остановлен.");
    }

    public string GetInfo()
    {
      return "Электрический мотоцикл (ElectricMotorcycle)";
    }

    public void DoWheelie()
    {
      Console.WriteLine("Электрический мотоцикл встал на заднее колесо.");
    }
  }

  // Бензиновый мотоцикл
  public class GasMotorcycle : IMotorcycle
  {
    public void Start()
    {
      Console.WriteLine("Бензиновый мотоцикл запущен.");
    }

    public void Stop()
    {
      Console.WriteLine("Бензиновый мотоцикл остановлен.");
    }

    public string GetInfo()
    {
      return "Бензиновый мотоцикл (GasMotorcycle)";
    }

    public void DoWheelie()
    {
      Console.WriteLine("Бензиновый мотоцикл встал на заднее колесо.");
    }
  }

  // ==================== АБСТРАКТНАЯ ФАБРИКА ====================

  // Абстрактная фабрика транспортных средств
  public interface IVehicleFactory
  {
    ICar CreateCar();
    IMotorcycle CreateMotorcycle();
  }

  // Фабрика электрических транспортных средств
  public class ElectricVehicleFactory : IVehicleFactory
  {
    public ICar CreateCar()
    {
      return new ElectricCar();
    }

    public IMotorcycle CreateMotorcycle()
    {
      return new ElectricMotorcycle();
    }
  }

  // Фабрика бензиновых транспортных средств
  public class GasVehicleFactory : IVehicleFactory
  {
    public ICar CreateCar()
    {
      return new GasCar();
    }

    public IMotorcycle CreateMotorcycle()
    {
      return new GasMotorcycle();
    }
  }

  // ==================== МЕНЕДЖЕР ТРАНСПОРТНЫХ СРЕДСТВ ====================

  public class VehicleManager
  {
    private List<IVehicle> vehicles = new List<IVehicle>();

    public int Count
    {
      get { return vehicles.Count; }
    }

    public void CreateVehicle(string type, IVehicleFactory factory)
    {
      if (type == "car")
      {
        ICar car = factory.CreateCar();
        vehicles.Add(car);
        Console.WriteLine($"Создан: {car.GetInfo()}. Всего транспортных средств: {Count}");
      }
      else if (type == "motorcycle")
      {
        IMotorcycle motorcycle = factory.CreateMotorcycle();
        vehicles.Add(motorcycle);
        Console.WriteLine($"Создан: {motorcycle.GetInfo()}. Всего транспортных средств: {Count}");
      }
      else
      {
        Console.WriteLine("Неизвестный тип транспортного средства.");
      }
    }

    public void ShowAllVehicles()
    {
      if (vehicles.Count == 0)
      {
        Console.WriteLine("Список транспортных средств пуст.");
        return;
      }

      Console.WriteLine("Список всех транспортных средств:");
      for (int i = 0; i < vehicles.Count; i++)
      {
        Console.WriteLine($"{i + 1}. {vehicles[i].GetInfo()}");
      }
    }

    public void StartAllVehicles()
    {
      if (vehicles.Count == 0)
      {
        Console.WriteLine("Нет транспортных средств для запуска.");
        return;
      }

      foreach (IVehicle vehicle in vehicles)
      {
        vehicle.Start();
      }
      Console.WriteLine($"Все транспортные средства запущены. Всего транспортных средств: {Count}");
    }

    public void StopAllVehicles()
    {
      if (vehicles.Count == 0)
      {
        Console.WriteLine("Нет транспортных средств для остановки.");
        return;
      }

      foreach (IVehicle vehicle in vehicles)
      {
        vehicle.Stop();
      }
      Console.WriteLine($"Все транспортные средства остановлены. Всего транспортных средств: {Count}");
    }

    public void ClearAllVehicles()
    {
      vehicles.Clear();
      Console.WriteLine($"Список очищен. Всего транспортных средств: {Count}");
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      string fullName = "";
      string groupName = "";
      string practiceName = "ПР №2: Паттерн Абстрактная фабрика";
      string description = "Демонстрация работы системы создания транспортных средств";

      Console.WriteLine("==============================================");
      Console.WriteLine($"ФИО: {fullName}");
      Console.WriteLine($"Группа: {groupName}");
      Console.WriteLine($"Практическая работа: {practiceName}");
      Console.WriteLine($"Описание: {description}");
      Console.WriteLine("==============================================");
      Console.WriteLine();

      Console.WriteLine("--- Демонстрация работы паттерна «Абстрактная фабрика» ---");

      IVehicleFactory electricFactory = new ElectricVehicleFactory();
      IVehicleFactory gasFactory = new GasVehicleFactory();

      ICar electricCar = electricFactory.CreateCar();
      IMotorcycle electricMotorcycle = electricFactory.CreateMotorcycle();
      ICar gasCar = gasFactory.CreateCar();
      IMotorcycle gasMotorcycle = gasFactory.CreateMotorcycle();

      Console.WriteLine($"Электрическая фабрика создала: {electricCar.GetInfo()}");
      Console.WriteLine($"Электрическая фабрика создала: {electricMotorcycle.GetInfo()}");
      Console.WriteLine($"Бензиновая фабрика создала: {gasCar.GetInfo()}");
      Console.WriteLine($"Бензиновая фабрика создала: {gasMotorcycle.GetInfo()}");
      Console.WriteLine("Разные фабрики создают разные семейства объектов: электрические и бензиновые.");
      Console.WriteLine();

      VehicleManager manager = new VehicleManager();
      bool isRunning = true;

      while (isRunning)
      {
        Console.WriteLine();
        Console.WriteLine("========== МЕНЮ ==========");
        Console.WriteLine("1. Создать автомобиль");
        Console.WriteLine("2. Создать мотоцикл");
        Console.WriteLine("3. Показать все транспортные средства");
        Console.WriteLine("4. Запустить все транспортные средства");
        Console.WriteLine("5. Остановить все транспортные средства");
        Console.WriteLine("6. Очистить список");
        Console.WriteLine("7. Выход из программы");
        Console.Write("Выберите пункт меню: ");

        string choice = Console.ReadLine();
        Console.WriteLine();

        if (choice == "1")
        {
          IVehicleFactory factory = ChooseFactory();
          manager.CreateVehicle("car", factory);
        }
        else if (choice == "2")
        {
          IVehicleFactory factory = ChooseFactory();
          manager.CreateVehicle("motorcycle", factory);
        }
        else if (choice == "3")
        {
          manager.ShowAllVehicles();
        }
        else if (choice == "4")
        {
          manager.StartAllVehicles();
        }
        else if (choice == "5")
        {
          manager.StopAllVehicles();
        }
        else if (choice == "6")
        {
          manager.ClearAllVehicles();
        }
        else if (choice == "7")
        {
          Console.WriteLine("Выход из программы.");
          isRunning = false;
        }
        else
        {
          Console.WriteLine("Неверный пункт меню. Попробуйте снова.");
        }
      }

      Console.ReadKey();
    }

    static IVehicleFactory ChooseFactory()
    {
      while (true)
      {
        Console.WriteLine("Выберите тип: 1 — электрический, 2 — бензиновый");
        Console.Write("Ваш выбор: ");
        string typeChoice = Console.ReadLine();

        if (typeChoice == "1")
        {
          return new ElectricVehicleFactory();
        }
        else if (typeChoice == "2")
        {
          return new GasVehicleFactory();
        }
        else
        {
          Console.WriteLine("Неверный выбор. Попробуйте снова.");
        }
      }
    }
  }
}