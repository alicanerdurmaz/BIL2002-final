using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018280067
{
	class FileIO
	{
		public string UpdateIbanMoneyAmountOnTxt(string senderIban, string recieverIban,double senderMoneyAmount, double recieverMoneyAmount)
		{
			string line;
			var lineArray = new List<string[]>();

			try
			{
				using (StreamReader file = new StreamReader(@"c:\final\client.txt")) 
				{
					while ((line = file.ReadLine()) != null)
					{
						lineArray.Add(line.Split(','));
					}
				}
			}
			catch (Exception e)
			{
				return e.Message;
			}

			try
			{
				using (StreamWriter file =
				new StreamWriter(@"C:\final\client.txt"))
				{
					foreach (var item in lineArray)
					{
						if (String.Compare(item[1], senderIban, true) == 0)
						{
							double ibanMoney = ConvertToDouble(item[2]);
							ibanMoney -= senderMoneyAmount;
							item[2] = ibanMoney.ToString();
						}
						if (String.Compare(item[1], recieverIban, true) == 0)
						{
							double ibanMoney = ConvertToDouble(item[2]);
							ibanMoney += recieverMoneyAmount;
							item[2] = ibanMoney.ToString();
						}
						file.WriteLine($"{item[0]},{item[1]},{item[2]}");
					}
				}
			}
			catch (Exception e)
			{
				return e.Message;
			}
			return null;
		}

		public void ResetLockedAccounts()
		{
			// ilk önce tüm lockedAccounts.txt'yi okuyorum ve lines'a atıyorum.
			// lines'ı tek tek kontrol edip tarihi geçenleri null olarak işaretliyorum.
			// sonra lockedAccounts.txt'yi silip, lines'dan null olmayanları txt'ye yazıyorum.
			// yöntemi beğenmedim ama daha iyi henüz aklıma gelmedi.

			string[] lines = { "" };

			try
			{
				lines = File.ReadAllLines(@"C:\final\lockedAccounts.txt");
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
			DateTime currentTime = DateTime.Now;

			int i = 0;
			foreach (var line in lines)
			{
				string[] lineParse = line.Split(',');

				int result = 0;
				try
				{
					result = DateTime.Compare(currentTime, DateTime.Parse(lineParse[1]));
				}
				catch (Exception e)
				{

					Debug.WriteLine(e.Message);
				}

				if (result > 0)
				{
					lines[i] = null;

				}
				i++;
			}
			try
			{
				using (StreamWriter file =
				new StreamWriter(@"C:\final\lockedAccounts.txt", false))
				{
					foreach (var line in lines)
					{
						if (line != null)
						{
							file.WriteLine(line);
						}
					}
				}

			}
			catch (Exception error)
			{
				Debug.WriteLine(error.Message);
			}
		}

		private double ConvertToDouble(string money)
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
