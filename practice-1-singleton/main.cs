class SettingsManager
{
  private static SettingsManager instance;
  private Dictionary<string, string> settings;

  private SettingsManager()
  {
    settings = new Dictionary<string, string>();
  }

  public static SettingsManager GetInstance()
  {
    if (instance == null)
    {
      instance = new SettingsManager();
    }
    return instance;
  }

  public void SetSetting(string key, string value)
  {
    settings[key] = value;
  }

  public string GetSetting(string key)
  {
    if (settings.ContainsKey(key))
    {
      return settings[key];
    }
    return null;
  }

  public void RemoveSetting(string key)
  {
    settings.Remove(key);
  }

  public void ShowAllSettings()
  {
    if (settings.Count == 0)
    {
      Console.WriteLine("Настроек нет.");
      return;
    }
    foreach (KeyValuePair<string, string> setting in settings)
    {
      Console.WriteLine($"{setting.Key} = {setting.Value}");
    }
  }

  public void ClearSettings()
  {
    settings.Clear();
  }

  public int GetCount()
  {
    return settings.Count;
  }
}

class Program
{
  static void Main()
  {
    string studentName = "";
    string groupName = "";
    string practiceName = "ПР №1: Паттерн Одиночка";

    Console.WriteLine($"Студент: {studentName}");
    Console.WriteLine($"Группа: {groupName}");
    Console.WriteLine($"Практическая работа: {practiceName}");
    Console.WriteLine();

    SettingsManager firstManager = SettingsManager.GetInstance();
    SettingsManager secondManager = SettingsManager.GetInstance();
    bool isSameInstance = firstManager == secondManager;
    Console.WriteLine($"Оба обращения к менеджеру настроек возвращают один объект: {isSameInstance}");
    Console.WriteLine();

    bool isRunning = true;
    while (isRunning)
    {
      Console.WriteLine("=== Меню ===");
      Console.WriteLine("1. Показать все настройки");
      Console.WriteLine("2. Добавить/Изменить настройку");
      Console.WriteLine("3. Получить значение настройки");
      Console.WriteLine("4. Удалить настройку");
      Console.WriteLine("5. Очистить все настройки");
      Console.WriteLine("6. Выход из программы");
      Console.Write("Выберите пункт: ");

      string choice = Console.ReadLine();
      SettingsManager manager = SettingsManager.GetInstance();

      if (choice == "1")
      {
        manager.ShowAllSettings();
      }
      else if (choice == "2")
      {
        Console.Write("Введите ключ: ");
        string key = Console.ReadLine();
        Console.Write("Введите значение: ");
        string value = Console.ReadLine();
        manager.SetSetting(key, value);
        Console.WriteLine($"Настройка добавлена. Всего настроек: {manager.GetCount()}");
      }
      else if (choice == "3")
      {
        Console.Write("Введите ключ: ");
        string key = Console.ReadLine();
        string value = manager.GetSetting(key);
        if (value != null)
        {
          Console.WriteLine($"Значение настройки {key}: {value}");
        }
        else
        {
          Console.WriteLine($"Настройка с ключом {key} не найдена.");
        }
      }
      else if (choice == "4")
      {
        Console.Write("Введите ключ: ");
        string key = Console.ReadLine();
        manager.RemoveSetting(key);
        Console.WriteLine($"Настройка удалена. Всего настроек: {manager.GetCount()}");
      }
      else if (choice == "5")
      {
        manager.ClearSettings();
        Console.WriteLine($"Все настройки очищены. Всего настроек: {manager.GetCount()}");
      }
      else if (choice == "6")
      {
        isRunning = false;
      }
      else
      {
        Console.WriteLine("Неверный пункт меню.");
      }

      Console.WriteLine();
    }
  }
}