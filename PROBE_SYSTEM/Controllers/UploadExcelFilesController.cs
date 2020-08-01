using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npoi.Mapper;
using PROBE_SYSTEM.Models;

namespace PROBE_SYSTEM.Controllers
{
    public class UploadExcelFilesController : Controller
    {
        private readonly ProbeDbContext _dbContext;

        public UploadExcelFilesController(ProbeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            string elapsedTime = "Upload a File.";

            if (TempData.ContainsKey("Message"))
                elapsedTime = TempData["Message"].ToString();

            ViewBag.ElapsedTime = elapsedTime;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile fileInfo)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var mapper = new Mapper(fileInfo.OpenReadStream());

            var data = mapper.Take<UploadData>("data").Select(x => x.Value);

            await _dbContext.UploadData.AddRangeAsync(data);

            await _dbContext.SaveChangesAsync();

            stopWatch.Start();

            var ts = stopWatch.Elapsed;

            var elapsedTime = $"Run Time: {ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";

            TempData["Message"] = elapsedTime;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Upload2(IFormFile fileInfo)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var mapper = new Mapper(fileInfo.OpenReadStream());

            var data = mapper.Take<UploadData>("data").Select(x => x.Value);

            using (var connection = new
                    SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                var dt = data.ToDataTable();

                var bulkCopy = new SqlBulkCopy(connection) { DestinationTableName = "UploadData" };

                var schema = connection.GetSchema("Columns", new[] { null, null, "UploadData", null });

                // Create Column Mappings.
                foreach (DataColumn sourceColumn in dt.Columns)
                {
                    foreach (DataRow row in schema.Rows)
                        if (string.Equals(sourceColumn.ColumnName, (string)row["COLUMN_NAME"],
                            StringComparison.OrdinalIgnoreCase))
                            bulkCopy.ColumnMappings
                                    .Add(sourceColumn.ColumnName, (string)row["COLUMN_NAME"]);
                }

                await bulkCopy.WriteToServerAsync(dt);
            }

            stopWatch.Start();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = $"Run Time: " +
                                 $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";

            TempData["Message"] = elapsedTime;

            return RedirectToAction("Index");
        }
    }
}