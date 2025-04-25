using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Data;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace Movies.Api.Seed
{
    public class CsvImporter
    {
        public async Task ImportCsvAsync(string csvPath, string connectionString)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
                MissingFieldFound = null,
                BadDataFound = null
            };

            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, config);
            using var dr = new CsvDataReader(csv);

            using var bulkCopy = new SqlBulkCopy(connectionString)
            {
                DestinationTableName = "Movies",
                BatchSize = 10000,
                BulkCopyTimeout = 0,
                NotifyAfter = 10000
            };

            bulkCopy.SqlRowsCopied += (sender, e) =>
            {
                Console.WriteLine($"{e.RowsCopied} lines inserted...");
            };

            await bulkCopy.WriteToServerAsync(dr);
        }
    }
}