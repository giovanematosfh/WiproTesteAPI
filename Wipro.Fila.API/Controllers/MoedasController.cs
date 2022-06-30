using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Data;
using System.Globalization;
using Wipro.Fila.API.Models;
using Wipro.Fila.Domain.Entities;
using Wipro.Fila.Domain.Repository;

namespace Wipro.Fila.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class MoedasController : Controller
    {
        //private static List<ItemFila> itens = new List<ItemFila>();
        public MoedasController()
        {

        }

        [HttpPost]
        public void AddItemFila([FromServices] IItemFileRpository repository, ICollection<ItemFila> itemFilas)
        {
            foreach(var item in itemFilas)
            {
                repository.Create(item);
            }
            

        }

        [HttpGet]
        public IActionResult GetItemFila([FromServices] IItemFileRpository repository)
        {
            //var fileDirectory = Directory.GetCurrentDirectory();
            //if (fileDirectory == null) return Ok();

            //fileDirectory += "\\DadosMoeda.xlsx";
            //var moedasCsv = ReadFromExcel<DadosMoedaCsv>(fileDirectory);


            //// filtrar moedas por Id da moeda e data de inicio e fim
            //foreach (ItemFila item in itens)
            //{
            //    moedasCsv = moedasCsv.Where(w => w.Id_Moeda == item.Moeda && DateTime.Parse(w.Data_Ref, CultureInfo.CurrentCulture) >= item.Data_Inicio && DateTime.Parse(w.Data_Ref, CultureInfo.CurrentCulture) <= item.Data_Fim).ToList();
            //}
            var itens = repository.GetAll();
            return Ok(itens);
        }

        private static List<T> ReadFromExcel<T>(string path, bool hasHeader = true)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileInfo existingFile = new FileInfo(path);
            using (var excelPack = new ExcelPackage(existingFile))
            {

                //Lets Deal with first worksheet.(You may iterate here if dealing with multiple sheets)
                var ws = excelPack.Workbook.Worksheets[0];

                //Get all details as DataTable -because Datatable make life easy :)
                DataTable excelasTable = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    //Get colummn details
                    if (!string.IsNullOrEmpty(firstRowCell.Text))
                    {
                        string firstColumn = string.Format("Column {0}", firstRowCell.Start.Column);
                        excelasTable.Columns.Add(hasHeader ? firstRowCell.Text : firstColumn);
                    }
                }

                var startRow = hasHeader ? 2 : 1;
                //Get row details
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, excelasTable.Columns.Count];
                    DataRow row = excelasTable.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                //Get everything as generics and let end user decides on casting to required type
                return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(excelasTable));
            }
        }
    }
}
