using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using BusinessDomain;

namespace Infrastructure.Parse.Impl
{
	internal sealed class RailwayBillParser : IDocumentParser<IEnumerable<RailwayBill>>
	{
		public IEnumerable<RailwayBill> Parse(string documentPath)
		{
			var xmlDoc = XElement.Load(documentPath);

			IEnumerable<RailwayBill> contracts = xmlDoc.Descendants(Elements.RailwayBill)
				.Select(rb =>
				{
					var fs = rb.XPathSelectElement(Elements.ForwardingStation);
					var ts = rb.XPathSelectElement(Elements.TakeOverStation);
					var rs = rb.XPathSelectElement(Elements.ReceivingStation);
					var ds = rb.XPathSelectElement(Elements.DeliveryStation);

					return new RailwayBill
					{
						GvId = rb?.Attribute(Attributes.GvId)?.Value,
						ForwardingNumber = fs?.Element(Elements.ForwardingNumber)?.Value,
						ForwardingStation = ParseTrainStation(fs),
						TakeOverStation = ParseTrainStation(ts),
						ReceivingStation = ParseTrainStation(rs),
						DeliveryStation = ParseTrainStation(ds),
						TakeOverDate = ts?.Element(Elements.TakeOverDate)?.Value,
						IssueDate = rb.XPathSelectElement(Elements.IssueDate)?.Value,
						IssueLocation = rb.XPathSelectElement(Elements.IssueLocation)?.Value,
						Descriptions = rb.XPathSelectElements(Elements.Description).Select(d =>
									d.Element(Elements.DescriptionText)?.Value
						),
						ReservationNumber = rb.XPathSelectElement(Elements.ReservationNumber)?.Value,
						Wagon = new Wagon
						{
							WagonNumber = rb.XPathSelectElement(Elements.WagonNumber)?.Value,
							Info = rb.XPathSelectElement(Elements.WagonInfo)?.Value,
							TotalWeight = rb.XPathSelectElement(Elements.WagonTotalWeight).Value,
							Cargo = new Cargo
							{
								Id = rb.XPathSelectElement(Elements.WagonCargoId)?.Value,
								Description = rb.XPathSelectElement(Elements.WagonCargoDescription)?.Value,
								Weight = rb.XPathSelectElement(Elements.WagonCargoWeight)?.Value
							}
						},
						OtherTransportWayDescFrom = rb.XPathSelectElement(Elements.StrVBez)?.Value,
						OtherTransportWayDescTo = rb.XPathSelectElement(Elements.StrBBez)?.Value
					};
				}).ToList();

			return contracts;
		}

		private TrainStation ParseTrainStation(XElement parent)
		{
			return new TrainStation
			{
				StationId = parent?.Element(Elements.StationNumber)?.Value,
				Country = new Country(),
				Name = parent?.Element(Elements.StationName)?.Value
			};
		}

		private static class Elements
		{
			private const string DocumentHead = "sendungskopf";
			private const string Wagon = "wagen";
			private const string Cargo = "ladegut";

			public const string RailwayBill = "frachtbrief";
			public static readonly string ForwardingStation = $"{DocumentHead}/versandbhf";
			public static readonly string TakeOverStation = $"{DocumentHead}/uebernahmestelle";
			public static readonly string ReceivingStation = $"{DocumentHead}/empfangsbhf";
			public static readonly string DeliveryStation = $"{DocumentHead}/ablieferungsstelle";
			public static readonly string IssueLocation = $"{DocumentHead}/uebernahmezeitpunkt";
			public static readonly string IssueDate = $"{DocumentHead}/ausstellungsort";
			public static readonly string Description = $"{DocumentHead}/erklaerungen";
			public static readonly string ReservationNumber = $"{DocumentHead}/buchungsnr";
			public const string StationNumber = "bhfnr";
			public const string StationName = "bhfname";
			public const string ForwardingNumber = "versandnr";
			public const string TakeOverDate = "uebernahmezeitpunkt";
			public const string DescriptionText = "erklaerungen_text";
			public static readonly string WagonNumber = $"{Wagon}/wg_nr";
			public static readonly string WagonInfo = $"{Wagon}/wg_info";
			public static readonly string WagonTotalWeight = $"{Wagon}/wg_gesamtgewicht_kg";
			public static readonly string WagonCargoId = $"{Wagon}/{Cargo}/nhm";
			public static readonly string WagonCargoDescription = $"{Wagon}/{Cargo}/nhm_bezeichnung";
			public static readonly string WagonCargoWeight = $"{Wagon}/{Cargo}/bruttogewicht_kg";

			public static readonly string StrVBez =
				$"{DocumentHead}/andere_befoerderer/strecke_von/str_v_grenzpunkt/str_v_bezeichnung";

			public static readonly string StrBBez =
				$"{DocumentHead}/andere_befoerderer/strecke_bis/str_b_grenzpunkt/str_b_bezeichnung";
		}

		private static class Attributes
		{
			public const string GvId = "referenznummer";
		}
	}
}