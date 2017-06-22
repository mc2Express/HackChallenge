using System.Collections.Generic;
using System.IO;
using BusinessDomain;
using Infrastructure.Parse.Impl;

namespace Infrastructure.Parse
{
	public class HackChallengeDataImporter
	{
		public object GetHackChallangeData()
		{
			var contracts = new List<Contract>();
			var contractParser = new ContractParser();
			var contractFiles = Directory.GetFiles(@"C:\Dev\HackChallenge\Backend.Net\Data\Contracts");
			foreach (var file in contractFiles)
			{
				contracts.Add(contractParser.Parse(file));
			}

			var railwayBills = new List<RailwayBill>();
			var railwayBillParser = new RailwayBillParser();
			var railwayBillFiles = Directory.GetFiles(@"C:\Dev\HackChallenge\Backend.Net\Data\RailwayBills");
			foreach (var file in railwayBillFiles)
			{
				railwayBills.AddRange(railwayBillParser.Parse(file));
			}

			return null;
		}
	}
}