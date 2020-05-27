using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018280067
{
	public static class CreateTestData
	{

		private static void CreateClientTxt(List<Customer> customerList)
		{
			try
			{
				using (StreamWriter file =
				new StreamWriter(@"C:\final\client.txt"))
				{
					foreach (Customer customer in customerList)
					{
						if (customer.IbanTr != null)
							file.WriteLine($"{customer.HesapNo},{customer.IbanTr},{customer.MiktarIbanTr}");

						if (customer.IbanEuro != null)
							file.WriteLine($"{customer.HesapNo},{customer.IbanEuro},{customer.MiktarIbanEuro}");

						if (customer.IbanUsd != null)
							file.WriteLine($"{customer.HesapNo},{customer.IbanUsd},{customer.MiktarIbanUsd}");
					}
				}
				
			}
			catch (Exception error)
			{
				Debug.WriteLine(error.Message);
			}
		}

		public static void CreateTestCustomers()
		{
			Customer ismailBorazan = new Customer("326785", "İsmail Borozan", "IsmB1982", "TR610003200013900000326785", 350.00, "TR300003200016420000326785", 8000.00, null, 0);
			Customer kamileHursitgilogullari = new Customer("400129", "Kamile Hurşitgiloğulları", "12Hrst34", "TR610008324560000000400129", 2980.45, null, 0, null, 0);
			Customer zebercetBak = new Customer("388000", "Zebercet  Bak", "Zb123456", "TR610007222250001200388000", 19150.00, "TR300007222249000001388000", 52.93, "TR300008222266600002388000", 2850.00);
			Customer nazliGulUcan = new Customer("201005", "Naz  Gül  Uçan", "Mordor99", "TR610032455466661200201005", 666.66, null, 0, "TR300032455410080003201005", 10000.00);

			List<Customer> customerList = new List<Customer>
			{
				ismailBorazan,
				kamileHursitgilogullari,
				zebercetBak,
				nazliGulUcan
			};

			CreateClientTxt(customerList);
		}
	}
}
