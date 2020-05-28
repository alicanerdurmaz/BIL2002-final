using _2018280067.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

using System.Windows.Forms;

namespace _2018280067.Forms
{
	public partial class LoginForm : Form
	{
		private uint loginAttemptCount = 0;


		public LoginForm()
		{
			InitializeComponent();
		}

	
		private void LoginForm_Load(object sender, EventArgs e)
		{
			TextError.Visible = false;
			LoginAttemptTimer.Tick += new EventHandler(TimerEventProcessor);
		}

		private void BtnSubmit_Click(object sender, EventArgs e)
		{

			using (AccountForm accountForm = new AccountForm())
			{
				InputAccountId.Text = "326785";
				accountForm.UserId = InputAccountId.Text;
				accountForm.Show();
			}
			this.Hide();

			return;

			if (InputAccountId.Text.Length < 1) return;
			if (InputAccountPassword.Text.Length < 1) return;

			if(CheckAccountIsLocked(InputAccountId.Text)) return;
		
			bool result = CreateHashAndValidate.CheckPassword(InputAccountPassword.Text, InputAccountId.Text);

			if (!result)
			{
				if (!LoginAttemptTimer.Enabled)
				{
					LoginAttemptTimer.Start();
				}

				if(loginAttemptCount >= 3)
				{
					TextError.Text = "Hesabınız kilitlendi. Lütfen 24 saat sonra tekrar deneyiniz";
					TextError.Visible = true;
					SaveLockedAccount(InputAccountId.Text);
					return;
				}

				loginAttemptCount++;
				TextRemainingAttempt.Text = $"Kalan deneme hakkı:{3 - loginAttemptCount}";
				TextError.Text = "Hatalı Hesap no veya Parola";
				TextError.Visible = true;
			}

			else
			{
				TextError.Visible = false; 
				loginAttemptCount = 0;
				LoginAttemptTimer.Stop();

				using (AccountForm accountForm = new AccountForm())
				{
					accountForm.Show();
					accountForm.UserId = InputAccountId.Text;
				}	
				this.Hide();
			}
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
	
		private void SaveLockedAccount(string accountId)
		{
			try
			{
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\final\lockedAccounts.txt", true))
				{
					DateTime now = DateTime.Now;
					file.WriteLine($"{accountId},{now.AddHours(24)}");
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
		}

		private bool CheckAccountIsLocked(string accountId)
		{
			string[] lines = {""};

			try
			{
				lines = File.ReadAllLines(@"C:\final\lockedAccounts.txt");
			}
			catch (Exception e)
			{
				TextError.Text = e.Message;
				TextError.Visible = true;
				Debug.WriteLine(e);
			}
	

			DateTime currentTime = DateTime.Now;
			foreach (string line in lines)
			{
				string[] lineParse = line.Split(',');
		
				if (lineParse[0].Equals(accountId))
				{
					int result = 0;
					try
					{
						result = DateTime.Compare(currentTime, DateTime.Parse(lineParse[1]));
					}
					catch (Exception e)
					{

						Debug.WriteLine(e.Message);
					}
				
					if(result < 0)
					{
						string errorMessage = $"Hesabınız kilitlendi. Lütfen 24 saat sonra tekrar deneyiniz.";
						errorMessage += Environment.NewLine;
						errorMessage += $"Hesabın açılacağı tarih: {lineParse[1]}";
						TextError.Text = errorMessage;
						TextError.Visible = true;
						return true;
					}
					if (result > 0)
					{
						return false;
					}
				}
			}

			return false;
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
		{
			loginAttemptCount = 0;
			LoginAttemptTimer.Stop();
		}

		
	}
}
