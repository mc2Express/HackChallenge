using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using BusinessDomain;

namespace Infrastructure.Parse.Impl
{
	public class ContractParser : IDocumentParser<Contract>
	{
		public Contract Parse(string documentPath)
		{
			var xmlDoc = XElement.Load(documentPath);

			var contract = new Contract
			{
				TransportClasses = (from tx in xmlDoc.XPathSelectElements("TRANSPORTKLASSEN/TK")
					select ToTransportClass(tx)).ToList(),
				ContractNr = xmlDoc.Descendants("VERTRAG_NR").FirstOrDefault()?.Value,
				SpContractDescription =
					xmlDoc.Descendants("SP_VERTRAG").FirstOrDefault()?.Descendants("BEZEICHNUNG").FirstOrDefault()?.Value,
				CreationDate = xmlDoc.Descendants("ERST_DATUM").FirstOrDefault()?.Value,
				OffertDate = xmlDoc.Descendants("DATUM").FirstOrDefault()?.Value,
				OffertNr = xmlDoc.Descendants("OFFERT_NR").FirstOrDefault()?.Value
			};
			return contract;
		}

		private TransportClass ToTransportClass(XElement tx)
		{
			/*
			return new TransportClass
			{
				From = new TrainStation
				{
					Country = new Country
					{
						CountryCode = tx.XPathSelectElement("BED_GRUPPE_REL/BED_REL_BED/BED_REL/VON/LAND")?.Value,
						Name = tx.XPathSelectElement("BED_GRUPPE_REL/BED_REL_BED/BED_REL/VON/LAND_NAME")?.Value
					},
					Name = tx.XPathSelectElement("BED_GRUPPE_REL/BED_REL_BED/BED_REL/VON/POSITIV/BED_REL_SATZ/BHF/BEZ")?.Value,
					StationId = tx.XPathSelectElement("BED_GRUPPE_REL/BED_REL_BED/BED_REL/VON/POSITIV/BED_REL_SATZ/BHF/NR")?.Value
				},
				To = new TrainStation
				{
					Country = new Country
					{
						CountryCode = tx.XPathSelectElement("BED_GRUPPE_REL/BED_REL_BED/BED_REL/NACH/LAND")?.Value,
						Name = tx.XPathSelectElement("BED_GRUPPE_REL/BED_REL_BED/BED_REL/NACH/LAND_NAME")?.Value
					},
					Name = tx.XPathSelectElement("BED_GRUPPE_REL/BED_REL_BED/BED_REL/NACH/POSITIV/BED_REL_SATZ/BHF/BEZ")?.Value,
					StationId = tx.XPathSelectElement("BED_GRUPPE_REL/BED_REL_BED/BED_REL/NACH/POSITIV/BED_REL_SATZ/BHF/NR")?.Value
				},
				Via = new TrainStation
				{
					Country = new Country
					{
						CountryCode = tx.XPathSelectElement("BED_GRUPPE_REL/BED_REL_BED/BED_REL/UEBER/LAND")?.Value,
						Name = tx.XPathSelectElement("BED_GRUPPE_REL/BED_REL_BED/BED_REL/UEBER/LAND_NAME")?.Value
					},
					Name = tx.XPathSelectElement("BED_GRUPPE_REL/BED_REL_BED/BED_REL/UEBER/POSITIV/BED_REL_SATZ/BHF/BEZ")?.Value,
					StationId = tx.XPathSelectElement("BED_GRUPPE_REL/BED_REL_BED/BED_REL/UEBER/POSITIV/BED_REL_SATZ/BHF/NR")?.Value
				},
				SzVertragNr = tx.XPathSelectElement("SZ_VERTRAG_NR")?.Value
			};
			*/


			var from = tx.Descendants("BED_REL").FirstOrDefault()?.Descendants("VON").FirstOrDefault();
			var to = tx.Descendants("BED_REL").FirstOrDefault()?.Descendants("NACH").FirstOrDefault();
			var via = tx.Descendants("BED_REL").FirstOrDefault()?.Descendants("UEBER").FirstOrDefault();
			return new TransportClass
			{
				From = new TrainStation
				{
					Country = new Country
					{
						CountryCode = from?.Descendants("LAND").FirstOrDefault()?.Value,
						Name = from?.Descendants("LAND_NAME").FirstOrDefault()?.Value
					},
					StationId = from?.Descendants("BHF").FirstOrDefault()?.Descendants("NR").FirstOrDefault()?.Value,
					Name = from?.Descendants("BHF").FirstOrDefault()?.Descendants("BEZ").FirstOrDefault()?.Value
				},
				To = new TrainStation
				{
					Country = new Country
					{
						CountryCode = to?.Descendants("LAND").FirstOrDefault()?.Value,
						Name = to?.Descendants("LAND_NAME").FirstOrDefault()?.Value
					},
					StationId = to?.Descendants("BHF").FirstOrDefault()?.Descendants("NR").FirstOrDefault()?.Value,
					Name = to?.Descendants("BHF").FirstOrDefault()?.Descendants("BEZ").FirstOrDefault()?.Value
				},
				Via = new TrainStation
				{
					Country = new Country
					{
						CountryCode = via?.Descendants("LAND").FirstOrDefault()?.Value,
						Name = via?.Descendants("LAND_NAME").FirstOrDefault()?.Value
					},
					StationId = via?.Descendants("BHF").FirstOrDefault()?.Descendants("NR").FirstOrDefault()?.Value,
					Name = via?.Descendants("BHF").FirstOrDefault()?.Descendants("BEZ").FirstOrDefault()?.Value
				},
				SzVertragNr = tx.Descendants("SZ_VERTRAG_NR").FirstOrDefault()?.Value
			};
		}
	}
}