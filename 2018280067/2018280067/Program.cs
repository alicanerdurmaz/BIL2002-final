using _2018280067.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2018280067
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			CreateTestData startupFunctions = new CreateTestData();
			startupFunctions.CreateTestCustomers();
			startupFunctions.ResetLockedAccounts();

			Application.Run(new LoginForm());
		}
	}
}
