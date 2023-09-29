using Order_Pool_Report___500___520.DbContext;
using Order_Pool_Report___500___520.Domain.Excel;
using Order_Pool_Report___500___520.Domain.List;
using Order_Pool_Report___500___520.Infrastructure.Files;
using Order_Pool_Report___500___520.Infrastructure.Smtp;
using Order_Pool_Report___500___520.Interfaces;
using Order_Pool_Report___500___520.Logs;
using Order_Pool_Report___500___520.Models.Queries;

//start app measure
var watch = System.Diagnostics.Stopwatch.StartNew();
DateTime dt = DateTime.Now;

string environment = "Production";
//string environment = "Test";

//EF DbContext
_ = new ApplicationLogsDbContext(environment);

//File
string template = TemplateFullPath.Template();

//Db Extract
IExtractDataFromDb dbExtract = new ExtractDataFromDb();
List<RpOracleDbDataExtractModel> dbRawList = dbExtract.GetList();
Console.WriteLine($"No. of lines extracted from DB: {dbRawList.Count}");

//Excel
ExcelMain.ExcelMainRun(dbRawList, template, dt);

//Email
IEmailReport emailReport = new EmailReport();
emailReport.Send(environment, dt, template);

//TV dashboard log
InsertLogToDb.Complete(environment);

//End app measure
watch.Stop();
var elapsedMs = watch.ElapsedMilliseconds;
Console.WriteLine(elapsedMs);