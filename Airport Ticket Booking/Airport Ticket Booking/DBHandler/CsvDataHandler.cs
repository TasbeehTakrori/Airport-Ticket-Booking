using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace AirportTicketBooking.DBHandler
{
    internal class CsvDataHandler<TModel>
    {
        protected Dictionary<string, TModel> DataDictionary { get; set; } = new();

        public async Task FetchData<TMapper>(
            string path, Func<TModel, string> extractUnique) where TMapper : ClassMap<TModel>
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
