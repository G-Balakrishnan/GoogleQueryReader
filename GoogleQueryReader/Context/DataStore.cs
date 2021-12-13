using GoogleQueryReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleQueryReader.Context
{
    public class DataStore
    {
        private static List<SearchModel> _placeHolders;
        public static List<SearchModel> PlaceHolders
        {
            set
            {
                _placeHolders = value;
            }
            get
            {
                if (_placeHolders is null)
                {
                    _placeHolders = new List<SearchModel>();
                }
                return _placeHolders;
            }
        }
    }

}
