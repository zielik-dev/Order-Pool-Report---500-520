using Microsoft.Office.Interop.Excel;
using Order_Pool_Report___500___520.Domain.List;
using Order_Pool_Report___500___520.Infrastructure;
using Order_Pool_Report___500___520.Models.Queries;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Order_Pool_Report___500___520.Domain.Excel
{
    public class ExcelMain : ConnectionStrings
    {
        public static void ExcelMainRun(List<RpOracleDbDataExtractModel> dbRawList, string template, DateTime dt)
        {
            Application xlApp = new Application
            {
                Visible = false,
                ScreenUpdating = false,
                DisplayAlerts = false
            };

            Workbook destWb = xlApp.Workbooks.Open(template, 0, false, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Worksheet plannedWs = destWb.Worksheets.get_Item(srcPlanned);
            Worksheet unPlannedWs = destWb.Worksheets.get_Item(srcUnPlanned);

            HouseKeeping.Clear(plannedWs, unPlannedWs);

            var uniqueOrderList = UniqueOrderNumbersList.GetUniqueOrderNumbers(dbRawList);
            Console.WriteLine($"Total unique order numbers: {uniqueOrderList.Count}");

            var finalListForExce = FinalListForExcel.BuildFinalList(dbRawList, uniqueOrderList);
            Console.WriteLine($"Total records in Excel List: {finalListForExce.Count}");

            TransferDataToExcel.InsertToWorksheet(finalListForExce, plannedWs, unPlannedWs);
            Console.WriteLine("Data to Excel transferred");


            string stamp = dt.ToString("dd-MM-yyyy ");
            string excelOutboundPath = String.Concat(archiveDir, stamp, srcTemplateFile);

            destWb.Save();
            destWb.SaveAs(excelOutboundPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            destWb.Close();

            xlApp.ScreenUpdating = true;
            xlApp.DisplayAlerts = true;
            xlApp.Quit();

            int pid = -1;
            HandleRef hwnd = new HandleRef(xlApp, (IntPtr)xlApp.Hwnd);
            GetWindowThreadProcessId(hwnd, out pid);

            KillProcess(pid, "EXCEL");
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(HandleRef handle, out int processId);
        public static void KillProcess(int pid, string processName)
        {
            // to kill current process of excel
            Process[] AllProcesses = Process.GetProcessesByName(processName);
            foreach (Process process in AllProcesses)
            {
                if (process.Id == pid)
                {
                    process.Kill();
                }
            }
            AllProcesses = null;
        }
    }
}
