
using TestProjectExcel.Apis;
using TestProjectExcel.Enums;

namespace TestProjectExcel.UI
{
    internal class ConsoleOutput
    {
        private string filePath = "";
        public bool OperationSelection(IApi api, int command)
        {
            
            switch (command - 1)
            {
                case ((int)Commands.InputPath):
                    {
                        Console.WriteLine("Введите путь до файла");
                        filePath = Console.ReadLine();
                        if (!File.Exists(filePath))
                        {
                            Console.WriteLine("Файл не нйден, попробуйте снова");
                            filePath = string.Empty;
                            return true;
                        }
                        Console.WriteLine("Файл найден!");
                        return true;
                    }
                case ((int)Commands.InputInfo):
                    {
                        if (string.IsNullOrEmpty(filePath))
                        {
                            Console.WriteLine("Не указан путь до файла");
                            return true;
                        }
                        Console.WriteLine("Ввведите имя товара:");
                        var productName = Console.ReadLine();
                        api.GetOrdersOfProduct(filePath, productName);
                        return true;
                    }
                case ((int)Commands.ChangeClientInfo):
                    {
                        if (string.IsNullOrEmpty(filePath))
                        {
                            Console.WriteLine("Не указан  путь до файла");
                            return true;
                        }
                        Console.WriteLine("Введите название организации и имя нового контактного лица через в следующем формате: Имя организации, имя контактного лица ");
                        //string orgAndName = "ООО Надежда, Вороновa Злата Алексеевна updated";
                        string orgAndName = Console.ReadLine();
                        var dataForUpdate = orgAndName.Split(", ");
                        var org = dataForUpdate[0];
                        var name = dataForUpdate[1];

                        api.UpdateClientInfo(filePath, org, name);
                        Console.ReadLine();
                        return true;
                    }

                case ((int)Commands.IsGoldenClient):
                    {
                        if (string.IsNullOrEmpty(filePath))
                        {
                            Console.WriteLine("Не указан  путь до файла");
                            return true;
                        }
                        Console.WriteLine("Укажите дату за которую нужно найти злотого клиента в следующем формате:начало периода, конец периода, например: 20.01.2023, 20.05.2023");
                        var inputPeriod = "01.05.2023, 30.06.2023";
                        Console.ReadLine();
                        var buffer = inputPeriod.Split(", ");
                        if (buffer.Length < 2)
                        {
                            Console.WriteLine("wrong data");
                            return true;
                        }
                        var parseResult1 = DateTime.TryParse(buffer[0], out var startDate);
                        var parseResult2 = DateTime.TryParse(buffer[1], out var endDate);
                        if (!parseResult1 || !parseResult2)
                        {
                            Console.WriteLine("wrong data");
                            return true;
                        }
                        Console.WriteLine("good data");
                        api.GetGoldenClient(filePath, startDate, endDate);
                        return true;
                    }
                case ((int)Commands.Finish):
                    {
                        Console.WriteLine("Завершение работы");
                        return false;
                    }
                default:
                    {
                        Console.WriteLine("Такой команды не существует, попробуйте снова");
                        return true;
                    }
                    
            }
        }
    }
}
