using _2018280067.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2018280067.Forms
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

	
		private void LoginForm_Load(object sender, EventArgs e)
		{

		}

		private void BtnSubmit_Click(object sender, EventArgs e)
		{
			bool result = CreateHashAndValidate.CheckPassword(InputAccountPassword.Text, InputAccountId.Text);
			Debug.WriteLine(result);
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void InputAccountPassword_TextChanged(object sender, EventArgs e)
		{
			bool result =
				   InputAccountPassword.Text.All(c => char.IsLetter(c) || char.IsDigit(c));
		

			if (!result)
			{
				errorProvider1.SetError(InputAccountPassword, "Şifre sadece büyük, küçük harf ve rakam içerebilir.Boşluk olamaz");
			}
			else
			{
				errorProvider1.Clear();
			}
		}

		private void InputAccountId_TextChanged(object sender, EventArgs e)
		{
			bool result =
				   InputAccountId.Text.All(c => char.IsDigit(c));

			if (!result)
			{
				errorProvider1.SetError(InputAccountId, "Hesap no sadece rakam içerebilir");
			}
			else
			{
				errorProvider1.Clear();
			}
		}

	}
}
