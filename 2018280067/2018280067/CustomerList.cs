using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018280067
{
	class CustomerList
	{
		public static List<Customer> Customers = new List<Customer>();

		public static Customer GetCustomerById(string accountId)
		{
			foreach (var item in Customers)
			{
				if(item.HesapNo == accountId)
				{
					return item;
				}
			}
			return null;
		}

		public static void UpdateCustomerListFromTxt()
		{

			string line;
			try
			{
				StreamReader file = new StreamReader(@"c:\final\client.txt");
				while ((line = file.ReadLine()) != null)
				{
					var lineArray = line.Split(',');

					foreach (var item in Customers)
					{
						if(String.Compare(lineArray[1], item.IbanTr, true) == 0)
						{
							item.MiktarIbanTr = ConvertToDouble(lineArray[2]);
						}
						if (String.Compare(lineArray[1], item.IbanEuro, true) == 0)
						{
							item.MiktarIbanEuro = ConvertToDouble(lineArray[2]);
						}
						if (String.Compare(lineArray[1], item.IbanUsd, true) == 0)
						{
							item.MiktarIbanUsd = ConvertToDouble(lineArray[2]);
						}
					}
				}
				file.Close();
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);	
			}
		}

		private static double ConvertToDouble(string money)
		{
			try
			{
				return double.Parse(money);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
			return 0;
		}
	}
}
