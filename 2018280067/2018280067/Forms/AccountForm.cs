using System;
using System.Diagnostics;
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
			double senderMoneyAmount = 0;
			double recieverMoneyAmount = 0;

			double.TryParse(TextAmountOfMoney.Text, out senderMoneyAmount);
			double.TryParse(TextAmountOfMoney.Text, out recieverMoneyAmount);

			var exchangeRates = new ExchangeRate();

			if (SelectedSenderCurrency == Currency.tr && SelectedRecieverCurrency == Currency.euro)
				recieverMoneyAmount /= exchangeRates["EURO"];
			
			if (SelectedSenderCurrency == Currency.tr && SelectedRecieverCurrency == Currency.usd)
				recieverMoneyAmount /= exchangeRates["USD"];

			if (SelectedSenderCurrency == Currency.usd && SelectedRecieverCurrency == Currency.tr)
				recieverMoneyAmount *= exchangeRates["USD"];

			if(SelectedSenderCurrency == Currency.usd && SelectedRecieverCurrency == Currency.euro)
			{
				recieverMoneyAmount /= exchangeRates["USD"];
				recieverMoneyAmount *= exchangeRates["EURO"];
			}

			if (SelectedSenderCurrency == Currency.euro && SelectedRecieverCurrency == Currency.tr)
				recieverMoneyAmount *= exchangeRates["EURO"];

			if (SelectedSenderCurrency == Currency.euro && SelectedRecieverCurrency == Currency.usd)
			{
				recieverMoneyAmount /= exchangeRates["EURO"];
				recieverMoneyAmount *= exchangeRates["USD"];
			}

			FileIO fileIO = new FileIO();
			fileIO.UpdateIbanMoneyAmountOnTxt(ComboBoxIbanSender.Text, ComboBoxIbanReciever.Text, senderMoneyAmount,recieverMoneyAmount);
			
			CustomerList.UpdateCustomerListFromTxt();
			CurrentUser = CustomerList.GetCustomerById(AccountId);
			UpdateTextIban();
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
	}
}
