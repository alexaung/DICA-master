using dica.Models;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace dica.Helper
{
    public class ExcelExportService
    {
        public ExcelVersion ExcelVersion { get; }
        public static DateTimeOffset? CurrentEventTime { get; set; }
        public string MIME => ExcelVersion == ExcelVersion.Excel2007AndAbove ? "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" : "application/vnd.ms-excel";
        public string Extension => ExcelVersion == ExcelVersion.Excel2007AndAbove ? "xlsx" : "xls";

        public ExcelExportService(ExcelVersion excelVersion = ExcelVersion.Excel2007AndAbove)
        {
            ExcelVersion = excelVersion;
        }

        public IWorkbook Export(InvestmentByCountryViewModel model)
        {
            //Create new Excel Workbook
            var workbook = CreateWorkbook();
            var styles = CreateStyles(workbook);

            //Create new Excel Sheet
            var sheet = workbook.CreateSheet("SimpleReport");

            CreateSheet(model, sheet, styles);

            //Write the Workbook to a memory stream

            return workbook;
        }

        private IWorkbook CreateWorkbook()
        {
            if (ExcelVersion == ExcelVersion.Excel2007AndAbove)
                return new XSSFWorkbook();

            return new HSSFWorkbook();
        }

        private static Dictionary<string, ICellStyle> CreateStyles(IWorkbook wb)
        {
            var styles = new Dictionary<string, ICellStyle>();
            var dataFormat = wb.CreateDataFormat();

            var font = wb.CreateFont();
            font.Boldweight = (short)FontBoldWeight.Bold;

            var styleTitle = wb.CreateCellStyle();
            styleTitle.SetFont(font);
            styleTitle.Alignment = HorizontalAlignment.Right;
            styles.Add("Title", styleTitle);

            var styleHeader = wb.CreateCellStyle();
            styleHeader.SetFont(font);
            styleHeader.Alignment = HorizontalAlignment.Center;
            styles.Add("Header", styleHeader);

            var styleDateTime = wb.CreateCellStyle();
            styleDateTime.DataFormat = dataFormat.GetFormat("d/m/yyyy h:mm");
            styles.Add("DateTime", styleDateTime);

            var styleDate = wb.CreateCellStyle();
            styleDate.DataFormat = dataFormat.GetFormat("d/m/yyyy");
            styles.Add("Date", styleDate);

            var style2Decimal = wb.CreateCellStyle();
            style2Decimal.DataFormat = dataFormat.GetFormat("0.00"); // dataFormat.GetFormat("#0.00");
            styles.Add("2Decimal", style2Decimal);

            var style1Decimal = wb.CreateCellStyle();
            style1Decimal.DataFormat = dataFormat.GetFormat("0.0"); // dataFormat.GetFormat("#0.0");
            styles.Add("1Decimal", style1Decimal);

            var styleGeneral = wb.CreateCellStyle();
            styleGeneral.DataFormat = dataFormat.GetFormat("General");
            styleGeneral.WrapText = false;
            styleGeneral.BottomBorderColor = HSSFColor.Black.Index;
            styles.Add("General", styleGeneral);

            return styles;
        }

        private void CreateSheet(InvestmentByCountryViewModel data, ISheet sheet, Dictionary<string, ICellStyle> styles)
        {
            
            CreateTitle(sheet, styles, data);
            CreateHeader(sheet, styles, data);
            CreateRow(sheet, styles, data);
            
            sheet.AutoSizeColumn(0, true);
            sheet.AutoSizeColumn(1, true);
        }

        private static void CreateTitle(ISheet sheet, Dictionary<string, ICellStyle> styles, InvestmentByCountryViewModel data)
        {
            //Create a header row
            var row = sheet.CreateRow(0);

            var cell = row.CreateCell(0);
            cell.CellStyle = styles["Title"];
            cell.SetCellValue("This is a Titel");

            sheet.AddMergedRegion(new CellRangeAddress(
                    0, //first row (0-based)
                    0, //last row  (0-based)
                    0, //first column (0-based)
                    (data.Sectors.Count * 2) + 1  //last column  (0-based)
            ));

            row = sheet.CreateRow(1);

            cell = row.CreateCell(0);
            cell.CellStyle = styles["Header"];
            cell.SetCellValue("This is a Title");

            sheet.AddMergedRegion(new CellRangeAddress(
                    1, //first row (0-based)
                    1, //last row  (0-based)
                    0, //first column (0-based)
                    (data.Sectors.Count * 2) + 1  //last column  (0-based)
            ));

            row = sheet.CreateRow(2);

            cell = row.CreateCell(0);
            cell.CellStyle = styles["Title"];
            //cell.CellStyle.Alignment = HorizontalAlignment.Right;
            cell.SetCellValue("This is a Title");

            sheet.AddMergedRegion(new CellRangeAddress(
                    2, //first row (0-based)
                    2, //last row  (0-based)
                    0, //first column (0-based)
                    (data.Sectors.Count * 2) + 1  //last column  (0-based)
            ));
        }
        private static void CreateHeader(ISheet sheet, Dictionary<string, ICellStyle> styles, InvestmentByCountryViewModel data)
        {          
            var row = sheet.CreateRow(3);
            var cell = row.CreateCell(0);
            cell.CellStyle = styles["Header"];
            cell.SetCellValue("#");

            sheet.AddMergedRegion(new CellRangeAddress(
                    3, //first row (0-based)
                    4, //last row  (0-based)
                    0, //first column (0-based)
                    0  //last column  (0-based)
            ));

            cell = row.CreateCell(1);
            cell.CellStyle = styles["Header"];
            cell.SetCellValue("Country");

            sheet.AddMergedRegion(new CellRangeAddress(
                    3, //first row (0-based)
                    4, //last row  (0-based)
                    1, //first column (0-based)
                    1  //last column  (0-based)
            ));

            var columNo = 2;
            data.Sectors.ForEach(s=> {
                cell = row.CreateCell(columNo);
                cell.CellStyle = styles["Header"];
                cell.SetCellValue(s.Name);

                sheet.AddMergedRegion(new CellRangeAddress(
                    3, //first row (0-based)
                    3, //last row  (0-based)
                    columNo++, //first column (0-based)
                    columNo++  //last column  (0-based)
                ));
            });

            row = sheet.CreateRow(4);
            columNo = 2;
            data.Sectors.ForEach(s => {
                cell = row.CreateCell(columNo++);
                cell.CellStyle = styles["Header"];
                cell.SetCellValue("Amount");


                cell = row.CreateCell(columNo++);
                cell.CellStyle = styles["Header"];
                cell.SetCellValue("Qty");
            });
        }

        private static void CreateRow(ISheet sheet, Dictionary<string, ICellStyle> styles, InvestmentByCountryViewModel data)
        {
            var rowNo = 5;
            var recordNo = 1;
            foreach (var country in data.Countries)
            {
                var row = sheet.CreateRow(rowNo++);

                var cell = row.CreateCell(0);
                cell.CellStyle = styles["General"];
                cell.SetCellValue(recordNo++);

                cell = row.CreateCell(1);
                cell.CellStyle = styles["General"];
                cell.SetCellValue(country.Name);

                var columNo = 2;
                data.Sectors.ForEach(sector => {
                    var investment = data.InvestmentByCountries.Where(i => i.Country == country.Name && i.Sector == sector.Name).FirstOrDefault();
                    cell = row.CreateCell(columNo++);
                    cell.CellStyle = styles["2Decimal"];
                    if (investment != null)
                        cell.SetCellValue(Convert.ToDouble(investment.Amount));

                    cell = row.CreateCell(columNo++);
                    cell.CellStyle = styles["General"];
                    if (investment != null)
                        cell.SetCellValue(investment.Quantity);
                });

            }
        }
    }
}