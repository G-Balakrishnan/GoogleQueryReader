using GoogleQueryReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleQueryReader.Context
{
    public class PlaceHolderRepository
    {
        public void Add(SearchModel model)
        {
            DataStore.PlaceHolders.Add(model);
        }
    }
}
