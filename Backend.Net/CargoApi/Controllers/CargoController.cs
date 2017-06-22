using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessDomain;
using Infrastructure.Parse;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CargoApi.Controllers
{
    public class CargoController : Controller
    {
        private static IEnumerable<Contract> contracts;

        public CargoController()
        {
            if (contracts != null)
            {
                return;
            }
            var importer = new HackChallengeDataImporter();
            contracts = importer.GetHackChallangeData();
        }

        public ActionResult Index()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver() 
            };
            var json = JsonConvert.SerializeObject(contracts, settings);
            return Content(json, "application/json");
        }

   
    }
}