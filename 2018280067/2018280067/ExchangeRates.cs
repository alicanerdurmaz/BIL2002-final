using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018280067
{
	class ExchangeRate : Dictionary<string, double>
	{
		public ExchangeRate()
		{
			this.Add("USD", 7.1094);
			this.Add("EURO", 7.9283);
		}
	}
}
