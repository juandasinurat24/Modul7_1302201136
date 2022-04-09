using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using Newtonsoft.Json.Converters;

namespace modul7_1302201136
{
	public class Bank
	{
		public string lang { get; set; }
		public Transfer transfer { get; set; }
		public string[] methods { get; set; }
		public Confirmation confirmation { get; set; }

	}
	public class Transfer
	{
		public int threshold { get; set; }
		public int low_fee { get; set; }
		public int high_fee { get; set; }

	}
	public class Confirmation
	{
		public string en { get; set; }
		public string id { get; set; }
	}
	public class BankTransferConfig
	{
		private const string CONFIG1 = "en";
		private const int CONFIG2 = 25000000;
		private const int CONFIG3 = 6500;
		private const int CONFIG4 = 15000;
		private string[] CONFIG5 = new string[4] { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
		private const string CONFIG6 = "YES";
		private const string CONFIG7 = "ya";
		public static int uang;
		public static string input;

		public void konfigurasi()
		{
			Bank c = new Bank();
			Transfer transfer = new Transfer();
			transfer.threshold = CONFIG2;
			transfer.low_fee = CONFIG3;
			transfer.high_fee = CONFIG4;
			Confirmation confirmation = new Confirmation();
			confirmation.en = CONFIG6;
			confirmation.id = CONFIG7;
			c.lang = CONFIG1;
			c.transfer = transfer;
			c.methods = CONFIG5;
			c.confirmation = confirmation;
			JsonSerializer serializer = new JsonSerializer();
			serializer.Converters.Add(new JavaScriptDateTimeConverter());
			serializer.NullValueHandling = NullValueHandling.Ignore;

			using (StreamWriter sw = new StreamWriter(@"c:\Program Files\text.json"))
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				serializer.Serialize(writer, c);

			}
			Console.WriteLine("Please insert the amount of money to transfer :");
			uang = Convert.ToInt32(Console.ReadLine());
			if (uang <= CONFIG2)
			{
				uang += CONFIG3;
			}
			else
			{
				uang += CONFIG4;
			}
			Console.WriteLine("Transfer fee : " + uang);
			foreach (string item in CONFIG5)
			{
				Console.WriteLine(item);
			}
			input = Console.ReadLine();
			Console.WriteLine("Please type " + CONFIG6 + " to confirm the transaction");
			input = Console.ReadLine();
			if (input != CONFIG6)
			{
				Console.WriteLine("Transfer Is Cancelled");
			}
			else
			{
				Console.WriteLine("Transfer Is Complete");
			}

		}

	}
}
