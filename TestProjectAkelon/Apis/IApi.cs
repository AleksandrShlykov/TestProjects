using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectExcel.Apis
{
    internal interface IApi
    {
        void GetOrdersOfProduct(string filePath, string productName);
        void UpdateClientInfo(string filePath, string org, string name);
        void GetGoldenClient(string filePath, DateTime startDate, DateTime endDate);



    }
}
