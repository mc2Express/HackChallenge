using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessDomain;
using Infrastructure.Parse;
using Newtonsoft.Json;

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
            var json = JsonConvert.SerializeObject(contracts);
            return Content(json, "application/json");
        }

   
    }
}