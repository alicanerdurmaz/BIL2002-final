using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2018280067.Forms
{
	partial class AccountForm
	{
		private bool CheckFormValidation()
		{
			if (ComboBoxRecievers.SelectedItem == null)
			{
				MessageBox.Show("Lutfen para göndermek istediğiniz kişiyi seçiniz");
				return false;
			}
			if (ComboBoxIbanReciever.SelectedItem == null)
			{
				MessageBox.Show("Lutfen para göndermek istediğiniz IBAN seçiniz");
				return false;
			}
			if (ComboBoxIbanSender.SelectedItem == null)
			{
				MessageBox.Show("Lutfen parayı göndermek istediğiniz kendi IBAN'ınız seçiniz");
				return false;
			}

			return true;
		}

		private bool CheckBalanceIsAvailable()
		{
			double money = 0;
			try
			{

				money = Double.Parse(TextAmountOfMoney.Text);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return false;
			}

			if (ComboBoxIbanSender.Text == CurrentUser.IbanTr)
			{
				SelectedSenderCurrency = Currency.tr;
				if (CurrentUser.MiktarIbanTr < money)
				{
					MessageBox.Show($"Bakiyeniz Uygun değil. bakiye: {CurrentUser.MiktarIbanTr}");
					return false;
				}
			}

			if (ComboBoxIbanSender.Text == CurrentUser.IbanEuro)
			{
				SelectedSenderCurrency = Currency.euro;
				if (CurrentUser.MiktarIbanEuro < money)
				{
					MessageBox.Show($"Bakiyeniz Uygun değil. bakiye: {CurrentUser.MiktarIbanEuro}");
					return false;
				}
			}

			if (ComboBoxIbanSender.Text == CurrentUser.IbanUsd)
			{
				SelectedSenderCurrency = Currency.usd;
				if (CurrentUser.MiktarIbanUsd < money)
				{
					MessageBox.Show($"Bakiyeniz Uygun değil. bakiye: {CurrentUser.MiktarIbanUsd}");
					return false;
				}
			}

			return true;
		}

		private void AccountForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			ReturnToLoginForm();
		}

		private void ReturnToLoginForm()
		{
			TimerIdleWarning.Stop();
			TimerIdleExit.Stop();

			FormClosed -= AccountForm_FormClosed;
			MouseMove -= new MouseEventHandler(AccountForm_MouseMove);
			TimerIdleWarning.Tick -= TimerIdleWarningDone;
			TimerIdleExit.Tick -= TimerIdleExitDone;

			MessageBox.Show("Güvenlik nedeni ile oturumunuz kapatıdı.");
			LoginFormRef.Show();
			this.Hide();
		}
	}
}
