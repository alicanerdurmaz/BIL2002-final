using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018280067.Forms
{
	partial class AccountForm
	{

		// User Inactivity Detect 
		private void AccountForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			TextInactivityWarning.Text = "";
			TimerIdleWarning.Stop();
			TimerIdleWarning.Start();
			TimerIdleExit.Stop();
		}
		// User Inactivity Warning
		private void TimerIdleWarningDone(object sender, EventArgs e)
		{
			TimerIdleWarning.Stop();
			TimerIdleExit.Start();
			TextInactivityWarning.Text = "GÜVENLİK UYARISI !";
			TextInactivityWarning.Text += Environment.NewLine;
			TextInactivityWarning.Text += "4 Dakikadır herhangi bir işlem yapmadınız. Güvenlik nedeni ile 60 saniye içinde oturumunuz kapanacak.";
		}
		// User Inactivity Timer end, handle shutdown form. 
		private void TimerIdleExitDone(object sender, EventArgs e)
		{
			TimerIdleWarning.Stop();
			TimerIdleExit.Stop();
			ReturnToLoginForm();
		}
	}
}
