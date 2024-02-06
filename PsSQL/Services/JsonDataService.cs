using Newtonsoft.Json;
using PsSQL.Models.DTOs;
using PsSQL.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace PsSQL.Services
{
    public class JsonDataService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _appDataPath;

        public JsonDataService(IWebHostEnvironment environment, string appDataPath)
        {
            _environment = environment;
            _appDataPath = appDataPath ?? Path.Combine(_environment.ContentRootPath, "App_Data");
        }

        private string JsonFilePath => Path.Combine(_appDataPath, "books.json");

        public List<BookModel> GetBooks()
        {
            try
            {
                string jsonContent = File.ReadAllText(JsonFilePath);

                if (!string.IsNullOrEmpty(jsonContent))
                {
                    return JsonConvert.DeserializeObject<List<BookModel>>(jsonContent) ?? new List<BookModel>();
                }
                else
                {
                    return new List<BookModel>();
                }
            }
            catch (Exception ex)
            {
                return new List<BookModel>();
            }
        }
    }
}
