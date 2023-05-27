using TestProjectExcel.Apis;
using TestProjectExcel.UI;

// "C:\\Code\\TestProject\\TestProjectExcel\\ClietnsInfo.xlsx";
var ceepWork = true;
var commandStringTemp = "(1) Ввести путь до файла, (2) Вывести информацию о клиентах, (3) Изменить данные, (4) Запрос на определение золотого клиента, (5) Завершение работы";
while (ceepWork)
{
    Console.WriteLine("Выберете 1 из команд:");
    var commandLanes = commandStringTemp.Split(", ");
    foreach (var c in commandLanes)
    {
        Console.WriteLine(c);
    }
    var commandString = Console.ReadLine();
    var isParsed = int.TryParse(commandString, out var command);
    var fullInfo = new List<string>();
    ConsoleOutput output = new ConsoleOutput();
    if (isParsed)
    {
      ceepWork = output.OperationSelection(new ExcelApi(), command);
    }
        
}

