using ClosedXML.Excel;


namespace TestProjectExcel.Apis
{
    internal class ExcelApi : IApi
    {
       
        public void GetOrdersOfProduct(string filePath, string productName)
        {
            using (XLWorkbook workbook = new XLWorkbook(filePath))
            {
                var wsProduct = workbook.Worksheet("Товары");
                var wsClients = workbook.Worksheet("Клиенты");
                var wsRequest = workbook.Worksheet("Заявки");
                var result = wsProduct.Rows()
                 .Join(wsRequest.Rows(),
                       rowProduct => rowProduct.Cell(1).Value,
                       rowRequest => rowRequest.Cell(2).Value,
                       (rowProduct, rowRequest) => new { RowProduct = rowProduct, RowRequest = rowRequest })
                 .Join(wsClients.Rows(),
                       tmp => tmp.RowRequest.Cell(3).Value,
                       rowClients => rowClients.Cell(1).Value,
                       (tmp, rowClients) => new { Tmp = tmp, RowClients = rowClients })
                 .Where(tmp => tmp.Tmp.RowProduct.Cell(2).Value.ToString().ToLower() == productName.ToLower())
                 .Select(tmp => new
                 {
                     ClientInfo = "id = " + tmp.RowClients.Cell(1).Value + ", " + tmp.RowClients.Cell(2).Value + ", " + tmp.RowClients.Cell(3).Value + ", " + tmp.RowClients.Cell(4).Value,
                     ProductAmount = tmp.Tmp.RowRequest.Cell(5).Value,
                     RequstCost = (int)tmp.Tmp.RowRequest.Cell(5).Value * (int)tmp.Tmp.RowProduct.Cell(4).Value,
                     RequestDate = tmp.Tmp.RowRequest.Cell(6).Value
                 });
                if (!result.Any())
                {
                    Console.WriteLine("Данный товар не заказывали");
                }
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }


        public void UpdateClientInfo(string filePath, string org, string name)
        {
            using (XLWorkbook workbook = new XLWorkbook(filePath))
            {
                var wsClients = workbook.Worksheet("Клиенты");
                var dataCell = wsClients.FirstCellUsed(c => c.Value.ToString() == org);
                var cellAddres = dataCell.Address;
                var newCell = wsClients.Cell(cellAddres.RowNumber, cellAddres.ColumnNumber + 2);
                newCell.Value = name;
                workbook.Save();
                Console.WriteLine("Данные были успешно обновлены!");
            }
        }

        public void GetGoldenClient(string filePath, DateTime startDate, DateTime endDate)
        {
            using (XLWorkbook workbook = new XLWorkbook(filePath))
            {
                var wsProduct = workbook.Worksheet("Товары");
                var wsClients = workbook.Worksheet("Клиенты");
                var wsRequest = workbook.Worksheet("Заявки");
                var result = wsProduct.Rows()
                        .Join(wsRequest.Rows(),
                           rowProduct => rowProduct.Cell(1).Value,
                           rowRequest => rowRequest.Cell(2).Value,
                           (rowProduct, rowRequest) => new { RowProduct = rowProduct, RowRequest = rowRequest })
                        .Where(x => x.RowRequest.RowNumber() > 1 && x.RowRequest.CellsUsed().Count() > 0)
                        .Join(wsClients.Rows(),
                        tmp => tmp.RowRequest.Cell(3).Value,
                        rowClients => rowClients.Cell(1).Value,
                        (tmp, rowClients) => new { Tmp = tmp, RowClients = rowClients })
                        .Select(tmp => new
                        {
                            ClientInfo = "id = " + tmp.RowClients.Cell(1).Value + ", " + tmp.RowClients.Cell(2).Value + ", " + tmp.RowClients.Cell(3).Value + ", " + tmp.RowClients.Cell(4).Value,
                            ProductAmount = tmp.Tmp.RowRequest.Cell(5).Value,
                            RequstCostPerItem = tmp.Tmp.RowProduct.Cell(4).Value,
                            RequestDate = tmp.Tmp.RowRequest.Cell(6).Value
                        })
                        .Where(x => ((DateTime)x.RequestDate) >= startDate && ((DateTime)x.RequestDate) <= endDate)
                        .GroupBy(x => x.ClientInfo)
                        .Select(g => new
                        {
                            ClientInfo = g.Key,
                            TotalProductAmount = g.Sum(x => (int)x.ProductAmount),
                            TotalRequestCost = g.Sum(x => ((int)x.ProductAmount * (double)x.RequstCostPerItem))
                        });

                var max = result.OrderByDescending(p => p.TotalRequestCost).FirstOrDefault();
                Console.WriteLine(max);

            }
        }
    }
}
