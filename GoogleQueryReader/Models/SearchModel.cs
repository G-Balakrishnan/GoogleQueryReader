using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GoogleQueryReader.Models
{
    public class SearchModel
    {
  
        public string DirtKeyword { get; set; }
        [JsonIgnore]
        public string SearchQuery { get; set; }
        public string CountryCode { get; set; }
        public int ResultCount { get; set; } = 10;
        public string SortMode { get; set; } = "a";
        public int DaysRestricted { get; set; } = 900;
    }
}
