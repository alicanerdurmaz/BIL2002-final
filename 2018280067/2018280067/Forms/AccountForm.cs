using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2018280067.Forms
{
	public partial class AccountForm : Form
	{
		public string AccountId { get; set; }
		public Form LoginFormRef { get; set; }
		private Customer CurrentUser { get; set; }

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

		private void InitializeComboBoxes()
		{
			if (CurrentUser.IbanTr != null)
				ComboBoxIbanUser.Items.Add(CurrentUser.IbanTr);
			if (CurrentUser.IbanEuro != null)
				ComboBoxIbanUser.Items.Add(CurrentUser.IbanEuro);
			if (CurrentUser.IbanUsd != null)
				ComboBoxIbanUser.Items.Add(CurrentUser.IbanUsd);

			foreach (var item in CustomerList.Customers)
			{
				if(item.HesapNo != CurrentUser.HesapNo)
				{
					ComboBoxPersons.Items.Add(item.AdSoyad);
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
				TextAmountEur.Text = $"{CurrentUser.MiktarIbanEuro} EUR";
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

			ComboBoxIbanOther.Items.Clear();
			var selectedUser = ComboBoxPersons.SelectedItem.ToString();
		
			foreach (var item in CustomerList.Customers)
			{
				if (String.Compare(selectedUser, item.AdSoyad, true) == 0)
				{
					if (item.IbanTr != null)
						ComboBoxIbanOther.Items.Add(item.IbanTr);
					if (item.IbanEuro != null)
						ComboBoxIbanOther.Items.Add(item.IbanEuro);
					if (item.IbanUsd != null)
						ComboBoxIbanOther.Items.Add(item.IbanUsd);
				}
			}
		}


	
		private void AccountForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
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
