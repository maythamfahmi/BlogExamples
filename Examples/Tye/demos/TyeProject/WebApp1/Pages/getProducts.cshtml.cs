using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace WebApp1.Pages
{
    public class getProductsModel : PageModel
    {
        public List<string> ProductTitles { get; set; }

        public getProductsModel(SqlConnection connection, IDistributedCache cache)
        {
            this.ProductTitles = GetFromCache(cache, connection);
        }

        public List<string> GetFromCache(IDistributedCache cache, SqlConnection connection)
        {
            var json = cache.GetString("productTitles");

            if(json == null)
            {
                var productTitles = GetTitlesFromDb(connection);

                var cacheJson = JsonConvert.SerializeObject(productTitles);

                cache.SetString("productTitles", cacheJson);

                json = cacheJson;
            }

            return JsonConvert.DeserializeObject<List<string>>(json);
        }

        public List<string> GetTitlesFromDb(SqlConnection connection)
        {
            connection.Open();

            var command = new SqlCommand("SELECT TITLE FROM Products", connection);
            var result = command.ExecuteReader();

            var products = new List<string>();

            while (result.Read())
            {
                products.Add(result.GetString(0));
            }

            connection.Close();

            return products;
        }

        public void OnGet()
        {
        }
    }
}
