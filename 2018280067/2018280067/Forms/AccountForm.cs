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
	

		private Customer CurrentUser;

		public AccountForm()
		{
			InitializeComponent();
			FormClosed += AccountForm_FormClosed;
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
		
			Debug.WriteLine(selectedUser);
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
	}
}
