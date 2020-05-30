using System;
using System.Windows.Forms;

namespace _2018280067.Forms
{
	enum Currency
	{	
		none,
		tr,
		euro,
		usd,
	}

	public partial class AccountForm : Form
	{	
		public string AccountId { get; set; }
		public Form LoginFormRef { get; set; }
		private Customer CurrentUser { get; set; }
		private Currency SelectedSenderCurrency { get; set; }
		private Currency SelectedRecieverCurrency { get; set; }

		public AccountForm()
		{	
			InitializeComponent();
			
			FormClosed += AccountForm_FormClosed;
			MouseMove += new MouseEventHandler(AccountForm_MouseMove);

			TimerIdleWarning.Start();
			TimerIdleWarning.Tick += TimerIdleWarningDone;
			TimerIdleExit.Tick += TimerIdleExitDone;

			TextInactivityWarning.Text = "";
		}

		private void AccountForm_Load(object sender, EventArgs e)
		{
			CustomerList.UpdateCustomerListFromTxt();
			CurrentUser = CustomerList.GetCustomerById(AccountId);

			TextWelcome.Text = $"Hoşgeldiniz, {CurrentUser.AdSoyad}";

			InitializeComboBoxes();
			UpdateTextIban();
		}

		private void BtnEFT_Click(object sender, EventArgs e)
		{
			if (!CheckFormValidation()) return;
			
			CustomerList.UpdateCustomerListFromTxt();
			CurrentUser = CustomerList.GetCustomerById(AccountId);

			if (!CheckBalanceIsAvailable()) return;

			StartEFT();

		}

		private void StartEFT()
		{
			var moneyAmount = TextAmountOfMoney.Text;

			if (SelectedSenderCurrency != SelectedRecieverCurrency)
			{
				MessageBox.Show("Need exchange");
				return;
			}

			FileIO fileIO = new FileIO();
			fileIO.UpdateIbanMoneyAmountOnTxt(ComboBoxIbanSender.Text, ComboBoxIbanReciever.Text, moneyAmount);
			
			CustomerList.UpdateCustomerListFromTxt();
			CurrentUser = CustomerList.GetCustomerById(AccountId);
			UpdateTextIban();
		}

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
				if(CurrentUser.MiktarIbanTr < money)
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

		private void InitializeComboBoxes()
		{
			if (CurrentUser.IbanTr != null)
				ComboBoxIbanSender.Items.Add(CurrentUser.IbanTr);
			if (CurrentUser.IbanEuro != null)
				ComboBoxIbanSender.Items.Add(CurrentUser.IbanEuro);
			if (CurrentUser.IbanUsd != null)
				ComboBoxIbanSender.Items.Add(CurrentUser.IbanUsd);

			foreach (var item in CustomerList.Customers)
			{
				if (item.HesapNo != CurrentUser.HesapNo)
				{
					ComboBoxRecievers.Items.Add(item.AdSoyad);
				}
			}
		}

		private void UpdateTextIban()
		{
			if (CurrentUser.IbanTr != null)
			{
				TextIbanTr.Text = $"IBAN: {CurrentUser.IbanTr}";
				TextAmountTr.Text = $"{CurrentUser.MiktarIbanTr} TL";
			}

			if (CurrentUser.IbanEuro != null)
			{
				TextIbanEuro.Text = $"IBAN: {CurrentUser.IbanEuro}";
				TextAmountEur.Text = $"{CurrentUser.MiktarIbanEuro} EURO";
			}

			if (CurrentUser.IbanUsd != null)
			{
				TextIbanUsd.Text = $"IBAN: {CurrentUser.IbanUsd}";
				TextAmountUsd.Text = $"{CurrentUser.MiktarIbanUsd} USD";
			}
		}

		private void ComboBoxPersons_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Para gönderilecek IBAN ComboBox'ı güncelle.

			ComboBoxIbanReciever.Items.Clear();
			var selectedReciever = ComboBoxRecievers.SelectedItem.ToString();

			foreach (var item in CustomerList.Customers)
			{
				if (String.Compare(selectedReciever, item.AdSoyad, true) == 0)
				{
					if (item.IbanTr != null)
						ComboBoxIbanReciever.Items.Add(item.IbanTr);
					if (item.IbanEuro != null)
						ComboBoxIbanReciever.Items.Add(item.IbanEuro);
					if (item.IbanUsd != null)
						ComboBoxIbanReciever.Items.Add(item.IbanUsd);
				}
			}
		}

		// When user select IBAN reciever, find that IBAN currency and save.
		private void ComboBoxIbanReciever_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedIbanReciever = ComboBoxIbanReciever.SelectedItem.ToString();
			foreach (var item in CustomerList.Customers)
			{
				if (String.Compare(selectedIbanReciever, item.IbanTr, true) == 0)
					SelectedRecieverCurrency = Currency.tr;
				if (String.Compare(selectedIbanReciever, item.IbanEuro, true) == 0)
					SelectedRecieverCurrency = Currency.euro;
				if (String.Compare(selectedIbanReciever, item.IbanUsd, true) == 0)
					SelectedRecieverCurrency = Currency.usd;
			}
		}

		private void AccountForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			ReturnToLoginForm();
		}

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
		private void ReturnToLoginForm()
		{
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
