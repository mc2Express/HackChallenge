using System;
using System.Collections;
using System.Collections.Generic;
using BusinessDomain;
using Infrastructure.Parse.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlParseTests
{
    [TestClass]
    public class RailwayBillParserTests
    {
        [TestMethod]
        public void TestRailBilling()
        {
            string path = @"C:\Dev\Projects\HackChallenge\Backend.Net\Infrastructure.Parse\Data\RailwayBills\eFbDocument_1493199408272.xml";

            IEnumerable<RailwayBill> bills = new RailwayBillParser().Parse(path);
        }
    }
}
