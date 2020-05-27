using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018280067
{
	abstract class BaseCustomer : IEuro, IUsd
	{
		public abstract string HesapNo { get; }
		public abstract string AdSoyad { get; }
		public abstract string Parola { get; }

		public abstract string IbanTr { get; set; }
		public abstract double MiktarIbanTr { get; set; }

		public abstract string IbanUsd { get; set; }
		public abstract double MiktarIbanUsd { get; set; }

		public abstract string IbanEuro { get; set; }
		public abstract double MiktarIbanEuro { get; set; }

	}
}

