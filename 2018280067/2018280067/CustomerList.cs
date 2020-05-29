using System;
using System.Collections.Generic;
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
	}
}
