using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace AirportTicketBooking.DBHandler
{
    internal class CsvDataHandler<TKey, TModel, TMapper> where TKey : IEquatable<TKey> where TMapper : ClassMap<TModel>
    {
        protected Dictionary<TKey, TModel> DataDictionary { get; set; } = new();
        public async Task FetchData(
            string path, Func<TModel, TKey> extractUnique)
        {
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
    }
}
