using System;
using System.Linq;
using System.Xml.Linq;
using BusinessDomain;

namespace Infrastructure.Parse.Impl
{
	public class ContractParser : BaseXmlParser, IDocumentParser<Contract>
	{
		public Contract Parse(string documentPath)
		{
			var xmlDoc = XElement.Load(documentPath);

			var contract = new Contract
			{
				TransportClasses = (from tx in xmlDoc.Descendants("TK")
					select ToTransportClass(tx)).ToList(),
				ContractNr = xmlDoc.Descendants("VERTRAG_NR").FirstOrDefault()?.Value,
				CreationDate = xmlDoc.Descendants("ERST_DATUM").FirstOrDefault()?.Value,
				OffertDate = xmlDoc.Descendants("DATUM").FirstOrDefault()?.Value,
				OffertNr = xmlDoc.Descendants("OFFERT_NR").FirstOrDefault()?.Value
			};
			return contract;
		}

		private TransportClass ToTransportClass(XElement tx)
		{
			var from = tx.Descendants("VON").FirstOrDefault();
			var to = tx.Descendants("VON").FirstOrDefault();
			var via = tx.Descendants("UEBER").FirstOrDefault();
			return new TransportClass
			{
				From = new TrainStation
				{
					Country = new Country
					{
						CountryCode =
							Convert.ToInt32(from?.Descendants("LAND").FirstOrDefault()?.Value),
						Name = from?.Descendants("LAND_NAME").FirstOrDefault()?.Value
					},
					StationNumber =
						Convert.ToInt32(from?.Descendants("BHF").FirstOrDefault()?.Descendants("NR").FirstOrDefault()?.Value),
					Name = from?.Descendants("BHF").FirstOrDefault()?.Descendants("BEZ").FirstOrDefault()?.Value
				},
				To = new TrainStation
				{
					Country = new Country
					{
						CountryCode =
							Convert.ToInt32(to?.Descendants("LAND").FirstOrDefault()?.Value),
						Name = to?.Descendants("LAND_NAME").FirstOrDefault()?.Value
					},
					StationNumber =
						Convert.ToInt32(to?.Descendants("BHF").FirstOrDefault()?.Descendants("NR").FirstOrDefault()?.Value),
					Name = to?.Descendants("BHF").FirstOrDefault()?.Descendants("BEZ").FirstOrDefault()?.Value
				},
				Via = new TrainStation
				{
					Country = new Country
					{
						CountryCode =
							Convert.ToInt32(via?.Descendants("LAND").FirstOrDefault()?.Value),
						Name = via?.Descendants("LAND_NAME").FirstOrDefault()?.Value
					},
					StationNumber =
						Convert.ToInt32(via?.Descendants("BHF").FirstOrDefault()?.Descendants("NR").FirstOrDefault()?.Value),
					Name = via?.Descendants("BHF").FirstOrDefault()?.Descendants("BEZ").FirstOrDefault()?.Value
				},
				SzVertragNr = tx.Descendants("SZ_VERTRAG_NR").FirstOrDefault()?.Value
			};
		}
	}

	public abstract class BaseXmlParser
	{
	}
}