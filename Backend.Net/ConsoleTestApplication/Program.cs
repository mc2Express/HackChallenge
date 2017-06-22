using System;
using Infrastructure.Parse.Impl;

namespace ConsoleTestApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			var parser = new ContractParser();

			var result = parser.Parse("C:\\temp\\test.xml");
			Console.WriteLine("blub");
		}
	}
}