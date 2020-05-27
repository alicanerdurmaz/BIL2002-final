using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018280067
{
	class Customer : BaseCustomer
	{
		public override string HesapNo { get; }
		public override string AdSoyad { get; }
		public override string Parola { get; }

		public override string IbanTr { get; set; }
		public override double MiktarIbanTr { get; set; }

		public override string IbanUsd { get; set; }
		public override double MiktarIbanUsd { get; set; }

		public override string IbanEuro { get; set; }
		public override double MiktarIbanEuro { get; set; }

		public Customer(string hesapNo, string adSoyad, string parola, string ibanTr, double miktarIbanTr, string ibanEuro, double miktarIbanEuro, string ibanUsd, double miktarIbanUsd)
		{
			HesapNo = hesapNo;
			AdSoyad = adSoyad;
			Parola = parola;
			IbanTr = ibanTr;
			MiktarIbanTr = miktarIbanTr;
			IbanUsd = ibanUsd;
			MiktarIbanUsd = miktarIbanUsd;
			IbanEuro = ibanEuro;
			MiktarIbanEuro = miktarIbanEuro;
		}
	}
}
