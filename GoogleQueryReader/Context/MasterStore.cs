using GoogleQueryReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GoogleQueryReader.Context
{
    public class MasterStore
    {
        private static List<CountryCodeModel> _countryCodeModels;
        public static List<CountryCodeModel> CountryCodes
        {
            get
            {
                if (_countryCodeModels == null)
                {
                    var options = new JsonSerializerOptions
                    {
                        NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
                    };
                    string json =File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/CountryCodes.json"));
                    _countryCodeModels = JsonSerializer.Deserialize<List<CountryCodeModel>>(json, options);
                }
                return _countryCodeModels;
            }
            set
            {
                _countryCodeModels = value;
            }
        }





    }
}
