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
			CurrentUser = CustomerList.GetCustomerById(AccountId);

			TextWelcome.Text = $"Hoşgeldiniz, {CurrentUser.AdSoyad}";
			UpdateIbanValues();

		}

		private void UpdateIbanValues()
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

		private void AccountForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

	}
}
