using GoogleQueryReader.Context;
using GoogleQueryReader.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoogleQueryReader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaceHolderController : ControllerBase
    {
        private readonly PlaceHolderRepository placeHolderRepository;
        public PlaceHolderController(PlaceHolderRepository placeHolderRepository)
        {
            this.placeHolderRepository = placeHolderRepository;
        }


        [HttpPost]
        public string Post(SearchModel model)
        {
            placeHolderRepository.Add(model);
            return "Success";
        }
        [HttpGet]
        public List<SearchModel> Get()
        {
            return DataStore.PlaceHolders;
        }
        [HttpGet("GetCountryCodes")]
        public List<CountryCodeModel> GetCountryCodes()
        {
            return MasterStore.CountryCodes;
        }


    }





}
