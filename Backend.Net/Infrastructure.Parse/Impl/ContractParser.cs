using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BusinessDomain;

namespace Infrastructure.Parse.Impl
{
    internal class ContractParser : BaseXmlParser, IDocumentParser<Contract>
    {


        public Contract Parse(string documentPath)
        {
            XElement xmlDoc = XElement.Load(documentPath);
            var contract = xmlDoc.Descendants("blbal")
                .Select(x => new Contract())
                .FirstOrDefault();

            //select new Customer
            //{
            //    ID = Convert.ToInt32(cust.Element("id").Value),
            //    Name = cust.Element("customer").Value,
            //    MeetingType = cust.Element("type").Value,
            //    CallDate = Convert.ToDateTime(cust.Element("date").Value),
            //    DurationInHours = Convert.ToInt32(cust.Element("hours").Value),
            //    Contacts = new Contact()
            //    {
            //        Phone = new List<PhoneContact>(from phn in cust.Descendants("phone")
            //            select new PhoneContact
            //            {
            //                Type = phn.Element("type").Value,
            //                Number = phn.Element("no").Value
            //            })
            //    }
            //};
            return contract;
        }
    }

    internal abstract class BaseXmlParser
    {
    }
}