using dica.Models;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IWorkbook ExportByCountry(InvestmentByCountryViewModel model)
        {
            //Create new Excel Workbook
            var workbook = CreateWorkbook();
            var styles = CreateStyles(workbook);

            //Create new Excel Sheet
            var sheet = workbook.CreateSheet("Country Total");

            CreateSheetForCountry(model, sheet, styles);

            //Write the Workbook to a memory stream

            return workbook;
        }

        public IWorkbook ExportByRegion(InvestmentByRegionViewModel model)
        {
            //Create new Excel Workbook
            var workbook = CreateWorkbook();
            var styles = CreateStyles(workbook);

            //Create new Excel Sheet
            var sheet = workbook.CreateSheet("Region Total");

            CreateSheetForRegion(model, sheet, styles);

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
            styleTitle.BorderTop = BorderStyle.Medium;
            styleTitle.BorderBottom = BorderStyle.Medium;
            styleTitle.BorderLeft = BorderStyle.Medium;
            styleTitle.BorderRight = BorderStyle.Medium;
            styleTitle.TopBorderColor = HSSFColor.Black.Index;
            styleTitle.BottomBorderColor = HSSFColor.Black.Index;
            styleTitle.LeftBorderColor = HSSFColor.Black.Index;
            styleTitle.RightBorderColor = HSSFColor.Black.Index;
            styles.Add("Title", styleTitle);

            var styleSubTitle = wb.CreateCellStyle();
            styleSubTitle.SetFont(font);
            styleSubTitle.Alignment = HorizontalAlignment.Center;
            styleSubTitle.BorderTop = BorderStyle.Medium;
            styleSubTitle.BorderBottom = BorderStyle.Medium;
            styleSubTitle.BorderLeft = BorderStyle.Medium;
            styleSubTitle.BorderRight = BorderStyle.Medium;
            styleSubTitle.TopBorderColor = HSSFColor.Black.Index;
            styleSubTitle.BottomBorderColor = HSSFColor.Black.Index;
            styleSubTitle.LeftBorderColor = HSSFColor.Black.Index;
            styleSubTitle.RightBorderColor = HSSFColor.Black.Index;
            styles.Add("SubTitle", styleSubTitle);

            var styleHeader = wb.CreateCellStyle();
            styleHeader.SetFont(font);
            styleHeader.Alignment = HorizontalAlignment.Center;
            styleHeader.WrapText = false;
            styleHeader.BorderTop = BorderStyle.Medium;
            styleHeader.BorderBottom = BorderStyle.Medium;
            styleHeader.BorderLeft = BorderStyle.Medium;
            styleHeader.BorderRight = BorderStyle.Medium;
            styleHeader.TopBorderColor = HSSFColor.Black.Index;
            styleHeader.BottomBorderColor = HSSFColor.Black.Index;
            styleHeader.LeftBorderColor = HSSFColor.Black.Index;
            styleHeader.RightBorderColor = HSSFColor.Black.Index;
            styleHeader.FillBackgroundColor = HSSFColor.Grey25Percent.Index;
            styles.Add("Header", styleHeader);

            var styleDateTime = wb.CreateCellStyle();
            styleDateTime.DataFormat = dataFormat.GetFormat("d/m/yyyy h:mm");
            styles.Add("DateTime", styleDateTime);

            var styleDate = wb.CreateCellStyle();
            styleDate.DataFormat = dataFormat.GetFormat("d/m/yyyy");
            styles.Add("Date", styleDate);

            var style2Decimal = wb.CreateCellStyle();
            style2Decimal.DataFormat = dataFormat.GetFormat("0.00"); // dataFormat.GetFormat("#0.00");
            style2Decimal.BorderTop = BorderStyle.Medium;
            style2Decimal.BorderBottom = BorderStyle.Medium;
            style2Decimal.BorderLeft = BorderStyle.Medium;
            style2Decimal.BorderRight = BorderStyle.Medium;
            style2Decimal.TopBorderColor = HSSFColor.Black.Index;
            style2Decimal.BottomBorderColor = HSSFColor.Black.Index;
            style2Decimal.LeftBorderColor = HSSFColor.Black.Index;
            style2Decimal.RightBorderColor = HSSFColor.Black.Index;
            styles.Add("2Decimal", style2Decimal);

            var style1Decimal = wb.CreateCellStyle();
            style1Decimal.DataFormat = dataFormat.GetFormat("0.0"); // dataFormat.GetFormat("#0.0");
            styles.Add("1Decimal", style1Decimal);

            var styleGeneral = wb.CreateCellStyle();
            styleGeneral.DataFormat = dataFormat.GetFormat("General");
            styleGeneral.WrapText = false;
            styleGeneral.BorderTop = BorderStyle.Medium;
            styleGeneral.BorderBottom = BorderStyle.Medium;
            styleGeneral.BorderLeft = BorderStyle.Medium;
            styleGeneral.BorderRight = BorderStyle.Medium;
            styleGeneral.TopBorderColor = HSSFColor.Black.Index;
            styleGeneral.BottomBorderColor = HSSFColor.Black.Index;
            styleGeneral.LeftBorderColor = HSSFColor.Black.Index;
            styleGeneral.RightBorderColor = HSSFColor.Black.Index;
            styles.Add("General", styleGeneral);

            return styles;
        }

        private void CreateSheetForCountry(InvestmentByCountryViewModel data, ISheet sheet, Dictionary<string, ICellStyle> styles)
        {            
            CreateTitleForCountry(sheet, styles, data);
            CreateHeaderForCountry(sheet, styles, data);
            CreateRowForCountry(sheet, styles, data);
            sheet.AutoSizeColumn(0, true);
            sheet.AutoSizeColumn(1, true);
        }

        private static void CreateTitleForCountry(ISheet sheet, Dictionary<string, ICellStyle> styles, InvestmentByCountryViewModel data)
        {
            //Create a header row
            var row = sheet.CreateRow(0);

            for (int i = 0; i <= (data.Sectors.Count * 2) + 1; ++i)
            {
                var cell = row.CreateCell(i);
                cell.CellStyle = styles["Title"];
                if (i == 0)
                {
                    cell.SetCellValue("Appendix (A)");
                }
            }
            sheet.AddMergedRegion(new CellRangeAddress(
                    0, //first row (0-based)
                    0, //last row  (0-based)
                    0, //first column (0-based)
                    (data.Sectors.Count * 2) + 1  //last column  (0-based)
            ));

            
            row = sheet.CreateRow(1);

            for (int i = 0; i <= (data.Sectors.Count * 2) + 1; ++i)
            {
                var cell = row.CreateCell(i);
                cell.CellStyle = styles["SubTitle"];
                if (i == 0)
                {
                    var title = string.Format("Foreign Investment of Existing Enterprises from {0} to {1}", data.FromDate.Value.ToString("dd/MMM/yyyy"), data.ToDate.Value.ToString("dd/MMM/yyyy"));
                    cell.SetCellValue(title);
                }
            }

            sheet.AddMergedRegion(new CellRangeAddress(
                    1, //first row (0-based)
                    1, //last row  (0-based)
                    0, //first column (0-based)
                    (data.Sectors.Count * 2) + 1  //last column  (0-based)
            ));

            row = sheet.CreateRow(2);

            for (int i = 0; i <= (data.Sectors.Count * 2) + 1; ++i)
            {
                var cell = row.CreateCell(i);
                cell.CellStyle = styles["Title"];
                if (i == 0)
                {
                    cell.SetCellValue("US Dollar (Million)");
                }
            }

            sheet.AddMergedRegion(new CellRangeAddress(
                    2, //first row (0-based)
                    2, //last row  (0-based)
                    0, //first column (0-based)
                    (data.Sectors.Count * 2) + 1  //last column  (0-based)
            ));
        }

        private static void CreateHeaderForCountry(ISheet sheet, Dictionary<string, ICellStyle> styles, InvestmentByCountryViewModel data)
        {          
            var row = sheet.CreateRow(3);
            var cell = row.CreateCell(0);
            cell.CellStyle = styles["Header"];
            cell.SetCellValue("#");

            

            cell = row.CreateCell(1);
            cell.CellStyle = styles["Header"];
            cell.SetCellValue("Country");

            

            var columNo = 2;
            data.Sectors.ForEach(s=> {
                var firstColumnNo = columNo;
                cell = row.CreateCell(columNo++);
                cell.CellStyle = styles["Header"];
                cell.SetCellValue(s.Name);

                cell = row.CreateCell(columNo);
                cell.CellStyle = styles["Header"];
                cell.SetCellValue(s.Name);

                sheet.AddMergedRegion(new CellRangeAddress(
                    3, //first row (0-based)
                    3, //last row  (0-based)
                    firstColumnNo, //first column (0-based)
                    columNo++ //last column  (0-based)
                ));
            });

            row = sheet.CreateRow(4);

            cell = row.CreateCell(0);
            cell.CellStyle = styles["Header"];

            cell = row.CreateCell(1);
            cell.CellStyle = styles["Header"];

            columNo = 2;
            data.Sectors.ForEach(s => {
                cell = row.CreateCell(columNo++);
                cell.CellStyle = styles["Header"];
                cell.SetCellValue("Amount");


                cell = row.CreateCell(columNo++);
                cell.CellStyle = styles["Header"];
                cell.SetCellValue("Qty");
            });

            sheet.AddMergedRegion(new CellRangeAddress(
                    3, //first row (0-based)
                    4, //last row  (0-based)
                    0, //first column (0-based)
                    0  //last column  (0-based)
            ));

            sheet.AddMergedRegion(new CellRangeAddress(
                    3, //first row (0-based)
                    4, //last row  (0-based)
                    1, //first column (0-based)
                    1  //last column  (0-based)
            ));
        }

        private static void CreateRowForCountry(ISheet sheet, Dictionary<string, ICellStyle> styles, InvestmentByCountryViewModel data)
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

        private void CreateSheetForRegion(InvestmentByRegionViewModel data, ISheet sheet, Dictionary<string, ICellStyle> styles)
        {
            CreateTitleForRegion(sheet, styles, data);
            CreateHeaderForRegion(sheet, styles, data);
            CreateRowForRegion(sheet, styles, data);
            sheet.AutoSizeColumn(0, true);
            sheet.AutoSizeColumn(1, true);
        }

        private static void CreateTitleForRegion(ISheet sheet, Dictionary<string, ICellStyle> styles, InvestmentByRegionViewModel data)
        {
            //Create a header row
            var row = sheet.CreateRow(0);

            for (int i = 0; i <= (data.Sectors.Count * 2) + 1; ++i)
            {
                var cell = row.CreateCell(i);
                cell.CellStyle = styles["Title"];
                if (i == 0)
                {
                    cell.SetCellValue("Appendix (A)");
                }
            }
            sheet.AddMergedRegion(new CellRangeAddress(
                    0, //first row (0-based)
                    0, //last row  (0-based)
                    0, //first column (0-based)
                    (data.Sectors.Count * 2) + 1  //last column  (0-based)
            ));


            row = sheet.CreateRow(1);

            for (int i = 0; i <= (data.Sectors.Count * 2) + 1; ++i)
            {
                var cell = row.CreateCell(i);
                cell.CellStyle = styles["SubTitle"];
                if (i == 0)
                {
                    var title = string.Format("Foreign Investment of Existing Enterprises from ({0}) to ({1})", data.FromDate.Value.ToString("dd/MMM/yyyy"), data.ToDate.Value.ToString("dd/MMM/yyyy"));
                    cell.SetCellValue(title);
                }
            }

            sheet.AddMergedRegion(new CellRangeAddress(
                    1, //first row (0-based)
                    1, //last row  (0-based)
                    0, //first column (0-based)
                    (data.Sectors.Count * 2) + 1  //last column  (0-based)
            ));

            row = sheet.CreateRow(2);

            for (int i = 0; i <= (data.Sectors.Count * 2) + 1; ++i)
            {
                var cell = row.CreateCell(i);
                cell.CellStyle = styles["Title"];
                if (i == 0)
                {
                    cell.SetCellValue("US Dollar (Million)");
                }
            }

            sheet.AddMergedRegion(new CellRangeAddress(
                    2, //first row (0-based)
                    2, //last row  (0-based)
                    0, //first column (0-based)
                    (data.Sectors.Count * 2) + 1  //last column  (0-based)
            ));
        }

        private static void CreateHeaderForRegion(ISheet sheet, Dictionary<string, ICellStyle> styles, InvestmentByRegionViewModel data)
        {
            var row = sheet.CreateRow(3);
            var cell = row.CreateCell(0);
            cell.CellStyle = styles["Header"];
            cell.SetCellValue("#");

            cell = row.CreateCell(1);
            cell.CellStyle = styles["Header"];
            cell.SetCellValue("Region");

            var columNo = 2;
            data.Sectors.ForEach(s => {
                var firstColumnNo = columNo;
                cell = row.CreateCell(columNo++);
                cell.CellStyle = styles["Header"];
                cell.SetCellValue(s.Name);

                cell = row.CreateCell(columNo);
                cell.CellStyle = styles["Header"];
                cell.SetCellValue(s.Name);

                sheet.AddMergedRegion(new CellRangeAddress(
                    3, //first row (0-based)
                    3, //last row  (0-based)
                    firstColumnNo, //first column (0-based)
                    columNo++ //last column  (0-based)
                ));
            });

            row = sheet.CreateRow(4);

            cell = row.CreateCell(0);
            cell.CellStyle = styles["Header"];

            cell = row.CreateCell(1);
            cell.CellStyle = styles["Header"];

            columNo = 2;
            data.Sectors.ForEach(s => {
                cell = row.CreateCell(columNo++);
                cell.CellStyle = styles["Header"];
                cell.SetCellValue("Amount");


                cell = row.CreateCell(columNo++);
                cell.CellStyle = styles["Header"];
                cell.SetCellValue("Qty");
            });

            sheet.AddMergedRegion(new CellRangeAddress(
                    3, //first row (0-based)
                    4, //last row  (0-based)
                    0, //first column (0-based)
                    0  //last column  (0-based)
            ));

            sheet.AddMergedRegion(new CellRangeAddress(
                    3, //first row (0-based)
                    4, //last row  (0-based)
                    1, //first column (0-based)
                    1  //last column  (0-based)
            ));
        }

        private static void CreateRowForRegion(ISheet sheet, Dictionary<string, ICellStyle> styles, InvestmentByRegionViewModel data)
        {
            var rowNo = 5;
            var recordNo = 1;
            foreach (var region in data.Regions)
            {
                var row = sheet.CreateRow(rowNo++);

                var cell = row.CreateCell(0);
                cell.CellStyle = styles["General"];
                cell.SetCellValue(recordNo++);

                cell = row.CreateCell(1);
                cell.CellStyle = styles["General"];
                cell.SetCellValue(region);

                var columNo = 2;
                data.Sectors.ForEach(sector => {
                    var investment = data.InvestmentByRegions.Where(i => i.Region == region && i.Sector == sector.Name).FirstOrDefault();
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