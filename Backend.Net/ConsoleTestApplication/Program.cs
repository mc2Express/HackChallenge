using System;
using Infrastructure.Parse;

namespace ConsoleTestApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			var importer = new HackChallengeDataImporter();

			var result = importer.GetHackChallangeData();
			Console.WriteLine("blub");
		}
	}
}