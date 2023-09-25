using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using static System.Reflection.Metadata.BlobBuilder;
using System.IO;

namespace AirportTicketBooking.DBHandler
{
    internal class CsvDataHandler<TKey, TModel, TMapper> where TKey : IEquatable<TKey> where TMapper : ClassMap<TModel>
    {
        protected Dictionary<TKey, TModel> DataDictionary { get; set; } = new();
        public async Task FetchData(
            string path, Func<TModel, TKey> extractUnique)
        {
            DataDictionary.Clear();
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, csvConfig);
            csv.Context.RegisterClassMap<TMapper>();
            var records = csv.GetRecordsAsync<TModel>();
            await foreach (var record in records)
            {
                DataDictionary.Add(extractUnique(record), record);
            }
        }
        public void AppendData(string path, TModel record)
        {
            using var stream = File.Open(path, FileMode.Append, FileAccess.Write);
            using var writer = new StreamWriter(stream);
            using var csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
            csvWriter.WriteRecord(record);
            csvWriter.NextRecord();
        }
        public void DeleteRecord(string path, TKey key)
        {
            DataDictionary.Remove(key);
            using (var writer = new StreamWriter(path))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(DataDictionary.Values);
            }
        }
    }
}
