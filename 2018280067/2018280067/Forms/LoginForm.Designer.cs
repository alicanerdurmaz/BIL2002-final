namespace _2018280067.Forms
{
	partial class LoginForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.InputAccountId = new System.Windows.Forms.TextBox();
			this.InputAccountPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.BtnSubmit = new System.Windows.Forms.Button();
			this.BtnExit = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.TextError = new System.Windows.Forms.TextBox();
			this.LoginAttemptTimer = new System.Windows.Forms.Timer(this.components);
			this.TextRemainingAttempt = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// InputAccountId
			// 
			this.InputAccountId.Location = new System.Drawing.Point(179, 41);
			this.InputAccountId.MaxLength = 6;
			this.InputAccountId.Name = "InputAccountId";
			this.InputAccountId.Size = new System.Drawing.Size(241, 20);
			this.InputAccountId.TabIndex = 0;
			this.InputAccountId.TextChanged += new System.EventHandler(this.InputAccountId_TextChanged);
			// 
			// InputAccountPassword
			// 
			this.InputAccountPassword.Location = new System.Drawing.Point(179, 98);
			this.InputAccountPassword.MaxLength = 8;
			this.InputAccountPassword.Name = "InputAccountPassword";
			this.InputAccountPassword.PasswordChar = '*';
			this.InputAccountPassword.Size = new System.Drawing.Size(241, 20);
			this.InputAccountPassword.TabIndex = 1;
			this.InputAccountPassword.TextChanged += new System.EventHandler(this.InputAccountPassword_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(176, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Hesap No";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(176, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Parola";
			// 
			// BtnSubmit
			// 
			this.BtnSubmit.Location = new System.Drawing.Point(12, 226);
			this.BtnSubmit.Name = "BtnSubmit";
			this.BtnSubmit.Size = new System.Drawing.Size(134, 38);
			this.BtnSubmit.TabIndex = 4;
			this.BtnSubmit.Text = "GİRİŞ YAP";
			this.BtnSubmit.UseVisualStyleBackColor = true;
			this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
			// 
			// BtnExit
			// 
			this.BtnExit.Location = new System.Drawing.Point(430, 226);
			this.BtnExit.Name = "BtnExit";
			this.BtnExit.Size = new System.Drawing.Size(156, 38);
			this.BtnExit.TabIndex = 5;
			this.BtnExit.Text = "ÇIKIŞ";
			this.BtnExit.UseVisualStyleBackColor = true;
			this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// TextError
			// 
			this.TextError.BackColor = System.Drawing.SystemColors.Window;
			this.TextError.Enabled = false;
			this.TextError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextError.ForeColor = System.Drawing.Color.DarkRed;
			this.TextError.Location = new System.Drawing.Point(12, 150);
			this.TextError.Multiline = true;
			this.TextError.Name = "TextError";
			this.TextError.ReadOnly = true;
			this.TextError.Size = new System.Drawing.Size(574, 50);
			this.TextError.TabIndex = 6;
			this.TextError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// LoginAttemptTimer
			// 
			this.LoginAttemptTimer.Interval = 5000;
			// 
			// TextRemainingAttempt
			// 
			this.TextRemainingAttempt.Location = new System.Drawing.Point(228, 236);
			this.TextRemainingAttempt.Name = "TextRemainingAttempt";
			this.TextRemainingAttempt.Size = new System.Drawing.Size(134, 20);
			this.TextRemainingAttempt.TabIndex = 7;
			this.TextRemainingAttempt.Text = "Kalan Deneme Hakkı: 3";
			this.TextRemainingAttempt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(598, 276);
			this.Controls.Add(this.TextRemainingAttempt);
			this.Controls.Add(this.TextError);
			this.Controls.Add(this.BtnExit);
			this.Controls.Add(this.BtnSubmit);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.InputAccountPassword);
			this.Controls.Add(this.InputAccountId);
			this.Name = "LoginForm";
			this.Text = "LoginForm";
			this.Load += new System.EventHandler(this.LoginForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox InputAccountId;
		private System.Windows.Forms.TextBox InputAccountPassword;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button BtnSubmit;
		private System.Windows.Forms.Button BtnExit;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.TextBox TextError;
		private System.Windows.Forms.Timer LoginAttemptTimer;
		private System.Windows.Forms.TextBox TextRemainingAttempt;
	}
}